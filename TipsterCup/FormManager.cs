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
    public partial class FormManager : Form
    {
        Manager manager;
        public FormManager(Manager m)
        {
            InitializeComponent();
            manager = m;
        }

        private void FormManager_Load(object sender, EventArgs e)
        {
            lblName.Text = manager.FirstName;
            lblSurname.Text = manager.LastName;
            lblDate.Text = manager.DateOfBirth.ToShortDateString();
            lblExperience.Text = manager.Experience+"";
        }
    }
}
