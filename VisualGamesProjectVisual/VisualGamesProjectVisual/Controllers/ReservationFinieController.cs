using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VisualGamesProjectVisual.Models;

namespace VisualGamesProjectVisual.Controllers
{
    public class ReservationFinieController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<ReservationFinie> Get()
        {
            return ReservationFinieDAO.GetAllReservationFinie();
        }

        // GET api/<controller>/5
        public ReservationFinie Get(int id)
        {
            return ReservationFinieDAO.Get(id);
        }

        // POST api/<controller>
        public ReservationFinie Post(ReservationFinie reserv)
        {
            return ReservationFinieDAO.Create(reserv);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(ReservationFinie reserv)
        {
            if (ReservationFinieDAO.Update(reserv))
            {
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            if (ReservationFinieDAO.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}