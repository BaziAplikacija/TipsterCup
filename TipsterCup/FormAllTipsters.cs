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
        public FormAllTipsters()
        {
            InitializeComponent();
        }

        private void FormAllTipsters_Load(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();

                string query = "SELECT T.idTipster,(SELECT COUNT(*) FROM TIPSTER WHERE Rating > T.RATING) + 1 as rank, T.username, T.rating  FROM TIPSTER T  ORDER BY rank";

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
            frmTipster.Show();
        }
    }
}
