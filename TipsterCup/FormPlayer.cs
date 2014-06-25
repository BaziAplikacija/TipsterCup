using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            changeChartView();
            Player = player;

            lblFirstName.Text = player.FirstName;
            lblLastName.Text = player.LastName;
            lblPosition.Text = player.Position.Description;
            lblRating.Text = player.Rating.ToString();
            lblTeam.Text = Player.Team.Name;
        }

        public void changeChartView()
        {
            
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();
                String query = "SELECT m.idround as round, p.Match_Rating FROM participates p JOIN match m ON(p.idMatch = m.idMatch) WHERE p.idPlayer = 122 ORDER BY m.idRound";
                DataTable table = new DataTable();
                OracleDataAdapter dataAdapter = new OracleDataAdapter(query, connection);
                dataAdapter.Fill(table);
                chartPlayerRating.DataSource = table;
                chartPlayerRating.Series["Series1"].XValueMember = "Round";
                chartPlayerRating.Series["Series1"].YValueMembers = "Match_Rating";
                

            }

            chartPlayerRating.ChartAreas["ChartArea1"].AxisX.Title = "Rounds";
            chartPlayerRating.ChartAreas["ChartArea1"].AxisX.Minimum = 1;
            chartPlayerRating.ChartAreas["ChartArea1"].AxisX.Maximum = 38;
            chartPlayerRating.ChartAreas["ChartArea1"].AxisX.Interval = 1;


            chartPlayerRating.ChartAreas["ChartArea1"].AxisY.Title = "Rankings";
            chartPlayerRating.ChartAreas["ChartArea1"].AxisY.Minimum = 1000;
            chartPlayerRating.ChartAreas["ChartArea1"].AxisY.Maximum = 3000;
            

        }

        
    }
}
