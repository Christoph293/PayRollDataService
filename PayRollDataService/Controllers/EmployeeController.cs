using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollDataService.Interface;
using PayrollDataService.Model;

namespace PayrollDataService.Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService employeeService;
        private ILogger<EmployeeController> logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            this.employeeService = employeeService;
            this.logger = logger;
        }

        [HttpGet(Name = "GetEmployees")]
        public IEnumerable<Employee> Get() => employeeService.GetEmployees();

        [HttpGet("{Id}")]
        public Employee Get(int id) => employeeService.GetEmployee(id);

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee) => await employeeService.AddEmployee(employee);

        [HttpPut]
        public async Task<ActionResult<Employee>> PutEmployee(int id, Employee employee) => await employeeService.UpdateEmployee(id, employee);

        [HttpPut("{id:int}/locations")]
        public async Task<ActionResult<Employee>> UpdateEmployeeLocations(int id, [FromBody] List<int> locationIds)
        {
            await employeeService.UpdateLocationsOfEmployee(id, locationIds);
            return employeeService.GetEmployee(id);
        }
        

        [HttpDelete]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id) => await employeeService.DeleteEmployee(id);
    }
}
