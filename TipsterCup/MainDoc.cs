using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsterCup
{
    public class MainDoc
    {

        public List<Team> Teams;
        public List<Manager> Managers;
        public List<Player> Players;
        public List<Position> Positions;
        public List<Match> Matches;
        public List<Round> Rounds;
        public List<Goal> Goals;

        public MainDoc()
        {
            Teams = new List<Team>();
            Managers = new List<Manager>();
            Players = new List<Player>();
            Positions = new List<Position>();
            Matches = new List<Match>();
            Rounds = new List<Round>();
            Goals = new List<Goal>();
            
        }
         //IDGOAL	MINUTES	IDMATCH	IDPLAYER

        public Match getMatchById(int idMatch)
        {
            foreach (Match match in Matches)
            {
                if (match.Id == idMatch)
                {
                    return match;
                }
            }

            return null;
        }
        public void addGoal(int idGoal, int minutes, int idMatch, int idPlayer)
        {
            Goal newGoal = new Goal(idGoal, minutes, this.getMatchById(idMatch), this.getPlayerById(idPlayer));

            this.addGoal(newGoal);
            
        }
        public void addGoal(Goal goal)
        {

            foreach (Match match in Matches)
            {
                if (match.Id == goal.Match.Id)
                {
                    match.addGoal(goal);
                    break;
                }
            }
            Goals.Add(goal);


        }


        public void addRound(Round round)
        {
            Rounds.Add(round);
        }

        public void addRound(int idRound, DateTime dateFrom, DateTime dateTo)
        {
            Round newRound = new Round(idRound, dateFrom, dateTo);
            Rounds.Add(newRound);
        }

        public void addMatch(Match match)
        {
            Matches.Add(match);
            match.Round.addMatch(match);
        }
        
        public void addMatch(int idMatch, DateTime dateMatch, int idRound, int idGuestTeam, int idHomeTeam)
        {
            Match newMatch = new Match(idMatch, getTeamById(idHomeTeam), getTeamById(idGuestTeam), getRoundById(idRound), dateMatch);
            Matches.Add(newMatch);
            getRoundById(idRound).addMatch(newMatch);
        }

        public Round getRoundById(int idRound)
        {
            foreach (Round round in Rounds)
            {
                if (round.Id == idRound)
                {
                    return round;
                }
            }
            return null;
        }


        


        public Player getPlayerById(int idPlayer)
        {

            foreach (Player player in Players)
            {

                if (player.Id == idPlayer)
                {
                    return player;
                }
            }

            return null;
        }

        public List<Player> getPlayersFromTeam(String teamName)
        {
            List<Player> toRet = new List<Player>();

            foreach (Player player in Players)
            {
                if (player.Team.Name.Equals(teamName))
                {
                    toRet.Add(player);
                }
            }

            return toRet;
        }


        public Position getPositionById(int idPosition)
        {
            foreach (Position position in Positions)
            {
                if (position.Id == idPosition)
                {
                    return position;
                }
            }

            return null;
        }
        public void addPosition(Position position)
        {
            Positions.Add(position);
        }
    
        public void addPosition(int id, String description, double factorGoal, double factorAssist, double factorInterrupt, double factorSave)
        {
            Position newPosition = new Position(id, description, factorGoal, factorAssist, factorInterrupt,factorSave);
            Positions.Add(newPosition);
        }
        public void addPlayer(Player player)
        {
            Players.Add(player);
        }
        //IDPLAYER	NAME	SURNAME	DATEOFBIRTH	RATING	IDTEAM	IDPOSITION
        public void addPlayer(int id, String firstName, String lastName, DateTime dateOfBirth, double rating, int idTeam, int idPosition)
        {

            Player newPlayer = new Player(id, firstName, lastName, dateOfBirth, rating, this.getTeamById(idTeam), this.getPositionById(idPosition));
            Players.Add(newPlayer);

        }

     

        public void addManager(Manager manager)
        {
            Managers.Add(manager);
        }
        //IDMANAGER	NAME	SURNAME	DATEOFBIRTH	EXPERIENCE
        public void addManager(int id, String firstName, String lastName, DateTime dateOfBirth, double experience)
        {
            Manager newManager = new Manager(id, firstName, lastName, dateOfBirth, experience);
            Managers.Add(newManager);
        }

       
        public Manager getManagerById(int managerId)
        {

            foreach (Manager manager in Managers)
            {
                if (manager.Id == managerId)
                {
                    return manager;
                }
            }

            return null;
        }

        public void addTeam(Team team)
        {
            Teams.Add(team);
        }

        public void addTeam(int id, String name, String city, Double rating, Manager manager, String stadium, String picturePath)
        {
            Team newTeam = new Team(id, name, city, rating, manager, stadium, picturePath);
            Teams.Add(newTeam);
        }

        public Team getTeamById(int idteam)
        {
            foreach (Team team in Teams)
            {
                if (team.Id == idteam)
                {
                    return team;
                }
            }

            return null;
        }
        public Team getTeamByName(String name)
        {

            foreach (Team team in Teams)
            {
                if (team.Name.Equals(name))
                {

                    return team;
                }
            }
            return null;
        }

        public List<Player> getFirstEleven(String teamName)//odbira koi 11 igraci ke igraat na daden natprevar
        {
            List<Player> toRet = new List<Player>();
            List<Player> allPlayers =  getPlayersFromTeam(teamName);
            List<int> lastToken = new List<int>();
            Random random = new Random();
            int totalTokens = 0;
            for (int p = 0; p < allPlayers.Count; p++)
            {
                lastToken.Add(totalTokens + (int)allPlayers[p].Rating);
                totalTokens += (int)allPlayers[p].Rating;
            }
            int[] chosen = { 0, 2, 4, 4, 1 };//1 GKP, 4 DF, 4 MDF, 2 FWD 
            while (toRet.Count < 11)
            {
                int pos = random.Next(totalTokens);
                for (int p = 0; p < allPlayers.Count; p++)
                {
                    if (pos < lastToken[p])
                    {
                        if (chosen[allPlayers[p].Position.Id] > 0)
                        {
                            chosen[allPlayers[p].Position.Id]--;
                            toRet.Add(allPlayers[p]);
                            for (int j = p + 1; j < allPlayers.Count; j++)
                            {
                                lastToken[j] -= (int)allPlayers[p].Rating;
                            }
                            allPlayers.RemoveAt(p);
                            lastToken.RemoveAt(p);
                            break;
                        }
                    }
                }
                    
            }

            return toRet;
        }
    }
}
