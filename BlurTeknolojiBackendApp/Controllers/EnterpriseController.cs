using BlurTeknolojiBackendApp.Data;
using BlurTeknolojiBackendApp.DTO;
using BlurTeknolojiBackendApp.Models;
using BlurTeknolojiBackendApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlurTeknolojiBackendApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EnterpriseController : ControllerBase
    {
        private readonly IEnterpriseService _enterpriseService;

        public EnterpriseController(IEnterpriseService enterpriseService)
        {
            _enterpriseService = enterpriseService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnterpriseDto>>> GetAll()
        {
            try
            {
                var enterprises = await _enterpriseService.GetAllAsync();
                return Ok(enterprises);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EnterpriseDto>> GetById(Guid id)
        {
            try
            {
                var enterprise = await _enterpriseService.GetByIdAsync(id);
                if (enterprise == null)
                {
                    return NotFound();
                }
                return Ok(enterprise);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEnterpriseDto createEnterpriseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _enterpriseService.CreateAsync(createEnterpriseDto);
            // oluşturulan kaydı döndür
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEnterpriseDto updateEnterpriseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _enterpriseService.UpdateAsync(updateEnterpriseDto);
            if (updated == null)
            {
                return NotFound();
            }
            return Ok(updated);

        }
       [HttpDelete("{id:guid}")]

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleted = await _enterpriseService.DeleteAsync(id);
                if (!deleted)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}