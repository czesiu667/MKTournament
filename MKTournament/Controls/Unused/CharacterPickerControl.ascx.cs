using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MKTournament.Controls
{
    public partial class CharacterPickerControl : System.Web.UI.UserControl
    {
        public int Selected
        {
            get
            {
                int id;
                if (int.TryParse(SelectedCharacter.Value, out id))
                {
                    return id;
                }
                return -1;
            }
        }
        public int TournamentID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            rptCharacterPicker.DataSource = DAL.MKDataAccess.GetCharacters();
            rptCharacterPicker.DataBind();
        }
    }
}