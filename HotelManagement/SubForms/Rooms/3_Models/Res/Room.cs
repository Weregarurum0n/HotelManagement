using System;

namespace HotelManagement.SubForms.Rooms._3_Models.Res
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomNo { get; set; }
        public int RoomTypeId { get; set; }
        public decimal RoomRate { get; set; }
        public int RoomStatusId { get; set; }
        public int MaxCapacity { get; set; }
        public bool Disabled { get; set; }

        public int CreatedId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
