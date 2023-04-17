using Developers2023.Application.Interfaces;
using Developers2023.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Developers2023.Api.Controllers
{
    /// <summary>
    /// Lista us³ug klienta
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Pobranie listy klientów
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            return Ok(_customerService.GetAll());
        }

        /// <summary>
        /// Pobranie danych klienta po identyfikatorze
        /// </summary>
        /// <param name="id">Identyfikator klienta</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        //[DisableRateLimiting]
        public ActionResult<Customer> GetById(int id)
        {
            Customer? customer = _customerService.GetById(id);

            if (customer != null)
                return Ok(customer);

            return NotFound();
        }
        
        /// <summary>
        /// Dodanie danych klienta
        /// </summary>
        /// <param name="customer">Dane klienta</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(Customer customer)
        {
            _customerService.Add(customer);
            return Ok();
        }

        /// <summary>
        /// Aktualizacja danych klienta
        /// </summary>
        /// <param name="customer">Dane klienta</param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Update(Customer customer)
        {
            _customerService.Update(customer);
            return Ok();
        }

        /// <summary>
        /// Usuniêcie klienta po identyfikatorze
        /// </summary>
        /// <param name="id">Identyfikator klienta</param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _customerService.Delete(id);

            return Ok();
        }
    }
}