using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MKTournament
{
	public partial class Characters : System.Web.UI.Page
	{
		private int CharacterID;
		protected void Page_Load(object sender, EventArgs e)
		{
			rptCharacterPicker.DataSource = DAL.MKDataAccess.GetCharacters();
			rptCharacterPicker.DataBind();

			if (int.TryParse(Request.QueryString["CharacterID"], out CharacterID))
			{
				//mvwCharacter.ActiveViewIndex=chara
			}
		}
	}
}