﻿using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Data;
public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
    }

    // Users Management
    public DbSet<User> Users { get; set; }
    public DbSet<SprintItem> SprintItems { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Project> Projects { get; set; }
    
    public DbSet<UserAssignedProject> UserAssignedProjects { get; set; }
    public DbSet<UserSprintItem> UserSprintItems { get; set; }
    public DbSet<UserFeature> UserFeatures { get; set; }



    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = HotelReservationSystem; Integrated Security = True; Connect Timeout = 30; Encrypt=True;Trust Server Certificate=True;Application Intent = ReadWrite; Multi Subnet Failover=False")
    //         .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    //         .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
    //         .EnableSensitiveDataLogging();
    // }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User to UserAssignedProjects
        modelBuilder.Entity<UserAssignedProject>()
            .HasOne(uap => uap.User)
            .WithMany(u => u.UserAssignedProjects)
            .HasForeignKey(u => u.UserID)
            .OnDelete(DeleteBehavior.NoAction);  // Avoid cascade delete

        // Project to UserAssignedProjects
        modelBuilder.Entity<UserAssignedProject>()
            .HasOne(uap => uap.Project)
            .WithMany(p => p.UserAssignedProjects)
            .HasForeignKey(uap => uap.ProjectID)
            .OnDelete(DeleteBehavior.NoAction);

        // User to CreatedProjects
        modelBuilder.Entity<Project>()
            .HasOne(p => p.Creator)
            .WithMany(u => u.CreatedProjects)
            .HasForeignKey(p => p.CreatorID)
            .OnDelete(DeleteBehavior.NoAction);  // Avoid cascade delete
    }
}
//Data Source =.; Initial Catalog = HotelReservationSystem; Integrated Security = True; Connect Timeout = 30; Encrypt=True;Trust Server Certificate=True;Application Intent = ReadWrite; Multi Subnet Failover=False