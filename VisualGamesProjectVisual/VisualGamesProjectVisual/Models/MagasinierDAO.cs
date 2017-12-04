using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VialGamesVisual.Models;

namespace VisualGamesProjectVisual.Models
{
	public class MagasinierDAO
	{

		private static readonly string QUERY = "SELECT * from Magasinier";
		private static readonly string GET = QUERY + " WHERE id = @id";
        private static readonly string GETCONENCTION = QUERY + " WHERE username=@username AND password=@password";
        private static readonly string CREATE = "INSERT INTO Magasinier(username,password,tel,email)" +
			"OUTPUT INSERTED.id VALUES(@username,@password,@tel,@email)";
		private static readonly string DELETE = "DELETE FROM Magasinier WHERE id=@id";
		private static readonly string UPDATE = "UPDATE Magasinier SET username=@username,password = @password,tel = @tel,email = @email where id = @id";

		public static List<Magasinier> getAllMagasinier()
		{
			List<Magasinier> listM = new List<Magasinier>();

			using (SqlConnection connection = Database.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(QUERY, connection);
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					listM.Add(new Magasinier(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),reader.GetString(4)));
				}

			}
			return listM;
		}

        public static Boolean getConnection(string username, string password)
        {
            List<Magasinier> admins = new List<Magasinier>();

            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(GETCONENCTION, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    admins.Add(new Magasinier(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                }
            }
            if (admins.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Magasinier Get(int id)
		{
			Magasinier m = null;

			using (SqlConnection conn = Database.GetConnection())
			{
				conn.Open();
				SqlCommand command = new SqlCommand(GET, conn);
				command.Parameters.AddWithValue("@id", id);
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					m = new Magasinier(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),reader.GetString(4));
				}
			}

			return m;
		}

		public static Magasinier Create(Magasinier m)
		{
			using (SqlConnection conn = Database.GetConnection())
			{
				conn.Open();

				SqlCommand command = new SqlCommand(CREATE, conn);
				command.Parameters.AddWithValue("@username", m.Username);
				command.Parameters.AddWithValue("@password", m.Password);
				command.Parameters.AddWithValue("@tel", m.Tel);
				command.Parameters.AddWithValue("@email", m.Email);


				m.Id = (int)command.ExecuteScalar(); //Revnoyer la valeur de l'intersection de la première ligne première colonne

			}
			return m;
		}

		public static bool Delete(int id)
		{
			bool estSupprime = false;
			using (SqlConnection conn = Database.GetConnection())
			{
				conn.Open();
				SqlCommand command = new SqlCommand(DELETE, conn);
				command.Parameters.AddWithValue("@id", id);

				estSupprime = command.ExecuteNonQuery() != 0;
			}
			return estSupprime;
		}

		public static Boolean Update(Magasinier m)
		{
			bool aEteModifie = false;

			using (SqlConnection conn = Database.GetConnection())
			{
				conn.Open();

				SqlCommand command = new SqlCommand(UPDATE, conn);
				command.Parameters.AddWithValue("@username", m.Username);
				command.Parameters.AddWithValue("@password", m.Password);
				command.Parameters.AddWithValue("@tel", m.Tel);
				command.Parameters.AddWithValue("@email", m.Email);

				command.Parameters.AddWithValue("@id", m.Id);

				aEteModifie = command.ExecuteNonQuery() != 0;

			}
			return aEteModifie;
		}

	}
}
