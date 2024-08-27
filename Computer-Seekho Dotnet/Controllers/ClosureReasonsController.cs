using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComputerSeekho.Models;
using ComputerSeekho.Repository;
using ComputerSeekho.Service;

namespace ComputerSeekho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClosureReasonsController : ControllerBase
    {
        private readonly IClosureReasonService _closureReasonService;

        public ClosureReasonsController(IClosureReasonService closureReasonService)
        {
            _closureReasonService = closureReasonService;
        }

        // GET: api/ClosureReasons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClosureReason>>> GetClosureReasons()
        {
            var closureReasons = await _closureReasonService.GetAllClosureReasons();
            return Ok(closureReasons);
        }

        // GET: api/ClosureReasons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClosureReason>> GetClosureReason(int id)
        {
            var closureReason = await _closureReasonService.GetClosureReasonById(id);

            if (closureReason == null)
            {
                return NotFound();
            }

            return Ok(closureReason);
        }

        // PUT: api/ClosureReasons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClosureReason(int id, ClosureReason closureReason)
        {
            if (id != closureReason.ClosureReasonId)
            {
                return BadRequest();
            }

            try
            {
                await _closureReasonService.UpdateClosureReason(closureReason);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _closureReasonService.GetClosureReasonById(id) == null)
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

        // POST: api/ClosureReasons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClosureReason>> PostClosureReason(ClosureReason closureReason)
        {
            if (closureReason == null)
            {
                return BadRequest();
            }

            await _closureReasonService.AddClosureReason(closureReason);

            return CreatedAtAction(nameof(GetClosureReason), new { id = closureReason.ClosureReasonId }, closureReason);
        }

        // DELETE: api/ClosureReasons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClosureReason(int id)
        {
            await _closureReasonService.DeleteClosureReason(id);
            return NoContent();
        }
    }
}
