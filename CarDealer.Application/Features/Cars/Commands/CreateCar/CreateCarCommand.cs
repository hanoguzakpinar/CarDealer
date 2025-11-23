using AutoMapper;
using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Application.Interfaces.UnitOfWorks;
using CarDealer.Domain.Common;
using CarDealer.Domain.Entities;
using MediatR;

namespace CarDealer.Application.Features.Cars.Commands.CreateCar;

public record CreateCarCommand(string Brand, string Model, int Year, decimal Price, string Color) : IRequest<Result<Guid>>;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Result<Guid>>
{
    private readonly IGenericRepository<Car> _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uOw;

    public CreateCarCommandHandler(IGenericRepository<Car> repository, IMapper mapper, IUnitOfWork uOw)
    {
        _repository = repository;
        _mapper = mapper;
        _uOw = uOw;
    }

    public async Task<Result<Guid>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car = _mapper.Map<Car>(request);

        await _repository.AddAsync(car);
        await _uOw.SaveChangesAsync();

        return Result<Guid>.Success(car.Id, "Araç başarıyla kayıt edildi.");
    }
}