using HotelManagement.Shared.BaseClass;
using HotelManagement.SubForms.Employees._3_Models.Req;
using HotelManagement.SubForms.Employees._3_Models.Res;
using System.Collections.Generic;

namespace HotelManagement.SubForms.Employees._4_Services
{
    public interface IEmployeesService
    {
        List<Employee> GetEmployees(GetEmployees req);
        Employee GetEmployee(int employeeId);
        ResponseStatus SetEmployee(SetEmployee req);
    }
}
