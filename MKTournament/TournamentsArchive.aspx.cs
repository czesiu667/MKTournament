using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MKTournament
{
	using System.Data;

	public partial class TournamentsArchive : Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            rptTournamentsClosed.DataSource =DAL.MKDataAccess.GetClosedTournaments();
            rptTournamentsClosed.DataBind();
        }
	}
}