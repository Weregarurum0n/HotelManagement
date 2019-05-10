using HotelManagement.Shared.Models.Objects;
using HotelManagement.SubForms.Rooms._3_Models.Req;
using HotelManagement.SubForms.Rooms._3_Models.Res;
using System.Collections.Generic;

namespace HotelManagement.SubForms.Rooms._4_Services
{
    public interface IRoomsService
    {
        List<Room> GetRooms(GetRooms req);
        Room GetRoom(int roomId);
        ReturnStatus SetRoom(SetRoom req);
    }
}
