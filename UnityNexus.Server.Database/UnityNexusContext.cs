using UnityNexus.Server.Shared.Models;
using Answer = UnityNexus.Server.Shared.Entities.Answer;
using Form = UnityNexus.Server.Shared.Entities.Form;
using Group = UnityNexus.Server.Shared.Entities.Group;
using Question = UnityNexus.Server.Shared.Entities.Question;
using Submission = UnityNexus.Server.Shared.Entities.Submission;

namespace UnityNexus.Server.Database
{
    public partial class UnityNexusContext : DbContext
    {

        public DbSet<Tag> Tags { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<Form> Forms { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Submission> Submissions { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;

        public UnityNexusContext(DbContextOptions<UnityNexusContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
