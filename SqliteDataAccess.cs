using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Dapper;
using static System.Net.Mime.MediaTypeNames;
/// <summary>
/// Christ- Yan Love LAROSE
/// </summary>
namespace Etudiant
{
    class SqliteDataAccess
    {
        //static string conn = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        static string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location; // path of the exe file
        static string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath); // working directory
        static string dataFilePath = System.IO.Path.Combine(strWorkPath, "CRECH.db"); // path database file

        //static string conn = $"Data Source={dataFilePath};Version=3"; // connection string
       
        static string conn = $"Data Source=C:\\Users\\cyllx\\Documents\\CRECH.DB; Version=3";

        static long idEmployes;


        /// <summary>
        /// Create a table in the database
        /// </summary>
        public static void CreateIfNotExists()
        {
            using (IDbConnection cnn = new SQLiteConnection(conn))
            {

                var query = "CREATE TABLE employes (ID INTEGER NOT NULL DEFAULT 1000 UNIQUE, nom TEXT NOT NULL, prenom TEXT NOT NULL, sexe TEXT NOT NULL, dateNaissance TEXT NOT NULL, dateEmbauche TEXT NOT NULL, nomContact TEXT NOT NULL, prenomContact TEXT NOT NULL, lien TEXT NOT NULL, telephone TEXT NOT NULL UNIQUE, telephoneContact TEXT NOT NULL, adresse TEXT NOT NULL, email TEXT NOT NULL UNIQUE, UNIQUE(nom, prenom), PRIMARY KEY(ID AUTOINCREMENT))";

                // Creation of table promotion in Crech

                var query2 = "CREATE TABLE IF NOT EXISTS parcours_crech(ID INTEGER NOT NULL, departement TEXT NOT NULL, poste TEXT NOT NULL, debut TEXT NOT NULL, FOREIGN KEY(ID) REFERENCES employes(ID))";

                // Creation of table parcours professionnel

                var query3 = "CREATE TABLE IF NOT EXISTS parcours_prof (ID INTEGER NOT NULL, detention TEXT NOT NULL, discipline TEXT NOT NULL, date TEXT NOT NULL, FOREIGN KEY(ID) REFERENCES employes(ID))";
                //Console.WriteLine("BASE DE DONNEE"+strExeFilePath);
                cnn.Execute(query, new DynamicParameters());
                cnn.Execute(query2 , new DynamicParameters());
                cnn.Execute(query3 , new DynamicParameters());
            }
        }
        /// <summary>
        /// Load employes from database
        /// </summary>
        /// <returns> List of films</returns>
        public static DataTable LoadData()
        {
            DataTable dt;

            using (SQLiteConnection cnn = new SQLiteConnection(conn))
            {

                var query = "select nom, prenom, sexe, telephone from employes";
                cnn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(query))
                {
                    using (SQLiteDataAdapter sda = new SQLiteDataAdapter())
                    {
                        cmd.Connection = cnn;
                        sda.SelectCommand = cmd;
                        using (dt = new DataTable())
                        {
                            sda.Fill(dt);


                        }
                    }
                }



                return dt;
            }

        }

        /// <summary>
        /// Insert employes in database
        /// </summary>
        /// <param name="employe"></param>
        public static string SavePersonne(Employes employe)
        {
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(conn))
                {
                    cnn.Open();

                    // insert into employes and generate a new ID


                    string sql = @"
                        insert into employes (nom, prenom, sexe, dateNaissance, dateEmbauche, nomContact, prenomContact, lien, telephone, telephoneContact, adresse, email)
                        Select @nom, @prenom, @sexe, @dateNaissance, @dateEmbauche, @nomContact, @prenomContact, @lien, @telephone, @telephoneContact, @adresse, @email
                        Where not exists (
                            select * 
                            from employes 
                            where 
                                nom = @nom
                            and prenom = @prenom
                            and sexe = @sexe
                            and dateNaissance = @dateNaissance
                            and dateEmbauche = @dateEmbauche
                            and nomContact = @nomContact
                            and prenomContact = @prenomContact
                            and lien = @lien
                            and telephone = @telephone
                            and telephoneContact = @telephoneContact
                            and adresse = @adresse
                            and email = @email)";





                    using (var cmd = new SQLiteCommand(sql, cnn))
                    {
                        string prenom = $"{employe.Prenom1} {employe.Prenom2}";
                        try
                        {
                            cmd.Parameters.AddWithValue("@nom", employe.Nom);
                            cmd.Parameters.AddWithValue("@prenom", prenom);
                        }
                        catch (SQLiteException ex)
                        {
                            return "Cette personne existe deja dans la base de donnees";
                        }
                    
                        cmd.Parameters.AddWithValue("@sexe", employe.Sexe);
                        cmd.Parameters.AddWithValue("@dateNaissance", employe.DateNaissance);
                        cmd.Parameters.AddWithValue("@adresse", employe.AdresseRue);
                        cmd.Parameters.AddWithValue("@dateEmbauche", employe.DateEmbauche);
                        cmd.Parameters.AddWithValue("@nomContact", employe.NomAContacter);
                        try
                        {
                            cmd.Parameters.AddWithValue("@telephone", employe.Telephone);


                        }
                        catch (SQLiteException ex)
                        {
                            return "Une personne de l'institution possede deja ce numero de telephone";
                        }
                        cmd.Parameters.AddWithValue("@prenomContact", employe.PrenomAContacter);
                        cmd.Parameters.AddWithValue("@lien", employe.LienParente);
                        cmd.Parameters.AddWithValue("@telephoneContact", employe.TelPersonne);

                        try
                        {
                            cmd.Parameters.AddWithValue("@email", employe.Email);

                        }
                        catch (SQLiteException ex)
                        {
                            return "Une personne de l'institution possede deja cet email";
                        }
                        cmd.ExecuteNonQuery();

                        idEmployes = cnn.LastInsertRowId;
                    }
                    return "";

                }

            }
            catch (SQLiteException ex)
            {
                return "";
            }

        }



   
        public static void SavePromotion(Promotion promotion)
        {
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(conn))
                {
                    cnn.Open();


                    // insert into employes and generate a new ID
                    string sql_promo = @"
                        insert into parcours_crech (ID, departement, poste, dateDebut, dateFin)
                        Select @ID, @departement, @poste, @dateDebut, @dateFin
                        Where not exists (
                            select * 
                            from parcours_crech 
                            where 
                                ID = @ID
                            and departement = @departement
                            and poste = @poste
                            and dateDebut = @dateDebut
                            and dateFin = @dateFin";


                    using (var cmd = new SQLiteCommand(sql_promo, cnn))
                    {
                        cmd.Parameters.AddWithValue("@ID", idEmployes);
                        cmd.Parameters.AddWithValue("@departement", promotion.Departement);
                        cmd.Parameters.AddWithValue("@poste", promotion.Poste);
                        cmd.Parameters.AddWithValue("@dateDebut", promotion.DateDebut);
                        cmd.Parameters.AddWithValue("@dateFin", promotion.DateFin);

                        cmd.ExecuteNonQuery();

                    }


                }


            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
            }
        }


        public static void SaveParcoursProf(ParcoursProf parcours)
        {
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(conn))
                {
                    cnn.Open();


                    string sql_parcours = @"
                        insert into parcours_prof (ID, detention, discipline, date)
                        Select @ID, @detention, @discipline, @date
                        Where not exists (
                            select * 
                            from parcours_prof 
                            where 
                                ID = @ID
                            and detention = @detention
                            and discipline = @discipline
                            and date = @date";


                    using (var cmd = new SQLiteCommand(sql_parcours, cnn))
                    {
                        Console.WriteLine(idEmployes);
                        cmd.Parameters.AddWithValue("@ID", idEmployes);
                        cmd.Parameters.AddWithValue("@detention", parcours.Detention);
                        cmd.Parameters.AddWithValue("@discipline", parcours.Discipline);
                        cmd.Parameters.AddWithValue("@date", parcours.Date);

                        cmd.ExecuteNonQuery();

                    }


                }

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }


}
