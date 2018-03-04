using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public class Classe
    {

        MySqlConnection connexion = new MySqlConnection("database=gsb_frais; server=localhost; user id=root");
        public void selectionFiche()
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;
            command.CommandText = "SELECT * FROM fichefrais";


        }

        public void selectionFicheMoisPrecedent()
        {
            MySqlCommand commandSelectFiche = new MySqlCommand();
            string moisPrecedent = getMoisPrecedent();
            string annee = getAnnee();

            string moisSelectionner = annee + moisPrecedent;
            commandSelectFiche.Connection = connexion;
            commandSelectFiche.CommandText = "SELECT * FROM fichefrais where mois='" + moisSelectionner + "'";

       

        }

        public void miseAJourFicheValidation()
        {
            MySqlCommand commandSelectFiche = new MySqlCommand();
            string moisPrecedent = getMoisPrecedent();
            string annee = getAnnee();

            string moisSelectionner = annee + moisPrecedent;

            commandSelectFiche.Connection = connexion;
            commandSelectFiche.CommandText = "UPDATE fichefrais SET idEtat='CL' WHERE mois='" + moisSelectionner + "'";

            commandSelectFiche.ExecuteNonQuery();

        }

        public void miseAJourFicheRemboursement()
        {
            MySqlCommand commandSelectFiche = new MySqlCommand();
            string moisPrecedent = getMoisPrecedent();
            string annee = getAnnee();

            string moisSelectionner = annee + moisPrecedent;

            commandSelectFiche.Connection = connexion;
            commandSelectFiche.CommandText = "UPDATE fichefrais SET idEtat='RB' WHERE mois='" + moisSelectionner + "' AND idEtat='VA'";

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
    }
}
