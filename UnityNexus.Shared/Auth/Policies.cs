namespace UnityNexus.Shared.Auth
{
    public static class Policies
    {
        public static IEnumerable<string> GetAllPolicyNames()
        {
            return (from method in typeof(Policies).GetMethods(BindingFlags.Public | BindingFlags.Static)
                    // The method should configure the policy builder, not return a built policy.
                    where method.ReturnType == typeof(void)
                    let methodParameter = method.GetParameters()
                    // The method has to accept the AuthorizationPolicyBuilder, and no other parameter.
                    where methodParameter.Length == 1 && methodParameter[0].ParameterType == typeof(AuthorizationPolicyBuilder)
                    select method.Name);
        }

        internal static void PolicyConfigurationFailedFallback(AuthorizationPolicyBuilder builder) =>
            builder.RequireAssertion(_ => false);

        public static void AllowAnonymousAccess(AuthorizationPolicyBuilder builder) =>
            builder.RequireAssertion(_ => true);

        public static void MustBeAllowedCreateOrEditGroups(AuthorizationPolicyBuilder builder) =>
            builder.RequireAuthenticatedUser()
                .RequireRole(RoleNames.CreateOrEditGroups);
    }
}
