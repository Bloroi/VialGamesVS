using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VisualGamesProjectVisual.Models;

namespace VisualGamesProjectVisual.Controllers
{
    public class ReservationEnCoursController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<ReservationEnCours> Get()
        {
            return ReservationEnCoursDAO.GetAllReservationEnCours();
        }

        // GET api/<controller>/5
        public ReservationEnCours Get(int id)
        {
            return ReservationEnCoursDAO.Get(id);
        }

        // POST api/<controller>
        public ReservationEnCours Post(ReservationEnCours reserv)
        {
            return ReservationEnCoursDAO.Create(reserv);
        }

        // PUT api/<controller>/5
        public string Put(ReservationEnCours reserv)
        {
            if (ReservationEnCoursDAO.Update(reserv))
            {
				return "OK";
            }
			return "KO";
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            if (ReservationEnCoursDAO.Delete(id))
            {
                return "OK";
            }
            return "KO";
        }
    }
}