using AplicativoAPI.Entities;
using AplicativoAPI.Persistence;
using AplicativoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplicativoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PupilController : ControllerBase
    {
        private readonly ITutoringService<Pupil> _servicePupil;

        public PupilController(ITutoringService<Pupil> servicePupil)
        {
            _servicePupil = servicePupil;
        }

        //api/pupil GET
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_servicePupil.GetAll());
        }

        //api/pupil/3fa85f64-5717-4562-b3fc-2c963f66afa6 GET
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var pupilo = _servicePupil.GetById(id);

            //para trazer junto preciso de um service e repository próprio, assim passo como parâmetro incluindo

            if (pupilo == null)
            {
                return NotFound();
            }

            return Ok(pupilo);
        }

        // api/pupil/3fa85f64-5717-4562-b3fc-2c963f66afa6 Post
        [HttpPost]
        public IActionResult Post(Pupil pupils)
        {
            _servicePupil.Insert(pupils);

            return CreatedAtAction(nameof(GetById), new { id = pupils.Id }, pupils);
        }

        // api/pupil/3fa85f64-5717-4562-b3fc-2c963f66afa6 PUT
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Pupil input)
        {
            //para resolver aqui devo colocar um servico especifico e não generico enquanto não sei 
            //com plena certeza fazer

            var pupil = _servicePupil.GetById(id);

            if (pupil == null)
                return NotFound();
            

            _servicePupil.Update(id, input);
            return Ok(input);
           
        }

        // api/pupil/3fa85f64-5717-4562-b3fc-2c963f66afa6 Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var pupil = _servicePupil.GetById(id);

            if(pupil == null)
                return NotFound();

            _servicePupil.Delete(id, pupil);

            return Ok("O aluno com o " + id + "foi removido.");
        }

        //fazer a controller do mastermind

        //[HttpPost("{id}/masterminds")]
        //public IActionResult PostSpeaker(Guid id, Mastermind mastermind)
        //{
        //    mastermind.Id = id;
        //    var master = _context.Tutoring.Any(d => d.Id == id);

        //    if (!master)
        //            return NotFound();

        //    _context.Masterminds.Add(mastermind);
        //    _context.SaveChanges();

        //    return NoContent();
        //}
    }
}
