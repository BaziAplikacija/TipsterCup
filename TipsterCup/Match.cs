using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsterCup
{
    public class Match : IComparable<Match>
    {
        public int Id { get; set; }
        public Team HomeTeam { get; set; }
        public Team GuestTeam { get; set; }
        public Round Round { get; set; }
        public DateTime DateMatch { get; set;}

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
