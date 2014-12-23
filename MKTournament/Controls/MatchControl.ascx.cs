using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MKTournament.Controls
{
	public partial class MatchControl : System.Web.UI.UserControl
	{
		public MatchInfo Match
		{
			get
			{
				if (ViewState["Match"] != null)
				{
					return (MatchInfo)ViewState["Match"];
				}
				else
				{
					return null;
				}
			}
			set
			{
				ViewState["Match"] = value;
			}
		}

        public int DDLResultValue { get { return int.Parse(ddlResult.SelectedValue); } }

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ddlResult.Items.Add(new ListItem("2:0", "2"));
				ddlResult.Items.Add(new ListItem("2:1", "1"));
				ddlResult.Items.Add(new ListItem("0:0", "0"));
				ddlResult.Items.Add(new ListItem("1:2", "-1"));
				ddlResult.Items.Add(new ListItem("0:2", "-2"));
				ddlResult.SelectedIndex = 2-Match.Result;
			}
			else
			{
				//MKDataAccess.SetMatchResult(Match.MatchID, int.Parse(ddlResult.SelectedValue));
			}
		}
	}
}