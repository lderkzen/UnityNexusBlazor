using System.ComponentModel;
using System.Text.Json.Serialization;

namespace UnityNexus.Shared.Entities
{
    public class DiscordUser : KeyedEntity
    {
        private string? _avatarUrl;
        private IReadOnlyList<string> _roles;

        public required string DiscordUserId { get; set; }

        public required string Username { get; set; }

        public required string DisplayName { get; set; }

        public string? AvatarHash { get; set; }

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

                if (AvatarHash is not null)
                    return (_avatarUrl = $"https://cdn.discordapp.com/avatars/{DiscordUserId}/{AvatarHash}.png");

                var defaultAvatarId = (ulong.TryParse(DiscordUserId!, out var parsedDiscordUserId)
                                           ? parsedDiscordUserId >> 22
                                           : 0)
                                    % 5;
                return _avatarUrl = $"https://cdn.discordapp.com/embed/avatars/{defaultAvatarId}.png";
            }
        }

        [DefaultValue((byte)NotificationFlag.Unconfigured)]
        public required NotificationFlag NotificationFlagSum { get; set; }

        /// <summary>
        /// Gets or sets the roles the user has.
        /// </summary>
        /// <exception cref="ArgumentNullException">The property gets set to <b>null</b>.</exception>
        public IReadOnlyList<string> Roles
        {
            get => _roles;
            set => _roles = value ?? throw new ArgumentNullException(nameof(value), $"{nameof(Roles)} cannot be set to null.");
        }

        public DiscordUser()
        {
            _roles = [];
        }
    }
}
