using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualGamesProjectVisual.Models
{
    public class ReservationEnCours
    {
        public string IdReservation
        {
            get;
            set;
        }

        public string Date
        {
            get;
            set;
        }

        public string DateLivraison
        {
            get;
            set;
        }

        public string IdMembre
        {
            get;
            set;
        }

        public string IdJeuVideo
        {
            get;
            set;
        }

        public ReservationEnCours()
        {
        }

        public ReservationEnCours(string idReservation, string date, string dateLivraison, string idMembre, string idJeuVideo)
        {
            IdReservation = IdReservation;
            Date = date;
            DateLivraison = dateLivraison;
            IdMembre = idMembre;
            IdJeuVideo = idJeuVideo;
        }

        public ReservationEnCours(string date, string dateLivraison):this(0, date, dateLivraison, 0, 0)
        {

        }
    }
}