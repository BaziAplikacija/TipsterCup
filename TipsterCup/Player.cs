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

        public Player(int id, String firstName, String lastName, DateTime dateOfBirth, double rating, Team team, Position position) 
            : base(id,firstName,lastName,dateOfBirth)
        {
            Rating = rating;
            Team = team;
            Position = position;
        }
    }
}
