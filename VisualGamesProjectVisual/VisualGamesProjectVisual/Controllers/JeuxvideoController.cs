using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VialGamesVisual.Models;
using VisualGamesProjectVisual.Filters;

namespace VialGamesVisual.Controllers
{
	public class JeuxvideoController : ApiController
	{
        //http//127.0.0.1:8080/api/jeuxvideo
        public IEnumerable<Jeuxvideo> Get()
		{
			return JeuxvideoDAO.getAllJeuxvideo();

		}

		public Jeuxvideo Get(int id)
		{
			return JeuxvideoDAO.Get(id);
		}

		public Jeuxvideo Post(Jeuxvideo jv)
		{
			return JeuxvideoDAO.Create(jv);
		}

		public IHttpActionResult Put(Jeuxvideo jv)// update = Put
		{
			if (JeuxvideoDAO.Update(jv))
			{
				return Ok();

			}

			return BadRequest();
		}


		public IHttpActionResult Delete(int id)
		{
			if (JeuxvideoDAO.Delete(id))
			{
				return Ok();

			}

			return BadRequest();
		}
	}
}