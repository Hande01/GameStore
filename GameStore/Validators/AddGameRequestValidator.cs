﻿using FluentValidation;
using GameStore.Models.Requests;

namespace GameStore.Validators
{
    public class AddGameRequestValidator : AbstractValidator<AddGameRequest>
    {
        public AddGameRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .MinimumLength(2);

            RuleFor(x => x.Year)
                .GreaterThan(1900).WithMessage("Year must be greater than 1900 lshfkjsd")
                .LessThan(2100);
        }
    }
}
