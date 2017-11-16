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
        private static readonly string GET = QUERY + " WHERE idReservation=#idReservation";
        private static readonly string CREATE = "INSERT INTO reservationFinie(date, dateLivraison, idMembre, idJeuVideo) OUTPUT INSERTED.ID VALUES (@date, @dateLivraison, @idMembre, @idJeuVideo)";
        private static readonly string DELETE = "DELETE FROM reservationFinie WHERE idReservation = @idReservation";
        private static readonly string UPDATE = "UPDATE reservationFinie SET dateReservation=@date, dateLivraison=@dateLivraison, idMembre=@idMenbre, idJeuVideo=@idJeuVideo";

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
                    reservationFinie.Add(new ReservationFinie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4)));
                }
            }
            return reservationFinie;
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
                    reserv = new ReservationFinie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));

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
                command.Parameters.AddWithValue("@date", reserv.Date);
                command.Parameters.AddWithValue("@dateLivraison", reserv.DateLivraison);
                command.Parameters.AddWithValue(@"", reserv.IdMembre);
                command.Parameters.AddWithValue(@"", reserv.IdJeuVideo);

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
                command.Parameters.AddWithValue("@date", reserv.Date);
                command.Parameters.AddWithValue("@dateLivraison", reserv.DateLivraison);
                command.Parameters.AddWithValue("@idMembre", reserv.IdMembre);
                command.Parameters.AddWithValue("@idJeuVideo", reserv.IdJeuVideo);

                aEteModifie = command.ExecuteNonQuery() != 0;
            }
            return aEteModifie;
        }
    }
}