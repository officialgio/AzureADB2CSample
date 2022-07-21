using AuthenticationSimpleSample.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AuthenticationSimpleSample.ViewModel;

[QueryProperty(nameof(User), nameof(User))]
public partial class HomeScreenViewModel : ObservableObject
{
    public HomeScreenViewModel() { }

    [ObservableProperty]
    User user;

    [ICommand]
    void Navigate() =>
        Shell.Current.GoToAsync($"{nameof(SettingsPage)}",
            new Dictionary<string, object>
            {
                [nameof(User)] = user
            });
}
