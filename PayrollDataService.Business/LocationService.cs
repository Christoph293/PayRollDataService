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
        private IBusinessAssociateRepository businessAssociateRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;        
        }

        public Task<Location> AddLocation(Location location)
        {
            return Task.Run(() => { return locationRepository.AddLocation(location); });
        }

        public bool AreLocationsPartOfBusinessAssociation(int businessAssociate, List<int> locationIds)
        {
            throw new NotImplementedException();
        }

        public Task<BusinessAssociate> ChangeBusinessAssociateOfLocation(int locationId, int id)
        {
            return Task.Run(() =>
            {
                locationRepository.UpdateBusinessAssociateOfLocation(locationId, id);
                return businessAssociateRepository.GetBusinessAssociate(id);
            });
        }

        public Task<Location> DeleteLocation(int id)
        {
            return Task.Run(() => { return locationRepository.DeleteLocation(id); });
        }

        public bool DoesLocationExist(int locationId)
        {
            return locationRepository.GetLocation(locationId) != null;
        }

        public bool DoLocationsExist(List<int> locationIds)
        {
            return locationRepository.GetLocations(locationIds).Count() == locationIds.Count();
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
