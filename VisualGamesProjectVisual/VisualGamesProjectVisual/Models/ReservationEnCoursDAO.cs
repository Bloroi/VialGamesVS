using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualGamesProjectVisual.Models
{
    public class ReservationEnCoursDAO
    {
        private static readonly string QUERY = "SELECT * FROM reservationEnCours";
        private static readonly string GET = QUERY + " WHERE idReservation=#idReservation";
        private static readonly string CREATE = "INSERT INTO reservationEnCours(date, dateLivraison, idMembre, idJeuVideo) OUTPUT INSERTED.ID VALUES (@date, @dateLivraison, @idMembre, @idJeuVideo)";
        private static readonly string DELETE = "DELETE FROM reservationEnCours WHERE idReservation = @idReservation";
        private static readonly string UPDATE = "UPDATE reservationEnCours SET date=@date, dateLivraison=@dateLivraison, idMembre=@idMenbre, idJeuVideo=@idJeuVideo";

        public static List<ReservationEnCours> getAllReservationEnCours()
        {
            List<ReservationEnCours> reservationsEnCours = new List<ReservationEnCours>();

            using (SqlConnection conenction = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(QUERY, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    reservationsEnCours.Add(new ReservationEnCours(reader.GetInt(0), reader.GetString(1), reader.GetString(2), reader.GetInt(3), reader.GetInt(4)));
                }
            }
            return reservationsEnCours;
        }

        public static ReservationEnCours Create(ReservationEnCours reservationEnCours)
        {
            using(SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(CREATE, connection);
                command.Parameters.AddWithValue("@date", reservationEnCours.Date);
                command.Parameters.AddWithValue("@dateLivraison", reservationEnCours.);
                command.Parameters.AddWithValue(@"", reservationEnCours.);
                command.Parameters.AddWithValue(@"", reservationEnCours.);
            }
        }
    }
}