using LiveChat.Domain.Entities;
using LiveChat.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiveChat.Infrastructure.DbContext;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Conversation> Conversations { get; set; }
    public DbSet<ConversationMember> ConversationMembers { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<MessageDelivery> MessageDeliveries { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Configuring Foreign key for message table
        builder.Entity<Message>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);
        // Configuring Foreign key for conversation member table
        builder.Entity<ConversationMember>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(cm => cm.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        // Configuring Foreign key for message delivery table
        builder.Entity<MessageDelivery>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(md => md.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);
        // Adding indexes for messages for improved performance
        builder.Entity<Message>()
            .HasIndex(m => m.SenderId);
        // Preventing the same user from joining same conversation twice.
        builder.Entity<ConversationMember>()
            .HasIndex(cm => new { cm.ConversationId, cm.UserId })
            .IsUnique();
    }
}