using PayrollDataService.Interface;
using PayrollDataService.Model;

namespace PayrollDataService.RepositoryMock
{
    public class EmployeeRepositoryMock : IEmployeeRepository
    {
        private IRepositoryMockBase repositoryMockBase;

        public EmployeeRepositoryMock(IRepositoryMockBase repositoryMockBase)
        {
            this.repositoryMockBase = repositoryMockBase;
        }

        public Task<Employee> AddEmployee(Employee employee)
        {
            return Task.Run(() => { repositoryMockBase.Employees.Add(employee); return employee; });
        }

        public Task<Employee> DeleteEmployee(int id)
        {
            return Task.Run(() =>
            {
                var employee = repositoryMockBase.Employees.First(x => x.ID == id);
                repositoryMockBase.Employees.Remove(employee);
                return employee;
            });
        }

        public Employee GetEmployee(int id) => repositoryMockBase.Employees.FirstOrDefault(x => x.ID == id);

        public IEnumerable<Employee> GetEmployees() => repositoryMockBase.Employees;

        public IEnumerable<Employee> GetEmployeesByBusinessAssociateId(int id)
        {
            return repositoryMockBase.Employees.Where(x => x.BusinessAssociate == id).ToList();
        }

        public IEnumerable<Employee> GetEmployeesByLocationId(int id)
        {
            return repositoryMockBase.Employees.Where(x => x.Locations.Contains(id)).ToList();
        }

        public Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLocationsOfEmployee(int id, List<int> locationIds)
        {
            throw new NotImplementedException();
        }
    }
}
