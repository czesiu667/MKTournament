using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MKTournament
{
	using System.Data;

	public partial class Tournaments : Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptTournamentsOpen.DataSource = DAL.MKDataAccess.GetOpenTournaments();
                rptTournamentsOpen.DataBind();
                if (rptTournamentsOpen.Items.Count == 0)
                {
                    rptTournamentsOpen.Visible = false;
                }

                rptTournamentsPending.DataSource = DAL.MKDataAccess.GetPendingTournaments();
                rptTournamentsPending.DataBind();
                if (rptTournamentsPending.Items.Count == 0)
                {
                    rptTournamentsPending.Visible = false;
                }
            }
        }
	}
}