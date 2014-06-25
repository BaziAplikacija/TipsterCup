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
    public partial class FormTip : Form
    {
        Match Match;
        int money;
        public FormTip(Match match)
        {
            InitializeComponent();

            Match = match;
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
            }
            else
            {
                nudCash.Maximum = Math.Max(10, money - 10);
            }


        }
    }
}
