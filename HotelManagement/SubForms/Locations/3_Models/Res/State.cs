using System;

namespace HotelManagement.SubForms.Locations._3_Models.Res
{
    public class State
    {
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        public string Abbrev { get; set; }
        public bool Disabled { get; set; }

        public int CreatedId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
