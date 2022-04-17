using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(t => t.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(t => t.WriterSurname).NotEmpty().WithMessage("Yazar soy adını boş geçilemez");
            RuleFor(t => t.WriterAbout).NotEmpty().WithMessage("Yazar soy adını boş geçilemez");
            RuleFor(t => t.WriterTitle).NotEmpty().WithMessage("Unvan boş geçilemez");
            RuleFor(t => t.WriterSurname).MaximumLength(20).WithMessage("En az 2 karakter");
            RuleFor(t => t.WriterSurname).MinimumLength(3).WithMessage("50 den fazla karakter girişi yapılamaz");

            //Odev
            RuleFor(t => t.WriterAbout).Must(t => t != null && t.ToUpper().Contains("A")).WithMessage("Hakkında kısmı en az bir a harfi içermelidir.");
        }
    }
}
