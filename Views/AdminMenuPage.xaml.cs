using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using SimulateurATM.Controllers;

namespace SimulateurATM.Views;

public partial class AdminMenuPage : ContentPage
{
	public AdminMenuPage()
	{
		InitializeComponent();
	}
    async private void OnClickedPaiementInteret(object sender, EventArgs e)
    {
        Guichet.payerInterets();

        string message = "Paiement des interets effectues pour tous les clients.";
        ToastDuration duration = ToastDuration.Short;
        double fontSize = 14;
        var toast = Toast.Make(message, duration, fontSize);
        await toast.Show();
    }

    //    private async void OnClickedComptesCheques(object sender, EventArgs e)
    //    {
    //        await Navigation.PushAsync(new ListePage());
    //    }

    //    private async void OnClickedComptesEpargnes(object sender, EventArgs e)
    //    {
    //        await Navigation.PushAsync(new ListePage());
    //    }

    //    private async Task OnClickedListeClientsAsync(object sender, EventArgs e)
    //    {
    //        await Navigation.PushAsync(new ListePage());
    //    }
}