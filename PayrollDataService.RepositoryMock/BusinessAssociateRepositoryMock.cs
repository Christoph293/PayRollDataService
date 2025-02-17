using PayrollDataService.Interface;
using PayrollDataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.RepositoryMock
{
    public class BusinessAssociateRepositoryMock : IBusinessAssociateRepository
    {
        private IRepositoryMockBase repositoryMockBase;

        public BusinessAssociateRepositoryMock(IRepositoryMockBase repositoryMock)
        {
            this.repositoryMockBase = repositoryMock;
        }

        public BusinessAssociate AddBusinessAssociate(BusinessAssociate businessAssociate)
        {
            repositoryMockBase.BusinessAssociates.Add(businessAssociate); 
            return businessAssociate;
        }

        public BusinessAssociate DeleteBusinessAssociate(int id)
        {
            var businessAssociate = repositoryMockBase.BusinessAssociates.First(x => x.ID == id);
            repositoryMockBase.BusinessAssociates.Remove(businessAssociate);
            return businessAssociate;
        }

        public BusinessAssociate GetBusinessAssociate(int id)
        {
            return repositoryMockBase.BusinessAssociates.Where(x => x.ID == id).FirstOrDefault();
        }

        public IEnumerable<BusinessAssociate> GetBusinessAssociates()
        {
            return repositoryMockBase.BusinessAssociates;
        }

        public BusinessAssociate UpdateBusinessAssociate(int id, BusinessAssociate businessAssociate)
        {
             repositoryMockBase.BusinessAssociates.Remove(repositoryMockBase.BusinessAssociates.First(x => x.ID == id)); 
             repositoryMockBase.BusinessAssociates.Add(businessAssociate); return businessAssociate;
        }
    }
}
