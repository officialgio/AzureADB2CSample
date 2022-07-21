using AuthenticationSimpleSample.Auth;
using AuthenticationSimpleSample.Model;
using AuthenticationSimpleSample.View;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;

namespace AuthenticationSimpleSample;

public partial class MainPage : ContentPage
{
    AuthService authService;
    User user;
	public MainPage()
	{
		InitializeComponent();
        authService = new AuthService();
        user = new User();
	}

    protected override async void OnAppearing()
    {
        try
        {
            var accounts = await AuthService.authenticationClient.GetAccountsAsync();
            AuthenticationResult result;

            if (accounts.Count() >= 1)
            {
                result = await AuthService.authenticationClient
                   .AcquireTokenSilent(Constants.Scopes, accounts.FirstOrDefault())
                   .ExecuteAsync();

                await SecureStorage.SetAsync("Token", result?.IdToken); // store token securely for later use
                authService.GetUserClaims(result, user);
                await Shell.Current.GoToAsync($"{nameof(HomeScreen)}",
                new Dictionary<string, object>
                {
                    [nameof(User)] = user
                });
                await DisplayAlert($"Welcome back {user.Name}", "Received refresh token successfully", "Ok");
            }
        }
        catch
        {
            // Do nothing - the user isn't logged in
        }
    }

    // Get the result of AuthService and read the token. 
    // If there's data then that means authentication was successful
    // Get claims by reading the token
    // Afterwards, redirect client to Settings page
    async void AzureADPageClicked(object sender, EventArgs e)
    {
        var result = await authService.LoginAsync(CancellationToken.None);
        var token = result?.IdToken;
        if (token is not null)
        {
            var handler = new JwtSecurityTokenHandler();
            var data = handler.ReadJwtToken(token);
            var claims = data.Claims.ToList();
            await SecureStorage.SetAsync("token", token); // store token securely for later use v
            if (data is not null)
            {
                user.Name = data.Claims.FirstOrDefault(x => x.Type.Equals("name"))?.Value;
                user.Email = data.Claims.FirstOrDefault(x => x.Type.Equals("preferred_username"))?.Value;
                await DisplayAlert("Welcome", "Successfully Logged In!", "Ok");
                await Shell.Current.GoToAsync($"{nameof(HomeScreen)}",
                new Dictionary<string, object>
                {
                    [nameof(User)] = user
                });
            }
        }
    }
}
