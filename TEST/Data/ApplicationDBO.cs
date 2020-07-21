using FluentValidation;
using ICWebApp.Data.Interfaces;
using System.Collections.Generic;

namespace ICWebApp.Data.DBO.Applications
{
    public class ApplicationDBO : INameable, IInsertable, IIdentifiable, IDescriptionable
    {
        public string Id
        {
            get => _Id;
            set => _Id = value.ToUpper().Trim();
        }
        public string Name
        {
            get => _Name;
            set => _Name = value.Trim();
        }
        public string Description
        {
            get => _desc ?? Id;
            set => _desc = value;
        }
        public bool IsNew { get; set; } = false;
        public virtual List<ApplicationVersionDBO> Versions { get; set; }

        private string _Id;
        private string _Name;
        private string? _desc;
    }

    public class ApplicationDBOValidator : AbstractValidator<ApplicationDBO>
    {
        public ApplicationDBOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id aplikacji jest wymagane")
                .MaximumLength(10)
                .WithMessage("Id może mieć maksymalnie 10 znaków");

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage("Nazwa aplikacji jest wymagana")
               .MaximumLength(200)
               .WithMessage("Nazwa aplikacji może mieć maksymalnie 200 znaków");
        }
    }
}
