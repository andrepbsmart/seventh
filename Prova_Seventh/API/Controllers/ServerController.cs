using System.Net;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using Prova.Application.Commands;
using Prova.Application.Responses;

namespace Prova.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Server
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.Created, "Create Server", typeof(IEnumerable<Response>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        [SwaggerResponse((int)HttpStatusCode.TooManyRequests)]
        [HttpPost]
        [Route("server")]
        public async Task<IActionResult> CreateServer([FromBody] ServerCommandCreate request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }

        /// <summary>
        /// Update Server
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Update Server", typeof(IEnumerable<Response>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        [SwaggerResponse((int)HttpStatusCode.TooManyRequests)]
        [HttpPut]
        [Route("server")]
        public async Task<IActionResult> UpdateServer([FromBody] ServerCommandUpdate request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete Server
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Delete Server", typeof(IEnumerable<Response>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        [SwaggerResponse((int)HttpStatusCode.TooManyRequests)]
        [HttpDelete]
        [Route("server/{serverid}")]
        public async Task<IActionResult> DeleteServer(string serverid)
        {
            try
            {
                ServerCommandDelete request = new ServerCommandDelete(){ idServer = serverid };
                var response = await _mediator.Send(request);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }

        /// <summary>
        /// Detail Server By Unique Identifier
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Detail Server By Unique Identifier", typeof(IEnumerable<ServerResponseDetail>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        [SwaggerResponse((int)HttpStatusCode.TooManyRequests)]
        [HttpGet]
        [Route("server/{serverid}")]
        public async Task<IActionResult> ServerFindbyID(string serverid)
        {
            try
            {
                ServersQueryGetbyId request = new ServersQueryGetbyId() { idServer = serverid };
                var response = await _mediator.Send(request);
                if (response == null)
                {
                    return NotFound(new Response { StatusCode = StatusCodes.Status404NotFound, Message = "Servidor não encontrado" });
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }

        /// <summary>
        /// List All Servers
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "List All Servers", typeof(IEnumerable<ServersQueryAll>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        [SwaggerResponse((int)HttpStatusCode.TooManyRequests)]
        [HttpGet]
        [Route("servers")]
        public async Task<IActionResult> ListAllServers([FromQuery] ServersQueryAll request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            };
        }
    }
}
