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
        public FormAllTipsters frmParent;
        private Bitmap bgImage;

        public FormTipster(int idTipster)
        {
            this.idTipster = idTipster;
            InitializeComponent();
            bgImage = new Bitmap("bgFootballStadium.jpg");
            
        }

        private void FormTipster_Load(object sender, EventArgs e)
        {
            
            if (idTipster != FormLogin.IdLoggedTipster)
            {
                btnTransaction.Visible = true;
            }
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

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            FormTransaction frmTrans = new FormTransaction(this.idTipster,this.lblUsername.Text);
            frmTrans.frmParent = this;
            frmTrans.ShowDialog();

            if (frmParent != null)
            {
                frmParent.callLoad();
            }
            
        }

        private void FormTipster_Paint(object sender, PaintEventArgs e)
        {
            if (idTipster == FormLogin.IdLoggedTipster)
            {
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawImage(bgImage, 0, 0, this.Width, this.Height);
            }
        }


    }
}
