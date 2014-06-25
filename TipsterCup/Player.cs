using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TipsterCup
{
    public class Player : VirtualMan
    {

        //IDPLAYER	NAME	SURNAME	DATEOFBIRTH	RATING	IDTEAM	IDPOSITION

        public Double Rating { get; set; }
        public Team Team { get; set;}
        public Position Position { get; set; }

        public int TokensGoals { get; set; }
        public int TokensAssists { get; set; }
        public int TokensInterrupts { get; set; }
        public int TokensSaves { get; set; }

        public Player(int id, String firstName, String lastName, DateTime dateOfBirth, double rating, Team team, Position position) 
            : base(id,firstName,lastName,dateOfBirth)
        {
            Rating = rating;
            Team = team;
            Position = position;

            TokensGoals = (int) Rating;//vo osnova verojatnosta daden igrac da dade gol e proporcionalna
                                  // na negoviot rejting
            TokensAssists = (int)Rating;
            TokensInterrupts = (int)Rating;
            TokensSaves = (int)Rating;
            switch (Position.Id)
            {
                case 1://Napad
                    TokensGoals *= 3;//Napagacot da ima najgolemi shansi za gol
                    TokensAssists *= 2;
                    TokensInterrupts *= 1;
                    TokensSaves = 0;
                    break;
                case 2://Sredina
                    TokensGoals *= 2;
                    TokensAssists *= 3;
                    TokensInterrupts *= 2;
                    TokensSaves = 0;
                    break;
                case 3://Odbrana
                    TokensGoals /= 10;
                    TokensAssists /= 10;
                    TokensInterrupts *= 5;
                    TokensSaves = 0;
                    break;
                case 4://Golman
                    TokensGoals /= 1000;//Postoi moznost i golman da dade gol, no taa e premnogu mala
                    TokensAssists /= 1000;
                    TokensInterrupts /= 100;
                    TokensSaves = (int)Rating;
                    break;
            }


        }


        //konstruktor so id namesto referenci
        public Player(MainDoc mainDoc, int id, String firstName, String lastName, DateTime dateOfBirth, double rating, int teamId, int positionId)
            : base(id, firstName, lastName, dateOfBirth)
        {
            Rating = rating;

            Team = mainDoc.getTeamById(teamId);
            Position = mainDoc.getPositionById(positionId);

            TokensGoals = (int)Rating;//vo osnova verojatnosta daden igrac da dade gol e proporcionalna
            // na negoviot rejting
            TokensAssists = (int)Rating;
            TokensInterrupts = (int)Rating;
            TokensSaves = (int)Rating;
            switch (Position.Id)
            {
                case 1://Napad
                    TokensGoals *= 3;//Napagacot da ima najgolemi shansi za gol
                    TokensAssists *= 2;
                    TokensInterrupts *= 1;
                    TokensSaves = 0;
                    break;
                case 2://Sredina
                    TokensGoals *= 2;
                    TokensAssists *= 3;
                    TokensInterrupts *= 2;
                    TokensSaves = 0;
                    break;
                case 3://Odbrana
                    TokensGoals /= 10;
                    TokensAssists /= 10;
                    TokensInterrupts *= 5;
                    TokensSaves = 0;
                    break;
                case 4://Golman
                    TokensGoals /= 1000;//Postoi moznost i golman da dade gol, no taa e premnogu mala
                    TokensAssists /= 1000;
                    TokensInterrupts /= 100;
                    TokensSaves = (int)Rating;
                    break;
            }


        }

        public void updateRating(int matchRating)//podlozni se na promena tezinite
        {
            Rating = (49 * Rating + matchRating) / 50;
        }

        //public OracleDataReader OracleDataRreader { get; set; }
    }
}
