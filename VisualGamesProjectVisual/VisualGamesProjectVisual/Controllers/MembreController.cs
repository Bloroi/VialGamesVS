using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VisualGamesProjectVisual.Filters;
using VisualGamesProjectVisual.Models;

namespace VisualGamesProjectVisual.Controllers
{
    public class MembreController : ApiController
    {
        // GET: api/Membre
        public IEnumerable<Membre> Get()
        {
            return MembreDAO.GetAllMembre();
        }

        // GET: api/Membre/5
        public Membre Get(int id)
        {
            return MembreDAO.Get(id);
        }

        // POST: api/Membre
        public Membre Post(Membre membre)
        {
            return MembreDAO.Create(membre);
        }

        // PUT: api/Membre/5
        public string Put(Membre membre)
        {
            if (MembreDAO.Update(membre))
            {
                return "OK";
            }
            return "KO";
        }

        // DELETE: api/Membre/5
        public string Delete(int id)
        {
            if (MembreDAO.Delete(id))
            {
                return "OK";
            }
            return "KO";
        }
    }
}
