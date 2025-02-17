using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollDataService.Interface;
using PayrollDataService.Model;
using PayrollDataService.Repository;

namespace PayrollDataService.Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private ILocationRepository locationRepository;
        private IEmployeeRepository employeeRepository;
        private ILogger<LocationController> logger;

        public LocationController(ILocationRepository locationRepository, IEmployeeRepository employeeRepository, ILogger<LocationController> logger)
        {
            this.locationRepository = locationRepository;
            this.employeeRepository = employeeRepository;
            this.logger = logger;
        }

        [HttpGet(Name = "GetLocations")]
        public IEnumerable<Location> Get() => locationRepository.GetLocations();

        [HttpGet("{id:int}")]
        public Location Get(int id) => locationRepository.GetLocation(id);

        [HttpGet("{id:int}/employees")]
        public IEnumerable<Employee> GetEmployeesByLocationId(int id) => employeeRepository.GetEmployeesByLocationId(id);

        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location) => await locationRepository.AddLocation(location);

        [HttpPut]
        public async Task<ActionResult<Location>> PutLocation(int id, Location location) => await locationRepository.UpdateLocation(id, location);

        [HttpDelete]
        public async Task<ActionResult<Location>> DeleteLocation(int id) => await locationRepository.DeleteLocation(id);
    }
}
