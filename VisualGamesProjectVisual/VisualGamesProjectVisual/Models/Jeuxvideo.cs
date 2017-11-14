using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VialGamesVisual.Models
{
	public class Jeuxvideo
	{
		public int Id
		{
			get;
			set;
		}

		public String Nom
		{
			get;
			set;
		}

		public String Editeur
		{
			get;
			set;
		}

		public String Types
		{
			get;
			set;
		}

		public String Developpeur
		{
			get;
			set;
		}

		public String Sortie
		{
			get;
			set;
		}

		public String Genres
		{
			get;
			set;
		}

		public String Theme
		{
			get;
			set;
		}

		public decimal Prix
		{
			get;
			set;
		}

		public String Description
		{
			get;
			set;
		}

		public String UrlImage
		{
			get;
			set;
		}

		public Jeuxvideo()
		{

		}

		public Jeuxvideo(int id, String nom, String editeur, String types, String developpeur, String sortie, String genres, String theme, decimal prix, String description,String urlImage)
		{
			Id = id;
			Nom = nom;
			Editeur = editeur;
			Types = types;
			Developpeur = developpeur;
			Sortie = sortie;
			Genres = genres;
			Theme = theme;
			Prix = prix;
			Description = description;
			UrlImage = urlImage;

		}

		public Jeuxvideo(String nom, String editeur, String types, String developpeur, String sortie, String genres, String theme, decimal prix, String description,String urlImage)
			: this(0, nom, editeur, types, developpeur, sortie, genres, theme, prix, description,urlImage) { }

		public Jeuxvideo(String nom, String editeur, String types, String developpeur, String sortie, String genres, String theme, decimal prix, String description)
			: this(0, nom, editeur, types, developpeur, sortie, genres, theme, prix, description,"0") { }
	}
}
