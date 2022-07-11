using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NodesListing.API.Contracts;
using NodesListing.API.Data;
using NodesListing.API.Models.Country;

namespace NodesListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesController(IMapper mapper, ICountriesRepository countriesRepository)
        {
            _mapper = mapper;
            _countriesRepository = countriesRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var countries = await _countriesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryDto>>(countries);

            return Ok(records);
        }

        // GET: api/Countries/RO
        [HttpGet("{code}")]
        public async Task<ActionResult<GetCountryDetailsDto>> GetCountry(string code)
        {
            var country = await _countriesRepository.GetDetails(code);
          
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

            var country = await _countriesRepository.GetAsync(code);

            if(country == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCountryDto, country);

            try
            {
                await _countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await CountryExists(code))
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
            var record = _mapper.Map<Country>(createCountryDto);
            var addedCountry = await _countriesRepository.AddAsync(record);

            if(addedCountry == null)
            {
                if(await CountryExists(createCountryDto.Code))
                {
                    return Conflict();
                } else
                {
                    return StatusCode(500);
                }

            }

            return CreatedAtAction("GetCountry", new { code = record.Code }, createCountryDto);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(string id)
        {
            var country = await _countriesRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            await _countriesRepository.DeleteAsync(country);

            return NoContent();
        }

        private async Task<bool> CountryExists(string id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
