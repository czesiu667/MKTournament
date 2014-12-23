using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MKTournament.Controls
{
    public partial class TeamControl : System.Web.UI.UserControl
    {
        public DAL.TeamInfo Team { get; set; }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Team == null)
            {
                this.Visible = false;
                return;
            }
            rptTeamMembers.DataSource = Team.TeamMembers;
            rptTeamMembers.DataBind();
        }
    }
}