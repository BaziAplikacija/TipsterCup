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
        FormStandings frmStandings;
        FormRounds frmRounds;
        FormAllTipsters frmAllTipsters;
        FormStatistics frmStatistics;

        public static Boolean betweenRounds;
        public static Round currentRound;
        int seconds;
        int dayInRound;
        int currentDay;
        
        
        public FormMain()
        {
            InitializeComponent();
            frmStandings = null;
            frmRounds = null;
            frmAllTipsters = null;
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
            FormTipster frmMyProfile = new FormTipster(FormLogin.IdLoggedTipster);
            frmMyProfile.Show();
        }

        private void btnTipsters_Click(object sender, EventArgs e)
        {
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
            int seconds = this.seconds;
            if (betweenRounds)
            {
                String text = "Time until next round:   ";
                int hours = seconds / 60 / 60;
                /*if(hours > 0){
                    text += hours + " : ";
                }*/
                seconds -= hours * 60 * 60;
                int minutes = seconds / 60;
                /*if(minutes > 0){
                    text += minutes + " : ";
                }*/
                seconds -= minutes * 60;
                text  += String.Format("{0:00} : {1:00} : {2:00}",hours, minutes, seconds);
                lblNextRound.Text = text;
                if (this.seconds < 10)
                {
                    lblNextRound.ForeColor = Color.Red;
                }
                else
                {
                    lblNextRound.ForeColor = Color.Black;
                }
            }
            else
            {
                if (currentDay != dayInRound - (int)(currentRound.DateTo - FormLogin.virtualDate).TotalDays)
                {
                    currentDay = dayInRound - (int)(currentRound.DateTo - FormLogin.virtualDate).TotalDays;
                    seconds = FormLogin.timeInterval * 60;

                }
                lblNextRound.ForeColor = Color.Black;
                lblNextRound.Text = "Round " + currentRound.Id +" Day "+currentDay;
            }
            lblNextRound.TextAlign = ContentAlignment.BottomCenter;
            lblNextRound.Location = new Point(this.Width - 20 - lblNextRound.Width, lblNextRound.Location.Y);
        }


        private void setRound()
        {
            int round = 0;
            //lastRound = 0;
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

                }
                if (round == 0)
                {
                    query = "SELECT * FROM Round WHERE dateFrom > (TO_DATE('" + FormLogin.virtualDate.Month + "/" + FormLogin.virtualDate.Day + "/" + FormLogin.virtualDate.Year
                    + "', 'mm/dd/yyyy')) ORDER BY idround";
                    command = new OracleCommand(query, connection);
                    reader = command.ExecuteReader();
                    DateTime from = DateTime.Now;
                    DateTime to =DateTime.Now;
                    while (reader.Read())
                    {

                        round = reader.GetInt32(0);
                        from = reader.GetDateTime(1);
                        to = reader.GetDateTime(2);
                        break;
                    }
                    
                    betweenRounds = true;
                    currentRound = new Round(round, from, to);
                    round++;
                    //lastRound = round;
                }
                else
                {
                    MessageBox.Show("vo round");
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds--;
            if (seconds == 0 && currentDay != dayInRound)
            {
                betweenRounds = false;
                initLabel();
                currentDay += 1;
                seconds = FormLogin.timeInterval * 60;
                //btnRounds_Click(null, null);
            }
            else if (seconds == 0 && currentDay == dayInRound)
            {
                timer1.Stop();
                initializeCountdown();
                //btnRounds_Click(null, null);
                return;
            }
            initLabel();
            initLblDate();
        }

        private void initializeCountdown()
        {
            setRound();

            double difference = 0;
            seconds = 0;
            dayInRound = (int)(currentRound.DateTo - currentRound.DateFrom).TotalDays + 1;
            currentDay = 0;

            if (betweenRounds)
            {
                difference = (currentRound.DateFrom - FormLogin.virtualDate).TotalDays;
            }
            else
            {
                currentDay = dayInRound - (int)(currentRound.DateTo - FormLogin.virtualDate).TotalDays;
            }


            seconds = (int)difference * FormLogin.timeInterval * 60;
            
            initLabel();
            timer1.Start();
        }

        
    }
}
