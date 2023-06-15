using AplicativoAPI.Entities;
using AplicativoAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplicativoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PupilController : ControllerBase
    {
        private readonly TutoringDbContext _context;

        public PupilController(TutoringDbContext context)
        {
            _context = context;
        }

        //api/pupil GET
        [HttpGet]
        public IActionResult GetAll() 
        {
            var pupils = _context.Tutoring.Where(d => !d.isDeleted).ToList();

            return Ok(pupils);
        }

        //api/pupil/3fa85f64-5717-4562-b3fc-2c963f66afa6 GET
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var pupils = _context.Tutoring.SingleOrDefault(d => d.Id == id);

            if (pupils == null)
            {
                return NotFound();
            }

            return Ok(pupils);
        }

        // api/pupil/3fa85f64-5717-4562-b3fc-2c963f66afa6 Post
        [HttpPost]
        public IActionResult Post(Pupil pupils)
        {
            _context.Tutoring.Add(pupils);

            return CreatedAtAction(nameof(GetById), new { id = pupils.Id }, pupils);
        }

        // api/pupil/3fa85f64-5717-4562-b3fc-2c963f66afa6 PUT
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Pupil input)
        {
            var pupils = _context.Tutoring.SingleOrDefault(d => d.Id == id);

            if (pupils == null)
            {
                return NotFound();
            }

            pupils.Update(input.Name, input.Description ,input.CreatedDate, input.UpdatedDate);

            return NoContent();
           
        }

        // api/pupil/3fa85f64-5717-4562-b3fc-2c963f66afa6 Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var pupils = _context.Tutoring.SingleOrDefault(d => d.Id == id);

            if(pupils == null)
                return NotFound();

            pupils.Delete();

            return NoContent();
        }


        [HttpPost("{id}/masterminds")]
        public IActionResult PostSpeaker(Guid id, Mastermind mastermind)
        {
            var master = _context.Tutoring.SingleOrDefault(d => d.Id == id);

            if (master == null)
                    return NotFound();

            master.Masterminds.Add(mastermind);

            return NoContent();
        }
    }
}
