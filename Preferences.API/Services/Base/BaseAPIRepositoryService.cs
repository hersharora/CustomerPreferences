using Preferences.Data.Pattern;

namespace Preferences.API.Services
{
    public class BaseAPIRepositoryService
    {

        protected readonly IUnitOfWork UnitOfWork;
        public BaseAPIRepositoryService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}