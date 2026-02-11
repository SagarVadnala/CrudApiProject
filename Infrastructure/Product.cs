namespace Infrastructure
/*
        **** Data Model and act as DTO (Data Transfer Object) ****
        Entity Class
        Because:
        It represents a real-world domain object → Customer
        It contains properties that map to data fields (like a database table)
*/
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int AvailableQty { get; set; }
    }
}



/*
 * Product table
 * 1.ID
 * 2.productname
 * 3.Product description
 * 4.Price
 * 5.AvailableQty
 */
