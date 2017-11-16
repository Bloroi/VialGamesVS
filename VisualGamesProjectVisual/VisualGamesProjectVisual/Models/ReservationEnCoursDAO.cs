using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VialGamesVisual.Models;

namespace VisualGamesProjectVisual.Models
{
    public class ReservationEnCoursDAO
    {
        private static readonly string QUERY = "SELECT * FROM reservationEnCours";
        private static readonly string GET = QUERY + " WHERE idReservation=#idReservation";
        private static readonly string CREATE = "INSERT INTO reservationEnCours(date, dateLivraison, idMembre, idJeuVideo) OUTPUT INSERTED.ID VALUES (@date, @dateLivraison, @idMembre, @idJeuVideo)";
        private static readonly string DELETE = "DELETE FROM reservationEnCours WHERE idReservation = @idReservation";
        private static readonly string UPDATE = "UPDATE reservationEnCours SET dateReservation=@date, dateLivraison=@dateLivraison, idMembre=@idMenbre, idJeuVideo=@idJeuVideo";

        public static List<ReservationEnCours> GetAllReservationEnCours()
        {
            List<ReservationEnCours> reservationsEnCours = new List<ReservationEnCours>();

            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(QUERY, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    reservationsEnCours.Add(new ReservationEnCours(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4)));
                }
            }
            return reservationsEnCours;
        }

        public static ReservationEnCours Get(int id)
        {
            ReservationEnCours reserv = null;

            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(GET, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reserv = new ReservationEnCours(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));

                }
            }
            return reserv;
        }

        public static ReservationEnCours Create(ReservationEnCours reservationEnCours)
        {
            using(SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(CREATE, connection);
                command.Parameters.AddWithValue("@date", reservationEnCours.Date);
                command.Parameters.AddWithValue("@dateLivraison", reservationEnCours.DateLivraison);
                command.Parameters.AddWithValue(@"", reservationEnCours.IdMembre);
                command.Parameters.AddWithValue(@"", reservationEnCours.IdJeuVideo);

                reservationEnCours.IdReservation= (int)command.ExecuteScalar();
            }
            return reservationEnCours;
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

        public static bool Update(ReservationEnCours reservationEnCours)
        {
            bool aEteModifie = false;

            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(UPDATE, connection);
                command.Parameters.AddWithValue("@idReservation", reservationEnCours.IdReservation);
                command.Parameters.AddWithValue("@date", reservationEnCours.Date);
                command.Parameters.AddWithValue("@dateLivraison", reservationEnCours.DateLivraison);
                command.Parameters.AddWithValue("@idMembre", reservationEnCours.IdMembre);
                command.Parameters.AddWithValue("@idJeuVideo", reservationEnCours.IdJeuVideo);

                aEteModifie = command.ExecuteNonQuery() != 0;
            }
            return aEteModifie;
        }
    }
}