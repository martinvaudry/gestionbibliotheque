using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestionnaire_bibliotheque.FORMULAIRES
{
    public partial class liste_auteurs_formulaire : Form
    {
        private gestion_livres_formulaire gestlivres = null;

        public liste_auteurs_formulaire(gestion_livres_formulaire sourceForm)
        {
            gestlivres = sourceForm as gestion_livres_formulaire;
            InitializeComponent();
        }

        
        private void Label_fermeture_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Montrer la liste des auteurs dans la fenêtre
        private void liste_auteurs_formulaire_Load(object sender, EventArgs e)
        {
            CLASSES.AUTEUR auteur = new CLASSES.AUTEUR();
            listBox_auteurs.DataSource = auteur.listeauteurs(true);
            listBox_auteurs.DisplayMember = "nomcomplet";
            listBox_auteurs.ValueMember = "id";
        }
        //Bouton pour sélectionner l'auteur(e) et fermer la fenêtre
        private void bouton_selection_fermer_Click(object sender, EventArgs e)
        {

            try
            {
                //Sélectionner l'auteur(e)
                DataRowView drv = (DataRowView)listBox_auteurs.SelectedItem;
                string nomcomplet = drv["nomcomplet"].ToString();
                string id = drv["id"].ToString();

                //montrer le id et le nom complet en mode Ajouter (panel)
                gestlivres.texte_auteur_nomcomplet.Text = nomcomplet;
                gestlivres.label_auteur_id.Text = id;

                //montrer le id et le nom complet en mode Modifier (panel)
                gestlivres.textBox_auteur_modifier.Text = nomcomplet;
                gestlivres.label_auteur_id_modifier.Text = id;

             //vérifier qu'un(e) auteur(e) est bien sélectionné(e)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aucun auteur(e) sélectionné(e)!" + ex.Message);
            }

            //fermer la fenêtre
            this.Close();
        }

        private void listBox_auteurs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
