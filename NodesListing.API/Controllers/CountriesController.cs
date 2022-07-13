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

namespace NodesListing.API.Controllers;


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

}

