using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Request;

namespace Services.Mappers
{
    public static class ProductServiceMapper
    {
        public static Product ConvertToProductModel(this AddProductRequest request)
        {
            return new Product()
            {
                ProductName = request.ProductName,
                ProductDescription = request.productDescription,
                Price = request.Price,
                AvailableQty = request.AvailabiltyQTY,
                ProductDetail = new ProductDetail()
                {
                    ManufacturerName = request.prouctDetailsRequest.Manufacturer,
                    BatchCode = request.prouctDetailsRequest.BatchCode
                }
            };

        }
    }
}
