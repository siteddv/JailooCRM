﻿using JailooCRM.BLL;
using JailooCRM.DAL.DTOs;
using JailooCRM.DAL.Request;
using JailooCRM.DAL.Response;
using Microsoft.AspNetCore.Mvc;

namespace JailooCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthManager _authManager;

        public AuthController(AuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            return await _authManager.LoginAsync(request);
        }

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<LoginResponse> RefreshToken(TokenModel model)
        {
            return  await _authManager.CreateOrUpdateToken(model);
        }
    }
}
