﻿using System.Net;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using Prova.Application.Commands;
using Prova.Application.Responses;

namespace Prova.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Video
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.Created, "Create Video", typeof(IEnumerable<Response>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        [SwaggerResponse((int)HttpStatusCode.TooManyRequests)]
        [HttpPost]
        public async Task<IActionResult> CreateVideo([FromBody] VideoCommandCreate request)
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
        /// Delete Video
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Delete Video", typeof(IEnumerable<Response>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        [SwaggerResponse((int)HttpStatusCode.TooManyRequests)]
        [HttpDelete]
        public async Task<IActionResult> DeleteVideo([FromQuery] VideoCommandDelete request)
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
        /// Detail Video By Unique Identifier
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Detail Video By Unique Identifier", typeof(IEnumerable<VideoResponseDetail>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        [SwaggerResponse((int)HttpStatusCode.TooManyRequests)]
        [HttpGet]
        public async Task<IActionResult> FindbyID([FromQuery] VideosQueryGetbyId request)
        {
            try
            {
                var response = await _mediator.Send(request);
                if (response == null)
                {
                    return NotFound(new Response { StatusCode = StatusCodes.Status404NotFound, Message = "Video não encontrado" });
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }

        /// <summary>
        /// Content Video By Unique Identifier
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Content Video By Unique Identifier", typeof(IEnumerable<VideoResponseDetail>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        [SwaggerResponse((int)HttpStatusCode.TooManyRequests)]
        [HttpGet]
        [Route("binary")]
        public async Task<IActionResult> FindBinaryById([FromQuery] VideosQueryGetBinarybyId request)
        {
            try
            {
                var response = await _mediator.Send(request);
                if (response == null)
                {
                    return NotFound(new Response { StatusCode = StatusCodes.Status404NotFound, Message = "Video não encontrado" });
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }

        /// <summary>
        /// List All Videos
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "List All Videos", typeof(IEnumerable<VideosQueryAll>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        [SwaggerResponse((int)HttpStatusCode.TooManyRequests)]
        [HttpGet]
        [Route("videos")]
        public async Task<IActionResult> ListAllVideos([FromQuery] VideosQueryAll request)
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
