using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.Model
{
    public class BusinessAssociate : AddressableDBEntity
    {
        public BusinessAssociate()
        {
            Locations = new List<int>();
        }

        public IList<int> Locations;
    }
}
