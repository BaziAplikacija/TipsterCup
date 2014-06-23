using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsterCup
{
    class PlayTheMatch
    {
        //da nema zabuna, ednite Tokens, kaj igraci, odreduvat verojatnost deka daden igrac ke postigne nesto
        //pr. gol, asistencija i sl.
        //ovie ovde Tokens odreduvat verojatnost deka nesto voopsto ke se sluci
        private const int GOAL_TOKENS = 5;// 5/100 e verojatnost deka ke ima gol vo dadena minuta
        private const int INTERRUPT_TOKENS = 32;//32/100 deka ke ima prekin na protivnicka akcija itn.
        private const int SAVE_TOKENS = 13;
        private const int NOTHING_HAPPENS_TOKENS = 50;
        private const int TOTAL_TOKENS = GOAL_TOKENS + INTERRUPT_TOKENS + SAVE_TOKENS + NOTHING_HAPPENS_TOKENS;
        Random random;

        public PlayTheMatch(MainDoc mainDoc, Match match)
        {
            random = new Random();
            List<Player> homeTeam = mainDoc.getFirstEleven(match.HomeTeam.Name);
            List<Player> guestTeam = mainDoc.getFirstEleven(match.HomeTeam.Name);


        }



        int whatHappens()//0 - goal and eventually assist, 1 - interrupt, 2 save, nothing
        {
            int tokenValue = random.Next(TOTAL_TOKENS);
            int total = GOAL_TOKENS;

            if (tokenValue < total)
            {
                return 0;//goal
            }

            total += INTERRUPT_TOKENS;

            if(tokenValue < total)
            {
                return 1;//assist
            }

            total += SAVE_TOKENS;

            if (tokenValue < total)
            {
                return 2;//interrupt
            }

            return 3;//nothing happened
        }
    }
}
