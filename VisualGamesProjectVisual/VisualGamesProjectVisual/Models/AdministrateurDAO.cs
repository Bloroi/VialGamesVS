using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VialGamesVisual.Models;

namespace VisualGamesProjectVisual.Models
{
	public class AdministrateurDAO
	{

		private static readonly string QUERY = "SELECT * from administrateur";
		private static readonly string GET = QUERY + "WHERE id = @id";
		private static readonly string CREATE = "INSERT INTO administrateur(username,password,email)" +
			"OUTPUT INSERTED.id VALUES(@username,@password,@email)";
		private static readonly string DELETE = "DELETE FROM administrateur WHERE id=@id";
		private static readonly string UPDATE = "UPDATE administrateur SET nom = username=@username,password = @password,email = @email where id = @id";

		public static List<Administrateur> getAllAdministrateur()
		{
			List<Administrateur> listA = new List<Administrateur>();

			using (SqlConnection connection = Database.GetConnection())
			{ 
				connection.Open();
				SqlCommand command = new SqlCommand(QUERY, connection);
				SqlDataReader reader = command.ExecuteReader(); 
				while (reader.Read())
				{
					listA.Add(new Administrateur(reader.GetInt32(0),reader.GetString(1),reader.GetString(2),reader.GetString(3)));
				}

			}
			return listA;
		}

		public static Administrateur Get(int id)
		{
			Administrateur a = null;

			using (SqlConnection conn = Database.GetConnection())
			{
				conn.Open();
				SqlCommand command = new SqlCommand(GET, conn);
				command.Parameters.AddWithValue("@id", id);
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					a = new Administrateur(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
				}
			}

			return a;
		}

		public static Administrateur Create(Administrateur a)
		{
			using (SqlConnection conn = Database.GetConnection())
			{
				conn.Open();

				SqlCommand command = new SqlCommand(CREATE, conn);
				command.Parameters.AddWithValue("@username", a.Username);
				command.Parameters.AddWithValue("@password", a.Password);
				command.Parameters.AddWithValue("@email", a.Email);

				a.Id = (int)command.ExecuteScalar(); //Revnoyer la valeur de l'intersection de la première ligne première colonne

			}
			return a;
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

		public static Boolean Update(Administrateur a)
		{
			bool aEteModifie = false;

			using (SqlConnection conn = Database.GetConnection())
			{
				conn.Open();

				SqlCommand command = new SqlCommand(UPDATE, conn);
				command.Parameters.AddWithValue("@username", a.Username);
				command.Parameters.AddWithValue("@password", a.Password);
				command.Parameters.AddWithValue("@email", a.Email);

				command.Parameters.AddWithValue("@id", a.Id);

				aEteModifie = command.ExecuteNonQuery() != 0; 

			}
			return aEteModifie;
		}

	}

}
