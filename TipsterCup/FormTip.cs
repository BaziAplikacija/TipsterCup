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


// !!!! TREBA DA SE TESTIRA !!!!! 
namespace TipsterCup
{
    public partial class FormTip : Form
    {
        Match Match;
        int money;

        List<RadioButton> rButtons;
        List<Coefficient> coefficients;
        List<Label> labels;
        public FormTip(Match match)
        {
            InitializeComponent();

            Match = match;
            rButtons = new List<RadioButton>();
            coefficients = new List<Coefficient>();
            labels = new List<Label>();

            rButtons.Add(radioButton1);
            rButtons.Add(radioButton2);
            rButtons.Add(radioButton3);
            rButtons.Add(radioButton4);
            rButtons.Add(radioButton5);
            rButtons.Add(radioButton6);
            rButtons.Add(radioButton7);


            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FormTip_Load(object sender, EventArgs e)
        {
            lblHome.Text = Match.HomeTeam.Name;
            lblGuest.Text = Match.GuestTeam.Name;

            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();
                string query = "select money from tipster where idTipster = " + FormLogin.IdLoggedTipster;
                OracleCommand command = new OracleCommand(query, conn);
                command.CommandType = CommandType.Text;

                money = Int32.Parse(command.ExecuteScalar().ToString());

                query = "select * from CoeffForMatch where idMatch = " + Match.Id;

                command = new OracleCommand(query, conn);
                command.CommandType = CommandType.Text;

                OracleDataReader reader = command.ExecuteReader();

            }

            if (money < 10)
            {
                nudCash.Enabled = false;
                btnYes.Enabled = false;
                lblDisabled.Text = "You cannot tip because\nyou have less than 10 dollars.";
                lblDisabled.Visible = true;
            }
            else
            {
                nudCash.Maximum = Math.Max(10, money - 10);
            }

            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();
                
                string query = "select * from CoeffForMatch where idMatch = " + Match.Id + " order by idCoefficient ";

                OracleCommand command = new OracleCommand(query, conn);
                command.CommandType = CommandType.Text;

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    coefficients.Add(new Coefficient(reader.GetInt32(0),reader.GetInt32(2),reader.GetInt32(1),Double.Parse(reader[3].ToString()),reader.GetString(4)));
                }

            }

            for(int i=0; i<rButtons.Count; i++) {
                rButtons[i].Text = "    Coeff: " + coefficients[i].Value;
                labels[i].Text = coefficients[i].Description;
            }


        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Coefficient checkedCoeff = null;

            for (int i = 0; i < rButtons.Count; i++)
            {
                
                if (rButtons[i].Checked)
                {
                    checkedCoeff = coefficients[i];
                    break;
                    
                }
            }

           

            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();
                
                string query = "insert into tips(idtipster, idshowcoefficient, amount,validated) values (" + FormLogin.IdLoggedTipster + ", " + checkedCoeff.IdShowCoeff + ", " + (int)nudCash.Value + ",'n')";
                OracleCommand command = new OracleCommand(query,conn);
                command.CommandType = CommandType.Text;

                command.ExecuteNonQuery();
                query = "UPDATE Tipster SET money = money - " + (int)nudCash.Value + " WHERE idTipster = " + FormLogin.IdLoggedTipster;
                command = new OracleCommand(query, conn);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }

            MessageBox.Show("The tip was successful.");
            this.Close();
        }
    }
}
