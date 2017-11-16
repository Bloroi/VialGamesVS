﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualGamesProjectVisual.Models
{
	public class Magasinier
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

		public String Tel
		{
			get;
			set;
		}

		
		public Magasinier()
		{

		}

		public Magasinier(int id, String username, String password, String email,String tel)
		{
			Id = id;
			Username = username;
			Password = password;
			Email = email;
			Tel = tel;
		}

		public Magasinier(String username, String password, String email,String tel)
			: this (0, username,password,email,tel) { }

	}
}
