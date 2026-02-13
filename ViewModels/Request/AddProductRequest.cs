using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Request;

namespace ViewModels.Request
{
    public class AddProductRequest
    {
        public string ProductName { get; set; } = default!;
        public string productDescription { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public int AvailabiltyQTY { get; set; }


        // go to CruidApi project (API layer)  => Product controller
        public ProuctDetailsRequest prouctDetailsRequest { get; set; } = default!;
        // this will add the data to productDetailsRequest also
    }
}

/*
*Product table Models
* 1.ProductId
* 2.productname
* 3.Product description
* 4.Price
* 5.AvailableQty
*/

public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
{
    public AddProductRequestValidator()
    {
        RuleFor(product => product.ProductName)
            .NotNull()
            .Length(100)
            .WithMessage("mx product lentg is 100");
        RuleFor(product => product.productDescription)
            .NotNull()
            .Length(200)
            .WithMessage("Product description should not be more then 200 char kindly reduce it");
        
    }
}
