using PayrollDataService.Interface;
using PayrollDataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.Business
{
    public class BusinessAssociateService : IBusinessAssociateService
    {
        public IBusinessAssociateRepository businessAssociateRepository;

        public BusinessAssociateService(IBusinessAssociateRepository businessAssociateRepository)
        {
            this.businessAssociateRepository = businessAssociateRepository;
        }

        public Task<BusinessAssociate> AddBusinessAssociate(BusinessAssociate businessAssociate)
        {
            return Task.Run(() =>
            {
                return businessAssociateRepository.AddBusinessAssociate(businessAssociate);
            });
        }

        public Task<BusinessAssociate> DeleteBusinessAssociate(int id)
        {
            return Task.Run(() =>
            {
                return businessAssociateRepository.DeleteBusinessAssociate(id);
            });
        }

        public BusinessAssociate GetBusinessAssociate(int id)
        {
            return businessAssociateRepository.GetBusinessAssociate(id);
        }

        public IEnumerable<BusinessAssociate> GetBusinessAssociates()
        {
            return businessAssociateRepository.GetBusinessAssociates();
        }

        public Task<BusinessAssociate> UpdateBusinessAssociate(int id, BusinessAssociate businessAssociate)
        {
            return Task.Run(() =>
            {
                return businessAssociateRepository.UpdateBusinessAssociate(id, businessAssociate);
            });
        }
    }
}
