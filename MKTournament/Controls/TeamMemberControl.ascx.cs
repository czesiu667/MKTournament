using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MKTournament.Controls
{
	public partial class TeamMemberControl : System.Web.UI.UserControl
	{
		public DAL.TeamMemberInfo TeamMember { get; set; }

        protected void Page_PreRender(object sender, EventArgs e)
		{
            Character.ImageUrl = TeamMember.Character.AvatarPath;
            UserAvatar.ImageUrl = TeamMember.User.AvatarPath;
            UserName.Text = TeamMember.User.Name;
		}
	}
}