using HotelManagement.Shared.Models.Objects;
using HotelManagement.SubForms.Constants._3_Models.Req;
using HotelManagement.SubForms.Constants._3_Models.Res;
using System.Collections.Generic;

namespace HotelManagement.SubForms.Constants._4_Services
{
    public class ConstantsService : IConstantsService
    {
        public ConstantsService()
        {

        }

        public List<Constant> GetConstants(GetConstants req)
        {
            return null;
        }

        public Constant GetConstant(int constantId)
        {
            return null;
        }

        public ReturnStatus SetConstant(SetConstant req)
        {
            return null;
        }
    }
}
