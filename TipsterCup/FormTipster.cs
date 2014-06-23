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
    public partial class FormTipster : Form
    {
        
        public FormTipster()
        {
            InitializeComponent();
        }

        private void FormTipster_Load(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();
            }
        }


    }
}
