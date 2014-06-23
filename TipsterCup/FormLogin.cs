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

    public enum Language
    {
        ENGLISH,
        MACEDONIAN
    }

   
    
    public partial class FormLogin : Form
    {

        // formata koja kje se pojavi otkako validno kje se popolni Login formata
        FormMain frmMain;
        FormAdmin frmAdmin;

        public Language language = Language.ENGLISH;
        public static String currLanguage = "English";

        //go cuva intervalot vo minuti
        public static int timeInterval;

        //virtuelnata data vo igrata
        public static DateTime virtualDate;

        // parametri potrebni za konekcija so bazata
        public static String connString = "Data Source=(DESCRIPTION="
             + "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1620))"
             + "(CONNECT_DATA=(SERVICE_NAME=ORCL)));"
             + "User Id=DBA_20132014L_GRP_022;Password=9427657;";

        public static int IdLoggedTipster = -1;

        public static  Dictionary<String, String> translator; 
        

        public FormLogin()
        {
            
            
            InitializeComponent();

            
            initializeDateandInterval();

            initMessages();
        }

        private void initMessages()
        {
            translator = new Dictionary<String, String>();

            translator.Add("InvalidInput English", "The input parameters are invalid.");
            translator.Add("InvalidInput Macedonian", "Внесените параметри не се валидни.");

            translator.Add("Language English", "Language:");
            translator.Add("Login English", "Login as:");
            translator.Add("Username English", "Username:");
            translator.Add("Password English", "Password:");
            translator.Add("Exit English", "Exit");
            translator.Add("Tipster English", "Tipster");
            translator.Add("Administrator English", "Administrator");
            translator.Add("Form English", "Login");
            translator.Add("Register English", "Register");
            translator.Add("BannedMsg English", "You cannot log in because you are banned.");
            translator.Add("LoggedMsg English", "You cannot log in because there is someone is already logged in with your username.");

            translator.Add("Language Macedonian", "Јазик:");
            translator.Add("Login Macedonian", "Најави се како:");
            translator.Add("Username Macedonian", "Корисничко име:");
            translator.Add("Password Macedonian", "Лозинка:");
            translator.Add("Exit Macedonian", "Излез");
            translator.Add("Tipster Macedonian", "Типстер");
            translator.Add("Administrator Macedonian", "Администратор");
            translator.Add("Form Macedonian", "Најава");
            translator.Add("Register Macedonian", "Регистрирај се");
            translator.Add("BannedMsg Macedonian", "Не можете да се најавите бидејќи сте банирани.");
            translator.Add("LoggedMsg Macedonian", "Не можете да се најавите бидејќи веќе некој е најавен со вашето корисничко име.");
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
            cbLanguage.SelectedIndex = 0;
            cbLoginAs.SelectedIndex = 0;
        }




        //Go inicijalizira virtuelniot datum i intervalot
        public void initializeDateandInterval()
        {
            DateTime date = DateTime.Now;
            DateTime lastDate = DateTime.Now;
            using (OracleConnection connection = new OracleConnection(connString)) 
            {
                
                connection.Open(); // MORA DA SE POVIKA!

                
                String query = "SELECT * FROM BasicInfo";
               
                OracleCommand command = new OracleCommand(query, connection);
                command.CommandType = CommandType.Text;

                 
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    timeInterval = reader.GetInt32(0);
                    lastDate = reader.GetDateTime(1);
                    virtualDate = reader.GetDateTime(2);
                }

            }

            
            double minutes = date.Subtract(lastDate).TotalMinutes;
            int daysPassed =(int) (minutes / timeInterval);
            virtualDate = virtualDate.AddDays(daysPassed);
            int thisDay = (int)minutes % timeInterval;
            int hoursThisDay = thisDay / 60;
            int minutesThisDay = thisDay % 60;
            
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();
                
                DateTime updateLastDate = date.Subtract(new TimeSpan(hoursThisDay, minutesThisDay, 0));
                String query = "UPDATE BasicInfo SET Last_Date = (TO_DATE('" + updateLastDate.Month + "/" + updateLastDate.Day + "/" + updateLastDate.Year
                    +" "+updateLastDate.Hour+":"+updateLastDate.Minute+"', 'mm/dd/yyyy hh24:mi'))";
                OracleCommand command = new OracleCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                String queryUpdateVirtualDate = "UPDATE BasicInfo SET Virtual_Date = (TO_DATE('" + virtualDate.Month + "/" + virtualDate.Day + "/" + virtualDate.Year
                    + "', 'mm/dd/yyyy'))";

                command = new OracleCommand(queryUpdateVirtualDate, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            timerOneTickOneDay.Interval = timeInterval * 60 * 1000;
            timerThisDay.Interval = (timeInterval - thisDay)*60*1000;
            timerThisDay.Start();
            timerCheckIntervalChanged.Start();
        }

       

        private void btnExit_Click(object sender, EventArgs e)
        {
           
            Application.Exit();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {

            if (validInput()) {

                if (IdLoggedTipster != -1) // znachi deka se najavil tipster a ne administrator
                {
                    using (OracleConnection conn = new OracleConnection(connString))
                    {
                        conn.Open();
                        string query = "UPDATE TIPSTER " +
                                       "SET loggedIn = 'y' " +
                                       "WHERE idTipster = " + IdLoggedTipster;
                        OracleCommand command = new OracleCommand(query, conn);
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                }
               
                
                this.Hide();
                if (cbLoginAs.SelectedIndex == 0)
                {
                    frmMain = new FormMain();

                    frmMain.Show();
                }
                else
                {
                    frmAdmin = new FormAdmin();
                    frmAdmin.Show();
                }
                
                
            }
        }
        // proveruva dali vlezot za username i password vsusnost postoi vo bazata
        private Boolean validInput()
        {
            String username = tbUsername.Text;
            String password = tbPassword.Text;

            username = username.Trim();

            if (username.Equals("") || password.Equals(""))
            {
                MessageBox.Show(translator["InvalidInput " + currLanguage]);
                return false;
            }

            String fromTable = "";

            if (cbLoginAs.SelectedIndex == 0)
            {
                fromTable = "Tipster";
            }
            else
            {
                fromTable = "Administrator";
            }
            
            using (OracleConnection connection = new OracleConnection(connString))
            {
                connection.Open(); // ne smee da se zaboravi!!!
                String cmdText = "SELECT * FROM " + fromTable + " WHERE username = '" + username + "' and password = '" + password + "'";

                OracleCommand command = new OracleCommand(cmdText, connection);
                command.CommandType = CommandType.Text;

                
               OracleDataReader dataReader = command.ExecuteReader();
                

                if (!dataReader.Read())
                {
                    connection.Close(); // za sekoj slucaj
                    MessageBox.Show(translator["InvalidInput " + currLanguage]);
                    return false;
                }
                else if (fromTable.Equals("Tipster") && dataReader.GetString(7).Equals("n"))
                {
                    MessageBox.Show(translator["BannedMsg " + currLanguage]);
                    return false;
                }
                else if (fromTable.Equals("Tipster") && dataReader.GetString(8).Equals("y"))
                {
                    MessageBox.Show(translator["LoggedMsg " + currLanguage]);
                    return false;
                }

                if (fromTable.Equals("Tipster"))
                    IdLoggedTipster = dataReader.GetInt32(0);
            }

            
            
            return true;
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLanguage.SelectedIndex == 1)
            {
                language = Language.MACEDONIAN;
                currLanguage = "Macedonian";
                
            }
            else
            {
                language = Language.ENGLISH;
                currLanguage = "English";
                
            }

            changeLanguageInItems();
        }

        private void changeLanguageInItems()
        {
            int selectedIndex = cbLoginAs.SelectedIndex;
            cbLoginAs.Items.Clear();
           
            lblLanguage.Text = translator["Language " + currLanguage];
            lblLoginAs.Text = translator["Login " + currLanguage];
            lblUsername.Text = translator["Username " + currLanguage];
            lblPassword.Text = translator["Password " + currLanguage];
            btnExit.Text = translator["Exit " + currLanguage];
            this.Text = translator["Form " + currLanguage];

            cbLoginAs.Items.Add(translator["Tipster " + currLanguage]);
            cbLoginAs.Items.Add(translator["Administrator " + currLanguage]);
            llblRegister.Text = translator["Register " + currLanguage];
            cbLoginAs.SelectedIndex = selectedIndex;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            virtualDate = virtualDate.AddDays(1);
            updateVirtualDateAndLastDate();
        }

        public void updateVirtualDateAndLastDate()
        {
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();
                
                String queryUpdateVirtualDate = "UPDATE BasicInfo SET Virtual_Date = (TO_DATE('" + virtualDate.Month + "/" + virtualDate.Day + "/" + virtualDate.Year
                    +"', 'mm/dd/yyyy'))";
                
                DateTime updateLastDate = DateTime.Now;
                String queryUpdateDate = "UPDATE BasicInfo SET Last_Date = (TO_DATE('" + updateLastDate.Month + "/" + updateLastDate.Day + "/" + updateLastDate.Year
                    + " " + updateLastDate.Hour + ":" + updateLastDate.Minute + "', 'mm/dd/yyyy hh24:mi'))";
                
                
                OracleCommand command = new OracleCommand(queryUpdateVirtualDate, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                command = new OracleCommand(queryUpdateDate, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timeInterval != timerOneTickOneDay.Interval/1000/60)
            {
                timerOneTickOneDay.Interval = timeInterval * 1000 * 60;
            }
        }

        private void llblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister frmRegister = new FormRegister();

            frmRegister.ShowDialog();
        }

        private void timerThisDay_Tick(object sender, EventArgs e)
        {
            virtualDate = virtualDate.AddDays(1);
            updateVirtualDateAndLastDate();
            timerOneTickOneDay.Start();
            timerThisDay.Stop();
        }
    }
}
