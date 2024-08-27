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
    public class StaffsController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffsController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        // GET: api/Staffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        {
            try
            {
                var staffList = await _staffService.GetAllStaff();
                return Ok(staffList);
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            try
            {
                var staff = await _staffService.GetStaffById(id);
                if (staff == null)
                {
                    return NotFound();
                }
                return Ok(staff);
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Staffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {
            if (id != staff.StaffId)
            {
                return BadRequest();
            }

            try
            {
                var existingStaff = await _staffService.GetStaffById(id);
                if (existingStaff == null)
                {
                    return NotFound();
                }

                await _staffService.UpdateStaff(staff);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Staffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            if (staff == null)
            {
                return BadRequest("Staff data is null");
            }

            try
            {
                await _staffService.AddStaff(staff);
                return CreatedAtAction(nameof(GetStaff), new { id = staff.StaffId }, staff);
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            try
            {
                var staff = await _staffService.GetStaffById(id);
                if (staff == null)
                {
                    return NotFound();
                }

                await _staffService.DeleteStaff(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpGet("stafflog")]
        public async Task<ActionResult<Staff>> GetStaffByUsername([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                var staff = await _staffService.GetStaffByUsername(username);
                if (staff == null || staff.StaffPassword != password)
                {
                    return NotFound();
                }
                return Ok(staff);
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



    }

}