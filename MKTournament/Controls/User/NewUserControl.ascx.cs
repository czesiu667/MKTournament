using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MKTournament.Controls
{
    public partial class NewUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCreate.Click += btnCreate_Click;
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            int userID = MKDataAccess.AddUser(txbName.Text, "/Images/Users/None1.png");
            if (fupUserAvatar.HasFile)
            {
                HttpPostedFile file = fupUserAvatar.PostedFile;
                file.SaveAs(HttpContext.Current.Server.MapPath("~/Images/Users/" + userID.ToString() + ".jpg"));
                MKDataAccess.SetAvatarPath(userID, "~/Images/Users/" + userID.ToString() + ".jpg");
            }
            
            Response.Redirect("User.aspx",true);
        }
    }
}