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
    public class EmpresasController : ControllerBase
    {
        private readonly catalanacontablesContext _context;

        public EmpresasController(catalanacontablesContext context)
        {
            _context = context;
        }

        [HttpGet("apiagregarempresas")]
        public async Task<IActionResult> ApiAgregarEmpresas()
        {
            var httpClientApi = HttpClientFactory.Create();
            var url = Help.Help.endPointApi() + "Empresas";
            string response = await httpClientApi.GetStringAsync(url);
            List<EmpresasApi> list = JsonConvert.DeserializeObject<List<EmpresasApi>>(response);

            foreach(EmpresasApi p in list)
            {
                var e = EmpresasExists(p.id);
                if (e == true)
                {
                    var empresas = await _context.Empresas.FindAsync(p.id);
                    _context.Empresas.Remove(empresas);
                    await _context.SaveChangesAsync();
                }
                Empresas emp = new Empresas();
                emp.Id = p.id;
                emp.Empresa = p.nombreEmpresa;
                emp.Abreviatura = p.abreviatura;
 
                _context.Empresas.Add(emp);
                await _context.SaveChangesAsync();
            }
            return Ok("Empresas agradas correctamente");
        }

        // GET: api/Empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresas>>> GetEmpresas()
        {
            return await _context.Empresas.ToListAsync();
        }

        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresas>> GetEmpresas(int id)
        {
            var empresas = await _context.Empresas.FindAsync(id);

            if (empresas == null)
            {
                return NotFound();
            }

            return empresas;
        }

        // PUT: api/Empresas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresas(int id, Empresas empresas)
        {
            if (id != empresas.Id)
            {
                return BadRequest();
            }

            _context.Entry(empresas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresasExists(id))
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

        // POST: api/Empresas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Empresas>> PostEmpresas(Empresas empresas)
        {
            _context.Empresas.Add(empresas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresas", new { id = empresas.Id }, empresas);
        }

        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empresas>> DeleteEmpresas(int id)
        {
            var empresas = await _context.Empresas.FindAsync(id);
            if (empresas == null)
            {
                return NotFound();
            }

            _context.Empresas.Remove(empresas);
            await _context.SaveChangesAsync();

            return empresas;
        }

        private bool EmpresasExists(int id)
        {
            return _context.Empresas.Any(e => e.Id == id);
        }
    }
}
