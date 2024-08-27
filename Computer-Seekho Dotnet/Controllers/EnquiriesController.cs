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
    public class EnquiriesController : ControllerBase
    {
        private readonly IEnquiryService _enquiryService;

        public EnquiriesController(IEnquiryService enquiryService)
        {
            _enquiryService = enquiryService;
        }

        // GET: api/Enquiries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enquiry>>> GetEnquiry()
        {
            var enquiries = await _enquiryService.GetAllEnquiries();
            return Ok(enquiries);
        }

        // GET: api/Enquiries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enquiry>> GetEnquiry(int id)
        {
            var enquiry = await _enquiryService.GetEnquiryById(id);

            if (enquiry == null)
            {
                return NotFound();
            }

            return Ok(enquiry);
        }

        // PUT: api/Enquiries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnquiry(int id, Enquiry enquiry)
        {
            if (id != enquiry.EnquiryId)
            {
                return BadRequest();
            }

            try
            {
                await _enquiryService.UpdateEnquiry(enquiry);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _enquiryService.GetEnquiryById(id) == null)
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

        // POST: api/Enquiries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Enquiry>> PostEnquiry(Enquiry enquiry)
        {
            if (enquiry == null)
            {
                return BadRequest();
            }

            await _enquiryService.AddEnquiry(enquiry);

            return CreatedAtAction(nameof(GetEnquiry), new { id = enquiry.EnquiryId }, enquiry);
        }

        // DELETE: api/Enquiries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnquiry(int id)
        {
            var enquiry = await _enquiryService.GetEnquiryById(id);
            if (enquiry == null)
            {
                return NotFound();
            }

            await _enquiryService.DeleteEnquiry(id);

            return NoContent();
        }
        // PUT: api/updateEnquiryProcessedFlag/5
        [HttpPut("updateEnquiryProcessedFlag/{enquiryId}")]
        public async Task<IActionResult> UpdateEnquiryProcessedFlag([FromRoute] int enquiryId)
        {
            await _enquiryService.UpdateEnquiryProcessedFlag(enquiryId);
            return Ok();
        }

        // GET: api/getEnquiriesByStaffId/5
        [HttpGet("getEnquiriesByStaffId/{staffId}")]
        public async Task<ActionResult<IEnumerable<Enquiry>>> GetEnquiriesByStaffId([FromRoute] int staffId)
        {
            var enquiries = await _enquiryService.GetEnquiriesByStaffId(staffId);
            return Ok(enquiries);
        }

        // GET: api/getByName/{name}
        [HttpGet("getByName/{name}")]
        public async Task<ActionResult<Enquiry>> GetByName([FromRoute] string name)
        {
            var enquiry = await _enquiryService.GetByName(name);
            if (enquiry == null)
            {
                return NotFound();
            }
            return Ok(enquiry);
        }

        // GET: api/getByMobile/{mobile}
        [HttpGet("getByMobile/{mobile}")]
        public async Task<ActionResult<Enquiry>> GetByMobile([FromRoute] string mobile)
        {
            var enquiry = await _enquiryService.GetByMobile(mobile);
            if (enquiry == null)
            {
                return NotFound();
            }
            return Ok(enquiry);
        }
    }
}
