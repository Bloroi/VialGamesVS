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

		public decimal PrixAchat
		{
			get;
			set;
		}

		public bool Etat
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

        public ReservationEnCours(int idReservation, string dateReservation, string dateLivraison, decimal prixAchat,bool etat, int idMembre, int idJeuVideo)
        {
            IdReservation = idReservation;
            DateReservation = dateReservation;
            DateLivraison = dateLivraison;
			PrixAchat = prixAchat;
			Etat = etat;
            IdMembre = idMembre;
            IdJeuVideo = idJeuVideo;
        }

        public ReservationEnCours(string dateReservation, string dateLivraison, decimal prixAchat, bool etat, int idMembre, int idJeuVideo):this(0, dateReservation, dateLivraison, prixAchat, etat, idMembre, idJeuVideo)
        {

        }
    }
}