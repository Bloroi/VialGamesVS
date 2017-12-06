using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VialGamesVisual.Models;

namespace VisualGamesProjectVisual.Models
{
    public class MembreDAO
    
    {
        private static readonly string QUERY = "SELECT * FROM membre";
        private static readonly string GET = QUERY + " WHERE id=@id";
        private static readonly string CHECKUSERNAME = QUERY + " WHERE username=@username";
        private static readonly string CHECKEMAIL = QUERY + " WHERE email=@email";
        private static readonly string GETCONENCTION = QUERY + " WHERE username=@username AND password=@password";
        private static readonly string CREATE = "INSERT INTO membre(username, password, nom, prenom, dateDeNaissance, email, tel, localite, cp, adresse) OUTPUT INSERTED.ID VALUES (@username, @password, @nom, @prenom, @dateDeNaissance, @email, @tel, @localite, @cp, @adresse)";
        private static readonly string DELETE = "DELETE FROM membre WHERE id = @id";
        private static readonly string UPDATE = "UPDATE membre SET username = @username, password = @password, nom = @nom, prenom = @prenom, dateDeNaissance = @dateDeNaissance, email=@email, tel = @tel, localite = @localite, cp = @cp, adresse = @adresse WHERE id = @id";

        public static List<Membre> GetAllMembre()
        {
            List<Membre> membres = new List<Membre>();

            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(QUERY, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    membres.Add(new Membre(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetInt32(9), reader.GetString(10)));
                }
            }

            return membres;
        }

        public static Boolean getConnection(string username, string password)
        {
            List<Membre> membres = new List<Membre>();

            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(GETCONENCTION, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    membres.Add(new Membre(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetInt32(9), reader.GetString(10)));
                }
            }

            if(membres.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Membre getMembre(string username, string password)
        {
            Membre membre = null;

            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(GETCONENCTION, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    membre = new Membre(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetInt32(9), reader.GetString(10));

                }
            }
            return membre;
        }

        public static int CheckValidate(string username, string email)
        {
            List<Membre> membres = new List<Membre>();
            int test = 0;

            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(CHECKUSERNAME, connection);
                command.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    membres.Add(new Membre(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetInt32(9), reader.GetString(10)));
                }
                if (membres.Count != 0)
                {
                    test = 1;
                }
                membres = new List<Membre>();
            }

            using(SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(CHECKEMAIL, connection);
                command.Parameters.AddWithValue("@email", email);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    membres.Add(new Membre(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetInt32(9), reader.GetString(10)));
                }
                if (membres.Count != 0)
                {
                    if (test == 1)
                    {
                        test = 3;
                    }
                    else
                    {
                        test = 2;
                    }
                }
            }

            return test;
        }

        public static Membre Get(int id)
        {
            Membre membre = null;

            using(SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(GET, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    membre = new Membre(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetInt32(9), reader.GetString(10));

                }
            }
            return membre;
        }

        public static Membre Create(Membre membre)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(CREATE, connection);
                command.Parameters.AddWithValue("@username", membre.Username);
                command.Parameters.AddWithValue("@password", membre.Password);
                command.Parameters.AddWithValue("@nom", membre.Nom);
                command.Parameters.AddWithValue("@prenom", membre.Prenom);
                command.Parameters.AddWithValue("@dateDeNaissance", membre.DateDeNaissance);
                command.Parameters.AddWithValue("@email", membre.Email);
                command.Parameters.AddWithValue("@tel", membre.Tel);
                command.Parameters.AddWithValue("@localite", membre.Localite);
                command.Parameters.AddWithValue("@cp", membre.Cp);
                command.Parameters.AddWithValue("@adresse", membre.Adresse);

                membre.Id = (int)command.ExecuteScalar();
            }
            return membre;
        }

        public static bool Delete(int id)
        {
            bool estSupprimee = false;
            using(SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(DELETE, connection);
                command.Parameters.AddWithValue("@id", id);
                estSupprimee = command.ExecuteNonQuery() != 0;
            }
            return estSupprimee;
        }

        public static bool Update(Membre membre)
        {
            bool aEteModifie = false;

            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(UPDATE, connection);
                command.Parameters.AddWithValue("@id", membre.Id);
                command.Parameters.AddWithValue("@username", membre.Username);
                command.Parameters.AddWithValue("@password", membre.Password);
                command.Parameters.AddWithValue("@nom", membre.Nom);
                command.Parameters.AddWithValue("@prenom", membre.Prenom);
                command.Parameters.AddWithValue("@dateDeNaissance", membre.DateDeNaissance);
                command.Parameters.AddWithValue("@email", membre.Email);
                command.Parameters.AddWithValue("@tel", membre.Tel);
                command.Parameters.AddWithValue("@localite", membre.Localite);
                command.Parameters.AddWithValue("@cp", membre.Cp);
                command.Parameters.AddWithValue("@adresse", membre.Adresse);

				aEteModifie = command.ExecuteNonQuery() != 0;
            }
            return aEteModifie;
        }
    }
}