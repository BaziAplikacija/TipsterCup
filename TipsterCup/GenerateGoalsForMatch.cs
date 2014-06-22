using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsterCup
{
    public class GenerateGoalsForMatch
    {
        Random random = new Random();

        public Match Match { get; set; }
        private int totalTokens;
        public List<Player> Players { get; set; }
        private List<int> playerLastToken;

        OracleConnection connection;
        OracleCommand command;
        OracleDataReader reader;

        string query;

        public GenerateGoalsForMatch(MainDoc mainDoc, Match match, OracleConnection conn)
        {

            connection = conn;

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            Match = match;
            Players = new List<Player>();
            playerLastToken = new List<int>();

            Players = mainDoc.getPlayersFromTeam(Match.HomeTeam.Name);
            Players.AddRange(mainDoc.getPlayersFromTeam(Match.GuestTeam.Name));

            foreach (Player p in Players)
            {
                playerLastToken.Add(totalTokens + p.TokensGoals);
                totalTokens += p.TokensGoals;
            }
        }



        private bool isScoredGoal()
        {
            int rnd = random.Next(100);
            if (rnd < 3)
            {
                return true;
            }
            return false;
        }
        public string Goals { get; set; }
        public void generateGoals() {
            for (int i = 1; i <= 90; i++)
            {
                bool goal = isScoredGoal();
                if (goal)
                {
                    int token = random.Next(totalTokens);
                    for (int p = 0; p < 22; p++)
                    {
                        if (token < playerLastToken[p])
                        {
                            String query = "SELECT lastGoalId FROM lastGoal";
                            command = new OracleCommand(query, connection);
                            command.CommandType = CommandType.Text;
                            reader = command.ExecuteReader();

                            int id = reader.GetInt32(0) + 1;//sleden gol
                            /*query = "INSERT INTO Goal VALUES(" + id + "," + i + "," + Match.Id + "," + Players[p].Id;
                            command = new OracleCommand(query, connection);
                            command.CommandType = CommandType.Text;*/
                            break;

                        }
                    }
                }
            }
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }


            


    }
}
