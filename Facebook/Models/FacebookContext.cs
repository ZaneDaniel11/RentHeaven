using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Facebook.Models;

public partial class FacebookContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public FacebookContext()
    {
    }

    public FacebookContext(DbContextOptions<FacebookContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Facebook.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.UserName).HasColumnName("username");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.BirthDate).HasColumnName("birthdate");
            entity.Property(e => e.ProfilePic).HasColumnName("profile_picture");
            entity.Property(e => e.CoverPhoto).HasColumnName("cover_photo");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.MobileNumber).HasColumnName("phone_number");
            entity.Property(e => e.IsVerified).HasColumnName("is_verified");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
