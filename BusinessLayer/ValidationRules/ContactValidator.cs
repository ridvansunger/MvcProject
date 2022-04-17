using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(t => t.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezseniz.");
            RuleFor(t => t.Subject).NotEmpty().WithMessage("Konu adını boş geçemezsiniz");
            RuleFor(t => t.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(t => t.Subject).MinimumLength(3).WithMessage("En az 3 karakter");
            RuleFor(t => t.UserName).MinimumLength(3).WithMessage("En az 3 karakter");
            RuleFor(t => t.Subject).MaximumLength(50).WithMessage("50 den fazla karakter girişi yapılamaz");

        }
    }
}
