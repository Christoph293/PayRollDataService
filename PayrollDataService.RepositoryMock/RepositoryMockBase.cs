using Bogus;
using PayrollDataService.Interface;
using PayrollDataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.RepositoryMock
{
    public class RepositoryMockBase : IRepositoryMockBase
    {

        public IList<Employee> Employees { get; }
        public IList<BusinessAssociate> BusinessAssociates { get; }
        public IList<Location> Locations { get; }
        public IList<CommunicationData> CommunicationDatas { get; }
        public IList<AddressData> AddressDatas { get; }

        public RepositoryMockBase()
        {
            AddressDatas = new Faker<AddressData>()
                .RuleFor(x => x.ID, f => f.IndexFaker)
                .RuleFor(x => x.Street, f => f.Address.StreetAddress())
                .RuleFor(x => x.StreetNo, f => f.Address.StreetSuffix())
                .RuleFor(x => x.PostalCode, f => f.Address.CityPrefix())
                .RuleFor(x => x.City, f => f.Address.City())
                .RuleFor(x => x.Country, f => f.Address.Country())
                .Generate(1500).ToList();

            CommunicationDatas = new Faker<CommunicationData>()
                .RuleFor(x => x.ID, f => f.IndexFaker)
                .RuleFor(x => x.Type, CommunicationType.Mobile)
                .RuleFor(x => x.Content, f => f.Phone.PhoneNumber())
                .Generate(1500).ToList();

            Locations = new Faker<Location>()
                .RuleFor(x => x.ID, f => f.IndexFaker)
                .RuleFor(x => x.Name, f => f.Address.City())
                .Generate(500).ToList();

            BusinessAssociates = new Faker<BusinessAssociate>()
                .RuleFor(x => x.ID, f => f.IndexFaker)
                .RuleFor(x => x.Name, f => f.Company.CompanyName())
                .Generate(100).ToList();

            var random = new Random();

            foreach (var item in BusinessAssociates)
            {
                var firstLocation = random.Next(Locations.Count);
                var secondLocation = random.Next(Locations.Count);
                item.Locations = new List<int> { firstLocation, secondLocation };

                Locations[firstLocation].BusinessAssociate = item.ID;
                Locations[secondLocation].BusinessAssociate = item.ID;
                item.AddressData = AddressDatas[random.Next(AddressDatas.Count)];
                item.CommunicationDatas = new List<CommunicationData> { CommunicationDatas[random.Next(CommunicationDatas.Count)] };
            }


            Employees = new Faker<Employee>()
                .RuleFor(x => x.ID, f => f.IndexFaker)
                .RuleFor(x => x.Name, f => f.Name.FirstName() + " " + f.Name.LastName())
                .Generate(1000).ToList();

            foreach(var employee in Employees)
            {
                employee.BusinessAssociate = random.Next(BusinessAssociates.Count);
                employee.Locations = new List<int> { random.Next(BusinessAssociates[employee.BusinessAssociate].Locations.Count()) };
                employee.AddressData = AddressDatas[random.Next(AddressDatas.Count)];
                employee.CommunicationDatas = new List<CommunicationData> { CommunicationDatas[random.Next(CommunicationDatas.Count)] };
            }
        }
    }
}
