using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace gestionnaire_bibliotheque.CLASSES
{
    class AUTEUR
    {

        LA_BASE_DE_DONNEE.SGB_basededonnee db = new LA_BASE_DE_DONNEE.SGB_basededonnee();

        //création d'une fonction pour ajouter un nouvel(le) auteur(e)
        public Boolean ajouterauteur(string prenom, string nom, string education, string biographie)
        {
            string query = "INSERT INTO `auteurs`(`prenom`, `nom`, `education`, `biographie`) VALUES (@auteurs_prenom, @auteurs_nom, @auteurs_education, @auteurs_biographie)";

            MySqlParameter[] parameters = new MySqlParameter[4];
            //------------------------------------------------
            parameters[0] = new MySqlParameter("@auteurs_prenom", MySqlDbType.VarChar);
            parameters[0].Value = prenom;
            //------------------------------------------------
            parameters[1] = new MySqlParameter("@auteurs_nom", MySqlDbType.VarChar);
            parameters[1].Value = nom;
            //------------------------------------------------
            parameters[2] = new MySqlParameter("@auteurs_education", MySqlDbType.VarChar);
            parameters[2].Value = education;
            //------------------------------------------------
            parameters[3] = new MySqlParameter("@auteurs_biographie", MySqlDbType.VarChar);
            parameters[3].Value = biographie;
            //------------------------------------------------

            if (db.setData(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //création d'une fonction pour modifier un(e) auteur(e)
        public Boolean modifierauteur(int id, string prenom, string nom, string education, string biographie)
        {
            string query = "UPDATE `auteurs` SET `prenom`=@auteurs_prenom, `nom`=@auteurs_nom, `education`=@auteurs_education, `biographie`=@auteurs_biographie WHERE `id`=@auteurs_id";
            MySqlParameter[] parameters = new MySqlParameter[5];
            //------------------------------------------------
            parameters[0] = new MySqlParameter("@auteurs_prenom", MySqlDbType.VarChar);
            parameters[0].Value = prenom;
            //------------------------------------------------
            parameters[1] = new MySqlParameter("@auteurs_nom", MySqlDbType.VarChar);
            parameters[1].Value = nom;
            //------------------------------------------------
            parameters[2] = new MySqlParameter("@auteurs_education", MySqlDbType.VarChar);
            parameters[2].Value = education;
            //------------------------------------------------
            parameters[3] = new MySqlParameter("@auteurs_biographie", MySqlDbType.VarChar);
            parameters[3].Value = biographie;
            //------------------------------------------------
            parameters[4] = new MySqlParameter("@auteurs_id", MySqlDbType.Int32);
            parameters[4].Value = id;
            //------------------------------------------------

            if (db.setData(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //création d'une fonction pour supprimer un(e) auteur(e)
        public Boolean supprimerauteur(int id)
        {
            string query = "DELETE FROM `auteurs` WHERE `id` = @id";

            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@id", MySqlDbType.Int32);
            parameters[0].Value = id;

            if (db.setData(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //crétation d'une fonction pour retourner au tableau des genres
        public DataTable listeauteurs(Boolean display_nomcomplet)
        {
            string query = "SELECT * FROM `auteurs`";

            if(display_nomcomplet)
            {
                query = "SELECT `id`, Concat(`prenom`, ' ', `nom`) as nomcomplet, `education`, `biographie` FROM `auteurs`";
            }
            DataTable table = new DataTable();
            table = db.GetData(query, null);
            return table;
        }
        //crétation d'une fonction pour avoir les auteurs par l'ID
        public DataTable avoirAuteurparId(int id)
        {
            string query = "SELECT * FROM `auteurs` WHERE id = @id";

            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@id", MySqlDbType.Int32);
            parameters[0].Value = id;

            query = "SELECT `id`, Concat(`prenom`, ' ', `nom`) as nomcomplet, `education`, `biographie` FROM `auteurs`";
       
            DataTable table = new DataTable();
            table = db.GetData(query, parameters);
            return table;
        }
    }
}
