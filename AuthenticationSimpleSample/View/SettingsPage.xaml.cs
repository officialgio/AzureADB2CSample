using AuthenticationSimpleSample.ViewModel;

namespace AuthenticationSimpleSample;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void Back(object sender, EventArgs e) => Shell.Current.GoToAsync("..");
}
