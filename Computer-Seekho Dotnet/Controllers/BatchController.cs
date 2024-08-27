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
    public class BatchController : ControllerBase
    {
        private readonly IBatchService _batchService;

        public BatchController(IBatchService batchService)
        {
            _batchService = batchService;
        }

        // GET: api/Batches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batch>>> GetBatches()
        {
            var batches = await _batchService.GetAllBatches();
            return Ok(batches);
        }

        // GET: api/Batches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Batch>> GetBatch(int id)
        {
            var batch = await _batchService.GetBatchById(id);

            if (batch == null)
            {
                return NotFound();
            }

            return Ok(batch);
        }

        // PUT: api/Batches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatch(int id, Batch batch)
        {
            if (id != batch.BatchId)
            {
                return BadRequest();
            }

            try
            {
                await _batchService.UpdateBatch(batch);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _batchService.GetBatchById(id) == null)
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

        // POST: api/Batches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Batch>> PostBatch(Batch batch)
        {
            if (batch == null)
            {
                return BadRequest();
            }

            await _batchService.AddBatch(batch);

            return CreatedAtAction(nameof(GetBatch), new { id = batch.BatchId }, batch);
        }

        // DELETE: api/Batches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            await _batchService.DeleteBatch(id);
            return NoContent();
        }
        // GET: api/Batches/getBatchByName/{batchName}
        [HttpGet("getBatchByName/{batchName}")]
        public async Task<ActionResult<IEnumerable<Batch>>> GetBatchByName(string batchName)
        {
            var batches = await _batchService.GetBatchByName(batchName);
            return Ok(batches);
        }
        // GET: api/Batches/getBatchByCourseId/{cid}
        [HttpGet("getBatchByCourseId/{cid}")]
        public async Task<ActionResult<IEnumerable<Batch>>> GetBatchByCourseId(int cid)
        {
            var batches = await _batchService.GetBatchByCourseId(cid);
            return Ok(batches);
        }
    }
}
