using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class NewProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetbyProductID(int productId)
        {
            return Ok("Get method called V 2.0");
        }
    }
}
 