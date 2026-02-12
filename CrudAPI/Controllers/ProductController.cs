using Microsoft.AspNetCore.Mvc;
using Services.Concete;
using Services.Interfaces;
using System.Threading.Tasks;
using ViewModels.Request;

namespace CrudAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {


        private readonly IProductService _productService;
        //constructor for DI *****
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> Get( int productId)
        {
            var responce = await _productService.GetproductbyID(productId);
            return Ok(responce);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductRequest addProductRequest) // Parameter binding  and the passed data will be binded to the AddProductRequest class properties and we can use it in our method
        {
            //// Below code will work but not recommended and used in legacy application we will use DI
            //ProductService service = new ProductService();
            //service.InsertProductAsync(addProductRequest);

            //using DI
            var response = await _productService.InsertProductAsync(addProductRequest);

            return Ok(response);
        }

        [HttpPut]
        public IActionResult Put()
        { 
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
