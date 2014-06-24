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
    public partial class FormMain : Form
    {
        FormStandings frmStandings;
        FormRounds frmRounds;
        FormAllTipsters frmAllTipsters;
        
        public FormMain()
        {
            InitializeComponent();
            frmStandings = null;
            frmRounds = null;
            frmAllTipsters = null;
        }

        

        

        private void btnRounds_Click(object sender, EventArgs e)
        {

            if (frmRounds != null)
            {
                frmRounds.Close();
            }
            frmRounds = new FormRounds(FormLogin.docMain);
            frmRounds.MdiParent = this;
            frmRounds.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            FormTipster frmMyProfile = new FormTipster(FormLogin.IdLoggedTipster);
            frmMyProfile.Show();
        }

        private void btnTipsters_Click(object sender, EventArgs e)
        {
            frmAllTipsters = new FormAllTipsters();
            frmAllTipsters.MdiParent = this;
           
            frmAllTipsters.Show();
        }

        private void btnStandings_Click(object sender, EventArgs e)
        {
            if (frmStandings != null)
            {
                frmStandings.Close();
            }
            frmStandings = new FormStandings();
            frmStandings.MdiParent = this;
            frmStandings.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnStandings_Click(null, null);
        }
    }
}
