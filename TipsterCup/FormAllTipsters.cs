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
    public partial class FormAllTipsters : Form
    {
        private Bitmap bgImage;
        public FormAllTipsters()
        {
            InitializeComponent();
            bgImage = new Bitmap("bgFootballStadium.jpg");
        
        }

        public void callLoad()
        {
            FormAllTipsters_Load(null, null);
        }

        private void FormAllTipsters_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            gridTipsters.Rows.Clear();
            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();

                string query = "SELECT T.idTipster,(SELECT COUNT(*) FROM TIPSTER WHERE Money > T.money) + 1 as rank, T.username, T.money  FROM TIPSTER T  ORDER BY rank";

                OracleCommand command = new OracleCommand(query, conn);
                command.CommandType = CommandType.Text;


                OracleDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    gridTipsters.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }

                reader.Close();



            }
        }

        private void gridTipsters_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idTipster = Int32.Parse(gridTipsters[0, e.RowIndex].Value.ToString());
            FormTipster frmTipster = new FormTipster(idTipster);
            frmTipster.frmParent = this;
            frmTipster.Show();
        }

        private void FormAllTipsters_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(bgImage, 0, 0, this.Width, this.Height);
        }
    }
}
