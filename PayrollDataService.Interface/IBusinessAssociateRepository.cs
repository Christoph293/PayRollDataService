using PayrollDataService.Model;

namespace PayrollDataService.Interface
{
    public interface IBusinessAssociateRepository
    {
        IEnumerable<BusinessAssociate> GetBusinessAssociates();

        BusinessAssociate GetBusinessAssociate(int id);

        Task<BusinessAssociate> AddBusinessAssociate(BusinessAssociate businessAssociate);

        Task<BusinessAssociate> UpdateBusinessAssociate(int id, BusinessAssociate businessAssociate);

        Task<BusinessAssociate> DeleteBusinessAssociate(int id);
    }
}
