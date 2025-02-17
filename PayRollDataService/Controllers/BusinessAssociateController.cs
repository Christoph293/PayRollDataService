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
        private IBusinessAssociateRepository businessAssociateRepository;
        private ILocationRepository locationRepository;
        private IEmployeeRepository employeeRepository;

        public BusinessAssociateController(ILogger<BusinessAssociateController> logger, IBusinessAssociateRepository businessAssociateRepository, ILocationRepository locationRepository, IEmployeeRepository employeeRepository)
        {
            this.logger = logger;
            this.businessAssociateRepository = businessAssociateRepository;
            this.locationRepository = locationRepository;
            this.employeeRepository = employeeRepository;
        }

        [HttpGet(Name = "GetBusinessAssociates")]
        public IEnumerable<BusinessAssociate> Get() => businessAssociateRepository.GetBusinessAssociates();

        [HttpGet("{id:int}")]
        public BusinessAssociate Get(int id) => businessAssociateRepository.GetBusinessAssociate(id);

        [HttpGet("{id:int}/locations")]
        public IEnumerable<Location> GetLocationsByBusinessAssociateId(int id) => locationRepository.GetLocationByBusinessAssociateId(id);

        [HttpGet("{id:int}/employees")]
        public IEnumerable<Employee> GetEmployeesByBusinessAssociateId(int id) => employeeRepository.GetEmployeesByBusinessAssociateId(id);

        [HttpPost]
        public async Task<ActionResult<BusinessAssociate>> PostBusinessAssociate(BusinessAssociate businessAssociate)
        {
            return await businessAssociateRepository.AddBusinessAssociate(businessAssociate);
        }

        [HttpPut]
        public async Task<ActionResult<BusinessAssociate>> PutBusinessAssociate(int id, BusinessAssociate businessAssociate)
        {
            return await businessAssociateRepository.UpdateBusinessAssociate(id, businessAssociate);
        }

        [HttpDelete]
        public async Task<ActionResult<BusinessAssociate>> DeleteBusinessAssociate(int id)
        {
            return await businessAssociateRepository.DeleteBusinessAssociate(id);
        }
    }
}
