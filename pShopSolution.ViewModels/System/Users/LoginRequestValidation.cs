using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.ViewModels.System.Users
{
    //Sử dụng Fluent Validation
    public class LoginRequestValidation: AbstractValidator<LoginRequest>
    {
        public LoginRequestValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");

            RuleFor(x => x.PassWord).NotEmpty().WithMessage("Password is required");
        }
    }
}
