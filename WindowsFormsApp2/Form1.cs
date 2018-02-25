using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient; 




namespace WindowsFormsApp2
{

    

    public partial class Form1 : Form
    {
        void SayHello()
        {
            MessageBox.Show("coucou");
        }
        MySqlConnection connexion = new MySqlConnection("database=gsb_frais; server=localhost; user id=root");

        public Form1()
        {
            InitializeComponent();


            try
            {
                connexion.Open();
                MessageBox.Show("Connecté");
            }
            catch(MySqlException co)
            {
                MessageBox.Show(co.ToString());
                MessageBox.Show("Erreur");
            }

            SayHello(); 
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;
            command.CommandText = "SELECT prenom FROM visiteur";

            DataTable data = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(data);

            dataGridView1.DataSource = data; 
        }
    }
}
