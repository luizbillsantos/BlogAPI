using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services;
using Api.Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private ICommentService _service;
        private IBlogPostRepository _repository;

        public CommentController(ICommentService service, IBlogPostRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        /// <summary>
        /// List all comments 
        /// </summary>
        /// <returns>List of comments</returns>
        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Get comment by Id
        /// </summary>
        /// <param name="id">comment Id</param>
        /// <returns>Comment</returns>
        [HttpGet]
        [Authorize("Bearer")]
        [Route("{id}", Name = "/comment/Get")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Save new comment 
        /// </summary>
        /// <param name="user">Comment</param>
        /// <returns>Object Saved</returns>
        [HttpPost]
        [Authorize("Bearer")]
        public async Task<ActionResult> Post([FromBody] CommentDtoCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (await _repository.ExistAsync(comment.PostId))
                {
                    var userLogged = User.FindFirstValue(ClaimTypes.Name);
                    comment.UserId = Convert.ToInt32(userLogged);
                    var result = await _service.Post(comment);
                    if (result != null)
                        return Created(new Uri(Url.Link("Get", new { id = result.Id })), result);
                    else
                        return BadRequest();
                }
                else
                    return BadRequest("PostId informado não existe");
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Delete comment from DB
        /// </summary>
        /// <param name="id">Comment Id</param>
        /// <returns>Bool</returns>
        [HttpDelete]
        [Route("{id}", Name = "/comment/Delete")]
        [Authorize("Bearer")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
