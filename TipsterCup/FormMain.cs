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
        
        MainDoc docMain;
        public FormMain()
        {
            InitializeComponent();
            
            docMain = new MainDoc();

            
            fillGrid();
            fillMainDoc();
            //GenerateGoalsForMatch ggm = new GenerateGoalsForMatch(docMain, docMain.getMatchById(31), connection);

        }

        private void fillMainDoc()
        {

            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();
                OracleCommand command;
                OracleDataReader reader;

           
            String query = "SELECT * FROM Manager";
            command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            reader = command.ExecuteReader();

            while (reader.Read())
            {

              
                int id = reader.GetInt32(0);
                String firstName = (String)reader[1];
                String lastName = (String)reader[2];
                DateTime dateOfBirth = (DateTime)reader[3];



                double experience = Convert.ToDouble(reader[4]);
                docMain.addManager(id, firstName, lastName, dateOfBirth, experience);
            }

           
            query = "SELECT * FROM Team";
            command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                //IDTEAM	NAME	CITY	RATING	IDMANAGER	STADIUM PICTUREPATH

                int id = Convert.ToInt32(reader[0]);
                String name = Convert.ToString(reader[1]);
                String city = Convert.ToString(reader[2]);
                double rating = Convert.ToDouble(reader[3]);
                int idManager = Convert.ToInt32(reader[4]);
                String stadium = Convert.ToString(reader[5]);
                String picturePath = Convert.ToString(reader[6]);

                docMain.addTeam(id, name, city, rating, docMain.getManagerById(idManager), stadium, picturePath);


            }

            query = "SELECT * FROM Position";
            command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader[0]);
                String name = Convert.ToString(reader[1]);
                double factorGoal = Convert.ToDouble(reader[2]);
                double factorAssist = Convert.ToDouble(reader[3]);
                double factorInterrupt = Convert.ToDouble(reader[4]);
                double factorSave = Convert.ToDouble(reader[5]);

                docMain.addPosition(id, name, factorGoal, factorAssist, factorInterrupt, factorSave);

            }

            query = "SELECT * FROM Player";
            command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            reader = command.ExecuteReader();
            //IDPLAYER	NAME	SURNAME	DATEOFBIRTH	RATING	IDTEAM	IDPOSITION
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader[0]);
                String firstName = Convert.ToString(reader[1]);
                String lastName = Convert.ToString(reader[2]);
                DateTime dateOfBirth = Convert.ToDateTime(reader[3]);
                double rating = Convert.ToDouble(reader[4]);
                int idTeam = Convert.ToInt32(reader[5]);
                int idPosition = Convert.ToInt32(reader[6]);

                

                docMain.addPlayer(id, firstName, lastName, dateOfBirth, rating, idTeam, idPosition);

            }


            query = "SELECT * FROM Round";
            command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            reader = command.ExecuteReader();
            //IDROUND DATEFROM DATETO
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader[0]);
                DateTime dateFrom = Convert.ToDateTime(reader[1]);
                DateTime dateTo = Convert.ToDateTime(reader[2]);

                docMain.addRound(id, dateFrom, dateTo);
            }

            query = "SELECT * FROM Match";
            command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            reader = command.ExecuteReader();
            //IDMATCH	DATEMATCH	IDROUND	IDGUESTTEAM	IDHOMETEAM
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader[0]);
                DateTime dateMatch = Convert.ToDateTime(reader[1]);
                int idRound = Convert.ToInt32(reader[2]);
                int idGuestTeam = Convert.ToInt32(reader[3]);
                int idHomeTeam = Convert.ToInt32(reader[4]);

                docMain.addMatch(id, dateMatch, idRound, idGuestTeam, idHomeTeam);
            }

            query = "SELECT * FROM Goal";
            command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            reader = command.ExecuteReader();
            //IDGOAL	MINUTES	IDMATCH	IDPLAYER
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader[0]);
                int minutes = Convert.ToInt32(reader[1]);
                int idMatch = Convert.ToInt32(reader[2]);
                int idPlayer = Convert.ToInt32(reader[3]);


                docMain.addGoal(id, minutes, idMatch, idPlayer);
            }
            }
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
                
                FormTeam frmTeam = new FormTeam(docMain.getTeamByName(teamName),docMain);
                frmTeam.Show();
            }
        }

        private void btnRounds_Click(object sender, EventArgs e)
        {
            FormRounds frmRounds = new FormRounds(docMain);
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
    }
}
