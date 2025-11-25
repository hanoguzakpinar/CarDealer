using CarDealer.Application.Features.Cars.Commands.CreateCar;
using CarDealer.Application.Features.Cars.Queries.GetAllCars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCarCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess) return Ok(result);
        return BadRequest(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCarsQuery());
        if (result.IsSuccess) return Ok(result);
        return BadRequest(result);
    }
}