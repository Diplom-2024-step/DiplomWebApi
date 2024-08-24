using Constants.Controller;
using Constants.Models.AppUsers;
using Constants.Shared;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Extensions;

public static class PolicyExtensions
{
    public static void AddPolicies(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()
            .AddPolicy(ControllerStringConstants.CanAccessEveryone, policy =>
                policy.RequireRole(UserStringConstants.AdminRole, UserStringConstants.UserRole))
            .AddPolicy(ControllerStringConstants.CanAccessUserAndAdmin, policy =>
                policy.RequireRole(UserStringConstants.AdminRole, UserStringConstants.UserRole)
                    )
            .AddPolicy(ControllerStringConstants.CanAccessOnlyAdmin, policy =>
                policy.RequireRole(UserStringConstants.AdminRole)
                    .NotInRole(UserStringConstants.UserRole));
    }

    public static AuthorizationPolicyBuilder NotInRole(this AuthorizationPolicyBuilder policy, params string[] roles)
    {
        return policy.RequireAssertion(context =>
        {
            var user = context.User;
            return !roles.Any(role => user.IsInRole(role));
        });
    }
}