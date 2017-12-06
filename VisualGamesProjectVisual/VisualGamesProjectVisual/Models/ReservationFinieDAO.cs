using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VialGamesVisual.Models;

namespace VisualGamesProjectVisual.Models
{
    public class ReservationFinieDAO
    {
        private static readonly string QUERY = "SELECT * FROM reservationFinie";
        private static readonly string GET = QUERY + " WHERE idReservation=@idReservation";
		private static readonly string GETRESERVATIONMEMBRE = "select ReservationFinie.* , Membre.* , Jeuxvideo.Id , Jeuxvideo.Nom,Jeuxvideo.Types from ReservationFinie join Membre on ReservationFinie.idMembre=Membre.id join Jeuxvideo on Jeuxvideo.id=ReservationFinie.idJeuVideo";
		private static readonly string WHEREQUERY2 = " where Membre.id = @id";
		private static readonly string CREATE = "INSERT INTO reservationFinie(dateReservation, dateLivraison,prixAchat, etat, idMembre, idJeuVideo) OUTPUT INSERTED.ID VALUES (@dateReservation, @dateLivraison,@prixAchat, @etat, @idMembre, @idJeuVideo)";
        private static readonly string DELETE = "DELETE FROM reservationFinie WHERE id = @id";
        private static readonly string UPDATE = "UPDATE reservationFinie SET dateReservation=@dateReservation, dateLivraison=@dateLivraison, prixAchat=@prixAchat,etat=@etat where id =@idReservation";

        public static List<ReservationFinie> GetAllReservationFinie()
        {
            List<ReservationFinie> reservationFinie = new List<ReservationFinie>();

            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(QUERY, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    reservationFinie.Add(new ReservationFinie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),reader.GetDecimal(3),reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6)));
                }
            }
            return reservationFinie;
        }

		public static List<ReservationFinie> GetAllReservationFinieMembre(int idMembre)
		{
			List<ReservationFinie> reservationsFinie = new List<ReservationFinie>();

			using (SqlConnection connection = Database.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(GETRESERVATIONMEMBRE, connection);

				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					reservationsFinie.Add(new ReservationFinie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6)));
				}
			}
			return reservationsFinie;
		}
		
		public static List<ReservationFinie> GetAllReservationFinie(int idReserv)
		{
			List<ReservationFinie> reservationsFinie = new List<ReservationFinie>();

			using (SqlConnection connection = Database.GetConnection())
			{
				connection.Open();
				SqlCommand command = new SqlCommand(GET, connection);
				command.Parameters.AddWithValue("@id", idReserv);
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					reservationsFinie.Add(new ReservationFinie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6)));
				}
			}
			return reservationsFinie;
		}

		public static List<ReservationFinie> GetReservMembre(int id)
		{
			List<ReservationFinie> reserv = new List<ReservationFinie>();

			using (SqlConnection connection = Database.GetConnection())
			{
				SqlCommand command;
				SqlDataReader reader;
				if (id < 0)
				{
					connection.Open();
					command = new SqlCommand(GETRESERVATIONMEMBRE, connection);
					command.Parameters.AddWithValue("@id", id);
					reader = command.ExecuteReader();
				}
				else
				{
					connection.Open();
					command = new SqlCommand(GETRESERVATIONMEMBRE + WHEREQUERY2, connection);
					command.Parameters.AddWithValue("@id", id);
					reader = command.ExecuteReader();
				}
				while (reader.Read())
				{
					reserv.Add(new ReservationFinie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), reader.GetString(4), new Membre(reader.GetInt32(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetString(15), reader.GetInt32(16), reader.GetString(17)), new Jeuxvideo(reader.GetInt32(18), reader.GetString(19), reader.GetString(20))));

				}

			}
			return reserv;
		}

		public static ReservationFinie Get(int id)
        {
            ReservationFinie reserv = null;

            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(GET, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reserv = new ReservationFinie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6));

                }
            }
            return reserv;
        }

        public static ReservationFinie Create(ReservationFinie reserv)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(CREATE, connection);
                command.Parameters.AddWithValue("@dateReservation", reserv.DateReservation);
                command.Parameters.AddWithValue("@dateLivraison", reserv.DateLivraison);
				command.Parameters.AddWithValue("@prixAchat", reserv.PrixAchat);
				command.Parameters.AddWithValue("@etat", reserv.Etat);
				command.Parameters.AddWithValue(@"idMembre", reserv.IdMembre);
                command.Parameters.AddWithValue(@"idJeuVideo", reserv.IdJeuxVideo);

                reserv.IdReservation = (int)command.ExecuteScalar();
            }
            return reserv;
        }

        public static bool Delete(int id)
        {
            bool estSupprimee = false;
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(DELETE, connection);
                command.Parameters.AddWithValue("@id", id);
                estSupprimee = command.ExecuteNonQuery() != 0;
            }
            return estSupprimee;
        }

        public static bool Update(ReservationFinie reserv)
        {
            bool aEteModifie = false;

            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(UPDATE, connection);
                command.Parameters.AddWithValue("@idReservation", reserv.IdReservation);
                command.Parameters.AddWithValue("@dateReservation", reserv.DateReservation);
                command.Parameters.AddWithValue("@dateLivraison", reserv.DateLivraison);
				command.Parameters.AddWithValue("@prixAchat", reserv.PrixAchat);
				command.Parameters.AddWithValue("@etat", reserv.Etat);

				aEteModifie = command.ExecuteNonQuery() != 0;
            }
            return aEteModifie;
        }
    }
}