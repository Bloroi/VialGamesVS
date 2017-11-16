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

        public String DateReservation
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

        public ReservationFinie(int idReservation, string dateReservation, string dateLivraison, int idMembre, int idJeuVideo)
        {
            IdReservation = idReservation;
            DateReservation = dateReservation;
            DateLivraison = dateLivraison;
            IdMembre = idMembre;
            IdJeuVideo = idJeuVideo;
        }

        public ReservationFinie(string dateReservation, string dateLivraison, int idMembre, int idJeuVideo) : this(0, dateReservation, dateLivraison, idMembre, idJeuVideo)
        {

        }
    }
}