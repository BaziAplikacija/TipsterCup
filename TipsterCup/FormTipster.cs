﻿using System;
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
        int idTipster;
        public FormAllTipsters frmParent;
        private Bitmap bgImage;

        public FormTipster(int idTipster)
        {
            this.idTipster = idTipster;
            InitializeComponent();
            bgImage = new Bitmap("bgFootballStadium.jpg");
            
        }

        private void FormTipster_Load(object sender, EventArgs e)
        {
            lblUser.Text = FormLogin.translator["Username " + FormLogin.currLanguage];
            lblFirst.Text = FormLogin.translator["FirstName " + FormLogin.currLanguage];
            lblSur.Text = FormLogin.translator["LastName " + FormLogin.currLanguage];
            lblE.Text = FormLogin.translator["Email " + FormLogin.currLanguage];
            lblM.Text = FormLogin.translator["Money " + FormLogin.currLanguage];
            btnTransaction.Text = FormLogin.translator["SendMoney " + FormLogin.currLanguage];
            using (OracleConnection conn = new OracleConnection(FormLogin.connString))
            {
                conn.Open();

                string query = "select * from Tipster where idTipster = " + idTipster;
                OracleCommand command = new OracleCommand(query, conn);
                command.CommandType = CommandType.Text;

                OracleDataReader reader = command.ExecuteReader();
                reader.Read();

                lblUsername.Text = reader.GetString(1);
                lblFirstName.Text = reader.GetString(3);
                lblSurname.Text = reader.GetString(4);
                lblMoney.Text = reader.GetInt32(5).ToString();
                lblEmail.Text = reader.GetString(6);
                
                query = "select COUNT(*) + 1 FROM Tipster WHERE Money > " + Int32.Parse(lblMoney.Text);

                command = new OracleCommand(query, conn);
                command.CommandType = CommandType.Text;

                lblRank.Text = command.ExecuteScalar().ToString();

                reader.Close();

            }
            
            if (idTipster != FormLogin.IdLoggedTipster)
            {
                btnTransaction.Visible = true;
            }
            else
            {
                changeView();
            }

            setDataGrid();

        }

        private void setDataGrid()
        {
            
            DataTable table = new DataTable();
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                String query = "SELECT c.description as Tip, c.value as Coefficient, r.homeTeam as HomeTeam, r.goalshome || ' - ' || r.goalsguest as Result, r.guestteam as GuestTeam"
                    + " FROM Computegain c JOIN Results r ON (c.idMatch = r.idMatch) WHERE c.idTipster = "+idTipster;
                OracleDataAdapter adapter = new OracleDataAdapter(query, connection);
                adapter.Fill(table);
                
            }
            dataGrid.DataSource = table;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGrid.AutoSize = true;
            dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGrid.Columns["Tip"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dataGrid.Columns["HomeTeam"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dataGrid.Columns["GuestTeam"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            dataGrid.Columns["GuestTeam"].HeaderText = "Guest Team";
            dataGrid.Columns["HomeTeam"].HeaderText = "Home Team";
            dataGrid.Columns["Tip"].HeaderText = "Tip";
            dataGrid.Columns["Coefficient"].HeaderText = "Coefficient";
            dataGrid.Columns["Result"].HeaderText = "Result";
            
            
        }


        private void changeView()
        {
            lblUsername.Location = new Point(200, 50);
            lblFirstName.Location = new Point(200, lblUsername.Location.Y+50);
            lblSurname.Location = new Point(200, lblUsername.Location.Y+100);
            lblEmail.Location = new Point(200, lblUsername.Location.Y+150);
            lblMoney.Location = new Point(200, lblUsername.Location.Y+200);
            lblRank.Location = new Point(200, lblUsername.Location.Y+250);

            lblUser.Location = new Point(50, lblUsername.Location.Y);
            lblFirst.Location = new Point(50, lblUsername.Location.Y+50);
            lblSur.Location = new Point(50, lblUsername.Location.Y+100);
            lblE.Location = new Point(50, lblUsername.Location.Y + 150);
            lblM.Location = new Point(50, lblUsername.Location.Y + 200);
            lblR.Location = new Point(50, lblUsername.Location.Y + 250);

            Color color = Color.FromArgb(255, 255, 255);
            lblUsername.ForeColor = color;
            lblFirstName.ForeColor = color;
            lblSurname.ForeColor = color;
            lblEmail.ForeColor = color;
            lblMoney.ForeColor = color;
            lblRank.ForeColor = color;

            lblUser.ForeColor = color;
            lblFirst.ForeColor = color;
            lblSur.ForeColor = color;
            lblE.ForeColor = color;
            lblM.ForeColor = color;
            lblR.ForeColor = color;

            lblUsername.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
            lblFirstName.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
            lblSurname.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
            lblEmail.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
            lblMoney.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
            lblRank.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);

            lblUser.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
            lblFirst.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
            lblSur.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
            lblE.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
            lblM.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
            lblR.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);

            pictureBox1.Dispose();
            pictureBox2.Dispose();
            pictureBox3.Dispose();

            dataGrid.Location = new Point(this.Width - dataGrid.Width - 100, dataGrid.Location.Y);
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            FormTransaction frmTrans = new FormTransaction(this.idTipster,this.lblUsername.Text);
            frmTrans.frmParent = this;
            frmTrans.ShowDialog();

            if (frmParent != null)
            {
                frmParent.callLoad();
            }
            
        }

        private void FormTipster_Paint(object sender, PaintEventArgs e)
        {
            if (idTipster == FormLogin.IdLoggedTipster)
            {
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawImage(bgImage, 0, 0, this.Width, this.Height);
            }
        }



    }
}
