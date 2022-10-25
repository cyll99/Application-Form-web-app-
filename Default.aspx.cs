using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Etudiant
{
    public partial class Default : System.Web.UI.Page
    {
        DateTime now = DateTime.Now;
        Personne personne;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqliteDataAccess.CreateIfNotExists();
            this.BindGrid();

        }

       
        /// <summary>
        /// Enable save button after filling required text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnableButton(object sender, EventArgs e)
        {

            if (!IfBoxEmpty())
                btnSave.Enabled = true;


        }

        /// <summary>
        /// Mehode to clear text box
        /// </summary>
        public void EmptyBoxes()
        {
            txtAdresse.Text = String.Empty;
            txtNom.Text = String.Empty;
            txtPrenom1.Text = String.Empty;
            txtPrenom2.Text = String.Empty;
            txtVille.Text = String.Empty;
            txtPays.Text = String.Empty;
            txtAge.Text = String.Empty;
            txtTelephone.Text = String.Empty;
            txtNationalite.Text = String.Empty;
            txtNom.Focus();

        }

        /// <summary>
        /// Methode to check if a string contains only letters
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool VerifyLetter(string word)
        {
            string trim = String.Concat(word.Where(c => !Char.IsWhiteSpace(c)));//delete all spaces

            foreach (char letter in trim)
            {
                if (!Char.IsLetter(letter))
                    return false;
            }
            return true;
        }


        /// <summary>
        /// Methode to verify if the text boxes are empty.
        /// </summary>
        /// <returns></returns>
        public bool IfBoxEmpty()
        {
            TextBox[] texboxes = { txtNom, txtAdresse, txtAge, txtNationalite, txtTelephone, txtVille, txtPays };
            foreach (TextBox textBox in texboxes)
            {
                if (textBox.Text.Length == 0)
                    return true;
            }
            if (txtPrenom1.Text.Length == 0 || txtPrenom2.Text.Length == 0)
                return false;
            return false;
        }




        /// <summary>
        /// Methode to check if infos are valid
        /// </summary>
        /// <returns></returns>
        public bool ValidInfos()
        {
            TextBox[] texboxes = { txtNom, txtAdresse, txtNationalite, txtVille, txtPays };
            foreach (TextBox textBox in texboxes)
            {
                if (!VerifyLetter(textBox.Text.Trim().ToString()))
                    return false;
            }
            if (!VerifyLetter(txtPrenom1.Text.Trim().ToString()) || !VerifyLetter(txtPrenom2.Text.Trim().ToString()))
                return false;
            else if (VerifyLetter(txtAge.Text.Trim()))
                return false;
            else if (VerifyLetter(txtTelephone.Text.Trim()))
                return false;
            else if (int.Parse(txtAge.Text.Trim()) < 0 && 150 < int.Parse(txtAge.Text.Trim()))
                return false;
            return true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            EmptyBoxes();//clear all boxes

        }

       

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!IfBoxEmpty()) //check if the required boxes contain valid informations
            {
                String nom = txtNom.Text.Trim().ToString();
                String adresse = txtAdresse.Text.Trim().ToString();
                String nationalite = txtNationalite.Text.Trim().ToString();
                String ville = txtVille.Text.Trim().ToString();
                String pays = txtPays.Text.Trim().ToString();
                String prenom1 = txtPrenom1.Text.Trim().ToString();
                String prenom2 = txtPrenom2.Text.Trim().ToString();
                String age = txtAge.Text.Trim();
                String telephone = txtTelephone.Text.Trim();
                String dateCree = $"{now.Day} / {now.Month} / {now.Year}";


                ////check if the infos provided are valid
                //String[] infos = { nom, prenom1, prenom2, adresse, ville, pays, nationalite };
                //foreach (string info in infos)
                //{
                //    if (!VerifyLetter(info))
                //    {
                //        MessageBox.Show($"L'information {info} n'est pas valide");
                //        return;
                //    }
                //}
                //if (VerifyLetter(age))
                //{
                //    MessageBox.Show($"L'age ne doit pas contenir de lettre");
                //    return;
                //}
                //if (VerifyLetter(telephone))
                //{
                //    MessageBox.Show($"Le numero de telephone ne doit pas contenir de lettre");
                //    return;
                //}
                //string trim = String.Concat(telephone.Where(c => !Char.IsWhiteSpace(c)));//delete all spaces
                //if (trim.Length < 8)
                //{
                //    MessageBox.Show($"Le numero de telephone local doit avoir au moins huit chiffres.");
                //    return;
                //}
                int Age = int.Parse(age);

                personne = new Personne(nom, prenom1, prenom2, Age, nationalite, adresse, ville, pays, telephone, dateCree); //initialization of the class
                SqliteDataAccess.SavePersonne(personne);



                //personnes.Add(personne); // add personne to the list


                //// setting infos to display
                //String prenom = personne.Prenom1 + " " + personne.Prenom2;
                //nom = personne.Nom;
                //age = personne.Age.ToString();
                //telephone = personne.Telephone;

                //// set up list view items 
                //ListViewItem listviewItem = new ListViewItem();
                //listviewItem.Text = nom;
                //listviewItem.SubItems.Add(prenom);
                //listviewItem.SubItems.Add(age);
                //listviewItem.SubItems.Add(telephone);
                //listView.Items.Add(listviewItem);

                //// add data to file to display later
                //using (StreamWriter sw = new StreamWriter(DATA_TO_DISPLAY, true, Encoding.UTF8))
                //{
                //    sw.WriteLine($"{nom},{prenom},{age},{telephone},{nationalite},{pays},{ville},{adresse},{dateCree}");
                //}


                EmptyBoxes(); //Empty all boxes 

            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        
        private void BindGrid()
        {
            GridView1.DataSource = SqliteDataAccess.LoadData();
            GridView1.DataBind();
        }
    }
}