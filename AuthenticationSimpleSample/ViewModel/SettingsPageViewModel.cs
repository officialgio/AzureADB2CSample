using AuthenticationSimpleSample.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace AuthenticationSimpleSample.ViewModel;

[QueryProperty(nameof(User), nameof(User))]
public partial class SettingsPageViewModel : ObservableObject
{
    public SettingsPageViewModel() { }

    [ObservableProperty]
    User user;
}
