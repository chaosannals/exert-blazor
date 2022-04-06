using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace WebAssemblyDemo;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var principal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>()));
        return new AuthenticationState(principal);
    }
}
