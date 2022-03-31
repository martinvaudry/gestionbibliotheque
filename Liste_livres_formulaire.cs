using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestionnaire_bibliotheque.FORMULAIRES
{
    public partial class Liste_livres_formulaire : Form
    {
        public Liste_livres_formulaire()
        {
            InitializeComponent();
        }
        //ouverture de la fenêtre
        private void Liste_livres_formulaire_Load(object sender, EventArgs e)
        {
            // montrer la liste de livres des auteurs dans la listview
            CLASSES.LIVRES livre = new CLASSES.LIVRES();
            DataTable listelivres = livre.listelivres();

            ListViewItem[] items = new ListViewItem[listelivres.Rows.Count];
            String[] titres = new String[listelivres.Rows.Count];


            //loop pour générer les titres et images
            for(int i = 0; i < listelivres.Rows.Count; i++)
            {
                byte[] listePochette = (byte[])listelivres.Rows[i][10];
                MemoryStream ms = new MemoryStream(listePochette);
               
                //ajout de l'image dans la liste d'images
                imageList_pochette_livre.Images.Add(Image.FromStream(ms)); 

                //ajout du titre dans le array titre
                titres[i] = listelivres.Rows[i][2].ToString(); 
            }

             listView_listeDeLivres.View = View.LargeIcon;
             imageList_pochette_livre.ImageSize = new Size(200, 250);
             listView_listeDeLivres.LargeImageList = imageList_pochette_livre;

            // loop pour montrer le data dans la listview

            for (int j = 0; j < imageList_pochette_livre.Images.Count; j++)
            {
                listView_listeDeLivres.Items.Add(new ListViewItem() { Text = titres[j], ImageIndex = j });
            }
         

        }
        //Bouton fermer la fenêtre
            private void Label_fermeture_Click(object sender, EventArgs e)
            {
             this.Close();
            }
    }
}
