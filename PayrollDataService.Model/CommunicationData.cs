using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.Model
{
    public class CommunicationData
    {
        public int ID { get; set; }

        public CommunicationType Type { get; set; }

        public string Content { get; set; }
    }
}
