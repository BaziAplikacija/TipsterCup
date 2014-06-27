using Oracle.DataAccess.Client;
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
        private Bitmap bgImage;

        int currentRound;
        //int lastRound;

        List<Round> Rounds;
        MainDoc docMain;
        List<Label> labels;
        List<Button> buttons;
        List<Match> matchesInRound;
       
        public FormRounds(MainDoc doc)
        {
            InitializeComponent();
            docMain = doc;
            //Rounds = new List<Round>();
            labels = new List<Label>();
            buttons = new List<Button>();
            bgImage = new Bitmap("bgFootballStadium.jpg");
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

            matchesInRound.Sort();

                for (int i = 0; i < matchesInRound.Count; i++)
                {
                    labels[i * 4].Text = matchesInRound[i].DateMatch.ToShortDateString();
                    if (matchesInRound[i].DateMatch.CompareTo(FormLogin.virtualDate) < 0)
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


        public ComboBox getComboBox()
        {
            return cbRounds;
        }


        public void cbRounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            setMatches();
            disableButtons();
        }

        private void disableButtons()
        {
            for (int i = 0; i < buttons.Count; ++i)
            {
                if (i >= matchesInRound.Count || matchesInRound[i].DateMatch.CompareTo(FormLogin.virtualDate) < 0)
                    buttons[i].Enabled = false;
                else
                    buttons[i].Enabled = true;
            }
        }


        private void FormRounds_Load(object sender, EventArgs e)
        {

            lblRound.Text = FormLogin.translator["Round " + FormLogin.currLanguage] + ":";
            this.Text = FormLogin.translator["FormRounds " + FormLogin.currLanguage];

            setControls();
            //currentRound = setRound();
            if (FormMain.finished)
            {
                currentRound = cbRounds.SelectedIndex = cbRounds.Items.Count - 1;
            }
            else
            {
                if (FormMain.betweenRounds)
                {
                    currentRound = FormMain.currentRound.Id;
                }
                else
                {
                    currentRound = FormMain.currentRound.Id;
                }
                cbRounds.SelectedIndex = currentRound - 1;
            }
            disableButtons();

            
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
                btnTip.Text = FormLogin.translator["Tip " + FormLogin.currLanguage];
                btnTip.Dock = DockStyle.Fill;
                btnTip.Click += new EventHandler(button_Click);
                tableResults.Controls.Add(btnTip, 4, i);
                buttons.Add(btnTip);
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

            FormTip frmTip = new FormTip(match);
            frmTip.Show();
        }

        private void FormRounds_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(bgImage, 0, 0, this.Width, this.Height);
        }






    }
}
