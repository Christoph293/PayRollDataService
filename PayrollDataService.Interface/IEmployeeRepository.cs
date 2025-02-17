using PayrollDataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.Interface
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();

        IEnumerable<Employee> GetEmployeesByBusinessAssociateId(int id);

        IEnumerable<Employee> GetEmployeesByLocationId(int id);

        Employee GetEmployee(int id);

        Employee AddEmployee(Employee employee);

        Employee UpdateEmployee(int id, Employee employee);

        Employee DeleteEmployee(int id);

        void DeleteLocationsOfEmployee(int id);

        void AddLocationsOfEmployee(int id, List<int> locationIds);

        void UpdateBusinessAssociate(int id, int businessAssociateId);

        void UpdateBusinessAssociateOfEmployeesWithLocationId(int locationId, int businessAssociateId);
    }
}
