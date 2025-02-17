using PayrollDataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.Interface
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();

        IEnumerable<Employee> GetEmployeesByBusinessAssociateId(int id);

        IEnumerable<Employee> GetEmployeesByLocationId(int id);

        Employee GetEmployee(int id);

        Task<Employee> AddEmployee(Employee employee);

        Task<Employee> UpdateEmployee(int id, Employee employee);

        Task<Employee> DeleteEmployee(int id);

        Task UpdateLocationsOfEmployee(int id, List<int> locationIds);
    }
}
