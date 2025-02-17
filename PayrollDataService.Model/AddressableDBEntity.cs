using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.Model
{
    public abstract class AddressableDBEntity
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public required AddressData AddressData { get; set; }
        public required IEnumerable<CommunicationData> CommunicationDatas { get; set; }
    }
}
