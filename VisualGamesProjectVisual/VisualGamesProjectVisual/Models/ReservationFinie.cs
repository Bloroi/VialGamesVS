using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualGamesProjectVisual.Models
{
    public class ReservationFinie
    {
        public int IdReservation
        {
            get;
            set;
        }

        public String Date
        {
            get;
            set;
        }

        public String DateLivraison
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

        public ReservationFinie()
        {
        }

        public ReservationFinie(int idReservation, string date, string dateLivraison, int idMembre, int idJeuVideo)
        {
            IdReservation = IdReservation;
            Date = date;
            DateLivraison = dateLivraison;
            IdMembre = idMembre;
            IdJeuVideo = idJeuVideo;
        }

        public ReservationFinie(string date, string dateLivraison, int idMembre, int idJeuVideo) : this(0, date, dateLivraison, idMembre, idJeuVideo)
        {

        }
    }
}