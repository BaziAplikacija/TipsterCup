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
    public partial class FormStatistics : Form
    {
        public FormStatistics()
        {
            InitializeComponent();
        }

        private void btnLastPerformance_Click(object sender, EventArgs e)
        {
            gridLastPerformance.Rows.Clear();
            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();

                OracleCommand command = new OracleCommand("select * from form", conn);
                command.CommandType = CommandType.Text;

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    gridLastPerformance.Rows.Add(reader.GetString(0), reader.GetString(1));
                }
                reader.Close();
            }
            gridLastPerformance.Visible = true;
        }

        private void btnTopscorer_Click(object sender, EventArgs e)
        {
            gridTopscorers.Rows.Clear();
            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();

                OracleCommand command = new OracleCommand("select * from topscorers", conn);
                command.CommandType = CommandType.Text;

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    gridTopscorers.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
                }
                reader.Close();
            }
            gridTopscorers.Visible = true;
        }
    }
}
