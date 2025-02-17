using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollDataService.Interface;
using PayrollDataService.Model;
using PayrollDataService.Repository;

namespace PayrollDataService.Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessAssociateController : ControllerBase
    {
        private ILogger<BusinessAssociateController> logger;
        private IBusinessAssociateService businessAssociateService;
        private ILocationService locationService;
        private IEmployeeService employeeService;

        public BusinessAssociateController(ILogger<BusinessAssociateController> logger, IBusinessAssociateService businessAssociateRepository, ILocationService locationRepository, IEmployeeService employeeRepository)
        {
            this.logger = logger;
            this.businessAssociateService = businessAssociateRepository;
            this.locationService = locationRepository;
            this.employeeService = employeeRepository;
        }

        [HttpGet(Name = "GetBusinessAssociates")]
        public IEnumerable<BusinessAssociate> Get() => businessAssociateService.GetBusinessAssociates();

        [HttpGet("{id:int}")]
        public BusinessAssociate Get(int id) => businessAssociateService.GetBusinessAssociate(id);

        //Usecase 1: Ausgabe aller Standorte eines Geschäftspartners
        [HttpGet("{id:int}/locations")]
        public IEnumerable<Location> GetLocationsByBusinessAssociateId(int id) => locationService.GetLocationByBusinessAssociateId(id);

        //Usecase 2: Ausgabe aller Mitarbeiter eines Geschäftspartners
        [HttpGet("{id:int}/employees")]
        public IEnumerable<Employee> GetEmployeesByBusinessAssociateId(int id) => employeeService.GetEmployeesByBusinessAssociateId(id);

        //Usecase 6: Standort von Geschäftspartner A wird von Geschäftspartner B übernommen
        [HttpPut("{id:int}/locations")]
        public async Task<BusinessAssociate> AddExistingLocationToBusinessAssociate(int id, [FromBody] int locationId)
        {
            if(!locationService.DoesLocationExist(locationId) || !businessAssociateService.DoesBusinessAssociateExist(id))
            {
                throw new System.Web.Http.HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            await employeeService.ChangeBusinessAssociateOfEmployeesWithLocationId(locationId, id);
            return await locationService.ChangeBusinessAssociateOfLocation(locationId, id);
        }

        [HttpPost]
        public async Task<ActionResult<BusinessAssociate>> PostBusinessAssociate(BusinessAssociate businessAssociate)
        {
            return await businessAssociateService.AddBusinessAssociate(businessAssociate);
        }

        [HttpPut]
        public async Task<ActionResult<BusinessAssociate>> PutBusinessAssociate(int id, BusinessAssociate businessAssociate)
        {
            return await businessAssociateService.UpdateBusinessAssociate(id, businessAssociate);
        }

        [HttpDelete]
        public async Task<ActionResult<BusinessAssociate>> DeleteBusinessAssociate(int id)
        {
            return await businessAssociateService.DeleteBusinessAssociate(id);
        }
    }
}
