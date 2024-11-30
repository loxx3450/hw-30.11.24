﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentTeacherManagement.Core.Interfaces;
using StudentTeacherManagement.Core.Models;
using StudentTeacherManagement.DTOs;

namespace StudentTeacherManagement.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
   private readonly IAuthService _authService;
   private readonly IMapper _mapper;

   public AuthController(IAuthService authService, IMapper mapper)
   {
      _authService = authService;
      _mapper = mapper;
   }

   [HttpPost("register")]
   public async Task<ActionResult> Register([FromBody] RegisterDTO user)
   {
      await _authService.Register(_mapper.Map<Student>(user));
      return Ok();
   }

   [HttpPost("verifyUser")]
   public async Task<ActionResult<AuthResponse>> VerifyUser([FromBody] VerificationData verificationData)
   {
      var (user, token) = await _authService.ValidateAccount(verificationData.Email, verificationData.Code);
      return Ok(new AuthResponse(){ User = user, Token = token });
   }

   [HttpPost("login")]
   public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginDTO user)
   {
      var (loggedUser, token) = await _authService.Login(user.Email, user.Password);

      if (loggedUser == null)
         return NotFound();
      
      return Ok(new AuthResponse(){ User = loggedUser, Token = token });
   }
}