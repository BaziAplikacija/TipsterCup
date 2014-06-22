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
    public partial class FormAdmin : Form
    {
        public OracleConnection connection;
        
        public FormAdmin(OracleConnection conn)
        {
            InitializeComponent();
            connection = conn;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            select_tipsters();
            cbTime.SelectedIndex = 0;
        }

        //Vo listBox gi stava tipsterite
        public void select_tipsters()
        {
            String queryTipsters = "SELECT * FROM Tipster";
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            OracleCommand command = new OracleCommand(queryTipsters, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader reader = command.ExecuteReader();
            listTipsters.Items.Clear();
            while (reader.Read())
            {
                Tipster tipster = new Tipster(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6), reader.GetString(7));
                if(tipster.Valid.Equals("y"))
                    listTipsters.Items.Add(tipster);
            }
            if (connection.State == ConnectionState.Open)
                connection.Close();
            listTipsters.SelectedIndex = 0;
        }

        //Gi menuva podatocite za tipsterot od desnata strana pri promena na selektiraniot indeks
        private void listTipsters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTipsters.SelectedIndex >= 0)
            {
                Tipster tipster = (Tipster)listTipsters.SelectedItem;
                lblUsernameData.Text = tipster.Username;
                lblPasswordData.Text = tipster.Password;
                lblNameData.Text = tipster.Name;
                lblSurnameData.Text = tipster.Surname;
                lblEmailData.Text = tipster.Email;
                lblRatingData.Text = String.Format("{0}", tipster.Rating);
            }
        }

        //Metod za baniranje na tipsterite
        private void btnBan_Click(object sender, EventArgs e)
        {
            if (listTipsters.SelectedIndex >= 0)
            {
                Tipster tipster = (Tipster)listTipsters.SelectedItem;
                String queryBan = "UPDATE Tipster SET valid = 'n' WHERE idTipster=" + tipster.IdTipster;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                OracleCommand command = new OracleCommand(queryBan, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                select_tipsters();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to change the time interval?", "Change time interval", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                String selected = (String) cbTime.SelectedItem;
                String time = selected.Substring(0, selected.Length-1);
                string hm = selected.Substring(selected.Length-1);
                int interval = Int32.Parse(time);
                if(hm.Equals("h")){
                    interval *= 60;
                }
                FormLogin.timeInterval = interval;

                String queryUpdateInterval = "UPDATE BasicInfo SET TIME_INTERVAL =" + interval;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                OracleCommand command = new OracleCommand(queryUpdateInterval, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            
        }
    }
}
