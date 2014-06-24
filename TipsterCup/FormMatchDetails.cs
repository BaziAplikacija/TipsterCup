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
            match = m;
            init();
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
        }
    }
}
