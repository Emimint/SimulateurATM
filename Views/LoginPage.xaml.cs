namespace SimulateurATM.Views;

public partial class LoginPage : ContentPage
{
    int nbrTentatives = 2;
	public LoginPage()
	{
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        if (IsCredentialCorrect(Username.Text, Password.Text))
        {
            await SecureStorage.SetAsync("hasAuth", "true");
            await Shell.Current.GoToAsync("///guichet");
        }
        else
        {
            if(nbrTentatives >= 1)
                await DisplayAlert("Echec de la connexion", $"Le nom d'utilisateur ou mot de passe sont incorrects. Essayez à nouveau (encore {nbrTentatives} tentative{(nbrTentatives-- == 1 ? "" : "s")}).", "OK");
            else
            { 
                await DisplayAlert("Echec de la connexion", "Vous avez atteint le maximum de tentatives autorisees. Veuillez revenir plus tard.", "OK");
                LoginButton.IsEnabled = false;
            }
        }
    }


    bool IsCredentialCorrect(string username, string password)
    {
        return Username.Text == "admin" && Password.Text == "1234";
    }
}