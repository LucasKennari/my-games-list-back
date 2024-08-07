﻿using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace my_games_list_back.Features.Users
{
    public class UserValidator : AbstractValidator<UserEntity>
    {
        public UserValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .Must(id => id != Guid.Empty);

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.Nickname)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255);
                //.Unique();

            RuleFor(x => x.Birthday)
                .NotEmpty()
                .LessThan(DateTime.Now)
                .Must(BeaValidDate);

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255)
                .EmailAddress();


            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(8).WithMessage("Password musc be at least 8 characters long")
                .MaximumLength(255)
                .Matches("[A-Z]").WithMessage("Password must contain at least one upper case letter")
                .Matches("[a-z]").WithMessage("Password must contain at least one lower case letter")
                .Matches("[0-9]").WithMessage("Password must contain at least one number")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character");

            RuleFor(x => x.CreatedAt)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);
        }

        private bool BeaValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

    }
}
