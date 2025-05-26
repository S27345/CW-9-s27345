using Microsoft.AspNetCore.Mvc;
using WebApplication.DTOs;
using WebApplication.Services;

namespace WebApplication.Controllers;

[ApiController]
[Route("[controller]/add")]
public class PrescriptionController(IDbService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] PrescriptionCreateDTO prescription)
    {
        try
        {
            await service.CreatePrescription(prescription);
            return Created("CreatePrescription", prescription);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
}