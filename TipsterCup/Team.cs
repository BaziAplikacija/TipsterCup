using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TipsterCup
{
    public class Team
    {
        //IDTEAM	NAME	CITY	RATING	IDMANAGER	STADIUM PICTUREPATH

        public int Id { get; set; }
        public String Name { get; set; }
        public String City { get; set; }
        public Double Rating { get; set; }
        public Manager Manager { get; set; }
        public String Stadium { get; set; }
        public String PicturePath { get; set; }
        public Image Picture { get; set; }

        public Team(int id, String name, String city, double rating, Manager manager, String stadium, String picturePath)
        {
            Id = id;
            Name = name;
            City = city;
            Rating = rating;
            Manager = manager;
            Stadium = stadium;
            PicturePath = picturePath;
            Picture = Image.FromFile(PicturePath);
            
        }
    }
}
