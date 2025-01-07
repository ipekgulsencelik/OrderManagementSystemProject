using FluentValidation;
using OrderManagement.DTO.DTOs.AboutDTOs;

namespace OrderManagement.Business.Validators.AboutValidators
{
    public class UpdateAboutValidator : AbstractValidator<UpdateAboutDTO>
    {
        public UpdateAboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Url boş bırakılamaz");
        }
    }
}