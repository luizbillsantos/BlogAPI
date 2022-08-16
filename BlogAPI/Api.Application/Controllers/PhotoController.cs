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
    public class PhotoController : ControllerBase
    {
        private IPhotoService _service;
        private IAlbumRepository _repository;

        public PhotoController(IPhotoService service, IAlbumRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        /// <summary>
        /// List all photos 
        /// </summary>
        /// <returns>List of photos</returns>
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
        /// Get photo by Id
        /// </summary>
        /// <param name="id">Photo Id</param>
        /// <returns>Photo</returns>
        [HttpGet]
        [Authorize("Bearer")]
        [Route("{id}", Name = "/photo/Get")]
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
        /// Save new photo 
        /// </summary>
        /// <param name="user">Photo</param>
        /// <returns>Object Saved</returns>
        [HttpPost]
        [Authorize("Bearer")]
        public async Task<ActionResult> Post([FromBody] PhotoDtoCreate photo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userLogged = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Name));
                var album = await _repository.SelectAsync(photo.AlbumId);
                if(album == null)
                    return BadRequest("Album não encontrado");

                if (album?.UserId == userLogged)
                {
                    
                    var result = await _service.Post(photo);
                    if (result != null)
                        return Created(new Uri(Url.Link("Get", new { id = result.Id })), result);
                    else
                        return BadRequest();
                }
                else
                    return BadRequest("Não é permitido adicionar fotos em albuns de outros usuários");
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Delete photo from DB
        /// </summary>
        /// <param name="id">Photo Id</param>
        /// <returns>Bool</returns>
        [HttpDelete]
        [Route("{id}", Name = "/photo/Delete")]
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
