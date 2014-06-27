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
    public partial class FormAllPlayers : Form
    {
        public FormAllPlayers()
        {
            InitializeComponent();
        }

       

        

        private void cbTeam_CheckedChanged(object sender, EventArgs e)
        {
            cbxTeam.Enabled = cbTeam.Checked;

            if (cbxTeam.Enabled)
            {
                cbxTeam.SelectedIndex = 0;
            }
            else
            {
                cbxTeam.SelectedIndex = -1;
            }
        }

        private void cbPosition_CheckedChanged(object sender, EventArgs e)
        {
            cbxPosition.Enabled = cbPosition.Checked;

            if (cbxPosition.Enabled)
            {
                cbxPosition.SelectedIndex = 0;
            }
            else
            {
                cbxPosition.SelectedIndex = -1;
            }
        }

        private void cbAge_CheckedChanged(object sender, EventArgs e)
        {
            tbAgeFrom.Enabled = cbAge.Checked;
            tbAgeTo.Enabled = cbAge.Checked;

            if (tbAgeFrom.Enabled == false)
            {
                tbAgeFrom.Text = "";
                tbAgeTo.Text = "";
            }
        }

        private void cbGoals_CheckedChanged(object sender, EventArgs e)
        {
            tbGoalsFrom.Enabled = cbGoals.Checked;
            tbGoalsTo.Enabled = cbGoals.Checked;

            if (tbGoalsFrom.Enabled == false)
            {
                tbGoalsFrom.Text = "";
                tbGoalsTo.Text = "";
            }
        }

        private void cbRating_CheckedChanged(object sender, EventArgs e)
        {
            tbRatingFrom.Enabled = cbRating.Checked;
            tbRatingTo.Enabled = cbRating.Checked;

            if (tbRatingFrom.Enabled == false)
            {
                tbRatingFrom.Text = "";
                tbRatingTo.Text = "";
            }
        }

        private void cbFirstName_CheckedChanged(object sender, EventArgs e)
        {
            tbFirstName.Enabled = cbFirstName.Checked;

            if (tbFirstName.Enabled == false)
            {
                tbFirstName.Text = "";
            }
            
        }

        private void cbLastName_CheckedChanged(object sender, EventArgs e)
        {
            tbLastName.Enabled = cbLastName.Checked;

            if (tbLastName.Enabled == false)
            {
                tbLastName.Text = "";
            }
        }

        private void tbAgeFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (char)8 != e.KeyChar)
            {
                e.Handled = true;
            }
        }

        private void FormAllPlayers_Load(object sender, EventArgs e)
        {
            fillGrid();

            cbFirstName.Text = FormLogin.translator["FirstName " + FormLogin.currLanguage];
            cbLastName.Text = FormLogin.translator["LastName " + FormLogin.currLanguage];
            cbAge.Text = FormLogin.translator["Age " + FormLogin.currLanguage];
            cbRating.Text = FormLogin.translator["Rating " + FormLogin.currLanguage];
            cbGoals.Text = FormLogin.translator["Goals " + FormLogin.currLanguage];

            lblFromAge.Text = FormLogin.translator["From " + FormLogin.currLanguage];
            lblFromGoals.Text = FormLogin.translator["From " + FormLogin.currLanguage];
            lblFromRating.Text = FormLogin.translator["From " + FormLogin.currLanguage];

            lblToAge.Text = FormLogin.translator["To " + FormLogin.currLanguage];
            lblToGoals.Text = FormLogin.translator["To " + FormLogin.currLanguage];
            lblToRating.Text = FormLogin.translator["To " + FormLogin.currLanguage];

            cbTeam.Text = FormLogin.translator["Team " + FormLogin.currLanguage];
            cbPosition.Text = FormLogin.translator["Position " + FormLogin.currLanguage];

            /* gridPlayers.Columns[0].HeaderText = FormLogin.translator["FirstName " + FormLogin.currLanguage];
              gridPlayers.Columns[1].HeaderText = FormLogin.translator["LastName " + FormLogin.currLanguage];
              gridPlayers.Columns[2].HeaderText = FormLogin.translator["Rating " + FormLogin.currLanguage];
              gridPlayers.Columns[3].HeaderText = FormLogin.translator["Team " + FormLogin.currLanguage];
              gridPlayers.Columns[4].HeaderText = FormLogin.translator["Position " + FormLogin.currLanguage];
              gridPlayers.Columns[5].HeaderText = FormLogin.translator["Goals " + FormLogin.currLanguage];
              gridPlayers.Columns[6].HeaderText = FormLogin.translator["Age " + FormLogin.currLanguage];*/
           
            

        }

        private void fillGrid()
        {
            gridPlayers.Rows.Clear();
            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();

                string query = formulateQuery();

                
                OracleCommand command = new OracleCommand(query, conn);
                command.CommandType = CommandType.Text;

               
                OracleDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    gridPlayers.Rows.Add(reader[0],reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7]);
                }

                reader.Close();

            }
        }

        private String formulateQuery()
        {
            String query = "SELECT * FROM PlayerComplete WHERE 0 < 1 ";

            if (cbFirstName.Checked && tbFirstName.Text.Trim().Length > 0)
            {
                query += " AND firstname LIKE '" + tbFirstName.Text.Trim() + "%' ";
            }

            if (cbLastName.Checked && tbLastName.Text.Trim().Length > 0)
            {
                query += " AND surname LIKE '" + tbLastName.Text.Trim() + "%' ";
            }

            if (cbAge.Checked)
            {
                if (tbAgeFrom.Text.Trim().Length > 0)
                {
                    query += " AND years >= " + Int32.Parse(tbAgeFrom.Text);
                }

                if (tbAgeTo.Text.Trim().Length > 0)
                {
                    query += " AND years <= " + Int32.Parse(tbAgeTo.Text);
                }
            }

            if (cbGoals.Checked)
            {
                if (tbGoalsFrom.Text.Trim().Length > 0)
                {
                    query += " AND goals >= " + Int32.Parse(tbGoalsFrom.Text);
                }

                if (tbGoalsTo.Text.Trim().Length > 0)
                {
                    query += " AND goals <= " + Int32.Parse(tbGoalsTo.Text);
                }
            }

            if (cbRating.Checked)
            {
                if (tbRatingFrom.Text.Trim().Length > 0)
                {
                    query += " AND Rating >= " + Int32.Parse(tbRatingFrom.Text);
                }

                if (tbRatingTo.Text.Trim().Length > 0)
                {
                    query += " AND Rating <= " + Int32.Parse(tbRatingTo.Text);
                }
            }

            if (cbTeam.Checked)
            {
                
                query += " AND Team LIKE '" + cbxTeam.SelectedItem.ToString() + "'";
            }

            if (cbPosition.Checked)
            {
                query += " AND Position LIKE '" + cbxPosition.SelectedItem.ToString() + "'";
            }

            return query;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            fillGrid();
        }

        
        
    }
}
