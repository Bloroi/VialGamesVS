using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VialGamesVisual.Models;
using VisualGamesProjectVisual.Models;

namespace VisualGamesProjectVisual.Controllers
{
	public class MagasinierController : ApiController
	{

		//http//127.0.0.1:8080/api/magasinier
		public IEnumerable<Magasinier> Get()
		{
			return MagasinierDAO.getAllMagasinier();

		}

		public Magasinier Get(int id)
		{
			return MagasinierDAO.Get(id);
		}

        public Magasinier Get(string username, string password)
        {
            return MagasinierDAO.getMag(username, password);
        }

        public Magasinier Post(Magasinier mag)
		{
			return MagasinierDAO.Create(mag);
		}

		public string Put(Magasinier mag)// update = Put
		{
			if (MagasinierDAO.Update(mag))
			{
				return "OK";

			}

			return "KO";
		}


		public string Delete(int id)
		{
			if (MagasinierDAO.Delete(id))
			{
				return "OK";

			}

			return"KO";
		}
	
}
}