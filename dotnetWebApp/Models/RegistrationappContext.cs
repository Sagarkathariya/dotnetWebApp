using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dotnetWebApp.Models;

public partial class RegistrationappContext : DbContext
{
    public RegistrationappContext()
    {
    }

    public RegistrationappContext(DbContextOptions<RegistrationappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserList> UserLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserList>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserList__1788CC4CB91D0585");

            entity.ToTable("UserList");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.UserAddress).HasMaxLength(50);
            entity.Property(e => e.UserEmail).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(40);
            entity.Property(e => e.UserRole).HasMaxLength(50);
            entity.Property(e => e.UserStatus).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
