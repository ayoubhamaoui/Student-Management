using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EtbUniv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private NpgsqlConnection conn;
        private DataTable dt;
        private NpgsqlCommand cmd;
        private string sql=null;

        string connString = String.Format("Host=ec2-46-137-121-216.eu-west-1.compute.amazonaws.com;Port=5432;Username=nyxhqyqvzpibqg;" +
            "Password=69f8f8d49c0c6fbaab9c308eb29160fe89315931cf31d1cbb6aaef9551406c19;Database=d962e9j6valh02;" +
            "Pooling=true;Use SSL Stream=True;SSL Mode=Require;TrustServerCertificate=True;"
            );



        private void btnAjouter_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connString);
            btnSelect.PerformClick(); //load all student
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                dgvData.DataSource = null;
                //load all student from table 'eleve'
                conn.Open();
                sql = "Select * from eleve";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvData.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, " FAIL !!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                conn.Close();
            }
        }
    }
}
