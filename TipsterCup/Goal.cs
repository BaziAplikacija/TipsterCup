using Oracle.DataAccess.Client;
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

        public Goal(int id, int minutes, Match match, int idPlayer)
        {
            Id = id;
            Minutes = minutes;
            Match = match;
            Player = createPlayer(idPlayer);
        }

        private Player createPlayer(int idPlayer)
        {
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();
                String query = "SELECT * FROM player WHERE idPlayer =" + idPlayer;
                OracleCommand command = new OracleCommand(query, connection);
                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                Player p = new Player(FormLogin.docMain, idPlayer, reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6));
                return p;
            }
        }

        public override string ToString()
        {
            return Minutes + " " + Player.FirstName + " " + Player.LastName;
        }
    }
}
