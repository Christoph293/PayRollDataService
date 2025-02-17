using PayrollDataService.Interface;
using PayrollDataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.RepositoryMock
{
    public class LocationRepositoryMock : ILocationRepository
    {
        IRepositoryMockBase repositoryMockBase;

        public LocationRepositoryMock(IRepositoryMockBase repositoryMockBase)
        {
            this.repositoryMockBase = repositoryMockBase;
        }

        public Location AddLocation(Location location)
        {
            repositoryMockBase.Locations.Add(location); 
            return location;
        }

        public Location DeleteLocation(int id)
        {
            var location = repositoryMockBase.Locations.First(x => x.ID == id);
            repositoryMockBase.Locations.Remove(location);
            return location;
        }

        public Location GetLocation(int id) => repositoryMockBase.Locations.FirstOrDefault(x => x.ID == id);

        public IEnumerable<Location> GetLocationByBusinessAssociateId(int businessAssociateId)
        {
            var locationIds = repositoryMockBase.BusinessAssociates[businessAssociateId].Locations;
            List<Location> locations = new List<Location>();
            foreach(var id in locationIds)
            {
                locations.Add(repositoryMockBase.Locations[id]);
            }

            return locations;
        }

        public IEnumerable<Location> GetLocations() => repositoryMockBase.Locations.ToList();

        public IEnumerable<Location> GetLocations(List<int> locationIds)
        {
            return repositoryMockBase.Locations.Where(x => locationIds.Contains(x.ID)).ToList();
        }

        public void UpdateBusinessAssociateOfLocation(int locationId, int id)
        {
            throw new NotImplementedException();
        }

        public Location UpdateLocation(int id, Location location)
        {
            repositoryMockBase.Locations.Remove(repositoryMockBase.Locations.First(x => x.ID == id)); 
            repositoryMockBase.Locations.Add(location);
            return location;
        }
    }
}
