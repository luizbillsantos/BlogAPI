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
    public class AlbumController : ControllerBase
    {

        private IAlbumService _service;

        public AlbumController(IAlbumService service)
        {
            _service = service;
        }

        /// <summary>
        /// List all albums 
        /// </summary>
        /// <returns>List of albums</returns>
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
        /// Get album by Id
        /// </summary>
        /// <param name="id">album Id</param>
        /// <returns>Album</returns>
        [HttpGet]
        [Authorize("Bearer")]
        [Route("{id}", Name = "/album/Get")]
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
        /// Save new album 
        /// </summary>
        /// <param name="user">Album</param>
        /// <returns>Object Saved</returns>
        [HttpPost]
        [Authorize("Bearer")]
        public async Task<ActionResult> Post([FromBody] AlbumDtoCreate album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userLogged = User.FindFirstValue(ClaimTypes.Name);
                album.UserId = Convert.ToInt32(userLogged);

                var result = await _service.Post(album);
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
        ///// Delete album from DB
        ///// </summary>
        ///// <param name="id">Album Id</param>
        ///// <returns>Bool</returns>
        //[HttpDelete]
        //[Route("{id}", Name = "/album/Delete")]
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
