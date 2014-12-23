using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class TeamInfo
    {
        public int TeamID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public int MatchesWon { get; set; }

        public int MatchesLost { get; set; }

        public int MatchesRemain { get; set; }
        public int TournamentID { get; set; }

        public List<TeamMemberInfo> TeamMembers { get; set; }
    }
}
