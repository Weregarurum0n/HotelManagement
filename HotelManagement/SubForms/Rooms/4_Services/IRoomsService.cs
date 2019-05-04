using HotelManagement.Shared.BaseClass;
using HotelManagement.SubForms.Rooms._3_Models.Req;
using HotelManagement.SubForms.Rooms._3_Models.Res;
using System.Collections.Generic;

namespace HotelManagement.SubForms.Rooms._4_Services
{
    public interface IRoomsService
    {
        List<Room> GetRooms(GetRooms req);
        Room GetRoom(int roomId);
        ResponseStatus SetRoom(SetRoom req);
    }
}
