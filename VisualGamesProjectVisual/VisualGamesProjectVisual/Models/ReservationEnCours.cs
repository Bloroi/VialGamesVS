﻿using System;
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

        public ReservationEnCours(int idReservation, string date, string dateLivraison, int idMembre, int idJeuVideo)
        {
            IdReservation = IdReservation;
            Date = date;
            DateLivraison = dateLivraison;
            IdMembre = idMembre;
            IdJeuVideo = idJeuVideo;
        }

        public ReservationEnCours(string date, string dateLivraison, int idMembre, int idJeuVideo):this(0, date, dateLivraison, idMembre, idJeuVideo)
        {

        }
    }
}