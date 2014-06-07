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

        public MainDoc()
        {
            Teams = new List<Team>();
            Managers = new List<Manager>();
            Players = new List<Player>();
            Positions = new List<Position>();
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

        
    }
}
