using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence;

public class DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : DbContext(options)
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<UserSkill> UserSkills { get; set; }
    public DbSet<ProjectComment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Skill>(e =>
        {
            e.HasKey(s => s.Id);

        });
        builder.Entity<UserSkill>(e =>
        {
            e.HasKey(us => us.Id);
            e.HasOne(us => us.Skill)
                .WithMany(s=>s.UserSkills)
                .HasForeignKey(us => us.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
            e.HasOne(us => us.User)
                .WithMany(s=>s.UserSkills)
                .HasForeignKey(us => us.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        });
        builder.Entity<ProjectComment>(e =>
        {
            e.HasKey(pc => pc.Id);
            e.HasOne(pc => pc.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(pc => pc.IdProject)
                .OnDelete(DeleteBehavior.Restrict);
            e.HasOne(pc => pc.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(pc => pc.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        });
        builder.Entity<User>(e =>
        {
            e.HasKey(u => u.Id);
            // e.HasMany(u => u.UserSkills)
            //     .WithOne(us => us.User)
            //     .HasForeignKey(us => us.IdUser)
            //     .OnDelete(DeleteBehavior.Restrict);
        });
        builder.Entity<Project>(e =>
        {
            e.HasKey(p => p.Id);
            e.HasOne(p => p.Client)
                .WithMany(c => c.OwnedProjects)
                .HasForeignKey(p => p.IdClient)
                .OnDelete(DeleteBehavior.Restrict);
            e.HasOne(p => p.FreeLancer)
                .WithMany(f => f.FreeLanceProjects)
                .HasForeignKey(p => p.IdFreeLancer)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        base.OnModelCreating(builder);
    }
}