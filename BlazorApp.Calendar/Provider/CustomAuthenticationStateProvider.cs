using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorApp.Calendar.Provider;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Здесь вы можете создать объект AuthenticationState соответствующий вашему требованию
        var identity = new ClaimsIdentity();
        var user = new ClaimsPrincipal(identity);

        return Task.FromResult(new AuthenticationState(user));
    }
    public async Task SetNonAuthenticatedState()
    {
        var authState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        await Task.Run(() => NotifyAuthenticationStateChanged(Task.FromResult(authState)));

        // Выполните другие действия, необходимые для сброса данных аутентификации, такие как удаление куки или удаление данных из хранилища
    }
}