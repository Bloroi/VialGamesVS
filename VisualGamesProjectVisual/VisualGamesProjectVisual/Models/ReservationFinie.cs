using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VialGamesVisual.Models;

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

		public decimal PrixAchat
		{
			get;
			set;
		}

		public string Etat
		{
			get;
			set;
		}


		public int IdMembre
        {
            get;
            set;
        }

        public int IdJeuxVideo
        {
            get;
            set;
        }

		public Jeuxvideo Jv
		{
			get;
			set;
		}

		public Membre Memb
		{
			get;
			set;
		}

		public ReservationFinie()
        {
        }

		public ReservationFinie(int idReservation, string dateReservation, string dateLivraison, decimal prixAchat, string etat)
		{
			IdReservation = idReservation;
			DateReservation = dateReservation;
			DateLivraison = dateLivraison;
			PrixAchat = prixAchat;
			Etat = etat;
		}

		public ReservationFinie(int id, string dateReservation, string dateLivraison, decimal prixAchat, string etat, Membre m, Jeuxvideo jv):this(id, dateReservation, dateLivraison, prixAchat, etat)
        {
			Memb = m;
			Jv = jv;
		}

		public ReservationFinie(int id, string dateReservation, string dateLivraison, decimal prixAchat, string etat, int idMembre, int idJv) :this(id, dateReservation, dateLivraison, prixAchat, etat)
		{
			IdMembre = idMembre;
			IdJeuxVideo = idJv;
		}

		public ReservationFinie(string dateReservation, string dateLivraison, decimal prixAchat, string etat, int idMembre, int idJv) :this(0, dateReservation, dateLivraison, prixAchat, etat)
		{
			IdMembre = idMembre;
			IdJeuxVideo = idJv;
		}

	}
}