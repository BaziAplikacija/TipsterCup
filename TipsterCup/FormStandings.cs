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
    public partial class FormStandings : Form
    {
        private Bitmap bgImage;
        public FormStandings()
        {
            InitializeComponent();
        }

        private void FormStandings_Load(object sender, EventArgs e)
        {
            bgImage = new Bitmap("bgFootballStadium.jpg");
            
            fillGrid();
            this.WindowState = FormWindowState.Maximized;

            gridStandings.Columns[0].HeaderText = FormLogin.translator["Team " + FormLogin.currLanguage];
            gridStandings.Columns[1].HeaderText = FormLogin.translator["W " + FormLogin.currLanguage];
            gridStandings.Columns[2].HeaderText = FormLogin.translator["D " + FormLogin.currLanguage];
            gridStandings.Columns[3].HeaderText = FormLogin.translator["L " + FormLogin.currLanguage];
            gridStandings.Columns[4].HeaderText = FormLogin.translator["Points " + FormLogin.currLanguage];
            this.Text = FormLogin.translator["FormStandings " + FormLogin.currLanguage];
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

        private void FormStandings_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(bgImage, 0, 0, this.Width, this.Height);
        }
    }
}
