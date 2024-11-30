﻿using StudentTeacherManagement.Core.Models;

namespace StudentTeacherManagement.DTOs;

public class RegisterDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public UserRole Role { get; set; }

    public string Email { get; set; }
    public string Password { get; set; }
}