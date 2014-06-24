using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipsterCup
{
    public partial class FormMatchDetails : Form
    {
        Match match;

        public FormMatchDetails()
        {
            InitializeComponent();
        }

        public FormMatchDetails(Match m)
        {
            InitializeComponent();
            match = createMatch(m.Id);
            init();
        }

        private Match createMatch(int id)
        {
            DateTime matchDate;
            int matchRound;
            int matchHomeTeam;
            int matchGuestTeam;
            
            using(OracleConnection connection = new OracleConnection(FormLogin.connString)){
                connection.Open();
                String queryGetMatch = "SELECT * FROM Match WHERE idMatch = "+id;
                OracleCommand command = new OracleCommand(queryGetMatch, connection);
                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                id = reader.GetInt32(0);
                matchDate = reader.GetDateTime(1);
                matchRound = reader.GetInt32(2);
                matchGuestTeam = reader.GetInt32(3);
                matchHomeTeam = reader.GetInt32(4);
            }
            Match m = new Match(id, matchHomeTeam, matchGuestTeam, matchRound, matchDate);
            return m;

        }

        private void init()
        {
            lblHomeTeam.Text = match.HomeTeam.Name;
            lblGuestTeam.Text = match.GuestTeam.Name;
            String result = "-";
            if (match.DateMatch.CompareTo(FormLogin.virtualDate) < 0)
            {
                result = match.GoalsHome.Count + " - " + match.GoalsGuest.Count;
            }
            lblResult.Text = result;
            
            pbHomeTeam.Image = match.HomeTeam.Picture;
            pbGuestTeam.Image = match.GuestTeam.Picture;
            
            lblDateInit.Text = match.DateMatch.ToShortDateString();
            lblRoundInit.Text = String.Format("{0}", match.Round.Id);
            lblVenueInit.Text = match.HomeTeam.Stadium;
            lblCityInit.Text = match.HomeTeam.City;

            lblHomeTeam.Location = new Point(pbHomeTeam.Location.X + (pbHomeTeam.Width - lblHomeTeam.Width) / 2, lblHomeTeam.Location.Y);
            lblGuestTeam.Location = new Point(pbGuestTeam.Location.X + (pbGuestTeam.Width - lblGuestTeam.Width) / 2, lblGuestTeam.Location.Y);
            

            int i = 0, j = 0;
            while(i<match.GoalsHome.Count && j<match.GoalsGuest.Count)
            {
                if (match.GoalsHome[i].Minutes < match.GoalsGuest[j].Minutes)
                {
                    listHome.Items.Add(match.GoalsHome[i]);
                    i++;
                    listGuest.Items.Add("");
                }
                else if (match.GoalsHome[i].Minutes == match.GoalsGuest[j].Minutes)
                {
                    listHome.Items.Add(match.GoalsHome[i]);
                    i++;
                    listGuest.Items.Add(match.GoalsGuest[j]);
                    j++;
                }
                else
                {
                    listHome.Items.Add("");
                    listGuest.Items.Add(match.GoalsGuest[j]);
                    j++;
                }
                
            }
            while (i < match.GoalsHome.Count)
            {
                listHome.Items.Add(match.GoalsHome[i]);
                i++;
                listGuest.Items.Add("");
            }
            while (j < match.GoalsGuest.Count)
            {
                listHome.Items.Add("");
                listGuest.Items.Add(match.GoalsGuest[j]);
                j++;
            }
        }
    }
}
