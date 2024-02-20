using Microsoft.Maui.Controls;
using SimulateurATM.Controllers;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui;
using System.Threading;
using CommunityToolkit.Maui.Core;


namespace SimulateurATM.Views
{
    public partial class GuichetPage : ContentPage
    {
        static List<Client> clients;
        static List<Cheque> comptesCheque;
        static List<Epargne> comptesEpargne;

        Client currentClient;
        public string Prenom { get; private set; }
        public ICommand AddCharCommand { get; private set; }

        public ICommand DeleteCharCommand { get; private set; }

        public GuichetPage() {
            InitializeComponent();
            Init();
        }
    

        public GuichetPage(string username, string nip)
        {
            InitializeComponent();
            Init();
            currentClient = Guichet.getClient(username, nip);
            Prenom = currentClient.getPrenom();
            AddCharCommand = new Command<string>(ExecuteAddCharCommand);
            DeleteCharCommand = new Command(ExecuteDeleteCharCommand);
            BindingContext = this;
        }

        private void ExecuteAddCharCommand(string param)
        {
            textInput.Text += param;
        }

        private void ExecuteDeleteCharCommand()
        {
            textInput.Text = string.Empty;
        }

        public static void Init()
        {
            // Création des clients et de leurs comptes :
            clients = new List<Client>();
            comptesCheque = new List<Cheque>();
            comptesEpargne = new List<Epargne>();

            Client client1 = new Client("Naim", "Himrane", "Nhimrane", "1234");
            clients.Add(client1);

            Cheque compteCheque1 = new Cheque("1234", "C1", 1000);
            comptesCheque.Add(compteCheque1);

            Epargne compteEpargne1 = new Epargne("1234", "E1", 5000);
            comptesEpargne.Add(compteEpargne1);

            Client client2 = new Client("John", "Doe", "Jdoe", "5678");
            clients.Add(client2);

            Cheque compteCheque2 = new Cheque("5678", "C2", 2000);
            comptesCheque.Add(compteCheque2);

            Epargne compteEpargne2 = new Epargne("5678", "E2", 8000);
            comptesEpargne.Add(compteEpargne2);

            Client client3 = new Client("Alice", "Smith", "Asmith", "9012");
            clients.Add(client3);

            Cheque compteCheque3 = new Cheque("9012", "C3", 1500);
            comptesCheque.Add(compteCheque3);

            Epargne compteEpargne3 = new Epargne("9012", "E3", 7000);
            comptesEpargne.Add(compteEpargne3);

            Client client4 = new Client("Emily", "Johnson", "Ejohnson", "3456");
            clients.Add(client4);

            Cheque compteCheque4 = new Cheque("3456", "C4", 3000);
            comptesCheque.Add(compteCheque4);

            Epargne compteEpargne4 = new Epargne("3456", "E4", 6000);
            comptesEpargne.Add(compteEpargne4);

            Client client5 = new Client("Michael", "Williams", "Mwilliams", "7890");
            clients.Add(client5);

            Cheque compteCheque5 = new Cheque("7890", "C5", 2500);
            comptesCheque.Add(compteCheque5);

            Epargne compteEpargne5 = new Epargne("7890", "E5", 9000);
            comptesEpargne.Add(compteEpargne5);

            // remplissage des listes dans Guichet.cs :
            Guichet.clients = clients;
            Guichet.comptesCheque = comptesCheque;
            Guichet.comptesEpargne = comptesEpargne;
        }

        public static readonly BindableProperty ClientsProperty =
            BindableProperty.Create(nameof(Clients), typeof(List<Client>), typeof(GuichetPage), new List<Client>());

        public List<Client> Clients
        {
            get { return (List<Client>)GetValue(ClientsProperty); }
            set { SetValue(ClientsProperty, value); }
        }

        public static readonly BindableProperty ComptesChequeProperty =
            BindableProperty.Create(nameof(ComptesCheque), typeof(List<Cheque>), typeof(GuichetPage), new List<Cheque>());

        public List<Cheque> ComptesCheque
        {
            get { return (List<Cheque>)GetValue(ComptesChequeProperty); }
            set { SetValue(ComptesChequeProperty, value); }
        }

        public static readonly BindableProperty ComptesEpargneProperty =
            BindableProperty.Create(nameof(ComptesEpargne), typeof(List<Epargne>), typeof(GuichetPage), new List<Epargne>());

        public List<Epargne> ComptesEpargne
        {
            get { return (List<Epargne>)GetValue(ComptesEpargneProperty); }
            set { SetValue(ComptesEpargneProperty, value); }
        }

        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmation", "Voulez vous quitter votre session?", "Oui", "Non"))
            {
                await Navigation.PushAsync(new LoginPage());
            }
        }

        async private void EtatComptes_Clicked(object sender, EventArgs e)
        {
            foreach (var x in comptesCheque)
            {
                string message = $"Solde du compte chèque {x.NumeroCompte}: {x.SoldeCompte}$";

                ToastDuration duration = ToastDuration.Short;
                double fontSize = 14;

                var toast = Toast.Make(message, duration, fontSize);

                await toast.Show();
            }

           //  Console.WriteLine($"currentClient.getNumeroNIP(): {currentClient.getNumeroNIP()}");

           // Cheque currentCheque = comptesCheque.FirstOrDefault(x => x.NumeroNIP == currentClient.getNumeroNIP());


/*            string message = $"Solde du compte chèque : {currentCheque.SoldeCompte}";

            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(message, duration, fontSize);

            await toast.Show();*/


        }
    }
}
