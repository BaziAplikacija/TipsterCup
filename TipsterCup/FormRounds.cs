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
        private List<Panel> panels;
        private List<Label> labelsResult;
        private List<Label> labelsHome;
        private List<Label> labelsGuest;
        List<Round> Rounds;
        MainDoc docMain;

        List<Match> matchesInRound;
        public FormRounds(MainDoc doc)
        {
            InitializeComponent();

            docMain = doc;

            

            Rounds = new List<Round>();

            panels = new List<Panel>();
            labelsResult = new List<Label>();
            labelsHome = new List<Label>();
            labelsGuest = new List<Label>();

            setPanelsAndLabels();

            cbRounds.SelectedIndex = cbRounds.Items.Count - 1;
            
            
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
                labelsResult[i].Text = matchesInRound[i].GoalsHome.Count + "-" + matchesInRound[i].GoalsGuest.Count;
                labelsHome[i].Text = matchesInRound[i].HomeTeam.Name;
                labelsGuest[i].Text = matchesInRound[i].GuestTeam.Name;
            }
        }


        private void setPanelsAndLabels()
        {
            panel1.Tag = 0;
            panel2.Tag = 1;
            panel3.Tag = 2;
            panel4.Tag = 3;
            panel5.Tag = 4;
            panel6.Tag = 5;
            panel7.Tag = 6;
            panel8.Tag = 7;
            panel9.Tag = 8;
            panel10.Tag = 9;

            lblRes1.Tag = 0;
            lblRes2.Tag = 1;
            lblRes3.Tag = 2;
            lblRes4.Tag = 3;
            lblRes5.Tag = 4;
            lblRes6.Tag = 5;
            lblRes7.Tag = 6;
            lblRes8.Tag = 7;
            lblRes9.Tag = 8;
            lblRes10.Tag = 9;

           
            labelsResult.Add(lblRes1);
            labelsResult.Add(lblRes2);
            labelsResult.Add(lblRes3);
            labelsResult.Add(lblRes4);
            labelsResult.Add(lblRes5);
            labelsResult.Add(lblRes6);
            labelsResult.Add(lblRes7);
            labelsResult.Add(lblRes8);
            labelsResult.Add(lblRes9);
            labelsResult.Add(lblRes10);

            labelsHome.Add(lblHome1);
            labelsHome.Add(lblHome2);
            labelsHome.Add(lblHome3);
            labelsHome.Add(lblHome4);
            labelsHome.Add(lblHome5);
            labelsHome.Add(lblHome6);
            labelsHome.Add(lblHome7);
            labelsHome.Add(lblHome8);
            labelsHome.Add(lblHome9);
            labelsHome.Add(lblHome10);


            labelsGuest.Add(lblGuest1);
            labelsGuest.Add(lblGuest2);
            labelsGuest.Add(lblGuest3);
            labelsGuest.Add(lblGuest4);
            labelsGuest.Add(lblGuest5);
            labelsGuest.Add(lblGuest6);
            labelsGuest.Add(lblGuest7);
            labelsGuest.Add(lblGuest8);
            labelsGuest.Add(lblGuest9);
            labelsGuest.Add(lblGuest10);
            

            panels.Add(panel1);
            panels.Add(panel2);
            panels.Add(panel3);
            panels.Add(panel4);
            panels.Add(panel5);
            panels.Add(panel6);
            panels.Add(panel7);
            panels.Add(panel8);
            panels.Add(panel9);
            panels.Add(panel10);

            

        }


        private Panel getSelectedPanel(int x, int y)
        {

            foreach (Panel panel in panels)
            {
                if (panel.Location.X >= x && x <= panel.Location.X + panel.Width)
                {
                    if (panel.Location.Y >= y && y <= panel.Location.Y + panel.Height)
                    {
                        return panel;
                    }
                }
            }

            return null;
        }

        private void cbRounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            setMatches();
            
        }

        private void FormRounds_Load(object sender, EventArgs e)
        {
            setMatches();
        }


       

      

    }
}
