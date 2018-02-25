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
        public static string getMoisPrecedent()
        {
            string moisPrecedent = DateTime.Now.AddMonths(-1).ToString("MM");

            return moisPrecedent;
        }

        public static DateTime getMoisPrecedent(DateTime date)
        {
            DateTime moisPrecedent = date.AddMonths(-1);
            return moisPrecedent;
        }

        public static string getMoisSuivant()
        {
            string moisSuivant = DateTime.Now.AddMonths(+1).ToString("MM");

            return moisSuivant;
        }

        public static DateTime getMoisSuivant(DateTime date)
        {
            DateTime moisSuivant = date.AddMonths(+1);
            return moisSuivant;
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


         // string moisPrecedent = getMoisPrecedent();
            /// MessageBox.Show(moisPrecedent);

            //   DateTime uneDate = DateTime.Now;

            //     DateTime moisPrecedentDerive = getMoisPrecedent(uneDate);

            //    MessageBox.Show(moisPrecedentDerive.ToString());

            string moisSuivant = getMoisSuivant();

            MessageBox.Show(moisSuivant);

            DateTime uneDate = DateTime.Now;

            DateTime moisSuivantDerive = getMoisSuivant(uneDate);

            MessageBox.Show(moisSuivantDerive.ToString());

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
