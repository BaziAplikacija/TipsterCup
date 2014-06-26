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
    public partial class FormAllPlayers : Form
    {
        public FormAllPlayers()
        {
            InitializeComponent();
        }

        private void cbName_CheckedChanged(object sender, EventArgs e)
        {
            timerName.Start();
            


        }

        private void FormAllPlayers_Load(object sender, EventArgs e)
        {

        }

        private void timerName_Tick(object sender, EventArgs e)
        {
            if ((cbName.Checked && cbName.Width == 220) || (!cbName.Checked && cbName.Width == 0))
            {
                timerName.Stop();
                return;
            }

            if (cbName.Checked)
            {
                cbName.Width++;
            }
            else
            {
                cbName.Width--;
            }

        }
    }
}
