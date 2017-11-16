using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualGamesProjectVisual.Models
{
    public class ReservationEnCours
    {
        public int IdReservation
        {
            get;
            set;
        }

        public string DateReservation
        {
            get;
            set;
        }

        public string DateLivraison
        {
            get;
            set;
        }

        public int IdMembre
        {
            get;
            set;
        }

        public int IdJeuVideo
        {
            get;
            set;
        }

        public ReservationEnCours()
        {
        }

        public ReservationEnCours(int idReservation, string dateReservation, string dateLivraison, int idMembre, int idJeuVideo)
        {
            IdReservation = IdReservation;
            DateReservation = dateReservation;
            DateLivraison = dateLivraison;
            IdMembre = idMembre;
            IdJeuVideo = idJeuVideo;
        }

        public ReservationEnCours(string dateReservation, string dateLivraison, int idMembre, int idJeuVideo):this(0, dateReservation, dateLivraison, idMembre, idJeuVideo)
        {

        }
    }
}