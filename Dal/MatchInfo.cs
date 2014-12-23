using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	[Serializable]
	public class MatchInfo
	{
		public int MatchID { get; set; }
		public TeamInfo FirstTeam { get; set; }
		public TeamInfo SecondTeam { get; set; }
		public bool WasPlayed { get; set; }
		public int Result { get; set; }
		public int TouranamentID { get; set; }
	}
}
