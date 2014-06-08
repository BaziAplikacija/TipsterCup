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
    public partial class FormPlayer : Form
    {
        Player Player;
        public FormPlayer(Player player)
        {
            InitializeComponent();
            Player = player;

            lblFirstName.Text = player.FirstName;
            lblLastName.Text = player.LastName;
            lblPosition.Text = player.Position.Description;
            lblRating.Text = player.Rating.ToString();
            lblTeam.Text = Player.Team.Name;
        }
    }
}
