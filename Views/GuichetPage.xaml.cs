using Microsoft.Maui.Controls;
using SimulateurATM.Controllers;
using System.Windows.Input;


namespace SimulateurATM.Views
{
    public partial class GuichetPage : ContentPage
    {
        static List<Client> clients;
        static List<Compte> comptes;

        public string nom { get; set; }
        public ICommand AddCharCommand { get; private set; }

        public ICommand DeleteCharCommand { get; private set; }

        public GuichetPage() {
            InitializeComponent();
            Init();
        }
    

        public GuichetPage(string nom, string prenom)
        {
            InitializeComponent();
            Init();
            this.nom = nom;
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

        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmation", "Voulez vous quitter votre session?", "Oui", "Non"))
            {
                Environment.Exit(0);
            }
        }

        public static void Init()
        {
            clients = new List<Client>();
            comptes = new List<Compte>();

            // Création des clients et de leurs comptes :
            // Creating and adding clients
            Client client1 = new Client("Alex", "Paul", "Apaul", "1234");
            clients.Add(client1);

            Cheque compteCheque1 = new Cheque("1234", "C1", 1000);
            comptes.Add(compteCheque1);

            Epargne compteEpargne1 = new Epargne("1234", "E1", 5000, 0.05f);
            comptes.Add(compteEpargne1);

            Client client2 = new Client("John", "Doe", "Jdoe", "5678");
            clients.Add(client2);

            Cheque compteCheque2 = new Cheque("5678", "C2", 2000);
            comptes.Add(compteCheque2);

            Epargne compteEpargne2 = new Epargne("5678", "E2", 8000, 0.03f);
            comptes.Add(compteEpargne2);

            Client client3 = new Client("Alice", "Smith", "Asmith", "9012");
            clients.Add(client3);

            Cheque compteCheque3 = new Cheque("9012", "C3", 1500);
            comptes.Add(compteCheque3);

            Epargne compteEpargne3 = new Epargne("9012", "E3", 7000, 0.02f);
            comptes.Add(compteEpargne3);

            Client client4 = new Client("Emily", "Johnson", "Ejohnson", "3456");
            clients.Add(client4);

            Cheque compteCheque4 = new Cheque("3456", "C4", 3000);
            comptes.Add(compteCheque4);

            Epargne compteEpargne4 = new Epargne("3456", "E4", 6000, 0.04f);
            comptes.Add(compteEpargne4);

            Client client5 = new Client("Michael", "Williams", "Mwilliams", "7890");
            clients.Add(client5);

            Cheque compteCheque5 = new Cheque("7890", "C5", 2500);
            comptes.Add(compteCheque5);

            Epargne compteEpargne5 = new Epargne("7890", "E5", 9000, 0.025f);
            comptes.Add(compteEpargne5);

        }
    }


}
