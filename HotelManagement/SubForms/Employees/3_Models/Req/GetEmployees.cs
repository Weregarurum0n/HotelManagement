using System;

namespace HotelManagement.SubForms.Employees._3_Models.Req
{
    public class GetEmployees
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
        public bool IncludeTerminated { get; set; }
        public DateTime TerminatedDateTime { get; set; }
    }
}
