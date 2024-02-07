namespace SimulateurATM.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private async void LogoutButton_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlert("Confirmation", "Voulez vous quitter votre session?", "Oui", "Non"))
        {
            SecureStorage.RemoveAll();
            await Shell.Current.GoToAsync("///login");
        }
    }
}