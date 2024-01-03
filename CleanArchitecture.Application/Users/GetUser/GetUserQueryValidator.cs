using CleanArchitecture.Application.Authenticate.Login;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.User.Login
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(v => v.userName)
                .NotEmpty().WithMessage("Username is required")
                .MaximumLength(50).WithMessage("Username must not exceed 50 characters.");

            RuleFor(v => v.password)
                .NotEmpty().WithMessage("Password is required")
                .MaximumLength(50).WithMessage("Password must not exceed 50 characters.");
        }
    }
}
