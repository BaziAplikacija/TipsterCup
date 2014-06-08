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
    public partial class FormTeam : Form
    {
        MainDoc docMain;
        Team Team { get; set; }
        List<Player> players;
        public FormTeam(Team team, MainDoc doc)
        {
            InitializeComponent();
            Team = team;
            docMain = doc;

           

            players = docMain.getPlayersFromTeam(Team.Name);


            fillFields();
            
        }

        private void fillFields()
        {
            lblName.Text = Team.Name;
            lblCity.Text = Team.City;
            lblStadium.Text = Team.Stadium;

            foreach (Player player in players)
            {
                gridPlayers.Rows.Add(player.Id,player.FirstName, player.LastName, player.Position.Description);


            }

            pbTeam.Image = Team.Picture;
        }

        private void gridPlayers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if(e.RowIndex >= 0) 
            {
                Player player = docMain.getPlayerById(Convert.ToInt32(gridPlayers.Rows[e.RowIndex].Cells[0].Value));

                FormPlayer frmPlayer = new FormPlayer(player);
                frmPlayer.Show();
            }
           
        }

       
    }
}
