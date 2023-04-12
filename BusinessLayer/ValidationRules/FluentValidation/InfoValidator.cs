using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class InfoValidator : AbstractValidator<Info>
    {
        public InfoValidator()
        {
            RuleFor(x => x.InfoName).NotEmpty().WithMessage("Bilgi İsmini Lütfen Giriniz...!");
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.InfoSkill).NotEmpty();
            RuleFor(x => x.InfoSkill).InclusiveBetween(1, 100).WithMessage("1-100 arasında yetenek puanı giriniz...!");
            RuleFor(x => x.InfoName).MaximumLength(100).WithMessage("Info Name 100 Karakteri Geçmemelidir...!");
        }
    }
}
