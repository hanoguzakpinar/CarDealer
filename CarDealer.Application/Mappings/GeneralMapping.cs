using AutoMapper;
using CarDealer.Application.Features.Cars.Commands.CreateCar;
using CarDealer.Domain.Entities;

namespace CarDealer.Application.Mappings;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Car, CreateCarCommand>().ReverseMap();
    }
}