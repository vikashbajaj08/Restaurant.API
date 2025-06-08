using FluentValidation;

namespace Restaurants.Application.CQRS.Commands.UpdateRestaurant
{
    public  class UpdateRestaurantCommandValidator :AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name id required");

            RuleFor(p => p.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
