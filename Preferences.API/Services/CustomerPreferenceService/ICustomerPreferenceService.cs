using System.Collections.Generic;
using Preferences.DTO;

namespace Preferences.API.Services
{
    public interface ICustomerPreferenceService
    {
        IEnumerable<CustomerPreferenceDto> Get();

        CustomerPreferenceDto Get(int id);

        IEnumerable<CustomerPreferenceDto> GetAllForCustomer(int customerId);

        void Add(CustomerPreferenceDto peference);

        void Delete(int id);
    }
}