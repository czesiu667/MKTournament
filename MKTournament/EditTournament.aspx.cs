using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MKTournament
{
	public partial class EditTournament : System.Web.UI.Page
	{
		private int id;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!int.TryParse(Request.QueryString["TournamentID"], out id))
			{
				Response.Redirect("~/Tournaments.aspx", true);
			}
			rptTeamMembers.DataSource = MKDataAccess.GetTournament(id).Teams;
			rptTeamMembers.DataBind();
		}
	}
}