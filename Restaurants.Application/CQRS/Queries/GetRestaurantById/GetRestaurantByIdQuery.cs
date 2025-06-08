using MediatR;
using Restaurants.Application.Dtos;

namespace Restaurants.Application.CQRS.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery : IRequest<RestaurantDto>
    {
        public int Id { get; set; }
    }
}
