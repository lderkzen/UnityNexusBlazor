namespace UnityNexus.Shared
{
    public class UnityNexusContext : DbContext
    {
        public DbSet<RemoteRole> Roles { get; set; } = null!;
        public DbSet<RemoteChannel> Channels { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<Form> Forms { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Submission> Submissions { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;

        public UnityNexusContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseNpgsql(GenerateConnectionString());
        }

        private static string GenerateConnectionString()
        {
            return string.Format(
                "Server={0};Port={1};User ID={2};Password={3};Database={4}",
                Environment.GetEnvironmentVariable("UNITY_NEXUS_DB_HOST"),
                Environment.GetEnvironmentVariable("UNITY_NEXUS_DB_PORT"),
                Environment.GetEnvironmentVariable("UNITY_NEXUS_DB_USERNAME"),
                Environment.GetEnvironmentVariable("UNITY_NEXUS_DB_PASSWORD"),
                Environment.GetEnvironmentVariable("UNITY_NEXUS_DB_NAME")
            );
        }
    }
}
