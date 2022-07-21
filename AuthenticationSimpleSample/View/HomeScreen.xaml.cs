using AuthenticationSimpleSample.ViewModel;

namespace AuthenticationSimpleSample.View;

public partial class HomeScreen : ContentPage
{
    public HomeScreen(HomeScreenViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        NameAnimation(nameHeader.Text);
    }



    public void NameAnimation(string name)
    {
        if (nameHeader.Text is not null)
        {
            new Animation {
                  { 0.2, 0.25, new Animation (x => nameHeader.TranslationX = x, 0, -40) },
                  { 0.250, 0.375, new Animation (x => nameHeader.TranslationX = x, 13, -11) },
                  { 0.12560, 0.2550, new Animation (x => nameHeader.TranslationX = x, -13, 13) }
            }.Commit(this, "Flow", length: 1000, easing: Easing.Linear, repeat: () => true);
        }
    }

    private async void SettingsBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SettingsPage));
    }
}
