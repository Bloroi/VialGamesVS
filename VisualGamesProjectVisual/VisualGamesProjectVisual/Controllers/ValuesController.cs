using JWT.Filters;
using System.Web.Http;

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