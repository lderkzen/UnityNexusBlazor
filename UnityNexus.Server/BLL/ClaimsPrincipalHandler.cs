namespace UnityNexus.Server.BLL
{
    public class ClaimsPrincipalHandler : IClaimsPrincipalHandler
    {
        public UserId? TryGetUserId(ClaimsPrincipal? principal)
        {
            if (!(principal?.Identity is ClaimsIdentity currentIdentity))
                return null;

            var claim = currentIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim is null)
                return null;

            if (!Guid.TryParse(claim.Value, out var userIdGuid))
                return null;

            return (UserId)userIdGuid;
        }
    }
}
