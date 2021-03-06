﻿using System;
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

        public void selectionFiche()
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;
            command.CommandText = "SELECT * FROM fichefrais";

            DataTable data = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(data);

            dataGridView1.DataSource = data;

        }

        public void selectionFicheMoisPrecedent()
        {
            MySqlCommand commandSelectFiche = new MySqlCommand();
            string moisPrecedent = getMoisPrecedent();
            string annee = getAnnee();

            string moisSelectionner = annee + moisPrecedent;
            commandSelectFiche.Connection = connexion;
            commandSelectFiche.CommandText = "SELECT * FROM fichefrais where mois='"+moisSelectionner+"'";
            
            DataTable dataFiche = new DataTable();

            MySqlDataAdapter adapterFiche = new MySqlDataAdapter(commandSelectFiche);

            adapterFiche.Fill(dataFiche);

            dataGridView1.DataSource = dataFiche;
             
        }

        public void miseAJourFicheValidation()
        {
            MySqlCommand commandSelectFiche = new MySqlCommand();
            string moisPrecedent = getMoisPrecedent();
            string annee = getAnnee();

            string moisSelectionner = annee + moisPrecedent;

            commandSelectFiche.Connection = connexion;
            commandSelectFiche.CommandText = "UPDATE fichefrais SET idEtat='CL' WHERE mois='"+moisSelectionner+"'";

            commandSelectFiche.ExecuteNonQuery(); 

        }

        public void miseAJourFicheRemboursement() 
        {
            MySqlCommand commandSelectFiche = new MySqlCommand();
            string moisPrecedent = getMoisPrecedent();
            string annee = getAnnee();

            string moisSelectionner = annee + moisPrecedent;

            commandSelectFiche.Connection = connexion;
            commandSelectFiche.CommandText = "UPDATE fichefrais SET idEtat='RB' WHERE mois='"+moisSelectionner+"' AND idEtat='VA'";

            commandSelectFiche.ExecuteNonQuery();
        }

        public static string getAnnee()
        {
            string annee; 

            if (DateTime.Now.ToString("MM") != "01")
            {
                 annee = DateTime.Now.ToString("yyyy");
            }

            else
            {
                 annee = DateTime.Now.AddMonths(-1).ToString("yyyy");
            }

            return annee;

        }

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

        public static Boolean entre(int jour1, int jour2)
        {
            DateTime dateActuel = DateTime.Now;
            int jour = dateActuel.Day;

            if (jour >= jour1 && jour <= jour2)
            {

                return true;
            }
            else
            {
                return false; 
            }
        }
        

        public static Boolean entre(int jour1, int jour2, DateTime dateTest)
        {
            int jour = dateTest.Day;

            if (jour >= jour1 && jour <= jour2)
            {

                return true;
            }
            else
            {
                return false;
            }
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

            // string moisSuivant = getMoisSuivant();

            //  MessageBox.Show(moisSuivant);

            //   DateTime uneDate = DateTime.Now;

            //  DateTime moisSuivantDerive = getMoisSuivant(uneDate);

            //  MessageBox.Show(moisSuivantDerive.ToString());

           // int jour1 = 2, jour2 = 25;
          //  DateTime date = DateTime.Now; 

          //  Boolean jourEntre = entre(jour1, jour2); 

            //    if(jourEntre == true)
            //   {
            //        MessageBox.Show("Le jour est entre");
            //   }
            //  else if(jourEntre == false) 
            //  {
            //      MessageBox.Show("Le jour n'est pas entre");
            //   }

           /* Boolean jourEntre = entre(jour1, jour2, date);

            if (jourEntre == true)
            {
                MessageBox.Show("Le jour est entre");
            }
            else if (jourEntre == false)
            {
                MessageBox.Show("Le jour n'est pas entre");
            }

     */
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

           // selectionFiche();

            selectionFiche();
            if (entre(1, 10))
            {
                MessageBox.Show("Le jour est entre");
                miseAJourFicheValidation();
                selectionFiche(); 
            }
            else if(entre(20,25))
            {
                MessageBox.Show("remboursé");
                miseAJourFicheRemboursement();
                selectionFiche();
            }
            else
            {
                MessageBox.Show("Le jour n'est pas entre");

            }
            // miseAJourFiche();
        }
    }
}
