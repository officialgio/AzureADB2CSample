using AuthenticationSimpleSample.View;

namespace AuthenticationSimpleSample;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(HomeScreen), typeof(HomeScreen));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        
    }
}
