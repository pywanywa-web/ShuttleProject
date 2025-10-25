using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ShuttleProject.Models.Data.MonitoringSystem;

public partial class MonitoringSystemContext : IdentityDbContext<ApplicationUser>
{
    public MonitoringSystemContext()
    {
    }

    public MonitoringSystemContext(DbContextOptions<MonitoringSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Shuttle> Shuttles { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=AppConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.HasDefaultSchema("dbo");
        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.HasKey(e => e.Id)
               .IsClustered(false);
            entity.ToTable(name: "Users");
        });
        modelBuilder.Entity<IdentityRole>(entity =>
        {
            entity.HasKey(e => e.Id)
               .IsClustered(false);
            entity.ToTable(name: "Role");
        });
        modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.UserId })
               .IsClustered(false);
            entity.ToTable("UserRoles");
        });
        modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.HasKey(e => e.Id)
               .IsClustered(false);
            entity.ToTable("UserClaims");
        });
        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(e => e.LoginProvider)
               .IsClustered(false);
            entity.ToTable("UserLogins");

        });
        modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
        {
            entity.HasKey(e => e.Id)
               .IsClustered(false);
            entity.ToTable("RoleClaims");
        });
        modelBuilder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.HasKey(e => e.LoginProvider)
               .IsClustered(false);
            entity.ToTable("UserTokens");
        });



        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId)
                .HasName("PK2")
                .IsClustered(false);

            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.LicenseNo).HasMaxLength(20);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.PassengerId)
                .HasName("PK5")
                .IsClustered(false);

            entity.Property(e => e.PassengerId).HasColumnName("PassengerID");
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.RouteId)
                .HasName("PK3")
                .IsClustered(false);

            entity.Property(e => e.RouteId)
                .ValueGeneratedNever()
                .HasColumnName("RouteID");
            entity.Property(e => e.EndPoint)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RouteName).HasMaxLength(15);
            entity.Property(e => e.StartPoint)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Shuttle>(entity =>
        {
            entity.HasKey(e => e.ShuttleId)
                .HasName("PK1")
                .IsClustered(false);

            entity.Property(e => e.ShuttleId)
                .HasMaxLength(18)
                .HasColumnName("ShuttleID");
            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.PlateNumber).HasMaxLength(10);
            entity.Property(e => e.Status)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Driver).WithMany(p => p.Shuttles)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefDrivers5");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId)
                .HasName("PK4")
                .IsClustered(false);

            entity.Property(e => e.TripId)
                .ValueGeneratedNever()
                .HasColumnName("TripID");
            entity.Property(e => e.PassengerId).HasColumnName("PassengerID");
            entity.Property(e => e.RouteId).HasColumnName("RouteID");
            entity.Property(e => e.ShuttleId)
                .HasMaxLength(18)
                .HasColumnName("ShuttleID");
            entity.Property(e => e.TripStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Passenger).WithMany(p => p.Trips)
                .HasForeignKey(d => d.PassengerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefPassengers3");

            entity.HasOne(d => d.Route).WithMany(p => p.Trips)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefRoutes2");

            entity.HasOne(d => d.Shuttle).WithMany(p => p.Trips)
                .HasForeignKey(d => d.ShuttleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefShuttles1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    internal void DeleteTrip(int id)
    {
        throw new NotImplementedException();
    }

    internal dynamic GetActivePassengers()
    {
        throw new NotImplementedException();
    }

    internal dynamic GetAllRoutes()
    {
        throw new NotImplementedException();
    }

    internal dynamic GetAvailableShuttles()
    {
        throw new NotImplementedException();
    }

    internal string? GetTripById(int id)
    {
        throw new NotImplementedException();
    }

    internal void SaveTrip(Trip newTrip)
    {
        throw new NotImplementedException();
    }

    internal void UpdateTrip(Trip editedTrip)
    {
        throw new NotImplementedException();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
