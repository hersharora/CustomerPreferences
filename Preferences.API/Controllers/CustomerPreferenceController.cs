using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Preferences.API.Services;
using Preferences.DTO;

namespace Preferences.API.Controllers
{
    [RoutePrefix("api/customerpreference")]
    public class CustomerPreferenceController : ApiController
    {
        private readonly ICustomerPreferenceService CustomerPreferenceService;

        public CustomerPreferenceController(ICustomerPreferenceService customerPreferenceService)
        {
            CustomerPreferenceService = customerPreferenceService;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<CustomerPreferenceDto>))]
        public IHttpActionResult Get()
        {
            var preferences = CustomerPreferenceService.Get();
            if (!preferences.Any())
            {
                return NotFound();
            }

            return Ok(preferences);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(CustomerPreferenceDto))]
        public IHttpActionResult Get(int id)
        {
            var preference = CustomerPreferenceService.Get(id);
            if (preference == null)
            {
                return NotFound();
            }

            return Ok(preference);
        }

        [HttpGet]
        [Route("customer/{customerId:int}")]
        [ResponseType(typeof(IEnumerable<CustomerPreferenceDto>))]
        public IHttpActionResult GetAllForCustomer(int customerId)
        {
            var preferences = CustomerPreferenceService.GetAllForCustomer(customerId);
            if (!preferences.Any())
            {
                return NotFound();
            }

            return Ok(preferences);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(CustomerPreferenceDto preference)
        {
            CustomerPreferenceService.Add(preference);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var preference = CustomerPreferenceService.Get(id);
            if (preference == null)
            {
                return NotFound();
            }

            CustomerPreferenceService.Delete(id);

            return Ok();
        }

    }
}
