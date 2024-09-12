using AnytourApi.Constants.Controller;
using AnytourApi.Constants.Models.AppUsers;
using AnytourApi.Constants.Shared;
using Microsoft.AspNetCore.Authorization;

namespace AnytourApi.WebApi.Extensions;

public static class PolicyExtensions
{
    public static void AddPolicies(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()
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