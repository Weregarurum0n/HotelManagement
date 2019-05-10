using HotelManagement.Shared.Models.Objects;
using HotelManagement.SubForms.Locations._3_Models.Req;
using HotelManagement.SubForms.Locations._3_Models.Res;
using System.Collections.Generic;

namespace HotelManagement.SubForms.Locations._4_Services
{
    public interface ILocationsService
    {
        List<Country> GetCountries();
        Country GetCountry(int countryId);
        ReturnStatus SetCountry(SetCountry req);

        List<State> GetStates(int countryId);
        State GetState(int countryId, int stateId);
        ReturnStatus SetState(SetState req);

        List<City> GetCities(int countryId, int stateId);
        City GetCity(int countryId, int stateId, int cityId);
        ReturnStatus SetCity(SetCity req);
    }
}
