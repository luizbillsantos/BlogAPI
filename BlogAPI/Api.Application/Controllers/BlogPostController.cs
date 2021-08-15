using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services;
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
    public class BlogPostController : ControllerBase
    {
        private IBlogPostService _service;

        public BlogPostController(IBlogPostService service)
        {
            _service = service;
        }


        /// <summary>
        /// List all posts 
        /// </summary>
        /// <returns>List of posts</returns>
        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
        /// Get post by Id
        /// </summary>
        /// <param name="id">post Id</param>
        /// <returns>Post</returns>
        [HttpGet]
        [Authorize("Bearer")]
        [Route("{id}", Name = "/blogpost/Get")]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
        /// Save new post 
        /// </summary>
        /// <param name="user">Post</param>
        /// <returns>Object Saved</returns>
        [HttpPost]
        [Authorize("Bearer")]
        public async Task<ActionResult> Post([FromBody] BlogPostDtoCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userLogged = User.FindFirstValue(ClaimTypes.Name);
                post.UserId = Convert.ToInt32(userLogged);
                var result = await _service.Post(post);
                if (result != null)
                    return Created(new Uri(Url.Link("Get", new { id = result.Id })), result);
                else
                    return BadRequest();
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        ///// <summary>
        ///// Delete Post from DB
        ///// </summary>
        ///// <param name="id">User Id</param>
        ///// <returns>Bool</returns>
        //[HttpDelete]
        //[Route("{id}", Name = "/blogpost/Delete")]
        //[Authorize("Bearer")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    try
        //    {
        //        return Ok(await _service.Delete(id));
        //    }
        //    catch (ArgumentException e)
        //    {

        //        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
        //    }
        //}

    }
}
