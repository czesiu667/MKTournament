using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class TeamMemberInfo
    {
        public int TeamMemberID { get; set; }
        public int TeamID { get; set; }
        public UserInfo User { get; set; }
        public CharacterInfo Character { get; set; }
    }
}
