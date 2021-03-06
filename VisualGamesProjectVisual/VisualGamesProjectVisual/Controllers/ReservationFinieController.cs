﻿using System;
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


		public IEnumerable<ReservationFinie> GetMembreRes(int idMembre)
		{
			return ReservationFinieDAO.GetReservMembre(idMembre);
		}

		public IEnumerable<ReservationFinie> Get(int type, int id)
		{
			if (type == 0)
			{
				return ReservationFinieDAO.GetAllReservationFinie(id);
			}
			else
			{
				return ReservationFinieDAO.GetAllReservationFinieMembre(id);
			}
		}

		// POST api/<controller>
		public ReservationFinie Post(ReservationFinie reserv)
        {
            return ReservationFinieDAO.Create(reserv);
        }

        // PUT api/<controller>/5
        public string Put(ReservationFinie reserv)
        {
            if (ReservationFinieDAO.Update(reserv))
            {
                return "OK";
            }
            return "KO";
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            if (ReservationFinieDAO.Delete(id))
            {
                return "OK";
            }
            return "KO";
        }
    }
}