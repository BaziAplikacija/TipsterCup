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
            changeChartView();
            
        }


        private void changeChartView()
        {
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();
                String query = "SELECT m.idRound AS ROUND, ROUND(SUM(part.match_Rating)/COUNT(part.match_Rating)) AS TEAMRATING"
                    + " FROM participates part JOIN player p ON (part.idPlayer = p.idPlayer) JOIN match m ON (part.idMatch = m.idMatch)"
                    + " WHERE p.idTeam = " + Team.Id
                    + " GROUP BY m.idRound"
                    + " ORDER BY m.idRound";
                OracleDataAdapter adapter = new OracleDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                chartTeamRating.DataSource = table;
                chartTeamRating.Series["Series1"].XValueMember = "Round";
                chartTeamRating.Series["Series1"].YValueMembers = "TeamRating";
            }

            chartTeamRating.ChartAreas["ChartArea1"].AxisX.Title = "Rounds";
            chartTeamRating.ChartAreas["ChartArea1"].AxisY.Title = "Rating";
            chartTeamRating.ChartAreas["ChartArea1"].AxisX.Minimum = 1;
            chartTeamRating.ChartAreas["ChartArea1"].AxisX.Maximum = 38;
            chartTeamRating.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chartTeamRating.ChartAreas["ChartArea1"].AxisY.Minimum = 1000;
            chartTeamRating.ChartAreas["ChartArea1"].AxisY.Maximum = 3000;
            



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
