﻿using System;
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



            Rounds = new List<Round>();

            labels = new List<Label>();
            

        }

        private void setMatches()
        {
            matchesInRound = new List<Match>();
            foreach (Match match in docMain.Matches)
            {
                if (match.Round.Id == cbRounds.SelectedIndex + 1)
                {
                    matchesInRound.Add(match);
                }
            }



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
            cbRounds.SelectedIndex = cbRounds.Items.Count - 1;


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
                labelResult.TextAlign = ContentAlignment.MiddleCenter;
                labelHome.Dock = DockStyle.Fill;
                labelHome.TextAlign = ContentAlignment.BottomRight;
                labelGuest.Dock = DockStyle.Fill;
                labelGuest.TextAlign = ContentAlignment.BottomLeft;
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

        private void button_Click(object sender, EventArgs e)
        {
            int row = tableResults.GetRow(sender as Control);
            Match match = matchesInRound[row];
        }






    }
}
