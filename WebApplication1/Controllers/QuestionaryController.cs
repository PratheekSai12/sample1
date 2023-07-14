using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [EnableCors("MyCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionaryController : Controller
    {
        private readonly IRepo<int, Questionary> _repo;

        public QuestionaryController(IRepo<int, Questionary> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult<Questionary> Something(Questionary questionary)
        {
            var c = _repo.Add(questionary);
            return Created("", c);
        }
        [Route("GetQuestionaryIdByUserName")]
        [HttpGet]
        public ActionResult<IEnumerable<int>> GetIdByUserName(string username)
        {
            var questions = _repo.GetAll();
            var myId = questions.Where(i => i.UserName == username).ToList();
            var id = myId.FirstOrDefault(e => e.UserName == username);
            if (myId.Count == 0)
                return NotFound("No such person available");
            return Ok(id.Id);
        }

        [HttpGet]
        public ActionResult<ICollection<Questionary>> GET()
        {
            return Ok(_repo.GetAll());
        }

        [HttpPut]
        public ActionResult<Questionary> Update(Questionary questionary)
        {
            var c = _repo.Update(questionary);
            if (c == null)
                return BadRequest("No such Host");
            return Ok(c);
        }

        [HttpDelete]
        public ActionResult<ICollection<Questionary>> Delete(int id)
        {
            var c = _repo.Delete(id);
            if (c == null)
                return BadRequest("No such Host id found");
            return Ok(c);
        }
    }
}
