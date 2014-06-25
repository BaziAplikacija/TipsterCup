using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace TipsterCup
{
    public partial class FormStatistics : Form
    {
        public FormStatistics()
        {
            InitializeComponent();
        }

        private void btnLastPerformance_Click(object sender, EventArgs e)
        {
            Button thisButton = sender as Button;
           
            

            

            if (gridLastPerformance.Visible)
            {
                gridLastPerformance.Visible = false;
                lblLastPerformance.Visible = false;

                thisButton.BackColor = SystemColors.Control;
                return;
            }

            thisButton.BackColor = Color.RoyalBlue;

            gridLastPerformance.Rows.Clear();
            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();

                OracleCommand command = new OracleCommand("select * from form", conn);
                command.CommandType = CommandType.Text;

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    gridLastPerformance.Rows.Add(reader.GetString(0), reader.GetString(1));
                }
                reader.Close();
            }
            gridLastPerformance.Visible = true;
            lblLastPerformance.Visible = true;
        }

        private void btnTopscorer_Click(object sender, EventArgs e)
        {
            Button thisButton = sender as Button;
          
            

            if (gridTopscorers.Visible)
            {
                gridTopscorers.Visible = false;
                lblTopScorers.Visible = false;
                thisButton.BackColor = SystemColors.Control;
                return;
            }
            thisButton.BackColor = Color.RoyalBlue;
            gridTopscorers.Rows.Clear();
            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();

                OracleCommand command = new OracleCommand("select * from topscorers", conn);
                command.CommandType = CommandType.Text;

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    gridTopscorers.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
                }
                reader.Close();
            }
            gridTopscorers.Visible = true;
            lblTopScorers.Visible = true;
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            lblLastPerformance.Text = "The last performance of the team.\nThe  rightmost letter\n stands for the result in the last round.";
            lblTopScorers.Text = "Lists the topscorers.";
            lblDreamTeam.Text = "Shows the dream team.";
            lblAverageAge.Text = "Shows the teams and their players average age.";
            lblHatTrick.Text = "Shows all players who managed to\n score 3 (or more) goals in some match.";
            lblTeamGoals.Text = "Shows each team with the number of goals scored\nand the number of goals received.\n F stands for FOR(scored)\n A stands for against (received)";
        }

        private void btnDreamTeam_Click(object sender, EventArgs e)
        {
            Button thisButton = sender as Button;
            
            if (gridDreamTeam.Visible)
            {
                gridDreamTeam.Visible = false;
                lblDreamTeam.Visible = false;
                thisButton.BackColor = SystemColors.Control;
                return;
            }
            thisButton.BackColor = Color.RoyalBlue;
            gridDreamTeam.Rows.Clear();

            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();

                OracleCommand command = new OracleCommand("select * from dreamteam", conn);
                command.CommandType = CommandType.Text;

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    gridDreamTeam.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2),reader.GetInt32(3));
                }
                reader.Close();
            }
            gridDreamTeam.Visible = true;
            lblDreamTeam.Visible = true;
        }

        private void btnAverageAge_Click(object sender, EventArgs e)
        {

            Button thisButton = sender as Button;
           
            if (gridAverageAge.Visible)
            {
                gridAverageAge.Visible = false;
                lblAverageAge.Visible = false;
                thisButton.BackColor = SystemColors.Control;
                return;
            }
            thisButton.BackColor = Color.RoyalBlue;
            gridAverageAge.Rows.Clear();

            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();

                OracleCommand command = new OracleCommand("select * from teamsaverageage", conn);
                command.CommandType = CommandType.Text;

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    gridAverageAge.Rows.Add(reader.GetString(0), reader.GetInt32(1));
                }
                reader.Close();
            }
            gridAverageAge.Visible = true;
            lblAverageAge.Visible = true;
        }

        private void btnHatTrick_Click(object sender, EventArgs e)
        {

            Button thisButton = sender as Button;
            
            if (gridHatTrick.Visible)
            {
                gridHatTrick.Visible = false;
                lblHatTrick.Visible = false;

                thisButton.BackColor = SystemColors.Control;
                return;
            }
            thisButton.BackColor = Color.RoyalBlue;
            gridHatTrick.Rows.Clear();

            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();

                OracleCommand command = new OracleCommand("select * from hattrick", conn);
                command.CommandType = CommandType.Text;

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    gridHatTrick.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5));
                }
                reader.Close();
            }
            gridHatTrick.Visible = true;
            lblHatTrick.Visible = true;
        }

        private void btnTeamGoals_Click(object sender, EventArgs e)
        {
            Button thisButton = sender as Button;
            
            if (gridTeamGoals.Visible)
            {
                gridTeamGoals.Visible = false;
                lblTeamGoals.Visible = false;
                thisButton.BackColor = SystemColors.Control;
                
                return;
            }
            thisButton.BackColor = Color.RoyalBlue;
            
            
            gridTeamGoals.Rows.Clear();
            

            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();

                OracleCommand command = new OracleCommand("select * from TeamGoals", conn);
                command.CommandType = CommandType.Text;

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    gridTeamGoals.Rows.Add(reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2));
                }
                reader.Close();
            }
            gridTeamGoals.Visible = true;
            lblTeamGoals.Visible = true;
        }

        
    }
}
