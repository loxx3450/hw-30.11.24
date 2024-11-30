Changes comparing with Project from the lesson:
- User.cs: added property Role
- AuthService.cs: methods Register and Login work now with Teacher as well; in method GenerateToken JWT Token saves Role
- RegisterDTO.cs: user should enter Role while registering
- StudentController.cs: added Attribute Authorize for certain Role
