using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DAL
{
	public static class MKDataAccess
	{
		private static string con = ConfigurationManager.ConnectionStrings["MKDBConnectionString"].ConnectionString;
		public enum Error
		{
			noErrors,
			CharacterDuplicate,
			UserDuplicate,
			WrongTournamentType,
			ToLessTeamsInTouranment,
			WrongResult,
			Pendingmatches,
			Rematch
		}
		#region User
		public static UserInfo GetUser(int ID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from us in dc.Users where us.UserID == ID select new UserInfo() { UserID = us.UserID, Name = us.Name, AvatarPath = us.AvatarPath }).SingleOrDefault();
		}

		public static List<UserInfo> GetUsers()
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from us in dc.Users select new UserInfo() { UserID = us.UserID, Name = us.Name, AvatarPath = us.AvatarPath }).OrderBy(x => x.Name).ToList();
		}

		public static int AddUser(string name, string avatarPath)
		{
			if (name.Length == 0)
			{
				return -1;
			}
			MKDBDataContext dc = new MKDBDataContext(con);

			User user = new User();
			user.Name = name;
			user.AvatarPath = avatarPath;

			dc.Users.InsertOnSubmit(user);
			dc.SubmitChanges();
			return user.UserID;
		}
		public static Error SetAvatarPath(int userID, string avararPath)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			User user = (from us in dc.Users where us.UserID == userID select us).SingleOrDefault();
			user.AvatarPath = avararPath;
			dc.SubmitChanges();
			return Error.noErrors;
		}
		public static int GetTournamensCount(int userID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from to in dc.Tournaments
					join te in dc.Teams on to.TournamentID equals te.TournamentID
					join tm in dc.TeamMembers on te.TeamID equals tm.TeamID
					where tm.UserID == userID
					select to).Count();
		}

		public static int GetWonTournamensCount(int userID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from to in dc.Tournaments
					join tm in dc.TeamMembers on to.WinerTeamID equals tm.TeamID
					where tm.UserID == userID
					select to).Count();
		}

		public static int GetMatchesCount(int userID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from ma in dc.Matches
					join tm in dc.TeamMembers on ma.FirstTeamID equals tm.TeamID
					where tm.UserID == userID && ma.Result > 0
					select ma).Count();
		}

		#endregion
		#region Character
		public static CharacterInfo GetCharacter(int ID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from ch in dc.Characters where ch.CharacterID == ID select new CharacterInfo() { CharacterID = ch.CharacterID, Name = ch.Name, AvatarPath = ch.AvatarPath }).SingleOrDefault();
		}

		public static List<CharacterInfo> GetCharacters()
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from ch in dc.Characters select new CharacterInfo() { CharacterID = ch.CharacterID, Name = ch.Name, AvatarPath = ch.AvatarPath }).ToList();
		}
		#endregion
		#region Match
		public static MatchInfo GetMatch(int ID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from ma in dc.Matches where ma.MatchID == ID select new MatchInfo() { MatchID = ma.MatchID, TouranamentID = ma.TournamentID, FirstTeam = GetTeam(ma.FirstTeamID), SecondTeam = GetTeam(ma.SecondTeamID), Result = ma.Result }).SingleOrDefault();
		}

		public static List<MatchInfo> GetMatches(int tournamentID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from ma in dc.Matches where ma.TournamentID == tournamentID select new MatchInfo() { MatchID = ma.MatchID, TouranamentID = ma.TournamentID, FirstTeam = GetTeam(ma.FirstTeamID), SecondTeam = GetTeam(ma.SecondTeamID), Result = ma.Result }).ToList();
		}

		public static Error SetMatchResult(int matchID, int result)
		{
			if (result < -2 || result > 2)
			{
				return Error.WrongResult;
			}
			MKDBDataContext dc = new MKDBDataContext(con);

			Match m = (from ma in dc.Matches where ma.MatchID == matchID select ma).SingleOrDefault();
			m.Result = result;

			dc.SubmitChanges();
			return Error.noErrors;
		}

		public static Error SetMatchResult(List<IDValuePair> toUpdate)
		{
			MKDBDataContext dc = new MKDBDataContext(con);

			foreach (IDValuePair i in toUpdate)
			{
				if (i.Value < -2 || i.Value > 2)
				{
					return Error.WrongResult;
				}

				Match m = (from ma in dc.Matches where ma.MatchID == i.ID select ma).SingleOrDefault();
				m.Result = i.Value;
			}
			dc.SubmitChanges();
			return Error.noErrors;
		}

		#endregion
		#region Team
		public static TeamInfo GetTeam(int? ID)
		{
			if (ID == null) return null;
			MKDBDataContext dc = new MKDBDataContext(con);
			TeamInfo team = (from te in dc.Teams where te.TeamID == ID select new TeamInfo() { TeamID = te.TeamID, Name = te.Name, Score = GetTeamScore(te.TeamID), TournamentID = te.TournamentID, TeamMembers = GetTeamMembers(te.TeamID) }).SingleOrDefault();
			return team;
		}

		public static List<TeamInfo> GetTeams(int tournamentID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from te in dc.Teams where te.TournamentID == tournamentID select new TeamInfo() { TeamID = te.TeamID, Name = te.Name, Score = GetTeamScore(te.TeamID), MatchesLost = GetTeamLostMatchesCount(te.TeamID), MatchesWon = GetTeamWonMatchesCount(te.TeamID), MatchesRemain = GetTeamRemainMatchesCount(te.TeamID), TournamentID = te.TournamentID, TeamMembers = GetTeamMembers(te.TeamID) }).ToList();
		}

		public static int GetTeamScore(int TeamID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from ma in dc.Matches where ma.FirstTeamID == TeamID && ma.Result > 0 select ma).ToList().Sum(x => x.Result) - (from ma in dc.Matches where ma.SecondTeamID == TeamID && ma.Result < 0 select ma).ToList().Sum(x => x.Result);
		}
		public static int GetTeamWonMatchesCount(int TeamID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from ma in dc.Matches where ma.FirstTeamID == TeamID && ma.Result > 0 select ma).ToList().Count + (from ma in dc.Matches where ma.SecondTeamID == TeamID && ma.Result < 0 select ma).ToList().Count;
		}
		public static int GetTeamLostMatchesCount(int TeamID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from ma in dc.Matches where ma.FirstTeamID == TeamID && ma.Result < 0 select ma).ToList().Count + (from ma in dc.Matches where ma.SecondTeamID == TeamID && ma.Result > 0 select ma).ToList().Count;
		}
		public static int GetTeamRemainMatchesCount(int TeamID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from ma in dc.Matches where ma.FirstTeamID == TeamID && ma.Result == 0 select ma).ToList().Count + (from ma in dc.Matches where ma.SecondTeamID == TeamID && ma.Result == 0 select ma).ToList().Count;
		}

		#endregion
		#region TeamMember
		public static TeamMemberInfo GetTeamMember(int ID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from teme in dc.TeamMembers where teme.TeamMemberID == ID select new TeamMemberInfo() { TeamMemberID = teme.TeamMemberID, TeamID = teme.TeamID, Character = GetCharacter(teme.CharacterID), User = GetUser(teme.UserID) }).SingleOrDefault();
		}

		public static List<TeamMemberInfo> GetTeamMembers(int TeamID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from teme in dc.TeamMembers where teme.TeamID == TeamID select new TeamMemberInfo() { TeamMemberID = teme.TeamMemberID, TeamID = teme.TeamID, Character = GetCharacter(teme.CharacterID), User = GetUser(teme.UserID) }).ToList();
		}
		#endregion
		#region Tournament

		public static List<int> GetTournamentsId()
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from to in dc.Tournaments select to.TournamentID).ToList();

		}

		public static TournamentInfo GetTournament(int ID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from to in dc.Tournaments where to.TournamentID == ID select new TournamentInfo() { TournamentID = to.TournamentID, Name = to.Name, StartDate = to.StartDate, EndDate = to.EndDate, Type = GetTournamentType(to.TournamentTypeID).Name, Matches = GetMatches(to.TournamentID), Teams = GetTeams(to.TournamentID), Winner = GetTeam(to.WinerTeamID) }).SingleOrDefault();

		}

		public static List<TournamentInfo> GetTournaments()
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from to in dc.Tournaments select new TournamentInfo() { TournamentID = to.TournamentID, Name = to.Name, StartDate = to.StartDate, EndDate = to.EndDate, Type = GetTournamentType(to.TournamentTypeID).Name, Matches = GetMatches(to.TournamentID), Teams = GetTeams(to.TournamentID), Winner = GetTeam(to.WinerTeamID) }).OrderByDescending(x => x.TournamentID).ToList();
		}

		public static List<TournamentInfo> GetOpenTournaments()
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from to in dc.Tournaments where to.StartDate == null && to.EndDate == null select new TournamentInfo() { TournamentID = to.TournamentID, Name = to.Name, StartDate = to.StartDate, EndDate = to.EndDate, Type = GetTournamentType(to.TournamentTypeID).Name, Matches = GetMatches(to.TournamentID), Teams = GetTeams(to.TournamentID), Winner = GetTeam(to.WinerTeamID) }).OrderByDescending(x => x.TournamentID).ToList();
		}

		public static List<TournamentInfo> GetPendingTournaments()
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from to in dc.Tournaments where to.StartDate != null && to.EndDate == null select new TournamentInfo() { TournamentID = to.TournamentID, Name = to.Name, StartDate = to.StartDate, EndDate = to.EndDate, Type = GetTournamentType(to.TournamentTypeID).Name, Matches = GetMatches(to.TournamentID), Teams = GetTeams(to.TournamentID), Winner = GetTeam(to.WinerTeamID) }).OrderBy(x => x.StartDate).ToList();
		}

		public static List<TournamentInfo> GetClosedTournaments()
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from to in dc.Tournaments where to.StartDate != null && to.EndDate != null select new TournamentInfo() { TournamentID = to.TournamentID, Name = to.Name, StartDate = to.StartDate, EndDate = to.EndDate, Type = GetTournamentType(to.TournamentTypeID).Name, Matches = GetMatches(to.TournamentID), Teams = GetTeams(to.TournamentID), Winner = GetTeam(to.WinerTeamID) }).OrderBy(x => x.StartDate).ToList();
		}

		public static void AddTournament(string name, string type)
		{

			if (name.Length==0)
			{
				return;
			}
			MKDBDataContext dc = new MKDBDataContext(con);

			Tournament t = new Tournament();
			t.Name = name;
			t.TournamentTypeID = (from ty in dc.TournamentTypes where ty.Name == type select ty.TournamentTypeID).Single();
			dc.Tournaments.InsertOnSubmit(t);
			dc.SubmitChanges();
		}

		public static Error AddPlayerToTournament(int tournamentID, int userID, int characterID)
		{
			if (IsInTournament(tournamentID, userID))
			{
				return Error.UserDuplicate;
			}

			MKDBDataContext dc = new MKDBDataContext(con);
			Team t = new Team();
			t.Name = "";
			t.Score = 0;
			t.TournamentID = tournamentID;
			dc.Teams.InsertOnSubmit(t);
			dc.SubmitChanges();

			TeamMember tm = new TeamMember();
			tm.TeamID = t.TeamID;
			tm.CharacterID = characterID;
			tm.UserID = userID;
			dc.TeamMembers.InsertOnSubmit(tm);
			dc.SubmitChanges();
			return Error.noErrors;
		}

		public static Error AddTeamToTournament(int tournamentID, int userID1, int characterID1, int userID2, int characterID2)
		{
			if (IsInTournament(tournamentID, userID1) || IsInTournament(tournamentID, userID2))
			{
				return Error.UserDuplicate;
			}

			if (userID1 == userID2)
			{
				return Error.UserDuplicate;
			}

			if (characterID1 == characterID2)
			{
				return Error.CharacterDuplicate;
			}

			MKDBDataContext dc = new MKDBDataContext(con);
			Team t = new Team();
			t.Name = "";
			t.Score = 0;
			t.TournamentID = tournamentID;

			dc.Teams.InsertOnSubmit(t);
			dc.SubmitChanges();

			TeamMember tm1 = new TeamMember();
			tm1.TeamID = t.TeamID;
			tm1.CharacterID = characterID1;
			tm1.UserID = userID1;

			TeamMember tm2 = new TeamMember();
			tm2.TeamID = t.TeamID;
			tm2.CharacterID = characterID2;
			tm2.UserID = userID2;

			dc.TeamMembers.InsertOnSubmit(tm1);
			dc.TeamMembers.InsertOnSubmit(tm2);
			dc.SubmitChanges();
			return Error.noErrors;
		}

		public static Error StartTournament(int tournamentID)
		{
			List<TeamInfo> teams = GetTeams(tournamentID);
			if (teams.Count <= 1)
			{
				return Error.ToLessTeamsInTouranment;
			}
			MKDBDataContext dc = new MKDBDataContext(con);
			for (int i = 0; i < teams.Count - 1; i++)
			{
				for (int j = i + 1; j < teams.Count; j++)
				{
					Match m = new Match();
					m.FirstTeamID = teams[i].TeamID;
					m.SecondTeamID = teams[j].TeamID;
					m.TournamentID = tournamentID;
					m.Result = 0;
					dc.Matches.InsertOnSubmit(m);
				}
			}
			Tournament tournament = (from to in dc.Tournaments where to.TournamentID == tournamentID select to).SingleOrDefault();
			tournament.StartDate = DateTime.Now;
			dc.SubmitChanges();

			return Error.noErrors;
		}

		public static Error SetRematch(int tournamentID, List<int> TeamIDs)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			for (int i = 0; i < TeamIDs.Count - 1; i++)
			{
				for (int j = i + 1; j < TeamIDs.Count; j++)
				{
					Match m = new Match();
					m.FirstTeamID = TeamIDs[i];
					m.SecondTeamID = TeamIDs[j];
					m.TournamentID = tournamentID;
					m.Result = 0;
					dc.Matches.InsertOnSubmit(m);
				}
			}
			dc.SubmitChanges();
			return Error.noErrors;
		}

		public static Error CloseTournament(int tournamentID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			if ((from ma in dc.Matches where ma.Result == 0 && ma.TournamentID == tournamentID select ma).Count() > 0)
			{
				return Error.Pendingmatches;
			}

			List<TeamInfo> teams = GetTeams(tournamentID);
			int maxScore = teams.Max(x => x.Score);

			List<TeamInfo> leadTeams = (from te in teams where te.Score == maxScore select te).ToList();

			if (leadTeams.Count != 1)
			{
				SetRematch(tournamentID, leadTeams.Select(x => x.TeamID).ToList());
				return Error.Rematch;
			}

			Tournament tournament = (from to in dc.Tournaments where to.TournamentID == tournamentID select to).SingleOrDefault();

			tournament.EndDate = DateTime.Now;
			tournament.WinerTeamID = leadTeams[0].TeamID;

			dc.SubmitChanges();

			return Error.noErrors;
		}

		public static bool IsInTournament(int tournamentID, int user)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			foreach (TeamInfo t in GetTeams(tournamentID))
			{
				foreach (TeamMemberInfo tm in t.TeamMembers)
				{
					if (tm.User.UserID == user)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static void OpenTournament(int tournamentID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			Tournament tournament = (from to in dc.Tournaments where to.TournamentID == tournamentID select to).SingleOrDefault();

			IQueryable<Match> matches = from ma in dc.Matches 
										where ma.TournamentID==tournamentID 
										select ma;

			dc.Matches.DeleteAllOnSubmit(matches);

			tournament.StartDate = null;
			tournament.EndDate = null;
			tournament.WinerTeamID = null;

			dc.SubmitChanges();
		}
		#endregion
		#region TournamentType
		public static TournamentType GetTournamentType(int ID)
		{
			MKDBDataContext dc = new MKDBDataContext(con);
			return (from ty in dc.TournamentTypes where ty.TournamentTypeID == ID select ty).SingleOrDefault();
		}
		#endregion
	}
}
