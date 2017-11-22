using System.Web.Http;
using VisualGamesProjectVisual.Filters;

namespace JWT.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values/
        [JwtAuthentication]
        public string Get()
        {
            return "value";
        }

    }
}