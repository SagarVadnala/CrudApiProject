using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class Customer
    {
        public int Id { get; set; } // PROPERTIES by default ID is consider as primary key if we didnt menton it.
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        /*
         to add migration use
        Add-Migration message
        update-Database
         */
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
