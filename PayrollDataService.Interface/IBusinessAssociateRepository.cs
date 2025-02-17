using PayrollDataService.Model;

namespace PayrollDataService.Interface
{
    public interface IBusinessAssociateRepository
    {
        IEnumerable<BusinessAssociate> GetBusinessAssociates();

        BusinessAssociate GetBusinessAssociate(int id);

        BusinessAssociate AddBusinessAssociate(BusinessAssociate businessAssociate);

        BusinessAssociate UpdateBusinessAssociate(int id, BusinessAssociate businessAssociate);

        BusinessAssociate DeleteBusinessAssociate(int id);
    }
}
