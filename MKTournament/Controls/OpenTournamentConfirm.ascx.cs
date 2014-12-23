using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MKTournament.Controls
{
	public partial class OpenTournamentConfirm : System.Web.UI.UserControl
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
			GenerateMenu();
		}

		private void GenerateMenu()
		{
			Menu1.Text = "Yes";
			Menu1.Click += Menu1_Click;

			Menu2.Text = "No";
			Menu2.OnClientClick = "$(this).closest('.OpenTournament').hide(); return false;";
		}

		void Menu1_Click(object sender, EventArgs e)
		{
			MKDataAccess.OpenTournament(Tournament.TournamentID);
			Response.Redirect("~/Tournaments.aspx", true);
		}
	}
}