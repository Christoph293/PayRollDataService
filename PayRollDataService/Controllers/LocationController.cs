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
        private ILocationService locationService;
        private IEmployeeService employeeService;
        private ILogger<LocationController> logger;

        public LocationController(ILocationService locationService, IEmployeeService employeeService, ILogger<LocationController> logger)
        {
            this.locationService = locationService;
            this.employeeService = employeeService;
            this.logger = logger;
        }

        [HttpGet(Name = "GetLocations")]
        public IEnumerable<Location> Get() => locationService.GetLocations();

        [HttpGet("{id:int}")]
        public Location Get(int id) => locationService.GetLocation(id);

        //Usecase: Ausgabe aller Mitarbeiter, die an einem Standort arbeiten
        [HttpGet("{id:int}/employees")]
        public IEnumerable<Employee> GetEmployeesByLocationId(int id) => employeeService.GetEmployeesByLocationId(id);

        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location) => await locationService.AddLocation(location);

        [HttpPut]
        public async Task<ActionResult<Location>> PutLocation(int id, Location location) => await locationService.UpdateLocation(id, location);

        [HttpDelete]
        public async Task<ActionResult<Location>> DeleteLocation(int id) => await locationService.DeleteLocation(id);
    }
}
