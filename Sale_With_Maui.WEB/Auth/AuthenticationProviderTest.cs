using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Sale_With_Maui.WEB.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimous = new ClaimsIdentity();
            var ralphUser = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName", "Ranflin"),
                new Claim("LastName", "Diaz"),
                new Claim(ClaimTypes.Name, "ranflin@yopmail.com"),
                new Claim(ClaimTypes.Role, "Admin")
            },
            authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonimous)));

        }
    }
}
