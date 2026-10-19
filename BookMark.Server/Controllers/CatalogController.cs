using BookMark.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookMark.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController(ICatalogService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TestResult([FromQuery] string q)
        {
            // ex. flowers+inauthor:keyes
            var result = await service.GetBookAsync(q);
            return Ok(result);
        }
    }
}
