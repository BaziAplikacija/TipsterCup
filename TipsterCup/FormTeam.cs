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
        
        List<Label> labels;
        private int originalWidth;
        Boolean originalSize;
        List<int> idMatches;
        List<String> homeTeams;
        List<String> results;
        List<String> guestTeams;


        public FormTeam(Team team, MainDoc doc)
        {
            InitializeComponent();
            Team = team;
            docMain = doc;

            labels = new List<Label>();
            idMatches = new List<int>();
            homeTeams = new List<String>();
            results = new List<String>();
            guestTeams = new List<String>();
           

            players = docMain.getPlayersFromTeam(Team.Name);
            
            originalWidth = this.Width;
            originalSize = false;
            this.Width = originalWidth - 400;
            tableResults.Visible = false;

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
            chartTeamRating.ChartAreas["ChartArea1"].Visible = true;
            chartTeamRating.Series["Series1"].BorderWidth = 3;



        }

        private void fillFields()
        {
            lblName.Text = Team.Name;
            lblCity.Text = Team.City;
            lblStadium.Text = Team.Stadium;
            lblManager.Text = Team.Manager.FirstName+" "+Team.Manager.LastName;

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



        private void btnTeamHistory_Click(object sender, EventArgs e)
        {
            if (originalSize)
            {
                this.Width -= 400;
                tableResults.Visible = false;
                
            }
            else
            {
                this.Width = originalWidth;
                tableResults.Visible = true;
            }
            originalSize = !originalSize;
            
        }



        private void showHistoryResults()
        {
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();
                String query = "SELECT m.idMatch, homeTeam, goalshome || ' - ' || goalsguest as result, guestteam "
                    + "FROM Results r JOIN Match m ON (r.idMatch = m.idMatch) WHERE (HOMETEAMID = "+Team.Id+" OR GUESTTEAMID = "+Team.Id+") ORDER BY m.datematch";
                OracleCommand command = new OracleCommand(query, connection);
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    idMatches.Add(reader.GetInt32(0));
                    homeTeams.Add(reader.GetString(1));
                    results.Add(reader.GetString(2));
                    guestTeams.Add(reader.GetString(3));
                }
            }

            tableResults.Controls.Clear();
            tableResults.RowStyles.Clear();

            tableResults.RowCount = idMatches.Count+1;
            
            for (int i = 0; i < tableResults.ColumnCount; i++){
                for (int j = 0; j < tableResults.RowCount; ++j)
                {
                    if (i == 0)
                    {
                        tableResults.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }
                }
            }


            setControls();
            setLabels();
        }


        private void setLabels()
        {
            labels[0].Text = "Home Team";
            labels[1].Text = "Result";
            labels[2].Text = "Guest Team";
            labels[0].Font = new Font(labels[0].Font.FontFamily, 12);
            labels[1].Font = new Font(labels[0].Font.FontFamily, 12);
            labels[2].Font = new Font(labels[0].Font.FontFamily, 12);


            for (int i = 0; i < idMatches.Count; i++)
            {
                if (homeTeams[i].Equals(Team.Name))
                {
                    labels[(i+1) * 3].ForeColor = Color.Red;
                }
                if (guestTeams[i].Equals(Team.Name))
                {
                    labels[(i+1) * 3 + 2].ForeColor = Color.Red;
                }
                labels[(i+1) * 3].Text = homeTeams[i];
                labels[(i+1) * 3 + 1].Text = results[i];
                labels[(i+1) * 3 + 2].Text = guestTeams[i];
            }
        }


        private void setControls()
        {
            tableResults.Controls.Clear();
            for (int i = 0; i <= tableResults.RowCount; ++i)
            {
                Label labelResult = new Label();
                Label labelHome = new Label();
                Label labelGuest = new Label();
                
                labelResult.Dock = DockStyle.Fill;
                labelResult.TextAlign = ContentAlignment.BottomCenter;
                labelResult.Click += new EventHandler(labelResult_Click);

                labelHome.Dock = DockStyle.Fill;
                labelHome.TextAlign = ContentAlignment.BottomRight;
                labelHome.Click += new EventHandler(labelTeam_Click);

                labelGuest.Dock = DockStyle.Fill;
                labelGuest.TextAlign = ContentAlignment.BottomLeft;
                labelGuest.Click += new EventHandler(labelTeam_Click);

                
                tableResults.Controls.Add(labelHome, 0, i);
                tableResults.Controls.Add(labelResult, 1, i);
                tableResults.Controls.Add(labelGuest, 2, i);
                
                labels.Add(labelHome);
                labels.Add(labelResult);
                labels.Add(labelGuest);

                
            }
        }


        private void labelResult_Click(object sender, EventArgs e)
        {
            int row = tableResults.GetRow(sender as Control);
            //FormMatchDetails frm = new FormMatchDetails(matchesInRound[row]);
            //frm.Show();
        }



        private void labelTeam_Click(object sender, EventArgs e)
        {
            int row = tableResults.GetRow(sender as Control);
            int column = tableResults.GetColumn(sender as Control);
            /*if (column == 1)
            {
                FormTeam frmTeam = new FormTeam(matchesInRound[row].HomeTeam, docMain);
                frmTeam.Show();
            }
            if (column == 3)
            {
                FormTeam frmTeam = new FormTeam(matchesInRound[row].GuestTeam, docMain);
                frmTeam.Show();
            }*/
        }

        private void FormTeam_Load(object sender, EventArgs e)
        {
            FormLogin.player.currentMedia = FormLogin.playlistTeams.get_Item(Team.Id-1);
            this.Controls.Add(tableResults);
            tableResults.AutoScroll = true;
            showHistoryResults();
        }

        private void FormTeam_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormLogin.player.currentMedia = FormLogin.playlistMain.get_Item(0);
        }

        private void lblManager_Click(object sender, EventArgs e)
        {
            FormManager frmManager = new FormManager(Team.Manager);
            frmManager.Show();
        }


        private void lblManager_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
