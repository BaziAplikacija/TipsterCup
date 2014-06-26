using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsterCup
{
    class Participates
    {
        public int IdParticipate { get; set; }
        public Player Player { get; set; }
        public Match Match { get; set; }
        public int NumGoals { get; set; }
        public int NumAssists { get; set; }
        public int NumInterrupts { get; set; }
        public int NumSaves { get; set; }

        public int MatchRating { get; set; }

        private const int BASE_RATING = 1000;//sekoj igrac u start da ima BASE_RATING so samoto ucestvo
        //verojatnosno-empirisko odreduvanje na najpogodni tezini, mozno e da ima i promeni
        private const int WEIGHT_GOAL = 1200;//na site igraci ke bidat ednakvo vrednuvani site dostignuvanja
        private const int WEIGHT_ASSIST = 1100;//nezavisno od pozicijata
        private const int WEIGHT_INTERRUPT = 300;//Tokens ke vlijaat koj kolku poeni ke dobiva od sto
        private const int WEIGHT_SAVE = 300;//bidejki toa odreduva koj igrac kolkavi sansi ima sto da postigne
                                            //vaka e po fer, bidejki na pr. gol e gol nezavisno dali igracot na
                                            //koja pozicija igra


        public Participates(int id, Player player, Match match, int ng, int na, int ni, int ns)
        {
            IdParticipate = id;
            Player = player;
            Match = match;
            NumGoals = ng;
            NumAssists = na;
            NumInterrupts = ni;
            NumSaves = ns;

            
        }

        public void calculateMatchRating()
        {
            MatchRating = BASE_RATING + NumGoals * WEIGHT_GOAL + NumAssists * WEIGHT_ASSIST + NumInterrupts * WEIGHT_INTERRUPT
                        + NumSaves * WEIGHT_SAVE;
        }
    }
}
