using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NodesListing.API.Data;
using NodesListing.API.Models.Country;

namespace NodesListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly NodeListingDbContext _context;
        private readonly IMapper _mapper;

        public CountriesController(NodeListingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
          if (_context.Countries == null)
          {
              return NotFound();
          }

          var countries = await _context.Countries.ToListAsync();
          var records = _mapper.Map<List<GetCountryDto>>(countries);

            return Ok(records);
        }

        // GET: api/Countries/RO
        [HttpGet("{code}")]
        public async Task<ActionResult<GetCountryDetailsDto>> GetCountry(string code)
        {
          if (_context.Countries == null)
          {
              return NotFound();
          }
            var country = await _context.Countries.Include(q => q.Nodes).FirstOrDefaultAsync(c => c.Code == code);

            if (country == null)
            {
                return NotFound();
            }

            var record = _mapper.Map<GetCountryDetailsDto>(country);

            return Ok(record);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{code}")]
        public async Task<IActionResult> PutCountry(string code, UpdateCountryDto updateCountryDto)
        {
            if (code != updateCountryDto.Code)
            {
                return BadRequest();
            }

            if(_context.Countries == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.FindAsync(code);

            if(country == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCountryDto, country);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(code))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateCountryDto>> PostCountry(CreateCountryDto createCountryDto)
        {
          if (_context.Countries == null)
          {
              return Problem("Entity set 'NodeListingDbContext.Countries'  is null.");
          }

            var record = _mapper.Map<Country>(createCountryDto);
            _context.Countries.Add(record);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CountryExists(record.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCountry", new { code = record.Code }, createCountryDto);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(string id)
        {
            if (_context.Countries == null)
            {
                return NotFound();
            }
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(string id)
        {
            return (_context.Countries?.Any(e => e.Code == id)).GetValueOrDefault();
        }
    }
}
