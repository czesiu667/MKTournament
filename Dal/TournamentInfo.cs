using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
	public class TournamentInfo
	{
		public int TournamentID { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public TeamInfo Winner { get; set; }

		public List<MatchInfo> Matches { get; set; }
		public List<TeamInfo> Teams { get; set; }

		public string TournamentStatus
		{
			get
			{
				if (StartDate == null)
				{
					return "open";
				}
				else if (EndDate == null)
				{
					return "pending";
				}
				return "closed";
			}
		}

		public List<MatchInfo> GetPlayedMatches()
        {
            return (from ma in Matches where ma.WasPlayed == true select ma).ToList();
        }

        public List<MatchInfo> GetNotPlayedMatches()
        {
            return (from ma in Matches where ma.Result == 0 select ma).ToList();
        }
	}
}
