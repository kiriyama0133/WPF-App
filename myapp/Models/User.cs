using System;
using System.Collections.Generic;

namespace myapp.Models;

public partial class User
{
    public Guid UserId { get; set; }

    public string? Steam64Id { get; set; }

    public string? Qq { get; set; }

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string? Nickname { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime RegisteredAt { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public string? AvatarUrl { get; set; }

    public string? Bio { get; set; }

    public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
