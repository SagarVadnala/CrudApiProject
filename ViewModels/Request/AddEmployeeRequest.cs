using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Request
{
    public class AddEmployeeRequest
    {
        [Required]
        [StringLength(100,ErrorMessage ="First name should not exceed 100 char")]
        public string FirstName { get; set; }
        public string lastname { get; set; }
    }
}
