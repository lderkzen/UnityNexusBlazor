namespace UnityNexus.Server.Database
{
    public partial class UnityNexusContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<Shared.Models.AnswerType> AnswerTypes { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Shared.Models.CategoryType> CategoryTypes { get; set; } = null!;
        public DbSet<Form> Forms { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<Shared.Models.GroupType> GroupTypes { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Submission> Submissions { get; set; } = null!;
        public DbSet<Shared.Models.SubmissionStatus> SubmissionStatusses { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<UserNotificationSettings> UserNotificationSettings { get; set; } = null!;
        public DbSet<Shared.Models.VisibilityLevel> VisibilityLevels { get; set; } = null!;

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
