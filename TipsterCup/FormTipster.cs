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
    public partial class FormTipster : Form
    {
        int idTipster;
        public FormTipster(int idTipster)
        {
            this.idTipster = idTipster;
            InitializeComponent();
        }

        private void FormTipster_Load(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();

                string query = "select * from Tipster where idTipster = " + idTipster;
                OracleCommand command = new OracleCommand(query, conn);
                command.CommandType = CommandType.Text;

                OracleDataReader reader = command.ExecuteReader();
                reader.Read();

                lblUsername.Text = reader.GetString(1);
                lblFirstName.Text = reader.GetString(3);
                lblSurname.Text = reader.GetString(4);
                lblMoney.Text = reader.GetInt32(5).ToString();
                lblEmail.Text = reader.GetString(6);
                
                query = "select COUNT(*) + 1 FROM Tipster WHERE Money > " + Int32.Parse(lblMoney.Text);

                command = new OracleCommand(query, conn);
                command.CommandType = CommandType.Text;

                lblRank.Text = command.ExecuteScalar().ToString();

                reader.Close();

            }
        }


    }
}
