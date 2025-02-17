using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollDataService.Interface;
using PayrollDataService.Model;
using System.Numerics;

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

        //Usecase: Mitarbeiter wechselt Standorte
        [HttpPut("{id:int}/locations")]
        public async Task<ActionResult<Employee>> UpdateEmployeeLocations(int id, [FromBody] List<int> locationIds)
        {
            if (!employeeService.DoesEmployeeExist(id) || !locationService.DoLocationsExist(locationIds))
            {
                throw new System.Web.Http.HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            var employee = employeeService.GetEmployee(id);
            if(!locationService.AreLocationsPartOfBusinessAssociation(employee.BusinessAssociate, locationIds))
            {
                throw new System.Web.Http.HttpResponseException(System.Net.HttpStatusCode.PreconditionFailed);
            }

            return await employeeService.UpdateLocationsOfEmployee(id, locationIds);
        }

        //Usecase: Mitarbeiter wechselt Geschäftspartner
        [HttpPut("{id:int}/businessAssociate")]
        public async Task<ActionResult<Employee>> UpdateEmployeeBusinessAssociate(int id, [FromBody] int businessAssociateId)
        {
            if(!employeeService.DoesEmployeeExist(id) || !businessAssociateService.DoesBusinessAssociateExist(businessAssociateId))
            {
                throw new System.Web.Http.HttpResponseException(System.Net.HttpStatusCode.NotFound);
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
