using Application.Users.Commands;
using Application.Users.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await Mediator.Send(new GetUserList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserDetail(string id)
        {
            return await Mediator.Send(new GetUserDetails.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateUser(User user)
        {
            return await Mediator.Send(new CreateUser.Command { User = user });
        }
    }
}