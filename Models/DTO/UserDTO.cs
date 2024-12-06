using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace dotnetproject.Models;

public class UserDTO {
    public int? ID { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required, EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }
    [Required, MinLength(8, ErrorMessage = "Password should be 8 characters long minimum")]
    public string? Password { get; set; }
    [Required, ]
    public DateTime? DateOfBirth { get; set; }
    public string? PlaceOfBirth { get; set; }
    public string? Address { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}

public class UserLoginDTO {
    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }
}

public class UserTokenDTO {
    [Required]
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}