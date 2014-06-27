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
    public partial class FormAdmin : Form
    {

        FormLogin parent;
        private bool closeParent;
        public FormAdmin(FormLogin form)
        {
            InitializeComponent();
            cbTime.SelectedIndex = 0;
            parent = form;
            closeParent = true;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            select_tipsters();
            listTipsters.DrawMode = DrawMode.OwnerDrawVariable;
            listTipsters.DrawItem += new DrawItemEventHandler(listTipsters_DrawItem);


            this.Text = FormLogin.translator["FormRegister " + FormLogin.currLanguage];
           // this.btnBan.Text = FormLogin.translator["BanBtn " + FormLogin.currLanguage];
            this.lblUsername.Text = FormLogin.translator["Username " + FormLogin.currLanguage];
            this.lblPassword.Text = FormLogin.translator["Password " + FormLogin.currLanguage];
            this.lblName.Text = FormLogin.translator["Name " + FormLogin.currLanguage];
            this.lblSurname.Text = FormLogin.translator["Surname " + FormLogin.currLanguage];
            this.lblRating.Text = FormLogin.translator["Rating " + FormLogin.currLanguage];
            this.lblEmail.Text = FormLogin.translator["Email " + FormLogin.currLanguage];
            this.tabControl1.TabPages[1].Text = FormLogin.translator["OptionsTab " + FormLogin.currLanguage];
            this.tabControl1.TabPages[0].Text = FormLogin.translator["TipstersTab " + FormLogin.currLanguage];
            this.gbTimeInterval.Text = FormLogin.translator["VirtualDay " + FormLogin.currLanguage];
            this.lblDay.Text = FormLogin.translator["DayLbl " + FormLogin.currLanguage];
            this.btnChange.Text = FormLogin.translator["ChangeBtn " + FormLogin.currLanguage];
            this.btnBack.Text = FormLogin.translator["BackBtn " + FormLogin.currLanguage];
            this.gbNewSeason.Text = FormLogin.translator["NewSeason " + FormLogin.currLanguage];
            this.btnStart.Text = FormLogin.translator["StartNewSeason " + FormLogin.currLanguage];

            if (!checkSeasonFinished())
            {
                btnStart.Enabled = false;
                label1.Text = FormLogin.translator["SeasonNotFin " + FormLogin.currLanguage];
            }
            else
            {
                btnStart.Enabled = true;
                label1.Text = FormLogin.translator["SeasonFin " + FormLogin.currLanguage];
            }
        }


        private bool checkSeasonFinished(){
            using(OracleConnection connection = new OracleConnection(FormLogin.connString)){
                String query = "SELECT dateTo FROM ROUND WHERE idRound = 38";
                OracleCommand command = new OracleCommand(query, connection);
                command.CommandType = CommandType.Text;
                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                DateTime lastDate = reader.GetDateTime(0);
                 
                if(lastDate.CompareTo(FormLogin.virtualDate) < 0){
                     return true; 
                }
            }
            return false;
        }


        //Vo listBox gi stava tipsterite
        public void select_tipsters()
        {
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open(); // NIKAKO NE SMEE DA SE ZABORAVI! 
                String queryTipsters = "SELECT * FROM Tipster";

                OracleCommand command = new OracleCommand(queryTipsters, connection);
                command.CommandType = CommandType.Text;
                OracleDataReader reader = command.ExecuteReader();
                listTipsters.Items.Clear();
                while (reader.Read())
                {
                    Tipster tipster = new Tipster(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6), reader.GetString(7));
                    listTipsters.Items.Add(tipster);
                }
            }
           
            
            listTipsters.SelectedIndex = 0;
        }

        //Gi menuva podatocite za tipsterot od desnata strana pri promena na selektiraniot indeks
        private void listTipsters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTipsters.SelectedIndex >= 0)
            {
                Tipster tipster = (Tipster)listTipsters.SelectedItem;
                lblUsernameData.Text = tipster.Username;
                lblPasswordData.Text = tipster.Password;
                lblNameData.Text = tipster.Name;
                lblSurnameData.Text = tipster.Surname;
                lblEmailData.Text = tipster.Email;
                lblRatingData.Text = String.Format("{0}", tipster.Money);
                if (tipster.Valid.Equals("n"))
                {
                    btnBan.Text = FormLogin.translator["UnBanBtn " + FormLogin.currLanguage];
                }
                else
                {
                    btnBan.Text = FormLogin.translator["BanBtn " + FormLogin.currLanguage];
                }
            }
        }

        //Metod za baniranje na tipsterite
        private void btnBan_Click(object sender, EventArgs e)
        {
            if (listTipsters.SelectedIndex >= 0)
            {
                Tipster tipster = (Tipster)listTipsters.SelectedItem;
                String valid = "'y'";
                if (tipster.Valid.Equals("y"))
                {
                    valid = "'n'";
                }
                String queryBan = "UPDATE Tipster SET valid = " +valid+ " WHERE idTipster=" + tipster.IdTipster;

                using (OracleConnection connection = new OracleConnection(FormLogin.connString))
                {
                    connection.Open();
                    OracleCommand command = new OracleCommand(queryBan, connection);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                int selectedIndex = listTipsters.SelectedIndex;
                FormAdmin_Load(this, null);
                listTipsters.SelectedIndex = selectedIndex;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to change the time interval?", "Change time interval", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                String selected = (String) cbTime.SelectedItem;
                String time = selected.Substring(0, selected.Length-1);
                string hm = selected.Substring(selected.Length-1);
                int interval = Int32.Parse(time);
                if(hm.Equals("h")){
                    interval *= 60;
                }
                FormLogin.timeInterval = interval;

                String queryUpdateInterval = "UPDATE BasicInfo SET TIME_INTERVAL =" + interval;
               
                using (OracleConnection connection = new OracleConnection(FormLogin.connString))
                {
                    connection.Open();
                    OracleCommand command = new OracleCommand(queryUpdateInterval, connection);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }

               
            }
            
        }

        private void listTipsters_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            Tipster tipster = listTipsters.Items[e.Index] as Tipster;
            if (tipster.Valid.Equals("n"))
            {
                e.Graphics.DrawString(tipster.ToString(), new Font("Lucida Console", 9.75F, FontStyle.Regular, GraphicsUnit.Pixel),new SolidBrush(Color.Red),e.Bounds);
            }
            else
            {
                e.Graphics.DrawString(tipster.ToString(), new Font("Lucida Console", 9.75F, FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(Color.Black), e.Bounds);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.Show();
            closeParent = false;
            this.Close();
        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(closeParent)
                parent.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                String query = "update basicInfo set time_interval = 1, virtual_Date = '08/16/2013'";
                OracleCommand command = new OracleCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                query = "delete from goal";
                command = new OracleCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                query = "delete from participates";
                command = new OracleCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                query = "delete from tips";
                command = new OracleCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                query = "delete from showCoeff";
                command = new OracleCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                query = "set Finished = 'n'";
                command = new OracleCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            btnStart.Enabled = false;
        }
    }
}
