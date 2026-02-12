namespace Infrastructure
/*
        **** Data Model and act as DTO (Data Transfer Object) ****
        Entity Class
        Because:
        It represents a real-world domain object → Customer
        It contains properties that map to data fields (like a database table)
*/
{

    //Models
    public class ProductDetail
    {
       public int Id { get; set; }

        public string ManufacturerName { get; set; }

        public string BatchCode { get; set; }


        public int ProductId { get; set; }
        public Product product { get; set; }

    }
}



/*
 * Product table
 * 1.ID
 * 2.productname
 * 3.Product description
 * 4.Price
 * 5.AvailableQty
 *
 *Product details
 *2.ProductId
 *3.ManufacturerName
 *4.BatchCode
 */
