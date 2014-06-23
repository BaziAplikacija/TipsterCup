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

        public List<Participates> Participations { get; set; }
        public List<Player> AllPlayers { get; set; }

        private int totalGoalTokens;
        private int totalAssistTokens;
        private int totalInterruptTokens;
        private int totalSaveTokens;

        public PlayTheMatch(MainDoc mainDoc, Match match)
        {
            random = new Random();
            List<Player> homeTeam = mainDoc.getFirstEleven(match.HomeTeam.Name);
            List<Player> guestTeam = mainDoc.getFirstEleven(match.HomeTeam.Name);

            int id = 0;//OVA TREBA DA GO DOBIJAM OD BAZATA
            totalAssistTokens = totalGoalTokens = totalInterruptTokens = totalSaveTokens = 0;
            foreach (Player p in homeTeam)
            {
                AllPlayers.Add(p);
                Participations.Add(new Participates(id, p, match, 0, 0, 0, 0));
                totalAssistTokens += p.TokensAssists;
                totalGoalTokens += p.TokensGoals;
                totalInterruptTokens += p.TokensInterrupts;
                totalSaveTokens += p.TokensSaves;
            }
            foreach (Player p in guestTeam)
            {
                AllPlayers.Add(p);
                Participations.Add(new Participates(id, p, match, 0, 0, 0, 0));
                totalAssistTokens += p.TokensAssists;
                totalGoalTokens += p.TokensGoals;
                totalInterruptTokens += p.TokensInterrupts;
                totalSaveTokens += p.TokensSaves;
            }
            //sluckite vo dadeni minuti
            for (int minute = 1; minute <= 90; minute++)//0 - goal and eventually assist, 1 - interrupt, 2 save, nothing
            {
                int happens = whatHappens();
                int nextGoal = 0;//Ova go dobij od baza
                if (happens == 0)//goal
                {
                    int scorerId = goalScorer();
                    Goal goal = new Goal(nextGoal, minute, match, AllPlayers[scorerId]);
                    Participations[scorerId].NumGoals++;
                    int assId = assistent();
                    if (assId != scorerId)
                    {
                        Participations[assId].NumAssists++;
                    }
                }
                else if (happens == 1)//interrupt
                {
                    int interrupterId = interrupter();
                    Participations[interrupterId].NumInterrupts++;
                }
                else if (happens == 2)//save
                {
                    int saverId = saver();
                    Participations[saverId].NumSaves++;
                }
            }

            foreach (Participates p in Participations)
            {
                p.calculateMatchRating();
            }
        }

        private int goalScorer()
        {
            int token = random.Next(totalGoalTokens);
            List<int> tokens = new List<int>();
            foreach(Player p in AllPlayers){
                tokens.Add(p.TokensGoals);
            }
            return ownerOfToken(token, tokens);
            
        }

        private int assistent()
        {
            int token = random.Next(totalAssistTokens);
            List<int> tokens = new List<int>();
            foreach (Player p in AllPlayers)
            {
                tokens.Add(p.TokensAssists);
            }
            return ownerOfToken(token, tokens);

        }

        private int interrupter()
        {
            int token = random.Next(totalInterruptTokens);
            List<int> tokens = new List<int>();
            foreach (Player p in AllPlayers)
            {
                tokens.Add(p.TokensInterrupts);
            }
            return ownerOfToken(token, tokens);
        }

        private int saver()
        {
            int token = random.Next(totalSaveTokens);
            List<int> tokens = new List<int>();
            foreach (Player p in AllPlayers)
            {
                tokens.Add(p.TokensSaves);
            }
            return ownerOfToken(token, tokens);
        }

        private int ownerOfToken(int chosen, List<int> tokens)
        {
            int lastToken = tokens[0];
            for (int i = 0; i < 22; i++)
            {
                if (chosen < lastToken)
                {
                    return i;
                }
                lastToken += tokens[i + 1];
            }
            return 21;
        }


        private int whatHappens()//0 - goal and eventually assist, 1 - interrupt, 2 save, nothing
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
