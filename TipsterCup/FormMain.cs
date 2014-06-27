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
using Oracle.DataAccess.Client;

namespace TipsterCup
{
    public partial class FormMain : Form
    {
        FormStandings frmStandings;
        FormRounds frmRounds;
        FormAllTipsters frmAllTipsters;
        FormStatistics frmStatistics;
        FormTipster frmMyProfile;
        FormAllPlayers frmAllPlayers;

        public static Boolean betweenRounds;
        public static Round currentRound;
        int seconds;
        public static Boolean finished;
        
        
        public FormMain()
        {
            InitializeComponent();
            frmStandings = null;
            frmRounds = null;
            frmAllTipsters = null;
            frmStatistics = null;
            frmMyProfile = null;
            frmAllPlayers = null;
            pbMusic.Location = new Point(this.Width - 2 * pbMusic.Width, pbMusic.Location.Y);
            if (!FormLogin.musicOn)
            {
                pbMusic.Image = Image.FromFile("imgMusicOff.png");
            }
        }



        public void InvalidateChildren()
        {

            foreach (Form frm in this.MdiChildren) 
            {
                frm.Invalidate();
            }
        }

        private void btnRounds_Click(object sender, EventArgs e)
        {

            if (frmRounds != null)
            {
                frmRounds.Close();
            }
            frmRounds = new FormRounds(FormLogin.docMain);
            frmRounds.MdiParent = this;
            frmRounds.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            if (frmStatistics != null)
            {
                frmStatistics.Close();
            }
            frmStatistics = new FormStatistics();
            frmStatistics.MdiParent = this;
            frmStatistics.Show();
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            if(frmMyProfile != null) {
                 frmMyProfile.Close();
            }
            frmMyProfile =   new FormTipster(FormLogin.IdLoggedTipster);
            frmMyProfile.MdiParent = this;
            
            frmMyProfile.Show();
        }

        private void btnTipsters_Click(object sender, EventArgs e)
        {

            if(frmAllTipsters != null) {
                frmAllTipsters.Close();
            }
            frmAllTipsters = new FormAllTipsters();
            frmAllTipsters.MdiParent = this;
           
            frmAllTipsters.Show();
        }

        private void btnStandings_Click(object sender, EventArgs e)
        {
            if (frmStandings != null)
            {
                frmStandings.Close();
            }
            frmStandings = new FormStandings();
            frmStandings.MdiParent = this;
            frmStandings.Show();
        }





        private void FormMain_Load(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;
            btnStandings_Click(null, null);
            initLblDate();
            initializeCountdown();
        }


        private void initLblDate(){
             lblDate.Text = "Date: " + FormLogin.virtualDate.ToShortDateString();
        }



        private void initLabel()
        {
            String text = "";
            lblNextRound.ForeColor = Color.Black;
            if (finished)
            {
                text = "Season finished";
            }
            else
            {
                if (betweenRounds)
                {
                    int seconds = this.seconds;
                    int hours = seconds / 60 / 60;
                    seconds -= hours * 3600;
                    int minutes = seconds / 60;
                    seconds -= minutes * 60;
                    text = "Time until round "+currentRound.Id+":   ";
                    text += String.Format("{1:00} : {2:00} : {3:00}", currentRound.Id, hours, minutes, seconds);
                    if (this.seconds < 10)
                    {
                        lblNextRound.ForeColor = Color.Red;
                    }
                }
                else
                {
                    text = "Round " + currentRound.Id + " is playing";
                }
            }
            lblNextRound.Text = text;
            lblNextRound.TextAlign = ContentAlignment.BottomRight;
            lblNextRound.Location = new Point(this.Width - lblNextRound.Width - 20, lblNextRound.Location.Y);
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (seconds > 0)
            {
                seconds--;
            }
            else
            {
                if (betweenRounds)
                {
                    betweenRounds = false;
                }
                else
                {
                    if (FormLogin.virtualDate.CompareTo(currentRound.DateTo) > 0)
                    {
                        timer1.Stop();

                        /* se nagraduvaat tipsterite koi pogodile 
                         */
                        using (OracleConnection conn = new OracleConnection(FormLogin.connString))
                        {
                            conn.Open();

                            string query = "select * from computegain where idRound = " + currentRound.Id;
                            OracleCommand command = new OracleCommand(query, conn);
                            command.CommandType = CommandType.Text;

                            OracleDataReader reader = command.ExecuteReader();
                            
                            while (reader.Read())
                            {
                                ComputeGain gain = new ComputeGain(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), Double.Parse(reader[4].ToString()), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetString(9));

                                if (gain.IsWinning())
                                {
                                    string up = "update tipster set money = money + " + (int)gain.GetGain() + " WHERE idTipster = " + gain.IdTipster;
                                    OracleCommand comm2 = new OracleCommand(up,conn);
                                    comm2.CommandType = CommandType.Text;
                                    comm2.ExecuteNonQuery();
                                        
                                }
                            }
                            query = "update tips set validated = 'y' where idTips IN (select idTips from computegain where idRound = " + currentRound.Id + " )";
                            command = new OracleCommand(query, conn);
                            command.CommandType = CommandType.Text;
                            command.ExecuteNonQuery();

                            reader.Close();

                           
                        }



                        initializeCountdown();
                        return;
                    }
                }
                if (frmRounds != null)
                {
                    frmRounds.cbRounds_SelectedIndexChanged(null, null);
                }
            }
            initLabel();
            initLblDate();
        }

