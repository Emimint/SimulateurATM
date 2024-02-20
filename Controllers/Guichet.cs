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

        static List<Client> clients;
        static List<Compte> comptesCheque;
        static List<Epargne> comptesEpargne;

        public static bool ValiderUtilisateur(string username, string nip)
        {
            foreach (Client client in clients)
            {
                return client.getUsername()== username && client.getNumeroNIP() == nip;
            }
            return false;
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

        /*        Lors d’un virement, l’utilisateur doit saisir le montant et le type de virement(du compte chèque vers le compte épargne, ou vice-versa). Le montant maximum pour cette transaction est de $100,000. Le système doit permettre seulement les virements du compte chèque vers le compte épargne ou du compte épargne vers le compte chèque.*/

    }
}
