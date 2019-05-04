using System;

namespace HotelManagement.SubForms.Employees._3_Models.Res
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public bool Locked { get; set; }
        public DateTime LockedDateTime { get; set; }
        public bool RequiresReset { get; set; }
        public int EmployeeTypeId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime LastLoginDateTime { get; set; }
        public bool Terminated { get; set; }
        public DateTime TerminatedDateTime { get; set; }

        public int CreatedId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
