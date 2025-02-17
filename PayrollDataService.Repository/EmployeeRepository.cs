using PayrollDataService.Interface;
using PayrollDataService.Model;

namespace PayrollDataService.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployeesByBusinessAssociateId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployeesByLocationId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLocationsOfEmployee(int id, List<int> locationIds)
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.GetEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
