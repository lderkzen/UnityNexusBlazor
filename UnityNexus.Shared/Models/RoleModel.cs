namespace UnityNexus.Shared.Models
{
    public record Role(
        string Name,
        string? HexColorCode,
        byte? PowerLevel
    );

    public class RoleModel
    {
        private string _roleName;
        private string? _hexColorCode;

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <exception cref="ArgumentNullException">The property gets set to <b>null</b>.</exception>
        public string RoleName
        {
            get => _roleName;
            set => _roleName = value ?? throw new ArgumentNullException(nameof(value), $"{nameof(RoleName)} cannot be set to null.");
        }

        /// <summary>
        /// Gets or sets the optional color code for the role (hex).
        /// </summary>
        public string? HexColorCode
        {
            get => _hexColorCode;
            set
            {
                if (value is null)
                {
                    _hexColorCode = null;
                    return;
                }

                if (value.Length != 6)
                    throw new ArgumentException($"{nameof(HexColorCode)} must have the length of 6.");

                if (!Regex.IsMatch(value, "^[0-9A-F]{6}$", RegexOptions.Compiled | RegexOptions.IgnoreCase))
                    throw new ArgumentException($"{nameof(HexColorCode)} must be a valid hexadecimal color code.");

                _hexColorCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the power level associated with this role.
        /// </summary>
        public byte? PowerLevel { get; set; }

        public RoleModel()
        {
            _roleName = string.Empty;
        }
    }
}
