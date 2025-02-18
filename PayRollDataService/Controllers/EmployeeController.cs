using Microsoft.AspNetCore.Mvc;
using PayrollDataService.Interface;
using PayrollDataService.Model;
using System.Net;

namespace PayrollDataService.Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService employeeService;
        private ILocationService locationService;
        private IBusinessAssociateService businessAssociateService;
        private ILogger<EmployeeController> logger;

        public EmployeeController(IEmployeeService employeeService, ILocationService locationService, IBusinessAssociateService businessAssociateService, ILogger<EmployeeController> logger)
        {
            this.employeeService = employeeService;
            this.locationService = locationService;
            this.businessAssociateService = businessAssociateService;
            this.logger = logger;
        }

        //Usecase 4: Mitarbeiter wechselt Standorte
        [HttpPut("{id:int}/locations")]
        public async Task<ActionResult<Employee>> UpdateEmployeeLocations(int id, [FromBody] List<int> locationIds)
        {
            if (!employeeService.DoesEmployeeExist(id))
            {
                return NotFound(new
                {
                    ReasonPhrase = "Employee ID Not Found"
                });
            }

            if(!locationService.DoLocationsExist(locationIds))
            {
                return NotFound(new
                {
                    ReasonPhrase = "Location ID Not Found"
                });
            }

            var employee = employeeService.GetEmployee(id);
            if(!locationService.AreLocationsPartOfBusinessAssociation(employee.BusinessAssociate, locationIds))
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, "At least one location is not part of the employees business associate");
            }

            return await employeeService.UpdateLocationsOfEmployee(id, locationIds);
        }

        //Usecase 5: Mitarbeiter wechselt Geschäftspartner
        [HttpPut("{id:int}/businessAssociate")]
        public async Task<ActionResult<Employee>> UpdateEmployeeBusinessAssociate(int id, [FromBody] int businessAssociateId)
        {

            if (!employeeService.DoesEmployeeExist(id))
            {
                return NotFound(new
                {
                    ReasonPhrase = "Employee ID Not Found"
                });
            }

            if (!businessAssociateService.DoesBusinessAssociateExist(businessAssociateId))
            {
                return NotFound(new
                {
                    ReasonPhrase = "Business Associate ID Not Found"
                });
            }

            return await employeeService.UpdateEmployeeBusinessAssociate(id, businessAssociateId);
        }

        [HttpGet(Name = "GetEmployees")]
        public IEnumerable<Employee> Get() => employeeService.GetEmployees();

        [HttpGet("{Id}")]
        public Employee Get(int id) => employeeService.GetEmployee(id);

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee) => await employeeService.AddEmployee(employee);

        [HttpPut]
        public async Task<ActionResult<Employee>> PutEmployee(int id, Employee employee) => await employeeService.UpdateEmployee(id, employee);

        [HttpDelete]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id) => await employeeService.DeleteEmployee(id);
    }
}
