using Microsoft.AspNetCore.Mvc;
using Models.Service;
using Models.Model;
using Models.Infrastructure;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerInfoController : ControllerBase
    {
        private ICustomerRepo _customerRepo;

        public CustomerInfoController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAll()
        {

            return await _customerRepo.GetAllAsync();
        }

        [HttpGet]
        [Route("getallcountries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetAllCountries()
        {

            return await _customerRepo.GetAllCountriesAsync();
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<Customer?>> GetById(int id)
        {
            return await _customerRepo.GetByIdAsync(id);
        }

        [HttpPut]
        [Route("put")]
        public async Task<IActionResult> Update([FromBody] Customer customer)
        {
            _customerRepo.Update(customer);
            await _customerRepo.SaveAsync();

            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Customer customer)
        {
            _customerRepo.Insert(customer);
            await _customerRepo.SaveAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _customerRepo.Delete(id);
            await _customerRepo.SaveAsync();

            return Ok();
        }
    }
}
