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
    public class AreasController : ControllerBase
    {
        private readonly catalanacontablesContext _context;

        public AreasController(catalanacontablesContext context)
        {
            _context = context;
        }


        [HttpGet("apiagregarareas")]
        public async Task<IActionResult> ApiAgregarAreas()
        {
            var httpClientApi = HttpClientFactory.Create();
            var url = Help.Help.endPointApi() + "Areas";
            string response = await httpClientApi.GetStringAsync(url);
            List<AreasApi> list = JsonConvert.DeserializeObject<List<AreasApi>>(response);

            foreach (AreasApi p in list)
            {
                var e = AreasExists(p.id);
                if (e == true)
                {
                    var area = await _context.Empresas.FindAsync(p.id);
                    _context.Empresas.Remove(area);
                    await _context.SaveChangesAsync();
                }
                Areas emp = new Areas();
                emp.Id = p.id;
                emp.Area = p.nombreArea;
                emp.EmpresaId = p.id_empresa;

                _context.Areas.Add(emp);
                await _context.SaveChangesAsync();
            }
            return Ok("Areas agradas correctamente");
        }



        // GET: api/Areas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Areas>>> GetAreas()
        {
            return await _context.Areas.ToListAsync();
        }

        // GET: api/Areas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Areas>> GetAreas(int id)
        {
            var areas = await _context.Areas.FindAsync(id);

            if (areas == null)
            {
                return NotFound();
            }

            return areas;
        }

        // PUT: api/Areas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAreas(int id, Areas areas)
        {
            if (id != areas.Id)
            {
                return BadRequest();
            }

            _context.Entry(areas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreasExists(id))
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

        // POST: api/Areas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Areas>> PostAreas(Areas areas)
        {
            _context.Areas.Add(areas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAreas", new { id = areas.Id }, areas);
        }

        // DELETE: api/Areas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Areas>> DeleteAreas(int id)
        {
            var areas = await _context.Areas.FindAsync(id);
            if (areas == null)
            {
                return NotFound();
            }

            _context.Areas.Remove(areas);
            await _context.SaveChangesAsync();

            return areas;
        }

        private bool AreasExists(int id)
        {
            return _context.Areas.Any(e => e.Id == id);
        }
    }
}
