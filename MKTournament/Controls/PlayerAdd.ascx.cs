using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MKTournament.Controls
{
	public partial class PlayerAdd : UserControl
	{
		public DAL.TournamentInfo Tournament
		{
			get
			{
				if (ViewState["Tournament"] != null)
				{
					return (TournamentInfo)ViewState["Tournament"];
				}
				else
				{
					return null;
				}
			}
			set
			{
				ViewState["Tournament"] = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			Add.Click += Add_Click;
			if (!IsPostBack)
			{

				foreach (CharacterInfo cha in MKDataAccess.GetCharacters())
				{
					ListItem li = new ListItem(cha.Name, cha.CharacterID.ToString());
					li.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundImage, cha.AvatarPath);
					ddlCaracter1.Items.Add(li);
					ddlCaracter2.Items.Add(li);
				}

				foreach (UserInfo use in MKDataAccess.GetUsers())
				{
					ListItem li = new ListItem(use.Name, use.UserID.ToString());
					li.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundImage, use.AvatarPath);
					ddlUser1.Items.Add(li);
					ddlUser2.Items.Add(li);
				}

				if (Tournament.Type == "1 vs 1")
				{
					Player2.Visible = false;
				}
			}
		}

		void Add_Click(object sender, EventArgs e)
		{
			if (Tournament.Type == "1 vs 1")
			{
				MKDataAccess.AddPlayerToTournament(Tournament.TournamentID, int.Parse(ddlUser1.SelectedItem.Value), int.Parse(ddlCaracter1.SelectedItem.Value));
			}
			else
			{
				MKDataAccess.AddTeamToTournament(Tournament.TournamentID, int.Parse(ddlUser1.SelectedItem.Value), int.Parse(ddlCaracter1.SelectedItem.Value), int.Parse(ddlUser2.SelectedItem.Value), int.Parse(ddlCaracter2.SelectedItem.Value));
			}
			Response.Redirect("Tournaments.aspx", true);
		}
	}
}