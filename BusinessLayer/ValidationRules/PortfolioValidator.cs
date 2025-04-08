using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator:AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Proje adı boş geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel alanı boş geçilemez");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("PGörsel 2 alanı boş geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat adı boş geçilemez");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Değer adı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje adı en az 5 karakterli olmak zorundadır");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Proje adı en fazla 100 karakterli olmak zorundadır");
        }
    }
}
