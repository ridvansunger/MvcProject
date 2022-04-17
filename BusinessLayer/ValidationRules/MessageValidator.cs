using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(t => t.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresini Boş geçemezsiniz");
            RuleFor(t => t.Subject).NotEmpty().WithMessage("Konuyu Boş geçemezsiniz");
            RuleFor(t => t.MessajeContent).NotEmpty().WithMessage("Mesajı Boş Geçemezsiniz");
            RuleFor(t => t.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın.");
            RuleFor(t => t.Subject).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla giriş yapmayın");
        }
    }
}
