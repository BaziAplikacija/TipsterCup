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

        // parametri potrebni za konekcija so bazata
        String connString = "Data Source=(DESCRIPTION="
             + "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1620))"
             + "(CONNECT_DATA=(SERVICE_NAME=ORCL)));"
             + "User Id=DBA_20132014L_GRP_022;Password=9427657;";
        OracleConnection connection;
        OracleCommand command; 


        public FormLogin()
        {
            InitializeComponent();

            connection = new OracleConnection(connString);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            connection.Open();
            cbLanguage.SelectedIndex = 0;
            cbLoginAs.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            connection.Close();
            Application.Exit();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {

            if (validInput()) { 
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
                
                connection.Close();
            }
            else
            {
                String errorMessage = "";

                if (language == Language.ENGLISH)
                {
                    errorMessage = "The input parameters are invalid.";
                }
                else
                {
                    errorMessage = "Внесените параметри не се валидни.";
                }
                MessageBox.Show(errorMessage);
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
            String cmdText = "SELECT * FROM " + fromTable + " WHERE username = '" + username + "' and password = '" + password + "'";
                            
            command = new OracleCommand(cmdText, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader = command.ExecuteReader();
            dataReader = command.ExecuteReader();

            if (!dataReader.Read())
            {
                
                return false;
            }
            
            return true;
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLanguage.SelectedIndex == 1)
            {
                language = Language.MACEDONIAN;
                changeLanguageInItems(true);
            }
            else
            {
                language = Language.ENGLISH;
                changeLanguageInItems(false);
            }
        }

        private void changeLanguageInItems(Boolean macedonian)
        {
            int selectedIndex = cbLoginAs.SelectedIndex;
            cbLoginAs.Items.Clear();
            if (macedonian)
            {
                lblLanguage.Text = "Јазик:";
                lblLoginAs.Text = "Најави се како:";
                lblUsername.Text = "Корисничко име:";
                lblPassword.Text = "Лозинка:";
                btnExit.Text = "Излез";
                btnGo.Text = "Почни!";
                this.Text = "Најава";

                cbLoginAs.Items.Add("Типстер");
                cbLoginAs.Items.Add("Администратор");
                

                
            }
            else
            {
                lblLanguage.Text = "Language:";
                lblLoginAs.Text = "Login as:";
                lblUsername.Text = "Username:";
                lblPassword.Text = "Password:";
                btnExit.Text = "Exit";
                btnGo.Text = "Go!";
                this.Text = "Login";

                cbLoginAs.Items.Add("Tipster");
                cbLoginAs.Items.Add("Administrator");
            }

            cbLoginAs.SelectedIndex = selectedIndex;

        }
    }
}
