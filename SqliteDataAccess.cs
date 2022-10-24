using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Etudiant
{
    class SqliteDataAccess
    {
        static string conn = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;


        public static void CreateIfNotExists()
        {
            using (IDbConnection cnn = new SQLiteConnection(conn))
            {
                var query = "CREATE TABLE IF NOT EXISTS infos (nom CHAR(50), prenom1 TEXT, prenom2 TEXT, telephone TEXT,  age INTEGER, nationalite TEXT, pays TEXT, ville TEXT,adresse TEXT,date TEXT)";
                
                cnn.Execute(query, new DynamicParameters());
            }
        }
        /// <summary>
        /// Load film from local database
        /// </summary>
        /// <returns> List of films</returns>
        public static List<Personne> LoadFilms()
        {
            List<Personne> personnes = new List<Personne>();
            using (SQLiteConnection cnn = new SQLiteConnection(conn))
            {
                var query = "select * from infos";
                cnn.Open();

                SQLiteCommand sQLiteCommand = new SQLiteCommand(query, cnn);
                SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
                if (sQLiteDataReader.HasRows)
                {
                    
                    while (sQLiteDataReader.Read())
                    {
                        //Personne personne = new Personne();
                        var nom = (string)sQLiteDataReader["nom"];
                        var prenom1 = (string)sQLiteDataReader["prenom1"];
                        var prenom2 = (string)sQLiteDataReader["prenom2"];
                        var age = Convert.ToInt32(sQLiteDataReader["age"]);
                        var telephone = (string)sQLiteDataReader["telephone"];
                        var pays = (string)sQLiteDataReader["pays"];
                        var ville = (string)sQLiteDataReader["ville"];
                        var nationalite = (string)sQLiteDataReader["nationalite"];
                        var adresse = (string)sQLiteDataReader["adresse"];
                        var date = (string)sQLiteDataReader["date"];

                        Personne personne = new Personne(nom, prenom1, prenom2, age, nationalite, adresse, ville, pays, telephone, date);

                        

                        
                        personnes.Add(personne);
                    }
                }

                return personnes;
            }

        }
        
        /// <summary>
        /// Insert film in local database
        /// </summary>
        /// <param name="film"></param>
        public static void SavePersonne(Personne personne)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(conn))
            {
                cnn.Open();

              
              
                string sql = @"
                        insert into offline (nom, prenom1, prenom2, age, nationalite, adresse, ville, pays, telephone, date)
                        Select @nom , @prenom1, @prenom2, @age, @nationalite, @adresse, @ville,@pays,@telephone,@date
                        Where not exists (
                            select * 
                            from offline 
                            where 
                                nom = @nom
                            and prenom1 = @prenom1
                            and prenom2 = @prenom2
                            and age = @age
                            and nationalite = @nationalite
                            and adresse = @adresse
                            and ville = @ville
                            and pays = @pays
                            and telephone = @telephone
                            and date = @date
)
                        ";
                using ( var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@nom", personne.Nom);
                    cmd.Parameters.AddWithValue("@prenom1", personne.Prenom1);
                    cmd.Parameters.AddWithValue("@prenom2", personne.Prenom2);
                    cmd.Parameters.AddWithValue("@age", personne.Age);
                    cmd.Parameters.AddWithValue("@nationalite", personne.Nationalite);
                    cmd.Parameters.AddWithValue("@adresse", personne.AdresseRue);
                    cmd.Parameters.AddWithValue("@ville", personne.Ville);
                    cmd.Parameters.AddWithValue("@pays", personne.Pays);
                    cmd.Parameters.AddWithValue("@telephone", personne.Telephone);
                    cmd.Parameters.AddWithValue("@date", personne.DateCree);
                    cmd.ExecuteNonQuery();
         
                }


            }
        }


        


    }


}
