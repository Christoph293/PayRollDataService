using PayrollDataService.Interface;
using PayrollDataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.Repository
{
    public class BusinessAssociateRepository : IBusinessAssociateRepository
    {
        public Task<BusinessAssociate> AddBusinessAssociate(BusinessAssociate businessAssociate)
        {
            throw new NotImplementedException();
        }

        public Task<BusinessAssociate> DeleteBusinessAssociate(int id)
        {
            throw new NotImplementedException();
        }

        public BusinessAssociate GetBusinessAssociate(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessAssociate> GetBusinessAssociates()
        {
            throw new NotImplementedException();
        }

        public Task<BusinessAssociate> UpdateBusinessAssociate(int id, BusinessAssociate businessAssociate)
        {
            throw new NotImplementedException();
        }
    }
}
