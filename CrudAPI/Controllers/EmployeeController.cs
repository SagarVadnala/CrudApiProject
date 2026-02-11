using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // if we remove this it will be not be an API program 
    public class EmployeeController : ControllerBase
    {
        [HttpGet(Name = "Fetch")]
        public IActionResult GetEmployee()
        {
            return Ok(GetAllEmployee());
        }
        [HttpPost(Name = "Fetch")]
        public IActionResult PostEmployee()
        {
            return Ok("Post method called");
        }
        [HttpPut(Name = "Fetch")]
        public IActionResult PutEmployee()
        {
            return Ok("Put method called");
        }
        [HttpDelete(Name = "Fetch")]
        public IActionResult DeleteEmployee()
        {
            return Ok("Delete method called");
        }

        //below method act as a DB temporarly 
        private List<Employee> GetAllEmployee()
        {
            return new List<Employee>()
                        {
                                new Employee()
                                {
                                    Id=1,
                                    Gender="Male",
                                    Name="John",
                                    Department="IT"
                                },
                                new Employee()
                                {
                                    Id=1,
                                    Gender="Male",
                                    Name="Jap",
                                    Department="IT"
                                },
                                new Employee()
                                {
                                    Id=1,
                                    Gender="Male",
                                    Name="Sam",
                                    Department="Tester"
                                },
                                new Employee()
                                {
                                    Id=4,
                                    Gender="Male",
                                    Name="JPEE",
                                    Department="IOT"
                                },
                                new Employee()
                                {
                                    Id=5,
                                    Gender="Female",
                                    Name="Sappy",
                                    Department="Developer"
                                }
                        };
        }
    }
}
