using PayrollDataService.Interface;
using PayrollDataService.Model;

namespace PayrollDataService.Business
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Task<Employee> AddEmployee(Employee employee)
        {
            return Task.Run(() =>
            {
                return employeeRepository.AddEmployee(employee);
            });
        }

        public Task ChangeBusinessAssociateOfEmployeesWithLocationId(int locationId, int businessAssociateId)
        {
            return Task.Run(() =>
            {
                employeeRepository.UpdateBusinessAssociateOfEmployeesWithLocationId(locationId, businessAssociateId);
            });
        }

        public Task<Employee> DeleteEmployee(int id)
        {
            return Task.Run(() =>
            {
                return employeeRepository.DeleteEmployee(id);
            });
        }

        public bool DoesEmployeeExist(int id)
        {
            return employeeRepository.GetEmployee(id) != null;
        }

        public Employee GetEmployee(int id)
        {
            return employeeRepository.GetEmployee(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employeeRepository.GetEmployees();
        }

        public IEnumerable<Employee> GetEmployeesByBusinessAssociateId(int id)
        {
            return employeeRepository.GetEmployeesByBusinessAssociateId(id);
        }

        public IEnumerable<Employee> GetEmployeesByLocationId(int id)
        {
            return employeeRepository.GetEmployeesByLocationId(id);
        }

        public Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            return Task.Run(() =>
            {
                return employeeRepository.UpdateEmployee(id, employee);
            });
        }

        public Task<Employee> UpdateEmployeeBusinessAssociate(int id, int businessAssociateId)
        {
            return Task.Run(() =>
            {
                employeeRepository.DeleteLocationsOfEmployee(id);
                employeeRepository.UpdateBusinessAssociate(id, businessAssociateId);
                return employeeRepository.GetEmployee(id);
            });
        }

        public Task<Employee> UpdateLocationsOfEmployee(int id, List<int> locationIds)
        {
            return Task.Run(() =>
            {
                employeeRepository.DeleteLocationsOfEmployee(id);
                employeeRepository.AddLocationsOfEmployee(id, locationIds);
                return employeeRepository.GetEmployee(id);
            });
        }
    }
}
