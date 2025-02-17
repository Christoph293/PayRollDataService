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
        private IEmployeeRepository employeeRepository;
        private ILogger<EmployeeController> logger;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
        {
            this.employeeRepository = employeeRepository;
            this.logger = logger;
        }

        [HttpGet(Name = "GetEmployees")]
        public IEnumerable<Employee> Get() => employeeRepository.GetEmployees();

        [HttpGet("{Id}")]
        public Employee Get(int id) => employeeRepository.GetEmployee(id);

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee) => await employeeRepository.AddEmployee(employee);

        [HttpPut]
        public async Task<ActionResult<Employee>> PutEmployee(int id, Employee employee) => await employeeRepository.UpdateEmployee(id, employee);

        [HttpPut("{id:int}/locations")]
        public async Task<ActionResult<Employee>> UpdateEmployeeLocations(int id, [FromBody] List<int> locationIds)
        {
            await employeeRepository.UpdateLocationsOfEmployee(id, locationIds);
            return employeeRepository.GetEmployee(id);
        }
        

        [HttpDelete]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id) => await employeeRepository.DeleteEmployee(id);
    }
}
