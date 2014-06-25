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

            initializeCountdown();
        }


        private void initLabel()
        {
            int seconds = this.seconds;
            if (betweenRounds)
            {
                String text = "";
                int hours = seconds / 60 / 60;
                if(hours > 0){
                    text += hours + "h ";
                }
                seconds -= hours * 60 * 60;
                int minutes = seconds / 60;
                if(minutes > 0){
                    text += minutes + "m ";
                }
                seconds -= minutes * 60;
                text += seconds + "s";
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
            lblNextRound.Location = new Point(this.Width / 2 - lblNextRound.Width / 2, this.Height - 4*lblNextRound.Height);
            lblNextRound.TextAlign = ContentAlignment.BottomCenter;
        }


        private void setRound()
        {
            int round = 0;
            //lastRound = 0;
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();

                String query = "SELECT * FROM Round WHERE dateFrom < (TO_DATE('" + FormLogin.virtualDate.Month + "/" + FormLogin.virtualDate.Day + "/" + FormLogin.virtualDate.Year
                    + "', 'mm/dd/yyyy')) AND dateTo > (TO_DATE('" + FormLogin.virtualDate.Month + "/" + FormLogin.virtualDate.Day + "/" + FormLogin.virtualDate.Year + "', 'mm/dd/yyyy'))";
                OracleCommand command = new OracleCommand(query, connection);
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    currentRound = new Round(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2));
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
            }
            else if (seconds == 0 && currentDay == dayInRound)
            {
                timer1.Stop();
                initializeCountdown();
                return;
            }
            initLabel();
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
