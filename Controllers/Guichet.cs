using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurATM.Controllers
{
    public class Guichet
    {

        public static List<Client> clients;
        public static List<Cheque> comptesCheque;
        public static List<Epargne> comptesEpargne;

        public static bool ValiderUtilisateur(string username, string nip)
        {
            foreach (Client client in clients)
            {
                if (client.getUsername() == username && client.getNumeroNIP() == nip)
                {
                    return true;
                }
            }
            return false;
        }

        public static Client getClient(string username, string nip)
        {
            foreach (Client client in clients)
            {
                if (client.getUsername() == username && client.getNumeroNIP() == nip)
                {
                    return client;
                }
            }
            return null;
        }


        public static float RetraitCheque(string nip, float montant)
        {
            foreach (Cheque compte in comptesCheque)
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
            foreach (Epargne compte in comptesEpargne)
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
            foreach (Cheque compte in comptesCheque)
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
            foreach (Epargne compte in comptesEpargne)
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
