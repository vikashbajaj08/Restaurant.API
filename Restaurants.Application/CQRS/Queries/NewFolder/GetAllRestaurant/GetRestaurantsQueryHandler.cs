using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.CQRS.Queries.NewFolder.GetAllRestaurant
{
    public class GetRestaurantsQueryHandler
        (ILogger<GetRestaurantsQueryHandler> logger,
        IMapper mapper,
        IRestaurantsRepository repository): IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
    {
        public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all restaurants");

            var restaurants = await repository.GetAllAsync();

            var dto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            return dto;
        }
    }
}
