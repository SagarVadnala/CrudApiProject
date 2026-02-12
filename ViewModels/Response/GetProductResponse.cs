using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Response
{
    public class GetProductResponse
    {
        public int ProductId { get; set; }
       // public string productDetails { get; set; }
        public string ProductName { get; set; } = default!;
        public string ProductDescription { get; set; } = default!;
        public decimal? Price { get; set; }
        public int AvailableProducts { get; set; } // we can use seperate model naming as we will bind it later
        public string manufacturerName { get; set; } = default!;
        public string BatchCode { get; set; } = default!;
    }
}
