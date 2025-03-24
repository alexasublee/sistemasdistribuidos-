using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PokedexApi.Services;
using PokedexApi.Mappers;
using PokedexApi.Dtos;

namespace PokedexApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")] 
public class HobbiesController: ControllerBase 
{
    private readonly IHobbiesService _hobbiesService;
    public HobbiesController(IHobbiesService hobbiesService)
    {
        _hobbiesService = hobbiesService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HobbyResponse>> GetHobbyByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var hobby = await _hobbiesService.GetHobbyByIdAsync(id, cancellationToken);
        if (hobby is null){
            return NotFound();
        }
        return Ok(hobby.ToDto());

    }

    [HttpGet]
    public async Task<ActionResult<List<HobbyResponse>>> GetHobbyByNameAsync([FromQuery] String? name, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            return BadRequest("Name is required");
        }
    var hobby = await _hobbiesService.GetHobbyByNameAsync(name, cancellationToken);
    if (hobby == null || !hobby.Any()) 
    {
        return Ok(new List<HobbyResponse>());
    }

    return Ok(hobby.Select(p => p.ToDto()).ToList());
}

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteHobbyById(Guid id, CancellationToken cancellationToken){
        var deleted = await _hobbiesService.DeleteHobbyByIdAsync(id, cancellationToken);
        if (deleted){
            return NoContent(); 
        }
        return NotFound(); 
    }


}