using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MKTournament
{
    public partial class User : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptUsers.DataSource = MKDataAccess.GetUsers();
                rptUsers.DataBind();
            }
        }
    }
}