using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace VisualGamesProjectVisual.Models
{
    public class Membre
    {
        public int Id
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string Nom
        {
            get;
            set;
        }

        public string Prenom
        {
            get;
            set;
        }

        public string DateDeNaissance
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Tel
        {
            get;
            set;
        }

        public string Localite
        {
            get;
            set;
        }

        public int Cp
        {
            get;
            set;
        }

        public string Adresse
        {
            get;
            set;
        }

        public Membre() { }

        public Membre(int id, string username, string password, string nom, string prenom, string dateDeNaissance, string email, string tel, string localite, int cp, string adresse)
        {
            Id = id;
            Username = username;
            Password = password;
            Nom = nom;
            Prenom = prenom;
            DateDeNaissance = dateDeNaissance;
            Email = email;
            Tel = tel;
            Localite = localite;
            Cp = cp;
            Adresse = adresse;
        }

        public Membre(string username, string password, string nom, string prenom, string dateDeNaissance, string email, string tel, string localite, int cp, string adresse):this(0, username, password, nom, prenom, dateDeNaissance, email, tel, localite, cp, adresse)
        {

        }
    }
}