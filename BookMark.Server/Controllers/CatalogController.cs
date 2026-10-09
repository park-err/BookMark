using BookMark.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMark.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController(ICatalogService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TestResult()
        {
            var result = await service.GetBookAsync("flowers+inauthor:keyes");
            return Ok(result);
        }
    }
}
