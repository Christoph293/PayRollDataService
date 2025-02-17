using PayrollDataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.Interface
{
    public interface IBusinessAssociateService
    {
        IEnumerable<BusinessAssociate> GetBusinessAssociates();

        BusinessAssociate GetBusinessAssociate(int id);

        Task<BusinessAssociate> AddBusinessAssociate(BusinessAssociate businessAssociate);

        Task<BusinessAssociate> UpdateBusinessAssociate(int id, BusinessAssociate businessAssociate);

        Task<BusinessAssociate> DeleteBusinessAssociate(int id);
        bool DoesBusinessAssociateExist(int businessAssociateId);
    }
}
