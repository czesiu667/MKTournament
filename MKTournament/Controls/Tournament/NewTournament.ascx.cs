using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MKTournament;

namespace MKTournament.Controls
{
    public partial class NewTournament : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlType.Items.Add("1 vs 1");
            ddlType.Items.Add("2 vs 2");


            btnCreate.Click += btnCreate_Click;
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            DAL.MKDataAccess.AddTournament(txbName.Text, ddlType.SelectedValue);
            Response.Redirect("Tournaments.aspx", true);
        }

        
    }
}