using AutoMapper;
using CarDealer.Application.DTOs.Cars;
using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Domain.Common;
using CarDealer.Domain.Entities;
using MediatR;

namespace CarDealer.Application.Features.Cars.Queries.GetAllCars;

public record GetAllCarsQuery : IRequest<Result<List<CarDto>>>;

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, Result<List<CarDto>>>
{
    private readonly IGenericRepository<Car> _repository;
    private readonly IMapper _mapper;

    public GetAllCarsQueryHandler(IGenericRepository<Car> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<CarDto>>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        var cars = await _repository.GetAllAsync();
        var mapped = _mapper.Map<List<CarDto>>(cars);

        return Result<List<CarDto>>.Success(mapped);
    }
}