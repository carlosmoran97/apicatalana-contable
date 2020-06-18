using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiCatalanaContables.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace apiCatalanaContables.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly catalanacontablesContext _context;

        public CargosController(catalanacontablesContext context)
        {
            _context = context;
        }


        [HttpGet("apiagregarcargos")]
        public async Task<IActionResult> ApiAgregarCargos()
        {
            var httpClientApi = HttpClientFactory.Create();
            var url = Help.Help.endPointApi() + "Cargos";
            string response = await httpClientApi.GetStringAsync(url);
            List<CargosApi> list = JsonConvert.DeserializeObject<List<CargosApi>>(response);

            foreach (CargosApi p in list)
            {
                var e = CargosExists(p.id);
                if (e == true)
                {
                    var cargo = await _context.Empresas.FindAsync(p.id);
                    _context.Empresas.Remove(cargo);
                    await _context.SaveChangesAsync();
                }
                Cargos emp = new Cargos();
                emp.Id = p.id;
                emp.Cargo = p.nombrecargo;
                emp.DepartamentoId = p.id_Dpto;

                _context.Cargos.Add(emp);
                await _context.SaveChangesAsync();
            }
            return Ok("Cargos agradas correctamente");
        }



        // GET: api/Cargos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargos>>> GetCargos()
        {
            return await _context.Cargos.ToListAsync();
        }

        // GET: api/Cargos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cargos>> GetCargos(int id)
        {
            var cargos = await _context.Cargos.FindAsync(id);

            if (cargos == null)
            {
                return NotFound();
            }

            return cargos;
        }

        // PUT: api/Cargos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargos(int id, Cargos cargos)
        {
            if (id != cargos.Id)
            {
                return BadRequest();
            }

            _context.Entry(cargos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cargos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cargos>> PostCargos(Cargos cargos)
        {
            _context.Cargos.Add(cargos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCargos", new { id = cargos.Id }, cargos);
        }

        // DELETE: api/Cargos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cargos>> DeleteCargos(int id)
        {
            var cargos = await _context.Cargos.FindAsync(id);
            if (cargos == null)
            {
                return NotFound();
            }

            _context.Cargos.Remove(cargos);
            await _context.SaveChangesAsync();

            return cargos;
        }

        private bool CargosExists(int id)
        {
            return _context.Cargos.Any(e => e.Id == id);
        }
    }
}
