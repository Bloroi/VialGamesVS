using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualGamesProjectVisual.Models
{
	public class Administrateur
	{
		public int Id
		{
			get;
			set;
		}

		public String Username
		{
			get;
			set;
		}

		public String Password
		{
			get;
			set;
		}

		public String Email
		{
			get;
			set;
		}

		public Administrateur()
		{

		}

		public Administrateur(int id, String username,String password,String email)
		{
			Id = id;
			Username = username;
			Password = password;
			Email = email;

		}

		public Administrateur(String username, String password, String email)
			: this (0, username,password,email) { }

	}
}