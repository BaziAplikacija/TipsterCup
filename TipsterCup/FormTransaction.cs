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
    public partial class FormTransaction : Form
    {
        private int receiverId;
        public FormTipster frmParent;
        public FormTransaction(int receiverId, String tipsterUsername)
        {
            InitializeComponent();
            this.receiverId = receiverId;
            this.lblHeader.Text = "Send money to tipster " + tipsterUsername;
            
        }

        private void FormTransaction_Load(object sender, EventArgs e)
        {
           
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();
                int p_idTipsterFrom = FormLogin.IdLoggedTipster;
                int p_idTipsterTo = receiverId;
                int p_amount = (int)nudAmount.Value;
                DateTime p_datetrans = DateTime.Now;
                String p_message = tbMessage.Text;

                //MessageBox.Show(p_datetrans);                                                                    //TO_DATE('" + to.Month + "/" + to.Day + "/" + to.Year + "', 'mm/dd/yyyy')
                string query = "INSERT INTO Transaction(idTipsterFrom,idTipsterTo,datetrans,amount,message) VALUES(" + p_idTipsterFrom + ", " + p_idTipsterTo + ", TO_DATE('" + p_datetrans.Month + "/" + p_datetrans.Day + "/" + p_datetrans.Year + "', 'mm/dd/yyyy'), " +  + p_amount + " , '" + p_message + "')";
                OracleCommand command = new OracleCommand(query, conn);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                // dodavanje na pari receiver tipster

               
                command = new OracleCommand("procIncMoney", conn);
                command.CommandType = CommandType.StoredProcedure;


                
                command.Parameters.Add("p_idTipster", OracleDbType.Int32).Value = p_idTipsterTo;
                command.Parameters.Add("p_amount", OracleDbType.Int32).Value = p_amount;
                command.ExecuteNonQuery();
                // odzemanje na pari na receiver tipster

                command = new OracleCommand("procIncMoney", conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_idTipster", OracleDbType.Int32).Value = p_idTipsterFrom;
                command.Parameters.Add("p_amount", OracleDbType.Int32).Value = -p_amount;
                command.ExecuteNonQuery();



            }

            MessageBox.Show("The  transaction was successful.");
            frmParent.Invalidate();
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
