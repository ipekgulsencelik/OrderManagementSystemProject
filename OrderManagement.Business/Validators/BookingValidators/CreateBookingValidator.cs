using FluentValidation;
using OrderManagement.DTO.DTOs.BookingDTOs;

namespace OrderManagement.Business.Validators.BookingValidators
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingDTO>
    {
        public CreateBookingValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon boş geçilemez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanı boş geçilemez!");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi alanı boş geçilemez!");
            RuleFor(x => x.BookingDate).NotEmpty().WithMessage("Tarih alanı boş geçilemez lütfen tarih seçimi yapınız!");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Lütfen isim alanına en az 5 karekter veri girişi yapınız").MaximumLength(50).WithMessage("Lütfen isim alanına en fazla 50 kareter veri girişi yapınız.");
            RuleFor(x => x.ReservationStatus).MaximumLength(500).WithMessage("Lütfen açıklama alanına en fazla 500 kareter veri girişi yapınız.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz");
        }
    }
}