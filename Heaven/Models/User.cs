using System;
using System.Collections.Generic;

namespace Heaven.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string Email { get; set; } = null!;

    public string? PasswordHash { get; set; }

    public string? PhoneNumber { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public string? Bio { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? IsHost { get; set; }
}
