using Asp.Versioning;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Services.Concete;
using Services.Interfaces;
using System.Threading.Tasks;
using ViewModels.Request;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CrudAPI.Controllers
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProductController : ControllerBase
    {


        private readonly IProductService _productService;
        private readonly IValidator<AddProductRequest> _validator;
        

        //constructor for DI *****
        public ProductController(IProductService productService, IValidator<AddProductRequest> validator)
        {
            _productService = productService;
            _validator = validator;
        }


         
        [HttpGet]
        [Route ("GetProductById/{productId}")] // this is the route for the Get method and we can call it like this api/Product/GetProductById/1
        public async Task<IActionResult> Get( int productId)
        {
            var responce = await _productService.GetproductbyID(productId);
            return Ok(responce);
        }
        //[HttpGet]
        //[Route("GetProductByname/{productName}")]
        //public async Task<IActionResult> GetbyName( int productId)
        //{
        //    var responce = await _productService.GetproductbyID(productId);
        //    return Ok(responce);
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductRequest addProductRequest) // Parameter binding  and the passed data will be binded to the AddProductRequest class properties and we can use it in our method
        {

            //validation
            ValidationResult result =await _validator.ValidateAsync(addProductRequest);

            if (result.IsValid)
            {
                //// Below code will work but not recommended and used in legacy application we will use DI
                //ProductService service = new ProductService();
                //service.InsertProductAsync(addProductRequest);

                //using DI
                var response = await _productService.InsertProductAsync(addProductRequest);

                return Ok(response);
            }

            return BadRequest(result.Errors.Select(x=> new {PropertyName = x.PropertyName, Erroressage = x.ErrorMessage})); // this line is used to return the validation errors in the response if the validation fails


        }

        [HttpPut]
        public IActionResult Put()
        { 
            return Ok();
        }
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            bool responce = await _productService.DeleteProductbyId(productId);
            return Ok(responce);
        }
    }
}
