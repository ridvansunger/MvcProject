using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    using EntityLayer.Concrete;
    using FluentValidation;

    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(t => t.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz");
            RuleFor(t => t.CategoryDescription).NotEmpty().WithMessage("Açıklama boş geçilemez");
            RuleFor(t => t.CategoryName).MaximumLength(20).WithMessage("En az 3 karakter");
            RuleFor(t => t.CategoryName).MinimumLength(3).WithMessage("20 den fazla karakter girişi yapılamaz");
        }
    }
}
