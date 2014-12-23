using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MKTournament
{
	public partial class TournamentControl : System.Web.UI.UserControl
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

		public string test { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
			GenerateMenu(Tournament.Type);

			if (!IsPostBack)
			{
				Name.Text = Tournament.Name;
				Status.Text = Tournament.TournamentStatus;
				StartDate.Text = Tournament.StartDate != null ? Tournament.StartDate.GetValueOrDefault().ToString("dd-MM-yy") : "---";
				EndDate.Text = Tournament.EndDate != null ? Tournament.EndDate.GetValueOrDefault().ToString("dd-MM-yy") : "---";
				Type.Text = Tournament.Type;
				MatchesCount.Text = Tournament.Matches.Count.ToString();
				TeamsCount.Text = Tournament.Teams.Count.ToString();
				MatchesLeft.Text = Tournament.GetNotPlayedMatches().Count.ToString();
				Winner.Team = Tournament.Winner;

				rptTeamMembers.DataSource = Tournament.Teams;
				rptTeamMembers.DataBind();
			}
		}

		private void GenerateMenu(string type)
		{
			if (Tournament.TournamentStatus.ToLower() == "open")
			{
				Menu1.Text = "Edit Tournament";
				Menu1.PostBackUrl = "~/EditTournament.aspx?TournamentID="+Tournament.TournamentID;

				Menu2.Text = type.ToLower() == "1 vs 1" ? "Add Player" : "Add Team";
				Menu2.OnClientClick = "return ShowAddPlayer(this);";

				Menu3.Text = "Start Tournament";
				Menu3.Click += Menu3_Click;
			}
			else
			{
				Menu1.Text = "Open Tournament";
				Menu1.OnClientClick = "return OpenTournament(this);";

				Menu2.Text = type.ToLower() == "1 vs 1" ? "Show Players" : "Show Teams";
				Menu2.OnClientClick = "$(this).parent().parent().parent().children('.Players').slideToggle(); return false;";

				Menu3.Text = "Show Matches";
				Menu3.PostBackUrl = "~/TournamentMatches.aspx?TournamentID=" + Tournament.TournamentID;
			}
		}

		void Menu3_Click(object sender, EventArgs e)
		{
			MKDataAccess.StartTournament(Tournament.TournamentID);
			Response.Redirect("Tournaments.aspx", true);
		}
	}
}