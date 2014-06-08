using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsterCup
{
    public class Goal
    {
        //IDGOAL	MINUTES	IDMATCH	IDPLAYER

        public int Id {get;set;}
        public int Minutes{get;set;}
        public Match Match {get;set;}
        public Player Player {get;set;}

        public Goal(int id, int minutes, Match match, Player player)
        {
            Id = id;
            Minutes = minutes;
            Match = match;
            Player = player;
        }
    }
}
