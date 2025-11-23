using FluentValidation;

namespace CarDealer.Application.Features.Cars.Commands.CreateCar;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(p => p.Brand).NotEmpty().WithMessage("Marka boş olamaz.");
        RuleFor(p => p.Model).NotEmpty().WithMessage("Model boş olamaz.");
        RuleFor(p => p.Price).GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");
        RuleFor(p => p.Year).GreaterThan(1900).WithMessage("Geçerli bir yıl giriniz.");
    }
}