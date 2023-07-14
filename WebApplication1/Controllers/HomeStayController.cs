using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [EnableCors("MyCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeStayController : Controller
    {
        private readonly IRepo<int, HomeStay> _repo;

        public HomeStayController(IRepo<int, HomeStay> repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public ActionResult<HomeStay> Something(HomeStay homestay)
        {
            var c = _repo.Add(homestay);
            return Created("", c);
        }
        [Route("GetHomeIdByUserName")]
        [HttpGet]
        public ActionResult<IEnumerable<int>> GetHomeIdByUserName(string username)
        {
            var homestays = _repo.GetAll();
            var myId = homestays.Where(i => i.UserName == username).ToList();
            var id = myId.FirstOrDefault(e => e.UserName == username);
            if (myId.Count == 0)
                return NotFound("No such property available");
            return Ok(id.Id);
        }

        [HttpGet]
        public ActionResult<ICollection<HomeStay>> GET()
        {
            return Ok(_repo.GetAll());
        }

        [HttpPut]
        public ActionResult<HomeStay> Update(HomeStay homestay)
        {
            var c = _repo.Update(homestay);
            if (c == null)
                return BadRequest("No such property");
            return Ok(c);
        }

        [HttpDelete]
        public ActionResult<ICollection<HomeStay>> Delete(int id)
        {
            var c = _repo.Delete(id);
            if (c == null)
                return BadRequest("No such Home id found");
            return Ok(c);
        }
    }
}
