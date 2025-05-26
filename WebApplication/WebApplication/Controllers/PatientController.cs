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
        return Ok(await service.GetPatient(id));
    }
}