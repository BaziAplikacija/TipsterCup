using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipsterCup
{
    public class Match : IComparable<Match>
    {
        public int Id { get; set; }
        public Team HomeTeam { get; set; }
        public Team GuestTeam { get; set; }
        public Round Round { get; set; }
        public DateTime DateMatch { get; set;}
        public int IdRound { get; set; }
        public int IdHomeTeam { get; set; }
        public int IdGuestTeam { get; set; }

        public List<Goal> GoalsHome { get; set; }
        public List<Goal> GoalsGuest { get; set; }

        public Match(int id, Team homeTeam, Team guestTeam, Round round, DateTime dateMatch)
        {
            Id = id;
            HomeTeam = homeTeam;
            GuestTeam = guestTeam;
            Round = round;
            DateMatch = dateMatch;

            GoalsHome = new List<Goal>();
            GoalsGuest = new List<Goal>();
        }

        //konstruktor koj prima samo id, a ne referenci
        public Match(int id, int idHomeTeam, int idGuestTeam, int idRound, DateTime dateMatch)
        {
            Id = id;
            IdHomeTeam = idHomeTeam;
            IdGuestTeam = idGuestTeam;
            IdRound = idRound;
            DateMatch = dateMatch;
            GoalsHome = new List<Goal>();
            GoalsGuest = new List<Goal>();
            createHomeTeam();
            createGuestTeam();
            createRound();
            if (dateMatch.CompareTo(FormLogin.virtualDate) < 0)
            {
                fillGoals();
            }
        }


        private void fillGoals()
        {
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();
                String query = "SELECT * FROM goal WHERE idMatch =" + Id +" ORDER BY minutes";
                OracleCommand command = new OracleCommand(query, connection);
                OracleDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Goal goal = new Goal(reader.GetInt32(0), reader.GetInt32(1), this, reader.GetInt32(3));
                    if (goal.Player.Team.Id == HomeTeam.Id)
                    {
                        GoalsHome.Add(goal);
                    }
                    else
                    {
                        GoalsGuest.Add(goal);
                    }
                }
            }
        }


        private void createHomeTeam()
        {
            using(OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();
                String query = "SELECT * FROM team WHERE idTeam =" + IdHomeTeam;
                OracleCommand command = new OracleCommand(query, connection);
                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                HomeTeam = new Team(IdHomeTeam, reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6));
            }
        }

        private void createGuestTeam()
        {
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();
                String query = "SELECT * FROM team WHERE idTeam =" + IdGuestTeam;
                OracleCommand command = new OracleCommand(query, connection);
                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                GuestTeam = new Team(IdGuestTeam, reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6));
            }
        }

        private void createRound()
        {
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();
                String query = "SELECT * FROM round WHERE idround =" + IdRound;
                OracleCommand command = new OracleCommand(query, connection);
                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                Round = new Round(IdRound, reader.GetDateTime(1), reader.GetDateTime(2));
            
            }
        }

       


        // //IDGOAL	MINUTES	IDMATCH	IDPLAYER
        public void addGoal(int idGoal, int minutes,Player player)
        {
            Goal newGoal = new Goal(idGoal, minutes, this, player);

            if (player.Team.Id == HomeTeam.Id)
            {
                GoalsHome.Add(newGoal);
            }
            else if (player.Team.Id == GuestTeam.Id)
            {
                GoalsGuest.Add(newGoal);
            }
            else
            {
                throw new Exception("IGRACHOT KOJ DAL GOL NA  MATCH SO ID: " + this.Id + " NE IGRA NITU ZA EDEN OD TIMOVITE!");
            }
           
        }

        public void addGoal(Goal goal)
        {
            addGoal(goal.Id, goal.Minutes, goal.Player);
        }

        public int CompareTo(Match other)
        {
            
            return DateMatch.CompareTo(other.DateMatch);
        }
    }
}
