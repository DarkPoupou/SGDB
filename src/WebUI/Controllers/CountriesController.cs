using CleanArchitecture.Application.Countries.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
public class CountriesController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<CountryDto>> GetCountries()
    {
        return await Mediator.Send(new GetCountriesQuery());
    }
}
