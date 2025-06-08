using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.CQRS.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler
        (ILogger<UpdateRestaurantCommandHandler> logger,
        IRestaurantsRepository repository,
        IMapper mapper): IRequestHandler<UpdateRestaurantCommand, bool>
    {
        public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await repository.GetAsync(request.Id);

            if (restaurant is null)
                return false;

            mapper.Map(request, restaurant);
            //restaurant.Name = request.Name;
            //restaurant.Description = request.Description;
            //restaurant.HasDelivery = restaurant.HasDelivery;

            await repository.SaveChangesAsync();

            return true;
        }
    }
}
