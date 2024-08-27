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
    public class PaymentTypesController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypeService;

        public PaymentTypesController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        // GET: api/PaymentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentType>>> GetPaymentTypes()
        {
            try
            {
                var paymentTypes = await _paymentTypeService.GetAllPaymentTypes();
                return Ok(paymentTypes);
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/PaymentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentType>> GetPaymentType(int id)
        {
            try
            {
                var paymentType = await _paymentTypeService.GetPaymentTypeById(id);
                if (paymentType == null)
                {
                    return NotFound();
                }
                return Ok(paymentType);
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/PaymentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentType(int id, PaymentType paymentType)
        {
            if (id != paymentType.PaymentTypeId)
            {
                return BadRequest("PaymentType ID mismatch");
            }

            try
            {
                var existingPaymentType = await _paymentTypeService.GetPaymentTypeById(id);
                if (existingPaymentType == null)
                {
                    return NotFound();
                }

                await _paymentTypeService.UpdatePaymentType(paymentType);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/PaymentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentType>> PostPaymentType(PaymentType paymentType)
        {
            if (paymentType == null)
            {
                return BadRequest("PaymentType data is null");
            }

            try
            {
                await _paymentTypeService.AddPaymentType(paymentType);
                return CreatedAtAction(nameof(GetPaymentType), new { id = paymentType.PaymentTypeId }, paymentType);
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/PaymentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentType(int id)
        {
            try
            {
                var paymentType = await _paymentTypeService.GetPaymentTypeById(id);
                if (paymentType == null)
                {
                    return NotFound();
                }

                await _paymentTypeService.DeletePaymentType(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
