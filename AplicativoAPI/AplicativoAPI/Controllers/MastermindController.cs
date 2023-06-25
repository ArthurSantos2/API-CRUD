using AplicativoAPI.Entities;
using AplicativoAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AplicativoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastermindController : ControllerBase
    {
        private readonly ITutoringService<Mastermind> _service;
        public MastermindController(ITutoringService<Mastermind> service)
        {
            _service = service;
        }

        // GET: api/<MastermindController>
        [HttpGet]
        public IEnumerable<Mastermind> GetAll()
        {
            return _service.GetAll();
        }

        // GET api/<MastermindController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var master = _service.GetById(id);

            if (master == null)
                return NotFound();

            return Ok(master);
        }

        // POST api/<MastermindController>
        [HttpPost]
        public IActionResult Post(Mastermind mastermind)
        {
            _service.Insert(mastermind);

            return CreatedAtAction(nameof(GetById), new {id = mastermind.Id }, mastermind);
        }

        // PUT api/<MastermindController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Mastermind mastermind)
        {
            var master = _service.GetById(id);

            if (master == null)
                return NotFound();

            _service.Update(id, master);
            return Ok(mastermind);
        }

        // DELETE api/<MastermindController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var mastermind = _service.GetById(id);

            if (mastermind == null)
                return NotFound();

            _service.Delete(id, mastermind);

            return Ok("foi deletado o usuário de id:" + id);
        }
    }
}
