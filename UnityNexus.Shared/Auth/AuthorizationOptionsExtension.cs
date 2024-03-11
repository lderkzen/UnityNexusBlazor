namespace UnityNexus.Shared.Auth
{
    public static class AuthorizationOptionsExtension
    {
        public static void AddSharedPolicies(
            this AuthorizationOptions options,
            Type policyProviderType
        )
        {
            Console.WriteLine($"{nameof(AuthorizationPolicy)} Configuration started ...");
            var policies = FindPolicies(policyProviderType);
            options.TryToAddPolicies(policies);
            Console.WriteLine($"{nameof(AuthorizationPolicy)} Configuration completed.");
        }

        private static IEnumerable<PolicyInformation> FindPolicies(Type policyProviderType)
        {
            return from method in policyProviderType.GetMethods(BindingFlags.Public | BindingFlags.Static)
                   // The method should configure the policy builder, not return a built policy.
                   where method.ReturnType == typeof(void)
                   let methodParameter = method.GetParameters()
                   // The method has to accept the AuthorizationPolicyBuilder, and no other parameter.
                   where methodParameter.Length == 1 && methodParameter[0].ParameterType == typeof(AuthorizationPolicyBuilder)
                   select new PolicyInformation(method.Name, method);
        }

        private static void TryToAddPolicies(
            this AuthorizationOptions options,
            IEnumerable<PolicyInformation> policies
        )
        {
            foreach (var policy in policies) {
                try {
                    options.AddPolicy(policy.Name, builder => { policy.Method.Invoke(null, [builder]); });
                    Console.WriteLine($"Policy \'{policy.Name}\' was configured successfully");
                } catch (Exception) {
                    options.AddPolicy(policy.Name, Policies.PolicyConfigurationFailedFallback);
                    Console.WriteLine($"Failed to configure policy \'{policy.Name}\'. Using fallback policy instead");
                }
            }
        }

        private class PolicyInformation
        {
            internal string Name { get; }

            internal MethodInfo Method { get; }

            internal PolicyInformation(
                string name,
                MethodInfo method
            )
            {
                Name = name;
                Method = method;
            }
        }
    }
}
