using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MKTournament.Controls
{
	public partial class UserControl : System.Web.UI.UserControl
	{
		public UserInfo User
		{
			get
			{
				if (ViewState["User"] != null)
				{
					return (UserInfo)ViewState["User"];
				}
				else
				{
					return null;
				}
			}
			set
			{
				ViewState["User"] = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			lblName.Text = User.Name;
			imgUserAvatar.ImageUrl = User.AvatarPath;
            lblTournamentsPlayed.Text = MKDataAccess.GetTournamensCount(User.UserID).ToString();
            lblTournamentsWon.Text = MKDataAccess.GetTournamensCount(User.UserID).ToString();
            lblMatchesPlayed.Text = MKDataAccess.GetTournamensCount(User.UserID).ToString();
            lblMatchesWon.Text = MKDataAccess.GetWonTournamensCount(User.UserID).ToString();
		}
	}
}