using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();

        Task<Restaurant?> GetAsync(int Id);

        Task<int> CreateRestaurant(Restaurant restaurant);

        Task DeleteRestaurant(Restaurant restaurant);

        Task SaveChangesAsync();
    }
}
