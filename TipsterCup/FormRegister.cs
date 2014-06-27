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
    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // DIZAJNOT E KATASTROFALEN AMA FUNKCIONIRA OK
    // POKASNO KJE SE NAVRATIME NA DIZAJNOT
    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public partial class FormRegister : Form
    {
        String username;
        String password;
        String repPassword;
        String name;
        String surname;
        String email;
        public FormRegister()
        {
            InitializeComponent();
            
        }
        private bool isRegulated()
        {
            if (username.Trim().Length == 0)
            {
                MessageBox.Show("Username is empty!");
                return false;
            }

            if (password.Trim().Length == 0 || repPassword.Trim().Length == 0) 
            {
                MessageBox.Show("One of the password fields is empty!");
                return false;
            }

            if (!password.Equals(repPassword))
            {
                MessageBox.Show("Passwords do not match.");
                return false;
            }
            username = username.Trim();
             
            using (OracleConnection conn = new OracleConnection(FormLogin.connString)) // using avtomatski ja zatvora otvorenata konekcija
            {
                conn.Open();

                // mozhebi bi bilo podobro da se realizira so funkcija na nivo na baza
                string query = "SELECT COUNT(*) FROM Tipster WHERE UPPER(username) LIKE '" + username.ToUpper() + "'";
                OracleCommand commCheck = new OracleCommand(query, conn);
                commCheck.CommandType = CommandType.Text;
                Object o = commCheck.ExecuteScalar();

                
                int numRows = Int32.Parse(o.ToString());
                
                if (numRows != 0)
                {
                    MessageBox.Show("Already exists tipster with that username.");
                    conn.Clone(); // za sekoj slucaj
                    return false;
                }

                
                
             }
           
            return true;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            username = tbUsername.Text;
            password = tbPassword.Text;
            repPassword = tbRepPassword.Text;
            name = tbName.Text;
            surname = tbSurname.Text;
            email = tbEmail.Text;
            if (!isRegulated())
            {
                return;
            }
           

            


            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();

                OracleCommand command = new OracleCommand("procInsertTipster", conn);
                command.CommandType = CommandType.StoredProcedure;
                /*
                 *  p_username IN Tipster.username%TYPE,
                    p_password IN Tipster.password%TYPE, 
                    p_name     IN Tipster.name%TYPE,
                    p_surname IN Tipster.surname%TYPE, 
                    p_rating IN Tipster.rating%TYPE, 
                    p_email IN Tipster.email%TYPE ) 
                 */
                command.Parameters.Add( "p_username",OracleDbType.Varchar2).Value = username;
                command.Parameters.Add("p_password", OracleDbType.Varchar2).Value = password;
                command.Parameters.Add("p_name", OracleDbType.Varchar2).Value = name;
                command.Parameters.Add("p_surname", OracleDbType.Varchar2).Value = surname;
                command.Parameters.Add("p_money", OracleDbType.Int32).Value = 1000;
                command.Parameters.Add("p_email", OracleDbType.Varchar2).Value = email;

                command.ExecuteNonQuery();

            }

            MessageBox.Show("Your registration was successful.");
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            lblName.Text = FormLogin.translator["Name " + FormLogin.currLanguage] + ":";
            lblSurname.Text = FormLogin.translator["Surname " + FormLogin.currLanguage] + ":";
            lblEmail.Text = FormLogin.translator["Email " + FormLogin.currLanguage] + ":";
            lblPassword.Text = FormLogin.translator["Password " + FormLogin.currLanguage] + ":";
            lblUsername.Text = FormLogin.translator["Username " + FormLogin.currLanguage] + ":";
            lblRepPassword.Text = FormLogin.translator["RepPass " + FormLogin.currLanguage] + ":";
            this.Text = FormLogin.translator["FormRegister " + FormLogin.currLanguage];
            
        }

       
    }
}
