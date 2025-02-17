using PayrollDataService.Interface;
using PayrollDataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.Business
{
    public class LocationService : ILocationService
    {
        private ILocationRepository locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;        
        }

        public Task<Location> AddLocation(Location location)
        {
            return Task.Run(() => { return locationRepository.AddLocation(location); });
        }

        public Task<Location> DeleteLocation(int id)
        {
            return Task.Run(() => { return locationRepository.DeleteLocation(id); });
        }

        public Location GetLocation(int id)
        {
            return locationRepository.GetLocation(id);
        }

        public IEnumerable<Location> GetLocationByBusinessAssociateId(int businessAssociateId)
        {
            return locationRepository.GetLocationByBusinessAssociateId(businessAssociateId);
        }

        public IEnumerable<Location> GetLocations()
        {
            return locationRepository.GetLocations();
        }

        public Task<Location> UpdateLocation(int id, Location location)
        {
            return Task.Run(() => { return locationRepository.UpdateLocation(id, location); });
        }
    }
}
