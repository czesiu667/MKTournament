using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using MKTournament.Controls;

namespace MKTournament
{
	public partial class TournamentMatches : System.Web.UI.Page
	{
		private int id;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!int.TryParse(Request.QueryString["TournamentID"], out id))
			{
				Response.Redirect("~/Tournaments.aspx", true);
			}

			if (!IsPostBack)
			{
				List<DAL.MatchInfo> matches = MKDataAccess.GetMatches(id);
				rptMachesOpen.DataSource = matches.Where(x => x.Result == 0);
				rptMachesOpen.DataBind();
				if (rptMachesOpen.Items.Count == 0)
				{
					rptMachesOpen.Visible = false;
				}

				rptMachesClosed.DataSource = matches.Where(x => x.Result != 0);
				rptMachesClosed.DataBind();
				if (rptMachesClosed.Items.Count == 0)
				{
					rptMachesClosed.Visible = false;
				}

				ScoreBoardControl.Tournament = MKDataAccess.GetTournament(id);
			}
			Menu1.Text = "Update";
			Menu1.Click += Menu1_Click;

			Menu2.Text = "Close Tournament";
			Menu2.Click += Menu2_Click;
		}

		void Menu2_Click(object sender, EventArgs e)
		{
			UpdateMatches();
			MKDataAccess.CloseTournament(id);
			Response.Redirect("~/Tournaments.aspx");
		}

		void Menu1_Click(object sender, EventArgs e)
		{
			UpdateMatches();
			Response.Redirect("~/TournamentMatches.aspx?" + Request.QueryString);
		}

		void UpdateMatches()
		{
			List<IDValuePair> toUpdate = new List<IDValuePair>();
			foreach (RepeaterItem mi in rptMachesOpen.Items)
			{
				if (mi.ItemType == ListItemType.Item || mi.ItemType == ListItemType.AlternatingItem)
				{
					MatchControl mc = (MatchControl)mi.FindControl("MatchControl");
					if (mc.DDLResultValue != mc.Match.Result)
					{
						toUpdate.Add(new IDValuePair(mc.Match.MatchID, mc.DDLResultValue));
					}
				}
			}

			foreach (RepeaterItem mi in rptMachesClosed.Items)
			{
				if (mi.ItemType == ListItemType.Item || mi.ItemType == ListItemType.AlternatingItem)
				{
					MatchControl mc = (MatchControl)mi.FindControl("MatchControl");
					if (mc.DDLResultValue != mc.Match.Result)
					{
						toUpdate.Add(new IDValuePair(mc.Match.MatchID, mc.DDLResultValue));
					}
				}
			}
			MKDataAccess.SetMatchResult(toUpdate);
		}
	}
}