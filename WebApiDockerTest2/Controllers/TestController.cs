using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiDockerTest2.Base;
using WebApiDockerTest2.Handlers;

namespace WebApiDockerTest2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : MyControllerBase
    {
        private readonly IMediator mediator;

        public TestController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet()]
        public async Task<ActionResult<int>> TestEndpoint([FromQuery] int Value)
        {
            return Ok(await mediator.Send(new TestRequest { Value = Value }));
        }

        [HttpGet("EchoString")]
        public async Task<ActionResult<int>> EchoString([FromQuery] string Value)
        {
            return Ok(await mediator.Send(new EchoStringRequest { Value = Value }));
        }
    }
}
