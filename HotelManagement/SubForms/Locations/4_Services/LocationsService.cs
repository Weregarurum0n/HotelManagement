﻿using HotelManagement.Shared.BaseClass;
using HotelManagement.SubForms.Locations._3_Models.Req;
using HotelManagement.SubForms.Locations._3_Models.Res;
using System.Collections.Generic;

namespace HotelManagement.SubForms.Locations._4_Services
{
    public class LocationsService : ILocationsService
    {
        public LocationsService()
        {

        }

        public List<Country> GetCountries()
        {
            return null;
        }
        public Country GetCountry(int countryId)
        {
            return null;
        }
        public ResponseStatus SetCountry(SetCountry req)
        {
            return null;
        }

        public List<State> GetStates(int countryId)
        {
            return null;
        }
        public State GetState(int countryId, int stateId)
        {
            return null;
        }
        public ResponseStatus SetState(SetState req)
        {
            return null;
        }

        public List<City> GetCities(int countryId, int stateId)
        {
            return null;
        }
        public City GetCity(int countryId, int stateId, int cityId)
        {
            return null;
        }
        public ResponseStatus SetCity(SetCity req)
        {
            return null;
        }
    }
}
