using Microsoft.AspNetCore.Mvc;

namespace ConsumoAPI.Controllers
{
    [ApiController]
    [Route("caracteristica")]
    public class TokenController : Controller
    {
        public async Task<IActionResult> Caracteristicas()
        {
            return View();
        }
    }
}
