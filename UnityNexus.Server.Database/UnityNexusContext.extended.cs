namespace UnityNexus.Server.Database
{
    public partial class UnityNexusContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            IReadOnlyDictionary<Type, ValueConverter> converters = GetConverter();

            ConvertModelProperties(modelBuilder, converters);

            SpecifyAllDateTimeValuesAsUTC(modelBuilder);
            SeedLookupTableData(modelBuilder);
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
                { typeof(NotifiableType), new EnumToNumberConverter<NotifiableType, byte>() },
                { typeof(NotificationFlag), new EnumToNumberConverter<NotificationFlag, short>() },
                { typeof(ChannelType), new EnumToNumberConverter<ChannelType, byte>() },
                { typeof(UnityNexus.Shared.Enums.AnswerType), new EnumToNumberConverter<UnityNexus.Shared.Enums.AnswerType, byte>() },
                { typeof(UnityNexus.Shared.Enums.CategoryType), new EnumToNumberConverter<UnityNexus.Shared.Enums.CategoryType, byte>() },
                { typeof(UnityNexus.Shared.Enums.GroupType), new EnumToNumberConverter<UnityNexus.Shared.Enums.GroupType, byte>() },
                { typeof(UnityNexus.Shared.Enums.SubmissionStatus), new EnumToNumberConverter<UnityNexus.Shared.Enums.SubmissionStatus, byte>() },
                { typeof(UnityNexus.Shared.Enums.VisibilityLevel), new EnumToNumberConverter<UnityNexus.Shared.Enums.VisibilityLevel, byte>() }
            };

        private static void ConvertModelProperties(
            ModelBuilder modelBuilder,
            IReadOnlyDictionary<Type, ValueConverter> converters
        )
        {
            modelBuilder.Entity<Answer>(builder =>
            {
                builder.Property(m => m.AnswerId)
                    .HasConversion(converters[typeof(AnswerId)])
                    .ValueGeneratedOnAdd();
                builder.Property(m => m.PreviousAnswerId)
                    .HasConversion(converters[typeof(AnswerId)]);
                builder.Property(m => m.QuestionId)
                    .HasConversion(converters[typeof(QuestionId)]);
                builder.Property(m => m.SubmissionId)
                    .HasConversion(converters[typeof(SubmissionId)]);
            });
            modelBuilder.Entity<Shared.Models.AnswerType>(builder =>
            {
                builder.Property(m => m.AnswerTypeId)
                    .HasConversion(converters[typeof(UnityNexus.Shared.Enums.AnswerType)]);
            });
            modelBuilder.Entity<Category>(builder =>
            {
                builder.Property(m => m.CategoryId)
                    .HasConversion(converters[typeof(CategoryId)])
                    .ValueGeneratedOnAdd();
                builder.Property(m => m.CategoryTypeId)
                    .HasConversion(converters[typeof(UnityNexus.Shared.Enums.CategoryType)]);
            });
            modelBuilder.Entity<Shared.Models.CategoryType>(builder =>
            {
                builder.Property(m => m.CategoryTypeId)
                    .HasConversion(converters[typeof(UnityNexus.Shared.Enums.CategoryType)]);
            });
            modelBuilder.Entity<Form>(builder =>
            {
                builder.Property(m => m.FormId)
                    .HasConversion(converters[typeof(FormId)])
                    .ValueGeneratedOnAdd();
                builder.Property(m => m.GroupId)
                    .HasConversion(converters[typeof(GroupId)]);
            });
            modelBuilder.Entity<Group>(builder =>
            {
                builder.Property(m => m.GroupId)
                    .HasConversion(converters[typeof(GroupId)])
                    .ValueGeneratedOnAdd();
                builder.Property(m => m.GroupTypeId)
                    .HasConversion(converters[typeof(UnityNexus.Shared.Enums.GroupType)]);
                builder.Property(m => m.CategoryId)
                    .HasConversion(converters[typeof(CategoryId)]);
                builder.Property(m => m.OwnerId)
                    .HasConversion(converters[typeof(UserId)]);
                builder.Property(m => m.ChannelId)
                    .HasConversion(converters[typeof(ChannelId)]);

                builder.HasMany(m => m.Tags)
                    .WithMany(m => m.Groups)
                    .UsingEntity(
                        "group_tag",
                        l => l.HasOne(typeof(Tag)).WithMany().HasForeignKey("tag_id").HasPrincipalKey(nameof(Tag.TagId)),
                        r => r.HasOne(typeof(Group)).WithMany().HasForeignKey("group_id").HasPrincipalKey(nameof(Group.GroupId)),
                        j => j.HasKey("group_id", "tag_id")
                    );
            });
            modelBuilder.Entity<Shared.Models.GroupType>(builder =>
            {
                builder.Property(m => m.GroupTypeId)
                    .HasConversion(converters[typeof(UnityNexus.Shared.Enums.GroupType)]);
            });
            modelBuilder.Entity<Question>(builder =>
            {
                builder.Property(m => m.QuestionId)
                    .HasConversion(converters[typeof(QuestionId)])
                    .ValueGeneratedOnAdd();
                builder.Property(m => m.FormId)
                    .HasConversion(converters[typeof(FormId)]);
                builder.Property(m => m.AnswerTypeId)
                    .HasConversion(converters[typeof(UnityNexus.Shared.Enums.AnswerType)]);
            });
            modelBuilder.Entity<Submission>(builder =>
            {
                builder.Property(m => m.SubmissionId)
                    .HasConversion(converters[typeof(SubmissionId)])
                    .ValueGeneratedOnAdd();
                builder.Property(m => m.FormId)
                    .HasConversion(converters[typeof(FormId)]);
                builder.Property(m => m.ApplicantId)
                    .HasConversion(converters[typeof(UserId)]);
                builder.Property(m => m.SubmissionStatusId)
                    .HasConversion(converters[typeof(UnityNexus.Shared.Enums.SubmissionStatus)]);
                builder.Property(m => m.VisibilityLevelId)
                    .HasConversion(converters[typeof(UnityNexus.Shared.Enums.VisibilityLevel)]);
            });
            modelBuilder.Entity<Shared.Models.SubmissionStatus>(builder =>
            {
                builder.Property(m => m.SubmissionStatusId)
                    .HasConversion(converters[typeof(UnityNexus.Shared.Enums.SubmissionStatus)]);
            });
            modelBuilder.Entity<Tag>(builder =>
            {
                builder.Property(m => m.TagId)
                    .HasConversion(converters[typeof(TagId)])
                    .ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<UserNotificationSettings>(builder =>
            {
                builder.Property(m => m.UserId)
                    .HasConversion(converters[typeof(UserId)]);
            });
            modelBuilder.Entity<Shared.Models.VisibilityLevel>(builder =>
            {
                builder.Property(m => m.VisibilityLevelId)
                    .HasConversion(converters[typeof(UnityNexus.Shared.Enums.VisibilityLevel)]);
            });
        }

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

        public void SeedLookupTableData(ModelBuilder modelBuilder)
        {
            short lastPosition = 0;
            modelBuilder
                .Entity<Shared.Models.AnswerType>().HasData(
                    Enum.GetValues(typeof(UnityNexus.Shared.Enums.AnswerType))
                        .Cast<UnityNexus.Shared.Enums.AnswerType>()
                        .Select(e => new Shared.Models.AnswerType
                        {
                            AnswerTypeId = e,
                            Name = e.ToString(),
                            Position = lastPosition++
                        })
                );

            lastPosition = 0;
            modelBuilder
                .Entity<Shared.Models.CategoryType>().HasData(
                    Enum.GetValues(typeof(UnityNexus.Shared.Enums.CategoryType))
                        .Cast<UnityNexus.Shared.Enums.CategoryType>()
                        .Select(e => new Shared.Models.CategoryType
                        {
                            CategoryTypeId = e,
                            Name = e.ToString(),
                            Position = lastPosition++
                        })
                );

            lastPosition = 0;
            modelBuilder
                .Entity<Shared.Models.GroupType>().HasData(
                    Enum.GetValues(typeof(UnityNexus.Shared.Enums.GroupType))
                        .Cast<UnityNexus.Shared.Enums.GroupType>()
                        .Select(e => new Shared.Models.GroupType
                        {
                            GroupTypeId = e,
                            Name = e.ToString(),
                            Position = lastPosition++
                        })
                );

            lastPosition = 0;
            modelBuilder
                .Entity<Shared.Models.SubmissionStatus>().HasData(
                    Enum.GetValues(typeof(UnityNexus.Shared.Enums.SubmissionStatus))
                        .Cast<UnityNexus.Shared.Enums.SubmissionStatus>()
                        .Select(e => new Shared.Models.SubmissionStatus
                        {
                            SubmissionStatusId = e,
                            Name = e.ToString(),
                            Position = lastPosition++
                        })
                );

            lastPosition = 0;
            modelBuilder
                .Entity<Shared.Models.VisibilityLevel>().HasData(
                    Enum.GetValues(typeof(UnityNexus.Shared.Enums.VisibilityLevel))
                        .Cast<UnityNexus.Shared.Enums.VisibilityLevel>()
                        .Select(e => new Shared.Models.VisibilityLevel
                        {
                            VisibilityLevelId = e,
                            Name = e.ToString(),
                            Position = lastPosition++
                        })
                );
        }
    }
}
