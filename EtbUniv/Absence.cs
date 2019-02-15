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
    public partial class Absence : Form
    {

        private NpgsqlConnection conn;
        //private DataTable dt;
        private NpgsqlCommand cmd;
        private NpgsqlCommand cmdTest;
        private string sql = null;

        string connString = String.Format("Host=ec2-46-137-121-216.eu-west-1.compute.amazonaws.com;Port=5432;Username=nyxhqyqvzpibqg;" +
            "Password=69f8f8d49c0c6fbaab9c308eb29160fe89315931cf31d1cbb6aaef9551406c19;Database=d962e9j6valh02;" +
            "Pooling=true;Use SSL Stream=True;SSL Mode=Require;TrustServerCertificate=True;"
            );

        public Absence()
        {
            InitializeComponent();
        }



        private void Absence_Load(object sender, EventArgs e)
        {
            nSemaine.Items.AddRange(Enumerable.Range(1, 100).Select(i => (object)i).ToArray());
            conn = new NpgsqlConnection(connString);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            //ajouter nbh d'absence
            try
            {
                conn.Open();

                //cmdTest = new NpgsqlCommand("Select *  from ab_existe(" + txtID + ");"); 
                sql = "Select * from ab_insert(:_nSemaine,:_cne,:_nbAbsence)";
                cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("_nSemaine", Int32.Parse(nSemaine.Text));
                cmd.Parameters.AddWithValue("_cne", Int32.Parse(txtID.Text));
                cmd.Parameters.AddWithValue("_nbAbsence", Int32.Parse(txtAbs.Text));

                

                if ((int)cmd.ExecuteScalar() == 1)
                {
                    conn.Close();
                    MessageBox.Show("Operation bien effectuer", "Ajouter absense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "INSERT FAIL !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }
    }
}
