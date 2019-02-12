using Domain.model;
using FluentValidation;

namespace StudentRecord.Validator
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name cannot be empty");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Second name cannot be empty");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Please specify an email address");
            RuleFor(x => x.Address).NotNull().WithMessage("Please specify an address");
        }
    }
}
