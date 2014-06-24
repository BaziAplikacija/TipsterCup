﻿using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipsterCup
{
    public partial class FormRounds : Form
    {
        List<Round> Rounds;
        MainDoc docMain;
        List<Label> labels;

        List<Match> matchesInRound;
        public FormRounds(MainDoc doc)
        {
            InitializeComponent();
            docMain = doc;
            //Rounds = new List<Round>();
            labels = new List<Label>();
        }


        private void setMatches()
        {
            matchesInRound = new List<Match>();

            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();
                String query = "SELECT * FROM Match WHERE idRound = "+ (cbRounds.SelectedIndex + 1);
                OracleCommand command = new OracleCommand(query, connection);
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Match m = new Match(reader.GetInt32(0), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(2), reader.GetDateTime(1));
                    matchesInRound.Add(m);
                }
                
            }

            /*foreach (Match match in docMain.Matches)
            {
                if (match.Round.Id == cbRounds.SelectedIndex + 1)
                {
                    matchesInRound.Add(match);
                }
            }*/

            
            for (int i = 0; i < matchesInRound.Count; i++)
            {
                labels[i * 4].Text = matchesInRound[i].DateMatch.ToShortDateString();
                if (matchesInRound[i].DateMatch.CompareTo(FormLogin.virtualDate) <= 0)
                {
                    labels[i * 4 + 2].Text = matchesInRound[i].GoalsHome.Count + "-" + matchesInRound[i].GoalsGuest.Count;
                }
                else
                {
                    labels[i * 4 + 2].Text = "";
                }
                labels[i * 4 + 1].Text = matchesInRound[i].HomeTeam.Name;
                labels[i * 4 + 3].Text = matchesInRound[i].GuestTeam.Name;

            }

        }





        private void cbRounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            setMatches();

        }



        private void FormRounds_Load(object sender, EventArgs e)
        {
            setControls();
            cbRounds.SelectedIndex = setRound() - 1;
        }


        private int setRound()
        {
            int round = 0;
            
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();
                
                String query = "SELECT idRound FROM Round WHERE dateFrom < (TO_DATE('" + FormLogin.virtualDate.Month + "/" + FormLogin.virtualDate.Day + "/" + FormLogin.virtualDate.Year
                    + "', 'mm/dd/yyyy')) AND dateTo > (TO_DATE('" + FormLogin.virtualDate.Month + "/" + FormLogin.virtualDate.Day + "/" + FormLogin.virtualDate.Year+ "', 'mm/dd/yyyy'))";
                OracleCommand command = new OracleCommand(query, connection);
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    round = reader.GetInt32(0);
                }
                if (round == 0)
                {
                    query = "SELECT idRound FROM Round WHERE dateTo < (TO_DATE('" + FormLogin.virtualDate.Month + "/" + FormLogin.virtualDate.Day + "/" + FormLogin.virtualDate.Year
                    + "', 'mm/dd/yyyy')) ORDER BY idround";
                    command = new OracleCommand(query, connection);
                    reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        round = reader.GetInt32(0);
                    }
                }
            }
            return round;
        }


        private void setControls()
        {
            tableResults.Controls.Clear();
            for (int i = 0; i < 10; ++i)
            {
                Label labelResult = new Label();
                Label labelHome = new Label();
                Label labelGuest = new Label();
                Label labelDate = new Label();
                
                labelResult.Dock = DockStyle.Fill;
                labelResult.TextAlign = ContentAlignment.BottomCenter;
                labelResult.Click += new EventHandler(labelResult_Click);
                
                labelHome.Dock = DockStyle.Fill;
                labelHome.TextAlign = ContentAlignment.BottomRight;
                labelHome.Click += new EventHandler(labelTeam_Click);

                labelGuest.Dock = DockStyle.Fill;
                labelGuest.TextAlign = ContentAlignment.BottomLeft;
                labelGuest.Click += new EventHandler(labelTeam_Click);

                labelDate.Dock = DockStyle.Fill;
                labelDate.TextAlign = ContentAlignment.BottomLeft;

                tableResults.Controls.Add(labelHome, 1, i);
                tableResults.Controls.Add(labelResult, 2, i);
                tableResults.Controls.Add(labelGuest, 3, i);
                tableResults.Controls.Add(labelDate, 0, i);

                labels.Add(labelDate);
                labels.Add(labelHome);
                labels.Add(labelResult);
                labels.Add(labelGuest);

                Button btnTip = new Button();
                btnTip.Text = "Tip";
                btnTip.Dock = DockStyle.Fill;
                btnTip.Click += new EventHandler(button_Click);
                tableResults.Controls.Add(btnTip, 4, i);
            }
        }



        private void labelResult_Click(object sender, EventArgs e)
        {
            int row = tableResults.GetRow(sender as Control);
            FormMatchDetails frm = new FormMatchDetails(matchesInRound[row]);
            frm.Show();
        }



        private void labelTeam_Click(object sender, EventArgs e)
        {
            int row = tableResults.GetRow(sender as Control);
            int column = tableResults.GetColumn(sender as Control);
            if (column == 1)
            {
                FormTeam frmTeam = new FormTeam(matchesInRound[row].HomeTeam, docMain);
                frmTeam.Show();
            }
            if (column == 3)
            {
                FormTeam frmTeam = new FormTeam(matchesInRound[row].GuestTeam, docMain);
                frmTeam.Show();
            }
        }



        private void button_Click(object sender, EventArgs e)
        {
            int row = tableResults.GetRow(sender as Control);
            Match match = matchesInRound[row];
        }






    }
}
