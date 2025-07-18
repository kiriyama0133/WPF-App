using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace myapp.Models;

public partial class dbContextService : DbContext
{
    public dbContextService()
    {
    }

    public dbContextService(DbContextOptions<dbContextService> options)
        : base(options)
    {
    }

    #region 映射到数据库的表
    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamMember> TeamMembers { get; set; }

    public virtual DbSet<User> Users { get; set; }
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=kiriyama;Username=postgres;Password=1996yong;");

    // OnConfiguring 方法：用于配置数据库连接
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("teams_pkey");

            entity.ToTable("teams");

            entity.HasIndex(e => e.Name, "teams_name_key").IsUnique();

            entity.Property(e => e.TeamId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("team_id");
            entity.Property(e => e.CaptainId).HasColumnName("captain_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Logo).HasColumnName("logo");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Captain).WithMany(p => p.Teams)
                .HasForeignKey(d => d.CaptainId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teams_captain_id_fkey");
        });

        modelBuilder.Entity<TeamMember>(entity =>
        {
            entity.HasKey(e => e.TeamMemberId).HasName("team_members_pkey");

            entity.ToTable("team_members");

            entity.HasIndex(e => new { e.TeamId, e.UserId }, "team_members_team_id_user_id_key").IsUnique();

            entity.Property(e => e.TeamMemberId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("team_member_id");
            entity.Property(e => e.JoinedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("joined_at");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValueSql("'member'::character varying")
                .HasColumnName("role");
            entity.Property(e => e.TeamId).HasColumnName("team_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamMembers)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("team_members_team_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.TeamMembers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("team_members_user_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.HasIndex(e => e.Qq, "users_qq_key").IsUnique();

            entity.HasIndex(e => e.Steam64Id, "users_steam_64_id_key").IsUnique();

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("user_id");
            entity.Property(e => e.AvatarUrl).HasColumnName("avatar_url");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.LastLoginAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_login_at");
            entity.Property(e => e.Nickname)
                .HasMaxLength(255)
                .HasColumnName("nickname");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.Qq)
                .HasMaxLength(255)
                .HasColumnName("qq");
            entity.Property(e => e.RegisteredAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("registered_at");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValueSql("'guest'::character varying")
                .HasColumnName("role");
            entity.Property(e => e.Steam64Id)
                .HasMaxLength(255)
                .HasColumnName("steam_64_id");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    // 辅助方法，用于扩展 OnModelCreating
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
