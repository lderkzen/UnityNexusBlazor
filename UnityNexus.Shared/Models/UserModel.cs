namespace UnityNexus.Shared.Models
{
    public class UserModel
    {
        private string _username;
        private string? _avatarUrl;
        private IReadOnlyList<string> _roles;

        public UserId Id { get; set; }

        /// <summary>
        /// Gets or sets the user's Discord username, not unique across the platform.
        /// </summary>
        /// <exception cref="ArgumentNullException">The property gets set to <b>null</b>.</exception>
        [MaxLength(32)]
        public string Username
        {
            get => _username;
            set => _username = value ?? throw new ArgumentNullException(nameof(value), $"{nameof(Username)} cannot be set to null.");
        }

        /// <summary>
        /// Gets or sets the user's Discord nickname on the guild's server.
        /// </summary>
        [MaxLength(32)]
        public string? Nickname { get; set; }

        /// <summary>
        /// Gets or sets the user#s Discord ID.
        /// </summary>
        public string? DiscordUserId { get; set; }

        /// <summary>
        /// Gets or sets the user's Discord avatar hash.
        /// </summary>
        [MaxLength(32)]
        public string? AvatarId { get; set; }

        /// <summary>
        /// Gets the formatted display name for the user.
        /// </summary>
        [JsonIgnore]
        public string DisplayName => Nickname ?? Username;

        /// <summary>
        /// Gets the URL from where the avatar can be fetched.
        /// </summary>
        [JsonIgnore]
        public string AvatarUrl
        {
            get
            {
                if (_avatarUrl is not null)
                    return _avatarUrl;

                if (DiscordUserId is not null && AvatarId is not null)
                    return (_avatarUrl = $"https://cdn.discordapp.com/avatars/{DiscordUserId}/{AvatarId}.png");

                var defaultAvatarId = (ulong.TryParse(DiscordUserId!, out var parsedDiscordUserId)
                                           ? parsedDiscordUserId >> 22
                                           : 0)
                                    % 5;
                return _avatarUrl = $"https://cdn.discordapp.com/embed/avatars/{defaultAvatarId}.png";
            }
        }

        /// <summary>
        /// Gets or sets the roles the user has.
        /// </summary>
        /// <exception cref="ArgumentNullException">The property gets set to <b>null</b>.</exception>
        public IReadOnlyList<string> Roles
        {
            get => _roles;
            set => _roles = value ?? throw new ArgumentNullException(nameof(value), $"{nameof(Roles)} cannot be set to null.");
        }

        /// <summary>
        /// Gets or sets the users power level based on their highest permissions role.
        /// </summary>
        public byte PowerLevel { get; set; }

        /// <summary>
        /// Initializes a new <see cref="UserModel"/> instance, setting <see cref="Username"/> to <see cref="string.Empty"/>.
        /// </summary>
        public UserModel()
        {
            Id = UserId.From(Guid.Empty);
            _username = string.Empty;
            _roles = [];
        }
    }
}
