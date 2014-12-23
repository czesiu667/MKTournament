using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MKTournament
{
	public partial class Master : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            Menu1.Text = "Tournaments";
            Menu1.PostBackUrl = "~/Tournaments.aspx";

            Menu2.Text = "Tournaments Archive";
            Menu2.PostBackUrl = "~/TournamentsArchive.aspx";

            Menu3.Text = "Users";
            Menu3.PostBackUrl = "~/User.aspx";

            Menu4.Text = "Characters";
            Menu4.PostBackUrl = "~/Characters.aspx";
		}
	}
}