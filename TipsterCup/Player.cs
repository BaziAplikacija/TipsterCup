using System;
using System.Collections.Generic;
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

        public int Tokens { get; set; }

        public Player(int id, String firstName, String lastName, DateTime dateOfBirth, double rating, Team team, Position position) 
            : base(id,firstName,lastName,dateOfBirth)
        {
            Rating = rating;
            Team = team;
            Position = position;

            Tokens = (int) Rating + (int)Team.Rating;//vo osnova verojatnosta daden igrac da dade gol e proporcionalna
                                  // na negoviot rejting
            switch (Position.Id)
            {
                case 1:
                    Tokens *= 3;//Napagacot da ima najgolemi shansi za gol
                    break;
                case 2:
                    Tokens *= 2;
                    break;
                case 3:
                    Tokens *= 1;
                    break;
                case 4:
                    Tokens /= 1000;//Postoi moznost i golman da dade gol, no taa e premnogu mala
                    break;
            }


        }
    }
}
