﻿using System;
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
    public partial class FormStandings : Form
    {
        public FormStandings()
        {
            InitializeComponent();
        }

        private void FormStandings_Load(object sender, EventArgs e)
        {
            fillGrid();
            this.WindowState = FormWindowState.Maximized;
        }

        private void fillGrid()
        {
            String query = "SELECT * FROM Standings";
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open(); // NE SMEE DA SE ZABORAVI!
                OracleCommand command = new OracleCommand(query, connection);

                command.CommandType = CommandType.Text;

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    gridStandings.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
                }

            }





        }

        private void gridStandings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                String teamName = Convert.ToString(gridStandings.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                FormTeam frmTeam = new FormTeam(FormLogin.docMain.getTeamByName(teamName), FormLogin.docMain);
                frmTeam.Show();
            }
        }
    }
}