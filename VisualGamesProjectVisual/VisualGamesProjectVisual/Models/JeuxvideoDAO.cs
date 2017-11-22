using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VialGamesVisual.Models
{
	public class JeuxvideoDAO
	{
		private static readonly string QUERY = "SELECT * from jeuxvideo";
		private static readonly string GET = QUERY + " WHERE id = @id";
		private static readonly string CREATE = "INSERT INTO jeuxvideo(nom,editeur,types,developpeur,sortie,genres,theme,prix,description,urlImage,stock)" +
			"OUTPUT INSERTED.id VALUES(@nom,@editeur,@types,@developpeur,@sortie,@genres,@theme,@prix,@description,@urlImage,@stock)";
		private static readonly string DELETE = "DELETE FROM jeuxvideo WHERE id=@id";
		private static readonly string UPDATE = "UPDATE jeuxvideo SET nom = @nom,editeur=@editeur,types=@types,developpeur=@developpeur,sortie=@sortie,genres=@genres," +
			"theme=@theme,prix=@prix,description=@description,urlImage=@urlImage,stock=@stock where id = @id";

		public static List<Jeuxvideo> getAllJeuxvideo()
		{
			List<Jeuxvideo> jvs = new List<Jeuxvideo>();

			using(SqlConnection connection = Database.GetConnection()) { //Comme un try , ferme automatiquement la connection
				connection.Open();
				SqlCommand command = new SqlCommand(QUERY, connection);
				SqlDataReader reader = command.ExecuteReader(); //Contient les différents records que la bd a envoyé
				while (reader.Read())
				{
					/*
					int id= (int)reader["Id"];
					string nom = (string)reader["Nom"];
					string editeur = (string)reader["Editeur"];
					string types = (string)reader["Types"];
					string developpeur= (string)reader["Developpeur"];
					string sortie = (string)reader["Sortie"];
					string genres = (string)reader["Genres"];
					string theme = (string)reader["Theme"];
					decimal Prix = (decimal)reader["Prix"];
					string Description = (string)reader["Description"];*/

					//jvs.Add(new Jeuxvideo(reader.GetInt32(0),reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5),
					//reader.GetString(6), reader.GetString(7), reader.GetFloat(8), reader.GetString(9)));
					jvs.Add(new Jeuxvideo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5),
						reader.GetString(6), reader.GetString(7), reader.GetDecimal(8), reader.GetString(9),reader.GetString(10),reader.GetDecimal(11)));
				}

			}
			return jvs;
		}

		public static Jeuxvideo Get(int id)
		{
			Jeuxvideo jv = null;

			using(SqlConnection conn = Database.GetConnection())
			{
				conn.Open();
				SqlCommand command = new SqlCommand(GET, conn);
				command.Parameters.AddWithValue("@id", id);
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					jv = new Jeuxvideo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4),
						reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetDecimal(8), reader.GetString(9), reader.GetString(10), reader.GetDecimal(11));
				}
			}

			return jv;
		}

		public static Jeuxvideo Create(Jeuxvideo jv)
		{
			using (SqlConnection conn = Database.GetConnection())
			{
				conn.Open();

				SqlCommand command = new SqlCommand(CREATE, conn);
				command.Parameters.AddWithValue("@nom", jv.Nom);
				command.Parameters.AddWithValue("@editeur", jv.Editeur);
				command.Parameters.AddWithValue("@types", jv.Types);
				command.Parameters.AddWithValue("@developpeur", jv.Developpeur);
				command.Parameters.AddWithValue("@sortie", jv.Sortie);
				command.Parameters.AddWithValue("@genres", jv.Genres);
				command.Parameters.AddWithValue("@theme", jv.Theme);
				command.Parameters.AddWithValue("@prix", jv.Prix);
				command.Parameters.AddWithValue("@description", jv.Description);
				command.Parameters.AddWithValue("@urlImage", jv.UrlImage);
				command.Parameters.AddWithValue("@stock", jv.Stock);

				jv.Id = (int)command.ExecuteScalar(); //Revnoyer la valeur de l'intersection de la première ligne première colonne

			}
			return jv;
		}

		public static bool Delete(int id)
		{
			bool estSupprime = false;
			using (SqlConnection conn = Database.GetConnection())
			{
				conn.Open();
				SqlCommand command = new SqlCommand(DELETE, conn);
				command.Parameters.AddWithValue("@id", id);

				estSupprime = command.ExecuteNonQuery() != 0; // ca va nous envoyer le nombre de ligne affecté par la recherche
			}
			return estSupprime;
		}

		public static Boolean Update(Jeuxvideo jv)
		{
			bool aEteModifie = false;

			using (SqlConnection conn = Database.GetConnection())
			{
				conn.Open();

				SqlCommand command = new SqlCommand(UPDATE, conn);
				command.Parameters.AddWithValue("@nom", jv.Nom);
				command.Parameters.AddWithValue("@editeur", jv.Editeur);
				command.Parameters.AddWithValue("@types", jv.Types);
				command.Parameters.AddWithValue("@developpeur", jv.Developpeur);
				command.Parameters.AddWithValue("@sortie", jv.Sortie);
				command.Parameters.AddWithValue("@genres", jv.Genres);
				command.Parameters.AddWithValue("@theme", jv.Theme);
				command.Parameters.AddWithValue("@prix", jv.Prix);
				command.Parameters.AddWithValue("@description", jv.Description);
				command.Parameters.AddWithValue("@urlImage", jv.UrlImage);
				command.Parameters.AddWithValue("@stock", jv.Stock);

				command.Parameters.AddWithValue("@id", jv.Id);

				aEteModifie = command.ExecuteNonQuery() != 0; // elle envoit le nombre de lignes modifiées avec ma commande

			}
			return aEteModifie;
		}

	}
}