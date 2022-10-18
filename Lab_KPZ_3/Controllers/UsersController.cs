using Lab_KPZ_3.CQRS.Users.Commands;
using Lab_KPZ_3.CQRS.Users.Models;
using Lab_KPZ_3.CQRS.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_KPZ_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserModel>))]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetUsers(), CancellationToken.None));
        }

        /// <summary>
        /// Get user by ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetUserById { Id = id }, CancellationToken.None));
        }

        /// <summary>
        /// Create user.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<ActionResult> Create(CreateUser command)
        {
            return Ok(await Mediator.Send(command, CancellationToken.None));
        }

        /// <summary>
        /// Update user.
        /// </summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<ActionResult> Update(UpdateUser command)
        {
            return Ok(await Mediator.Send(command, CancellationToken.None));
        }

        /// <summary>
        /// Delete user by ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteUser { Id = id }, CancellationToken.None);

            return NoContent();
        }
    }
}
