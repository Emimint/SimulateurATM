using SimulateurATM.Controllers;

namespace SimulateurATM.Views;

public partial class LoginPage : ContentPage
{
    int nbrTentatives = 2;
    public LoginPage()
    {
        InitializeComponent();
        GuichetPage.Init();
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        //faire la recherche du client dans la liste des clients avec le nip
        // vous sortez son nom et prenom et vous les envoyer en parametre dans le constructeur
        // await Navigation.PushAsync(new GuichetPage("cylia", "oudiai"));
        // await Navigation.PushAsync(new GuichetPage());

        if (IsCredentialCorrect(Username.Text, Password.Text))
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


    bool IsCredentialCorrect(string username, string password)
    {
/*        foreach (Client client in GuichetPage.clients)
        {
            if (client.Nip == username && client.Password == password)
                return Username.Text == "admin" && Password.Text == "1234";
        }*/
        return Username.Text == "admin" && Password.Text == "1234";
    }
}