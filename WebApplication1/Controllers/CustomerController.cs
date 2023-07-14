using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [EnableCors("MyCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepo<int, Customer> _repo;

        public CustomerController(IRepo<int, Customer> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult<Customer> Something(Customer customer)
        {
            var c = _repo.Add(customer);
            return Created("", c);
        }
        [Route("GetCustomerIdByUserName")]
        [HttpGet]
        public ActionResult<IEnumerable<int>> GetCustomerIdByUserName(string username)
        {
            var customers = _repo.GetAll();
            var myId = customers.Where(i => i.UserName == username).ToList();
            var id = myId.FirstOrDefault(e => e.UserName == username);
            if (myId.Count == 0)
                return NotFound("No claims available");
            return Ok(id.Id);
        }

        [HttpGet]
        public ActionResult<ICollection<Customer>> GET()
        {
            return Ok(_repo.GetAll());
        }

        [HttpPut]
        public ActionResult<Customer> Update(Customer customer)
        {
            var c = _repo.Update(customer);
            if (c == null)
                return BadRequest("No such customer");
            return Ok(c);
        }

        [HttpDelete]
        public ActionResult<ICollection<Customer>> Delete(int id)
        {
            var c = _repo.Delete(id);
            if (c == null)
                return BadRequest("No such customer id found");
            return Ok(c);
        }
    }
}
