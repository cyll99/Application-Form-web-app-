using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Christ- Yan Love LAROSE
/// </summary>
namespace Etudiant
{   
    public partial class Default : System.Web.UI.Page
    {
        DateTime now = DateTime.Now;
        Employes employes;
        DataTable data;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqliteDataAccess.CreateIfNotExists();// create table 
            data = SqliteDataAccess.LoadData(); // load data from database
            this.BindGrid(); // bind data to gridview

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
            txtDateEmbauche.Text = String.Empty;
            txtDateNaissance.Text = String.Empty;
            txtTelephone.Text = String.Empty;
            txtEmail.Text = String.Empty;
            //DropSex.SelectedValue = (DropSex.SelectedItem).ToString();

            txtNomContact.Text = String.Empty;
            txtPrenomContact.Text = String.Empty;
            txtTelContact.Text = String.Empty;
            //DropLien.SelectedValue = (DropLien.SelectedItem).ToString();
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
                    if (letter != '-')
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
            TextBox[] texboxes = { txtNom, txtAdresse, txtDateNaissance,  txtTelephone, txtDateEmbauche, txtEmail, txtNomContact, txtPrenomContact, txtTelContact };
            foreach (TextBox textBox in texboxes)
            {
                if (textBox.Text.Length == 0)
                    return true;
            }
            if (txtPrenom1.Text.Length == 0 || txtPrenom2.Text.Length == 0)
                return false;
            return false;
        }





        protected void btnCancel_Click(object sender, EventArgs e)
        {
            EmptyBoxes();//clear all boxes
            Label1.Text = "";

        }

       

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!IfBoxEmpty()) //check if the required boxes contain valid informations
            {
                String nom = txtNom.Text.Trim().ToString();
                String adresse = txtAdresse.Text.Trim().ToString();
                String dateEmbauche = txtDateEmbauche.Text.Trim().ToString();
                String dateNaissance = txtDateNaissance.Text.Trim().ToString();
                String prenom1 = txtPrenom1.Text.Trim().ToString();
                String prenom2 = txtPrenom2.Text.Trim().ToString();
                String email = txtEmail.Text.Trim();
                String telephone = txtTelephone.Text.Trim();
                String sexe = DropSex.Text.Trim();

                String nomContact = txtNomContact.Text.Trim();
                String prenomContact = txtPrenomContact.Text.Trim();
                String telContact = txtTelContact.Text.Trim();
                String lien = DropLien.Text.Trim();


                ////check if the infos provided are valid
                String[] infos = { nom, prenom1, prenom2, nomContact, prenomContact };
                foreach (string info in infos)
                {
                    if (!VerifyLetter(info))
                    {
                        Label1.Text = $"L'information {info} n'est pas valide";
                        return;
                    }
                }
                

                //int Age = int.Parse(age);

                employes = new Employes(nom, prenom1, prenom2, sexe, email, adresse, dateNaissance, dateEmbauche, telephone, nomContact, prenomContact, lien, telContact); //initialization of the class
                SqliteDataAccess.SavePersonne(employes); // save employes in database

                string prenom = $"{employes.Prenom1} {employes.Prenom2}";

                //data.Rows.Add(new object[] {employes.Nom, prenom, employes.Age, employes.Telephone }); // add a new row to data
                BindGrid();//bind data


                EmptyBoxes(); //Empty all boxes 
                Label1.Text = "";

            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        /// <summary>
        /// Binding data to gridView
        /// </summary>
        private void BindGrid()
        {   
            GridView1.DataSource = data;
            GridView1.DataBind();
            
        }

    }
}