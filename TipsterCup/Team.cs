using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Oracle.DataAccess.Client;

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

        public Team(int id, String name, String city, double rating, int idManager, String stadium, String picturePath)
        {
            Id = id;
            Name = name;
            City = city;
            Rating = rating;
            Stadium = stadium;
            PicturePath = picturePath;
            Picture = Image.FromFile(PicturePath);
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();
                String queryManager = "SELECT * FROM Manager WHERE idManager = " + idManager;
                OracleCommand command = new OracleCommand(queryManager, connection);
                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                Manager = new Manager(idManager, reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetInt32(4));
            }
            
        }
    }
}
