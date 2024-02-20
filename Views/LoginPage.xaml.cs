using SimulateurATM.Controllers;

namespace SimulateurATM.Views;

public partial class LoginPage : ContentPage
{
    int nbrTentatives = 2;
    public LoginPage()
    {
        InitializeComponent();
        Guichet.Init();
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        if (Guichet.ValiderUtilisateur(Username.Text, Password.Text))
        {
            await Navigation.PushAsync(new GuichetPage(Username.Text, Password.Text));
        }
        else
        {
            if (nbrTentatives >= 1)
                await DisplayAlert("Echec de la connexion", $"Le nom d'utilisateur ou mot de passe sont incorrects. Essayez à nouveau (encore {nbrTentatives} tentative{(nbrTentatives-- == 1 ? "" : "s")}).", "OK");
            else
            {
                await DisplayAlert("Echec de la connexion", "Vous avez atteint le maximum de tentatives autorisees. Veuillez revenir plus tard.", "OK");
                LoginButton.IsEnabled = false;
            }
        }
    }
}