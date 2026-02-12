using Infrastructure;
using Services.Interfaces;
using Services.Mappers;
using Services.Concete;
using ViewModels.Request;
using ViewModels.Response;
using Microsoft.EntityFrameworkCore;

namespace Services.Concete
{
    public class ProductService : IProductService
    {
        private readonly CrudApiDBContext _dbContext;
        public ProductService(CrudApiDBContext crudApiDBContext)
        {
            _dbContext = crudApiDBContext;
        }

        public async Task<GetProductResponse> GetproductbyID(int productId)
        {
            //Include is used to add multiple tables data in single query response
            var productDetails = await _dbContext.Products.Include(x => x.ProductDetail).Where(p => p.ProductId == productId).FirstOrDefaultAsync(); // to get single responce

            if (productDetails is not null)
            {
                return new GetProductResponse()
                {
                    //mapping
                    ProductName = productDetails.ProductName,
                    Price = productDetails.Price,
                    BatchCode = productDetails.ProductDetail.BatchCode,
                    manufacturerName = productDetails.ProductDetail.ManufacturerName,
                    AvailableProducts = productDetails.AvailableQty,
                    ProductDescription = productDetails.ProductDescription,
                    ProductId = productDetails.ProductId

                };
            }
            return new GetProductResponse();
            

        }

        public Task<bool> InsertProductAsync(AddProductRequest addProductRequest)
        {
            // we are converting the model data ---> service ----> DB model (Product) and then we will insert the data into DB
            //Service layer to DB layer  
            //Product prodData = new Product();
            //prodData.ProductName = addProductRequest.ProductName;
            //prodData.ProductDescription = addProductRequest.productDescription;
            //prodData.AvailableQty = addProductRequest.AvailabiltyQTY;
            //prodData.Price = addProductRequest.Price;
            //// the above code is working but we will use extention methods which is used as per industry standards and best practices to convert the data from one model to another model (AddProductRequest to Product)
            //// and we will use AutoMapper for that but for now we are doing it manually
            ///the above code transvers to Mapperfolder =>ConvertToProductModel();

            // mapper 
            var prodData = addProductRequest.ConvertToProductModel(); // this method is created in ProductServiceMapper class in Mappers folder and we are using it here to convert the data from AddProductRequest to Product model


            // Moved to mapper class
            //ProductDetail productDetail = new ProductDetail();
            //productDetail.ManufacturerName = addProductRequest.prouctDetailsRequest.Manufacturer;
            //productDetail.BatchCode = addProductRequest.prouctDetailsRequest.BatchCode; // used to insert data in table 2 
           // prodData.ProductDetail = productDetail;

            _dbContext.Products.Add(prodData);
            // ef code 
          // add in context 
            int affectedRows = _dbContext.SaveChanges(); // i  var data = _dbContext.Products.Add(prodData); nsertred changes in DB
            return affectedRows > 0 ? Task.FromResult(true) : Task.FromResult(false);
        } 
    }
}
