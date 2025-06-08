using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.CQRS.Commands.CreateRestaurant;
using Restaurants.Application.CQRS.Commands.DeleteRestaurant;
using Restaurants.Application.CQRS.Commands.UpdateRestaurant;
using Restaurants.Application.CQRS.Queries.GetRestaurantById;
using Restaurants.Application.CQRS.Queries.NewFolder.GetAllRestaurant;
using Restaurants.Application.Dtos;
using System.Threading.Tasks;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
        {
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto>> GetAsync([FromRoute] int id)
        {
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery() { Id = id });

            if (restaurant is null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest($"Id is required");
            var isdeleted = await mediator.Send(new DeleteRestaurantCommand() { Id = id });

            if (isdeleted)
                return NoContent();
            return NotFound();
        }
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, [FromBody] UpdateRestaurantCommand command)
        {
            var validator = new UpdateRestaurantCommandValidator();
            var result = validator.Validate(command);

            command.Id = id;
            if (id == 0)
                return BadRequest($"Id is required");
            var isUpdated = await mediator.Send(command);

            if (isUpdated)
                return NoContent();
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand createRestaurant)
        {
            var validator = new CreateRestaurantCommandValidator();
            var result = validator.Validate(createRestaurant);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var id = await mediator.Send(createRestaurant);

            return CreatedAtAction(nameof(GetAsync), new { id }, null);
        }
    }
}
