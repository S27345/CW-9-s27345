using Microsoft.AspNetCore.Mvc;
using WebApplication.DTOs;
using WebApplication.Services;

namespace WebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController(IDbService service) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var patients = await service.GetPatient(id);
        if (!patients.Any())
        {
            return NotFound($"Patient not found with id {id}");
        }
        if (id <= 0)
        {
            return BadRequest("Invalid id. Has to be greater than 0");
        }

        return Ok(await service.GetPatient(id));
    }
}