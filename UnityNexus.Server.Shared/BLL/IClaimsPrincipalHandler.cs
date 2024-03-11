namespace UnityNexus.Server.Shared.BLL
{
    public interface IClaimsPrincipalHandler
    {
        /// <summary>
        /// Tries to get the <see cref="UserId"/> from the given <paramref name="principal"/>.
        /// </summary>
        /// <param name="principal">The principal to parse the <see cref="UserId"/> from.</param>
        /// <returns>The found <see cref="UserId"/>, or <b>null</b> if none was found.</returns>
        public UserId? TryGetUserId(ClaimsPrincipal? principal);
    }
}
