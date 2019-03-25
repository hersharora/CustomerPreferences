using AutoMapper;
using Preferences.DTO;
using Preferences.Models;

namespace Preferences.API.Mappings
{
    public class CustomerPreferenceMappingProfile : Profile
    {
        public CustomerPreferenceMappingProfile()
        {
            CreateMap<CustomerPreference, CustomerPreferenceDto>();
            CreateMap<CustomerPreferenceDto, CustomerPreference>();
        }
    }
}