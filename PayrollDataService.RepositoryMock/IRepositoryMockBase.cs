using PayrollDataService.Model;

namespace PayrollDataService.RepositoryMock
{
    public interface IRepositoryMockBase
    {
        public IList<Employee> Employees { get; }
        public IList<BusinessAssociate> BusinessAssociates { get; }
        public IList<Location> Locations { get; }
        public IList<CommunicationData> CommunicationDatas { get; }
        public IList<AddressData> AddressDatas { get; }
    }
}