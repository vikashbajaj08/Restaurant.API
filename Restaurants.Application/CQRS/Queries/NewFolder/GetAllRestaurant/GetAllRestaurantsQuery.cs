using MediatR;
using Restaurants.Application.Dtos;

namespace Restaurants.Application.CQRS.Queries.NewFolder.GetAllRestaurant
{
    public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
    {
    }
}
