using BETarjeta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BETarjeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly AplicationBDContext _context;
        public TarjetaController(AplicationBDContext context) {
            _context = context;
        }


        // GET: api/<TarjetaController>
        [HttpGet]
        public  async Task<IActionResult> Get()
        {
            try {
                var listsTarjetas = await  _context.TarjetaCredito.ToListAsync();
                return Ok(listsTarjetas);
            }
            catch (Exception error) {
                return BadRequest(error.Message);
            }

            //return new string[] { "value1", "value2" };
        }

        // GET api/<TarjetaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TarjetaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TarjetaCredito tarjeta)
        {
            try {
                _context.Add(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(tarjeta);
            }
            catch (Exception error) {
                return BadRequest(error.Message);
            }
        }

        // PUT api/<TarjetaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                if (id != tarjeta.Id)
                {
                    return NotFound(404);
                }
                else {
                    _context.Update(tarjeta);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "La tarjeta ha sido modificada correctamente"});
                }

            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // DELETE api/<TarjetaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var tarjeta = await _context.TarjetaCredito.FindAsync(id);
                if (tarjeta == null)
                {
                    return NotFound(404);
                }
                else {
                    _context.Remove(tarjeta);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "La tarjeta ha sido eliminada correctamente" });
                }

            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
