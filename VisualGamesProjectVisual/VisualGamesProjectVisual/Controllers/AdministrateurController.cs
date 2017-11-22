using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VialGamesVisual.Models;
using VisualGamesProjectVisual.Models;

namespace VisualGamesProjectVisual.Controllers
{
	public class AdministrateurController : ApiController
	{

		//http//127.0.0.1:8080/api/Administrateur
		public IEnumerable<Administrateur> Get()
		{
			return AdministrateurDAO.getAllAdministrateur();

		}

		public Administrateur Get(int id)
		{
			return AdministrateurDAO.Get(id);
		}

		public Administrateur Post(Administrateur a)
		{
			return AdministrateurDAO.Create(a);
		}

		public string Put(Administrateur a)// update = Put
		{
			if (AdministrateurDAO.Update(a))
			{
				return "OK";

			}

			return "KO";
		}


		public string Delete(int id)
		{
			if (AdministrateurDAO.Delete(id))
			{
				return "OK";

			}

			return "KO";
		}
	}
}