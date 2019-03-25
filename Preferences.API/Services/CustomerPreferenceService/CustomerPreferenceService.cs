using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Preferences.Data.Pattern;
using Preferences.Data.Repository;
using Preferences.DTO;
using Preferences.Models;

namespace Preferences.API.Services
{
    public class CustomerPreferenceService : BaseAPIRepositoryService, ICustomerPreferenceService
    {
        private IPreferenceRepository PreferenceRepository;

        public CustomerPreferenceService(IPreferenceRepository preferenceRepository, IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            PreferenceRepository = preferenceRepository;
        }

        public IEnumerable<CustomerPreferenceDto> Get()
        {
            var preferences = PreferenceRepository.GetAll();
            return Mapper.Map<IEnumerable<CustomerPreference>, IEnumerable<CustomerPreferenceDto>>(preferences.AsEnumerable());
        }

        public CustomerPreferenceDto Get(int id)
        {
            var preference = PreferenceRepository.GetSingle(id);
            return Mapper.Map<CustomerPreference, CustomerPreferenceDto>(preference);
        }

        public IEnumerable<CustomerPreferenceDto> GetAllForCustomer(int customerId)
        {
            var preferences = PreferenceRepository.FindBy(cp => cp.CustomerId == customerId);
            return Mapper.Map<IEnumerable<CustomerPreference>, IEnumerable<CustomerPreferenceDto>>(preferences.AsEnumerable());
        }

        public void Add(CustomerPreferenceDto preference)
        {
            PreferenceRepository.Add(Mapper.Map<CustomerPreferenceDto, CustomerPreference>(preference));
            UnitOfWork.Commit();
        }

        public void Delete(int id)
        {
            PreferenceRepository.DeleteWhere(cp => cp.Id == id);
            UnitOfWork.Commit();
        }

    }
}