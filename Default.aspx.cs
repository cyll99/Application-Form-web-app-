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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}