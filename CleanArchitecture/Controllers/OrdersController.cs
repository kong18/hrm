using CleanArchitecture.Api.Controllers.ResponseTypes;
using CleanArchitecture.Application.Orders.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CleanArchitecture.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _mediator;

        public OrdersController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="401">Unauthorized request.</response>
        /// <response code="403">Forbidden request.</response>
        /// 

        
        [HttpPost("order")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> CreateOrder(
            [FromBody] CreateOrderCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return CreatedAtAction(nameof(Created), new JsonResponse<Guid>(new Guid()));
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Successfully deleted.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="401">Unauthorized request.</response>
        /// <response code="403">Forbidden request.</response>
        /// <response code="404">One or more entities could not be found with the provided parameters.</response>
        //[HttpDelete("api/order/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult> DeleteOrder([FromRoute] Guid id, CancellationToken cancellationToken = default)
        //{
        //    await _mediator.Send(new DeleteOrderCommand(id: id), cancellationToken);
        //    return Ok();
        //}

        /// <summary>
        /// </summary>
        /// <response code="204">Successfully updated.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="401">Unauthorized request.</response>
        /// <response code="403">Forbidden request.</response>
        /// <response code="404">One or more entities could not be found with the provided parameters.</response>
        //[HttpPut("api/order/{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult> UpdateOrder(
        //    [FromRoute] Guid id,
        //    [FromBody] UpdateOrderCommand command,
        //    CancellationToken cancellationToken = default)
        //{
        //    if (command.Id == default)
        //    {
        //        command.Id = id;
        //    }

        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await _mediator.Send(command, cancellationToken);
        //    return NoContent();
        //}

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified OrderDto.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="401">Unauthorized request.</response>
        /// <response code="403">Forbidden request.</response>
        /// <response code="404">No OrderDto could be found with the provided parameters.</response>
        //[HttpGet("api/order/{id}")]
        //[ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<OrderDto>> GetOrderById(
        //    [FromRoute] Guid id,
        //    CancellationToken cancellationToken = default)
        //{
        //    var result = await _mediator.Send(new GetOrderByIdQuery(id: id), cancellationToken);
        //    return result == null ? NotFound() : Ok(result);
        //}

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified List&lt;OrderDto&gt;.</response>
        /// <response code="401">Unauthorized request.</response>
        /// <response code="403">Forbidden request.</response>
        //[HttpGet("api/order")]
        //[ProducesResponseType(typeof(List<OrderDto>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<List<OrderDto>>> GetOrders(CancellationToken cancellationToken = default)
        //{
        //    var result = await _mediator.Send(new GetOrdersQuery(), cancellationToken);
        //    return Ok(result);
        //}
    }
}
