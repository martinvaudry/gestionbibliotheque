using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace gestionnaire_bibliotheque.CLASSES
{
    class LIVRES
    {
        LA_BASE_DE_DONNEE.SGB_basededonnee db = new LA_BASE_DE_DONNEE.SGB_basededonnee();

        //Création d'une fonction pour ajouter un nouveau livre
        public Boolean ajouterlivre(string isbn, string titre, int genre_id, int auteur_id, int quantite, int pages, double prix, string publie, DateTime date_recu, string description, byte[] pochette)
        {
            string query = "INSERT INTO `livres`(`isbn`, `titre`, `genre_id`, `auteur_id`, `quantite`, `pages`,`prix`, `publie`, `date_recu`, `description`, `pochette`) VALUES (@livres_isbn, @livres_titre, @livres_genre_id, @livres_auteur_id, @livres_quantite, @livres_pages, @livres_prix, @livres_publie, @livres_date_recu, @livres_description, @livres_pochette)";

            MySqlParameter[] parameters = new MySqlParameter[11];
            
            //------------------------------------------------
            parameters[0] = new MySqlParameter("@livres_isbn", MySqlDbType.VarChar);
            parameters[0].Value = isbn;
            //------------------------------------------------
            parameters[1] = new MySqlParameter("@livres_titre", MySqlDbType.VarChar);
            parameters[1].Value = titre;
            //------------------------------------------------
            parameters[2] = new MySqlParameter("@livres_genre_id", MySqlDbType.Int32);
            parameters[2].Value = genre_id;
            //------------------------------------------------
            parameters[3] = new MySqlParameter("@livres_auteur_id", MySqlDbType.Int32);
            parameters[3].Value = auteur_id;
            //------------------------------------------------
            parameters[4] = new MySqlParameter("@livres_quantite", MySqlDbType.Int32);
            parameters[4].Value = quantite;
            //------------------------------------------------
            parameters[5] = new MySqlParameter("@livres_pages", MySqlDbType.Int64);
            parameters[5].Value = pages;
            //------------------------------------------------
            parameters[6] = new MySqlParameter("@livres_prix", MySqlDbType.Double);
            parameters[6].Value = prix;
            //------------------------------------------------
            parameters[7] = new MySqlParameter("@livres_publie", MySqlDbType.VarChar);
            parameters[7].Value = publie;
            //------------------------------------------------
            parameters[8] = new MySqlParameter("@livres_date_recu", MySqlDbType.Date);
            parameters[8].Value = date_recu;
            //------------------------------------------------
            parameters[9] = new MySqlParameter("@livres_description", MySqlDbType.VarChar);
            parameters[9].Value = description;
            //------------------------------------------------
            parameters[10] = new MySqlParameter("@livres_pochette", MySqlDbType.Blob);
            parameters[10].Value = pochette;
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

        //Création d'une fonction pour modifier un livre
        public Boolean modifierlivre(int id, string isbn, string titre, int genre_id, int auteur_id, int quantite, int pages, double prix, string publie, DateTime date_recu, string description, byte[] pochette)
        {
            string query = "UPDATE `livres` SET `isbn` =@livres_isbn, `titre` =@livres_titre, `genre_id` =@genre_id, `auteur_id` =@livres_auteur_id, `quantite` =@livres_quantite, `pages` =@livres_pages, `prix` =@livres_prix, `publie` =@livres_publie, `date_recu` =@livres_date_recu, `description` =@livres_description, `pochette` =@livres_pochette WHERE `id` =@livres_id";

            MySqlParameter[] parameters = new MySqlParameter[12];
            //------------------------------------------------
            parameters[0] = new MySqlParameter("@livres_isbn", MySqlDbType.VarChar);
            parameters[0].Value = isbn;
            //------------------------------------------------
            parameters[1] = new MySqlParameter("@livres_titre", MySqlDbType.VarChar);
            parameters[1].Value = titre;
            //------------------------------------------------
            parameters[2] = new MySqlParameter("@livres_genre_id", MySqlDbType.Int32);
            parameters[2].Value = genre_id;
            //------------------------------------------------
            parameters[3] = new MySqlParameter("@livres_auteur_id", MySqlDbType.Int32);
            parameters[3].Value = auteur_id;
            //------------------------------------------------
            parameters[4] = new MySqlParameter("@livres_quantite", MySqlDbType.Int32);
            parameters[4].Value = quantite;
            //------------------------------------------------
            parameters[5] = new MySqlParameter("@livres_pages", MySqlDbType.Int64);
            parameters[5].Value = pages;
            //------------------------------------------------
            parameters[6] = new MySqlParameter("@livres_prix", MySqlDbType.Double);
            parameters[6].Value = prix;
            //------------------------------------------------
            parameters[7] = new MySqlParameter("@livres_publie", MySqlDbType.VarChar);
            parameters[7].Value = publie;
            //------------------------------------------------
            parameters[8] = new MySqlParameter("@livres_date_recu", MySqlDbType.Date);
            parameters[8].Value = date_recu;
            //------------------------------------------------
            parameters[9] = new MySqlParameter("@livres_description", MySqlDbType.VarChar);
            parameters[9].Value = description;
            //------------------------------------------------
            parameters[10] = new MySqlParameter("@livres_pochette", MySqlDbType.Blob);
            parameters[10].Value = pochette;
            //------------------------------------------------
            parameters[11] = new MySqlParameter("@livres_id", MySqlDbType.Int32);
            parameters[11].Value = id;
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
        //Création d'une fonction pour supprimer un livre
        public Boolean supprimerlivre(int id)
        {
            string query = "DELETE FROM `livres` WHERE `id` = @id";

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
        //création d'une fonction pour retourner au tableau des livres
        public DataTable listelivres()
        {
            string query = "SELECT * FROM `livres` ORDER BY id DESC";

            DataTable table = new DataTable();
            table = db.GetData(query, null);
            return table;
        }
        // Vérifier si le ISBN existe déjà
        public Boolean IsisbnExists(string isbn, int id)
        {
            string query = "SELECT * FROM `livres` WHERE `isbn` = @isbn AND id <> @id";

            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@isbn", MySqlDbType.VarChar);
            parameters[0].Value = isbn;
            parameters[1] = new MySqlParameter("@id", MySqlDbType.Int32);
            parameters[1].Value = id;

            DataTable table = new DataTable();
            table = db.GetData(query, parameters);
            if(table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
        // Vérifier si le titre existe déjà
        public Boolean TitreExists(string titre, int id)
        {
            string query = "SELECT * FROM `livres` WHERE `titre` = @titre AND id <> @id";

            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@titre", MySqlDbType.VarChar);
            parameters[0].Value = titre;
            parameters[1] = new MySqlParameter("@id", MySqlDbType.Int32);
            parameters[1].Value = id;

            DataTable table = new DataTable();
            table = db.GetData(query, parameters);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        // Recherche un libre par ID ou ISBN
        public DataTable cherche_LivrePar_IDouISBN(string id_ou_isbn, int id, string isbn )
        {
            string query;

            MySqlParameter[] parameters = new MySqlParameter[1];

            if (id_ou_isbn.Equals("id"))
            {
                query = "SELECT * FROM `livres` WHERE `id` = @id";
                parameters[0] = new MySqlParameter("@id", MySqlDbType.Int32);
                parameters[0].Value = id;
            }
            else
            {
                query = "SELECT * FROM `livres` WHERE `isbn` = @isbn";
                parameters[0] = new MySqlParameter("@isbn", MySqlDbType.VarChar);
                parameters[0].Value = isbn;
            }

            DataTable table = new DataTable();
            table = db.GetData(query, parameters);

            return table;

        }
    }
    
}
