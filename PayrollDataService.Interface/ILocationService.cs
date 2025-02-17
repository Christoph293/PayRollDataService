using PayrollDataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.Interface
{
    public interface ILocationService
    {
        IEnumerable<Location> GetLocations();

        IEnumerable<Location> GetLocationByBusinessAssociateId(int businessAssociateId);

        Location GetLocation(int id);

        Task<Location> AddLocation(Location location);

        Task<Location> UpdateLocation(int id, Location location);

        Task<Location> DeleteLocation(int id);

        bool DoLocationsExist(List<int> locationIds);

        bool DoesLocationExist(int locationId);

        Task<BusinessAssociate> ChangeBusinessAssociateOfLocation(int locationId, int id);

        bool AreLocationsPartOfBusinessAssociation(int businessAssociate, List<int> locationIds);
    }
}
