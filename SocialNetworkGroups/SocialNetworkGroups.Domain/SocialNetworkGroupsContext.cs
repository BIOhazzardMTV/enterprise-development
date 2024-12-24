using Microsoft.EntityFrameworkCore;

namespace SocialNetworkGroups.Domain;

public class SocialNetworkGroupsContext(DbContextOptions<SocialNetworkGroupsContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Post> Posts{ get; set; }
    public DbSet<GroupRole> GroupRoles{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>().Property(u => u.FullName).HasMaxLength(200).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.Gender).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.DateOfBirth).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.RegistrationDate).IsRequired();

        modelBuilder.Entity<Group>().HasKey(g => g.Id);
        modelBuilder.Entity<Group>().Property(g => g.Title).HasMaxLength(200).IsRequired();
        modelBuilder.Entity<Group>().Property(g => g.Description).HasMaxLength(2000);
        modelBuilder.Entity<Group>().Property(g => g.CreationDate).IsRequired();
        modelBuilder.Entity<Group>().Property(g => g.AuthorId).IsRequired();

        modelBuilder.Entity<Post>().HasKey(p => p.Id);
        modelBuilder.Entity<Post>().Property(p => p.Title).HasMaxLength(200).IsRequired();
        modelBuilder.Entity<Post>().Property(p => p.Description).HasMaxLength(2000);
        modelBuilder.Entity<Post>().Property(p => p.CreationDate).IsRequired();
        modelBuilder.Entity<Post>().Property(p => p.GroupId).IsRequired();
        modelBuilder.Entity<Post>().Property(p => p.AuthorId).IsRequired();

        modelBuilder.Entity<GroupRole>().HasKey(gr => gr.Id);
        modelBuilder.Entity<GroupRole>().Property(gr => gr.UserId).IsRequired();
        modelBuilder.Entity<GroupRole>().Property(gr => gr.GroupId).IsRequired();
        modelBuilder.Entity<GroupRole>().Property(gr => gr.Role).IsRequired();
    }
}
