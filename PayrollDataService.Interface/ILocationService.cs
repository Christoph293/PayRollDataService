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
    }
}
