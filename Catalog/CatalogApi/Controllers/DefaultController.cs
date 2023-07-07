using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "This API is running..";
        }
    }
}
