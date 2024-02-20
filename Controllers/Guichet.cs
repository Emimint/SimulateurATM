using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurATM.Controllers
{
    public class Guichet
    {
        public Guichet() { Init(); }
        public static ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
        public static ObservableCollection<Cheque> ComptesCheque { get; set; } = new ObservableCollection<Cheque>();
        public static ObservableCollection<Epargne> ComptesEpargne { get; set; } = new ObservableCollection<Epargne>();

        public static void Init()
        {

            Client client1 = new Client("Naim", "Himrane", "Nhimrane", "1234");
            Clients.Add(client1);

            Cheque compteCheque1 = new Cheque("1234", "C1", 1000);
            ComptesCheque.Add(compteCheque1);

            Epargne compteEpargne1 = new Epargne("1234", "E1", 5000);
            ComptesEpargne.Add(compteEpargne1);

            Client client2 = new Client("John", "Doe", "Jdoe", "5678");
            Clients.Add(client2);

            Cheque compteCheque2 = new Cheque("5678", "C2", 2000);
            ComptesCheque.Add(compteCheque2);

            Epargne compteEpargne2 = new Epargne("5678", "E2", 8000);
            ComptesEpargne.Add(compteEpargne2);

            Client client3 = new Client("Alice", "Smith", "Asmith", "9012");
            Clients.Add(client3);

            Cheque compteCheque3 = new Cheque("9012", "C3", 1500);
            ComptesCheque.Add(compteCheque3);

            Epargne compteEpargne3 = new Epargne("9012", "E3", 7000);
            ComptesEpargne.Add(compteEpargne3);

            Client client4 = new Client("Emily", "Johnson", "Ejohnson", "3456");
            Clients.Add(client4);

            Cheque compteCheque4 = new Cheque("3456", "C4", 3000);
            ComptesCheque.Add(compteCheque4);

            Epargne compteEpargne4 = new Epargne("3456", "E4", 6000);
            ComptesEpargne.Add(compteEpargne4);

            Client client5 = new Client("Michael", "Williams", "Mwilliams", "7890");
            Clients.Add(client5);

            Cheque compteCheque5 = new Cheque("7890", "C5", 2500);
            ComptesCheque.Add(compteCheque5);

            Epargne compteEpargne5 = new Epargne("7890", "E5", 9000);
            ComptesEpargne.Add(compteEpargne5);

            Guichet.Clients = Clients;
            Guichet.ComptesCheque = ComptesCheque;
            Guichet.ComptesEpargne = ComptesEpargne;
        }

        public static bool ValiderUtilisateur(string username, string nip)
        {
            foreach (Client client in Clients)
            {
                if (client.Username == username && client.NumeroNIP == nip)
                {
                    return true;
                }
            }
            return false;
        }

        public static Client getClient(string username, string nip)
        {
            foreach (Client client in Clients)
            {
                if (client.NumeroNIP == username && client.NumeroNIP == nip)
                {
                    return client;
                }
            }
            return null;
        }


        public static float RetraitCheque(string nip, float montant)
        {
            foreach (Cheque compte in ComptesCheque)
            {
                if (compte.NumeroNIP == nip)
                {
                    compte.Retrait(montant);
                    return compte.SoldeCompte;
                }
            }
            return -1;
        }

        public static float RetraitEpargne(string nip, float montant)
        {
            foreach (Epargne compte in ComptesEpargne)
            {
                if (compte.NumeroNIP == nip)
                {
                    compte.Retrait(montant);
                    return compte.SoldeCompte;
                }
            }
            return -1;
        }

        public static float DepotCheque(string nip, float montant)
        {
            foreach (Cheque compte in ComptesCheque)
            {
                if (compte.NumeroNIP == nip)
                {
                    compte.Depot(montant);
                    return compte.SoldeCompte;
                }
            }
            return -1;
        }

        public static float DepotEpargne(string nip, float montant)
        {
            foreach (Epargne compte in ComptesEpargne)
            {
                if (compte.NumeroNIP == nip)
                {
                    compte.Depot(montant);
                    return compte.SoldeCompte;
                }
            }
            return -1;
        }
    }
}
