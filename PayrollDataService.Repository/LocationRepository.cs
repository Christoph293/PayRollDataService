using PayrollDataService.Interface;
using PayrollDataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.Repository
{
    public class LocationRepository : ILocationRepository
    {
        public Location AddLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public Location DeleteLocation(int id)
        {
            throw new NotImplementedException();
        }

        public Location GetLocation(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetLocationByBusinessAssociateId(int businessAssociateId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetLocations()
        {
            throw new NotImplementedException();
        }

        public Location UpdateLocation(int id, Location location)
        {
            throw new NotImplementedException();
        }
    }
}
