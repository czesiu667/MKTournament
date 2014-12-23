using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MKTournament.Controls
{
    public partial class ScoreBoardControl : System.Web.UI.UserControl
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
            if(!IsPostBack)
            {
                rptScoreBoard.DataSource = Tournament.Teams.OrderByDescending(x=>x.Score);
                rptScoreBoard.DataBind();
            }
        }
    }
}