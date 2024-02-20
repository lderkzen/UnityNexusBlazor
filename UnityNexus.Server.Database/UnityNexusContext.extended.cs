namespace UnityNexus.Server.Database
{
    public partial class UnityNexusContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            IReadOnlyDictionary<Type, ValueConverter> converter = GetConverter();

            SpecifyAllDateTimeValuesAsUTC(modelBuilder);
        }

        private static void SpecifyAllDateTimeValuesAsUTC(ModelBuilder modelBuilder)
        {
            void SpecifyPropertyConversion(
                IReadOnlyPropertyBase property,
                IReadOnlyTypeBase entityType
            )
            {
                if (property.ClrType == typeof(DateTime))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime>(property.Name)
                        .HasConversion(
                            v => v.ToUniversalTime(),
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
                }
                else if (property.ClrType == typeof(DateTime?))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime?>(property.Name)
                        .HasConversion(
                            v => v.HasValue ? v.Value.ToUniversalTime() : v,
                            v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);
                }
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                foreach (var property in entityType.GetProperties())
                    SpecifyPropertyConversion(property, entityType);
        }

        private static IReadOnlyDictionary<Type, ValueConverter> GetConverter() =>
            new Dictionary<Type, ValueConverter>
            {
                { typeof(AnswerId), new AnswerId.EfCoreValueConverter() },
                { typeof(CategoryId), new CategoryId.EfCoreValueConverter() },
                { typeof(ChannelId), new ChannelId.EfCoreValueConverter() },
                { typeof(FormId), new FormId.EfCoreValueConverter() },
                { typeof(GroupId), new GroupId.EfCoreValueConverter() },
                { typeof(QuestionId), new QuestionId.EfCoreValueConverter() },
                { typeof(RoleId), new RoleId.EfCoreValueConverter() },
                { typeof(SubmissionId), new SubmissionId.EfCoreValueConverter() },
                { typeof(TagId), new TagId.EfCoreValueConverter() },
                { typeof(UserId), new UserId.EfCoreValueConverter() },
                { typeof(AnswerType), new EnumToNumberConverter<AnswerType, byte>() },
                { typeof(CategoryType), new EnumToNumberConverter<CategoryType, byte>() },
                { typeof(GroupType), new EnumToNumberConverter<GroupType, byte>() },
                { typeof(NotifiableType), new EnumToNumberConverter<NotifiableType, byte>() },
                { typeof(NotificationFlag), new EnumToNumberConverter<NotificationFlag, short>() },
                { typeof(RemoteChannelType), new EnumToNumberConverter<RemoteChannelType, byte>() },
                { typeof(SubmissionStatus), new EnumToNumberConverter<SubmissionStatus, byte>() },
                { typeof(VisibilityLevel), new EnumToNumberConverter<VisibilityLevel, byte>() }
            };

        public async Task Transactional(Func<Task> act)
        {
            IDbContextTransaction? transaction = null;
            try
            {
                transaction = await Database.BeginTransactionAsync();
                await act();
                await transaction.CommitAsync();
            }
            catch
            {
                if (transaction is not null)
                    await transaction.RollbackAsync();

                throw;
            }
        }

        public async Task<TResult> Transactional<TResult>(Func<Task<TResult>> act)
        {
            IDbContextTransaction? transaction = null;
            try
            {
                transaction = await Database.BeginTransactionAsync();
                var result = await act();
                await transaction.CommitAsync();
                return result;
            }
            catch
            {
                if (transaction is not null)
                    await transaction.RollbackAsync();

                throw;
            }
        }
    }
}
