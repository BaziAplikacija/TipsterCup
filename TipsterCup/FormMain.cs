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
    public partial class FormMain : Form
    {
        
        public FormMain()
        {
            InitializeComponent();
            
            
            
            fillGrid();
            //GenerateGoalsForMatch ggm = new GenerateGoalsForMatch(docMain, docMain.getMatchById(31), connection);

        }

        

        private void fillGrid()
        {
            String query = "SELECT * FROM Standings";
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open(); // NE SMEE DA SE ZABORAVI!
                OracleCommand command = new OracleCommand(query, connection);

                command.CommandType = CommandType.Text;

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    gridStandings.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
                }

            }
            
            
            

           
        }

        private void gridStandings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                String teamName = Convert.ToString(gridStandings.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                
                FormTeam frmTeam = new FormTeam(FormLogin.docMain.getTeamByName(teamName),FormLogin.docMain);
                frmTeam.Show();
            }
        }

        private void btnRounds_Click(object sender, EventArgs e)
        {
            FormRounds frmRounds = new FormRounds(FormLogin.docMain);
            frmRounds.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // !!!!PROBLEM E KOGA NAGLO KJE SNEMA KONEKCIJA a ostanuva tipster logiran!!!!
            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();

                string query = "UPDATE TIPSTER SET loggedin = 'n' WHERE idTipster = " + FormLogin.IdLoggedTipster;

                OracleCommand command = new OracleCommand(query, conn);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            Application.Exit();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            FormTipster frmMyProfile = new FormTipster(FormLogin.IdLoggedTipster);
            frmMyProfile.Show();
        }

        private void btnTipsters_Click(object sender, EventArgs e)
        {
            FormAllTipsters frmAllTipsters = new FormAllTipsters();
            frmAllTipsters.Show();
        }
    }
}
