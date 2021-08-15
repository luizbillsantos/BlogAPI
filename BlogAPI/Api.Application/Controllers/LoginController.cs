﻿using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<object> Login([FromBody] LoginDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (user == null)
                return BadRequest();

            try
            {
                var result = await _service.FindByLogin(user);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
