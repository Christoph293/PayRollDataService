using PayrollDataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.Interface
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetLocations();

        IEnumerable<Location> GetLocationByBusinessAssociateId(int businessAssociateId);

        Location GetLocation(int id);

        Location AddLocation(Location location);

        Location UpdateLocation(int id, Location location);

        Location DeleteLocation(int id);

        IEnumerable<Location> GetLocations(List<int> locationIds);

        void UpdateBusinessAssociateOfLocation(int locationId, int id);
    }
}
