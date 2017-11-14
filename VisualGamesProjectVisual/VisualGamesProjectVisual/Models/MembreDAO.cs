using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualGamesProjectVisual.Models
{
    public class Membre
    {
        private static readonly string QUERY = "SELECT * FROM membre";
        private static readonly string GET = QUERY + " WHERE id=#id";
        private static readonly string CREATE = "INSERT INTO membre(username, password, nom, prenom, dateDeNaissance, email, tel, localite, cp, adresse) OUTPUT INSERTED.ID VALUES (@username, @password, @nom, @prenom, @dateDeNaissance, @email, @tel, @localite, @cp, @adresse)";
        private static readonly string DELETE = "DELETE FROM membre WHERE id = @id";
        private static readonly string UPDATE = "UPDATE membre SET username = @username, password = @password, nom = @nom, prenom = @prenom, dateDeNaissance = @dateDeNaissance, emai=@email, tel = @tel, localite = @localite, cp = @cp, adresse = @adresse WHERE id = @id";

        public static List<Membre> getAllMembre()
        {
            List<Membre> membres = new List<Membre>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(QUERY, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    membres.Add(new Membre(reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2)));
                }
            }

            return membres;
        }

        public static Membre Get(int id)
        {
            Membre membre = null;

            using(SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(GET, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    membre = new Membre(reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2));

                }
            }
            return membre;
        }

        public static Membre Create(Membre membre)
        {
            using (SqlConnection connection = DataBase.GetConnection())
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
            }
        }

        public static bool Delete(int id)
        {
            bool estSupprimee = false;
            using(SqlConnection connection = DataBase.GetConnection())
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

            using (SqlConnection connection = DataBase.GetConnection())
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
            }
        }
    }
}