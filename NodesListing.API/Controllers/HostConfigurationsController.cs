using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NodesListing.API.Contracts;
using NodesListing.API.Models.HostConfiguration;

namespace NodesListing.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class HostConfigurationsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IHostConfigurationsRepository _hostConfigurationsRepository;

    public HostConfigurationsController(IMapper mapper, IHostConfigurationsRepository hostConfigurationsRepository)
    {
        _hostConfigurationsRepository = hostConfigurationsRepository;
        _mapper = mapper;
    }

    // GET: api/HostConfigurations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetHostConfigurationDto>>> GetHostConfigurations()
    {
        var records = await _hostConfigurationsRepository.GetAllAsync();

        return _mapper.Map<List<GetHostConfigurationDto>>(records);
    }

    // GET: api/HostConfigurations/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GetHostConfigurationDetailsDto>> GetHostConfiguration(int id)
    {
        var hostConfiguration = await _hostConfigurationsRepository.GetDetailsAsync(id);

        if (hostConfiguration == null)
        {
            return NotFound();
        }

        return _mapper.Map<GetHostConfigurationDetailsDto>(hostConfiguration);
    }

    // PUT: api/HostConfigurations/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHostConfiguration(int id, UpdateHostConfigurationDto updateHostConfigurationDto)
    {
        if (id != updateHostConfigurationDto.Id)
        {
            return BadRequest();
        }

        var hostConfiguration = await _hostConfigurationsRepository.GetAsync(id);

        if(hostConfiguration == null)
        {
            return NotFound();
        }

        _mapper.Map(updateHostConfigurationDto, hostConfiguration);
        await _hostConfigurationsRepository.UpdateAsync(hostConfiguration);

        return NoContent();
    }
}
