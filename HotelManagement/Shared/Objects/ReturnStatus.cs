namespace HotelManagement.Shared.Models.Objects
{
    public class ReturnStatus
    {
        public int ReturnId { get; set; }
        public string ReturnMessage { get; set; }

        public ReturnStatus() { }
        public ReturnStatus(int returnId, string returnMessage)
        { ReturnId = returnId; ReturnMessage = returnMessage; }
    }
}
