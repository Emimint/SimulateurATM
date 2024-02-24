using SimulateurATM.Controllers;
using System.Collections.Generic;
using System.ComponentModel;

namespace SimulateurATM.Views
{
    public partial class AccountPage: ContentPage
    {
        public List<Client> ListeClients { get; set; }
        public string Titre { get; set; }

        public AccountPage()
        {
            InitializeComponent();
        }

        public AccountPage(List<Client> clients)
        {
            InitializeComponent();
            ListeClients = clients;
            Titre = "Liste des clients";
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            listeDesElements.ItemsSource = ListeClients;
        }
    }
}
