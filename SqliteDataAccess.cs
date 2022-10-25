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
                var query = "CREATE TABLE IF NOT EXISTS infos (nom CHAR(50), prenom TEXT, telephone TEXT,  age INTEGER, nationalite TEXT, pays TEXT, ville TEXT,adresse TEXT,date TEXT)";
                
                cnn.Execute(query, new DynamicParameters());
            }
        }
        /// <summary>
        /// Load film from local database
        /// </summary>
        /// <returns> List of films</returns>
        public static DataTable LoadData()
        {
            DataTable dt;
            
            using (SQLiteConnection cnn = new SQLiteConnection(conn))
            {

                var query = "select nom, prenom, age, telephone from infos";
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
        /// Insert film in local database
        /// </summary>
        /// <param name="film"></param>
        public static void SavePersonne(Personne personne)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(conn))
            {
                cnn.Open();

              
              
                string sql = @"
                        insert into infos (nom, prenom, age, nationalite, adresse, ville, pays, telephone, date)
                        Select @nom , @prenom, @age, @nationalite, @adresse, @ville,@pays,@telephone,@date
                        Where not exists (
                            select * 
                            from infos 
                            where 
                                nom = @nom
                            and prenom = @prenom
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
                    string prenom = $"{personne.Prenom1} {personne.Prenom2}";
                    cmd.Parameters.AddWithValue("@nom", personne.Nom);
                    cmd.Parameters.AddWithValue("@prenom", prenom);
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
