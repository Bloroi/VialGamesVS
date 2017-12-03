using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using VisualGamesProjectVisual.Models;
using WebApi.Jwt;

namespace VisualGamesProjectVisual.Controllers
{
    public class TokenController : ApiController
    {
        // THis is naive endpoint for demo, it should use Basic authentication to provdie token or POST request
        [AllowAnonymous]
        public IEnumerable<string> Get(string username, string password)
        {
            List<string> list = new List<string>();
            string check = CheckUser(username, password);
            if (check != "0")
            {
                list.Add(check);
                list.Add(JwtManager.GenerateToken(username));
            }
            else
            {
                list.Add("0");
            }
            return list;
        }

        public string CheckUser(string username, string password)
        {
            if (MembreDAO.getConnection(username, password))
            {
                return "1" ;
            }
            else
            {
                if (AdministrateurDAO.getConnection(username, password))
                {
                    return "2";
                }
                else
                {
                    if (MagasinierDAO.getConnection(username, password))
                    {
                        return "3";
                    }
                    else
                    {
                        return "0";
                    }
                }
            }
        }
    }
}