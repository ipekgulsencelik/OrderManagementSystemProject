using FluentValidation;
using OrderManagement.DTO.DTOs.AboutDTOs;

namespace OrderManagement.Business.Validators.AboutValidators
{
    public class CreateAboutValidator : AbstractValidator<CreateAboutDTO>
    {
        public CreateAboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz").MinimumLength(3).WithMessage("En az 3 karakter olmalıdır.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Url boş bırakılamaz");
        }
    }
}