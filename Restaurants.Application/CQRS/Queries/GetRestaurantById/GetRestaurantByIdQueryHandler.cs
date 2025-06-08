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

namespace Restaurants.Application.CQRS.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler 
        (ILogger<GetRestaurantByIdQueryHandler> logger,
        IMapper mapper,
        IRestaurantsRepository repository): IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
    {
        public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Get {request.Id}");
            var restaurant = await repository.GetAsync(request.Id);

            var dto = mapper.Map<RestaurantDto?>(restaurant);
            return dto;
        }
    }
}
