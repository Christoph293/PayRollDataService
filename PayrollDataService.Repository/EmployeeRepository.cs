using PayrollDataService.Interface;
using PayrollDataService.Model;
using System.Collections.Generic;

namespace PayrollDataService.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            //select * from Employee where ID = id;

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

        public void UpdateBusinessAssociate(int id, int businessAssociateId)
        {
            //Update Employee Set BusinessAssociateId = businessAssociateId where ID = id;

            throw new NotImplementedException();
        }

        public Employee UpdateEmployee(int id, Employee employee)
        {
            throw new NotImplementedException();
        }

        public void AddLocationsOfEmployee(int id, List<int> locationIds)
        {
            //INSERT INTO EmployeeLocationMap
            //(EmployeeId, LocationId)
            //VALUES
            //(id, locationIds[0]), 
            //(id, locationIds[1]) 
            //...

            throw new NotImplementedException();
        }

        public void DeleteLocationsOfEmployee(int id)
        {
            //Delete from EmployeeLocationMap Where EmployeeId = id

            throw new NotImplementedException();
        }

        public void UpdateBusinessAssociateOfEmployeesWithLocationId(int locationId, int businessAssociateId)
        {
            //Update Employee Set BusinessAssociateId = businessAssociateid where Id in (Select EmployeeId from EmployeeLocationMap where LocationID = locationId)
            throw new NotImplementedException();
        }
    }
}
