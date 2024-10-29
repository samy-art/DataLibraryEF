using System.Collections.Generic;
using System.Linq;

namespace DataLibraryEF
{
    public class CDataAccess {
        public List<Employee> GetAllEmployees()
        {
            DacWondersEntities dacWondersEntities = new DacWondersEntities();
            List<Employee> lst = (from emp in dacWondersEntities.Employees select emp).ToList();
            dacWondersEntities.Dispose();
            return lst;
        }

        public void AddEmployee(Employee emp)
        {
            using (DacWondersEntities dacWondersEntities = new DacWondersEntities())
            {
                dacWondersEntities.Employees.Add(emp);
                dacWondersEntities.SaveChanges();
            }
        }

        public void ModifyEmployee(Employee empToBeModified)
        {
            using (DacWondersEntities dacWondersEntities = new DacWondersEntities())
            {
                var empSelected = (from emp in dacWondersEntities.Employees
                                   where emp.Eid == empToBeModified.Eid
                                   select emp).First();
                empSelected.EName = empToBeModified.EName;
                empSelected.Dept = empToBeModified.Dept;
                dacWondersEntities.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (DacWondersEntities dacWondersEntities = new DacWondersEntities())
            {
                var empSelected = (from emp in dacWondersEntities.Employees
                                   where emp.Eid == id
                                   select emp).First();
                dacWondersEntities.Employees.Remove(empSelected);
                dacWondersEntities.SaveChanges();
            }
        }

    }
}
