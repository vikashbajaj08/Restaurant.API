using FluentValidation;
using Restaurants.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.CQRS.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidator()
        {
            RuleFor(p => p.Name)
                .Length(3,100).WithMessage("Name is");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Description is required");

            RuleFor(p => p.Category)
                .NotEmpty().WithMessage("Category is required");

            RuleFor(p => p.ContactEmail)
                .NotEmpty().WithMessage("Contact email is required");

            RuleFor(p => p.PostalCode)
                .Matches(@"^\d{2}-\d{3}$")
                .WithMessage("Please enter valid postal code");
        }
    }
}
