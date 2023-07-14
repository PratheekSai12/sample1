using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using Host = WebApplication1.Models.Host;

namespace WebApplication1.Controllers
{
    [EnableCors("MyCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class HostController : Controller
    {
        private readonly IRepo<int, Host> _repo;

        public HostController(IRepo<int, Host> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult<Host> Something(Host host)
        {
            var c = _repo.Add(host);
            return Created("", c);
        }
        [Route("GetHostIdByUserName")]
        [HttpGet]
        public ActionResult<IEnumerable<int>> GetHostIdByUserName(string username)
        {
            var hosts = _repo.GetAll();
            var myId = hosts.Where(i => i.UserName == username).ToList();
            var id = myId.FirstOrDefault(e => e.UserName == username);
            if (myId.Count == 0)
                return NotFound("No such person available");
            return Ok(id.Id);
        }

        [HttpGet]
        public ActionResult<ICollection<Host>> GET()
        {
            return Ok(_repo.GetAll());
        }

        [HttpPut]
        public ActionResult<Host> Update(Host host)
        {
            var c = _repo.Update(host);
            if (c == null)
                return BadRequest("No such Host");
            return Ok(c);
        }

        [HttpDelete]
        public ActionResult<ICollection<Host>> Delete(int id)
        {
            var c = _repo.Delete(id);
            if (c == null)
                return BadRequest("No such Host id found");
            return Ok(c);
        }
    }
}
