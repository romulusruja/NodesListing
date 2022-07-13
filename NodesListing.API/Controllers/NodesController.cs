using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NodesListing.API.Contracts;
using NodesListing.API.Data;
using NodesListing.API.Models.Node;

namespace NodesListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly INodesRepository _nodesRepository;
        private readonly IMapper _mapper;

        public NodesController(IMapper mapper, INodesRepository nodesRepository)
        {
            _nodesRepository = nodesRepository;
            _mapper = mapper;
        }

        // GET: api/Nodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetNodeDto>>> GetNodes()
        {
            var nodes = await _nodesRepository.GetAllAsync();
            
            return Ok(_mapper.Map<List<GetNodeDto>>(nodes));
        }

        // GET: api/Nodes/5
        [HttpGet("{address}")]
        public async Task<ActionResult<GetNodeDetailsDto>> GetNode(string address)
        {
            var node = await _nodesRepository.GetDetailsAsync(address);

            if (node == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GetNodeDetailsDto>(node));
        }

        // PUT: api/Nodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{address}")]
        public async Task<IActionResult> PutNode(string address, UpdateNodeDto updateNodeDto)
        {
            if (address != updateNodeDto.Address)
            {
                return BadRequest();
            }

            var node = await _nodesRepository.GetAsync(address);

            if(node == null)
            {
                return NotFound();
            }

            _mapper.Map(updateNodeDto, node);
            await _nodesRepository.UpdateAsync(node);

            return NoContent();
        }

        // POST: api/Nodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateNodeDto>> PostNode(CreateNodeDto createNodeDto)
        {
            try
            {
                var node = _mapper.Map<Node>(createNodeDto);
                var record = _mapper.Map<CreateNodeDto>(await _nodesRepository.AddAsync(node));

                return CreatedAtAction("GetNode", new { address = record.Address }, record);
            }
            catch (DbUpdateException)
            {
                if (await NodeExists(createNodeDto.Address))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(500);
                }
            }
        }

        // DELETE: api/Nodes/5
        [HttpDelete("{address}")]
        public async Task<IActionResult> DeleteNode(string address)
        {
            var record = await _nodesRepository.GetAsync(address);

            if(record == null)
            {
                return NotFound();
            }

            await _nodesRepository.RemoveAllNodeDetailsAsync(record);

            return NoContent();
        }

        private async Task<bool> NodeExists(string address)
        {
            return await _nodesRepository.Exists(address);
        }
    }
}
