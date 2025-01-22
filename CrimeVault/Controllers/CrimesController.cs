using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrimeVault.WebAPI.Controllers;

[Route("[controller]")]

public class CrimesController(ISender sender, IMapper mapper) : ApiController(sender, mapper)
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(new List<string> { "This is a test", "yes iam not gonna lie" });
    }
}

