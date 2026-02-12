using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Request;
using ViewModels.Response;

namespace Services.Interfaces
{
    public interface IProductService
    {
        Task<bool> InsertProductAsync(AddProductRequest addProductRequest);
        Task<GetProductResponse> GetproductbyID(int productId);
    }
}
