using System.Security.Claims;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

namespace UnityNexus.Client.BLL;

public class KeycloakUserFactory : AccountClaimsPrincipalFactory<RemoteUserAccount>
{
    public KeycloakUserFactory(IAccessTokenProviderAccessor accessor) : base(accessor)
    {
    }

    private static void MapArrayClaimsToMultipleSeparateClaims(
        RemoteUserAccount account,
        ClaimsIdentity claimsIdentity
    )
    {
        foreach (var (key, value) in account.AdditionalProperties)
        {
            if (value is not JsonElement { ValueKind: JsonValueKind.Array } element)
                continue;

            claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(key));
            var claims = element.EnumerateArray()
                                .Select(m => new Claim(key, m.ToString()));
            claimsIdentity.AddClaims(claims);
        }
    }

    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
        RemoteUserAccount account,
        RemoteAuthenticationUserOptions options
    )
    {
        var user = await base.CreateUserAsync(account!, options);
        if (account is null)
            return user;

        if (user.Identity is not ClaimsIdentity claimsIdentity)
            return user;

        MapArrayClaimsToMultipleSeparateClaims(account, claimsIdentity);

        return user;
    }
}