        private void initializeCountdown()
        {
            setRound();

            
            if(!finished)
            {
                if (betweenRounds)
                {
                    seconds = (int)Math.Floor((currentRound.DateFrom - FormLogin.virtualDate).TotalDays - 1)*FormLogin.timeInterval*60 + FormLogin.secondsRemaining;
                }
                
            }
            initLabel();
            timer1.Start();
        }


        private void setRound()
        {


            int round = 0;
            finished = true;

            bool generateCoeff = true;
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();

                String query = "SELECT * FROM Round WHERE dateFrom <= (TO_DATE('" + FormLogin.virtualDate.Month + "/" + FormLogin.virtualDate.Day + "/" + FormLogin.virtualDate.Year
                    + "', 'mm/dd/yyyy')) AND dateTo >= (TO_DATE('" + FormLogin.virtualDate.Month + "/" + FormLogin.virtualDate.Day + "/" + FormLogin.virtualDate.Year + "', 'mm/dd/yyyy'))";
                OracleCommand command = new OracleCommand(query, connection);
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    currentRound = new Round(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2));
                    round = currentRound.Id;
                    betweenRounds = false;
                    finished = false;

                }
                if (round == 0)
                {
                    query = "SELECT * FROM Round WHERE dateFrom > (TO_DATE('" + FormLogin.virtualDate.Month + "/" + FormLogin.virtualDate.Day + "/" + FormLogin.virtualDate.Year
                    + "', 'mm/dd/yyyy')) ORDER BY idround";
                    command = new OracleCommand(query, connection);
                    reader = command.ExecuteReader();
                    DateTime from = DateTime.Now;
                    DateTime to = DateTime.Now;
                    while (reader.Read())
                    {

                        round = reader.GetInt32(0);
                        from = reader.GetDateTime(1);
                        to = reader.GetDateTime(2);
                        finished = false;
                        break;
                    }
                    

                    betweenRounds = true;
                    currentRound = new Round(round, from, to);
                    
                }
                reader.Close();

                query = "SELECT COUNT(*) FROM CoeffGenerated WHERE idRound = " + currentRound.Id;

                command = new OracleCommand(query, connection);
                command.CommandType = CommandType.Text;

                int numGenerated = Int32.Parse(command.ExecuteScalar().ToString());

               // MessageBox.Show("Num generated: " + numGenerated + " Current round: " + currentRound.Id);
                if (numGenerated >= 70)
                {
                    generateCoeff = false;
                }

            }

            new CoefficientProvider();

            if(generateCoeff)
            CoefficientProvider.fillShowCoeffRound(currentRound.Id);
        }

        private void btnPlayers_Click(object sender, EventArgs e)
        {
            if (frmAllPlayers != null)
            {
                frmAllPlayers.Close();
            }

            frmAllPlayers = new FormAllPlayers();
            frmAllPlayers.MdiParent = this;
            frmAllPlayers.Show();
        }

        private void pbMusic_Click(object sender, EventArgs e)
        {
            if (FormLogin.musicOn)
            {
                pbMusic.Image = Image.FromFile("imgMusicOff.png");
                FormLogin.player.settings.mute = true;
            }
            else
            {
                pbMusic.Image = Image.FromFile("imgMusicOn.png");
                FormLogin.player.settings.mute = false;
            }
            FormLogin.musicOn = !FormLogin.musicOn;
        }

        
    }
}
