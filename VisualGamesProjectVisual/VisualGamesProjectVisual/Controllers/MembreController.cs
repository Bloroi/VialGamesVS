using JWT.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        public Boolean Get(int type, string chaine)
        {
            if (type == 1)
            {
                return MembreDAO.checkValidityUsername(chaine);
            }
            else
            {
                return MembreDAO.checkValidityEmail(chaine);
            }
        }

        public Membre Get(string username, string password)
        {
            return MembreDAO.getMembre(username, password);
        }

        // POST: api/Membre
        public Membre Post(Membre membre)
        {
            return MembreDAO.Create(membre);
        }

        // PUT: api/Membre/5
        [JwtAuthentication]
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
