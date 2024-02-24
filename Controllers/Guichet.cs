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

        public static List<Client>? clients;
        public static List<Cheque>? comptesCheque;
        public static List<Epargne>? comptesEpargne;

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

        public static Cheque getCheque(string nip)
        {
            foreach (Cheque compte in comptesCheque)
            {
                if (compte.getNumeroNIP() == nip)
                {
                    return compte;
                }
            }
            return null;
        }

        public static Epargne getEpargne(string nip)
        {
            foreach (Epargne compte in comptesEpargne)
            {
                if (compte.getNumeroNIP() == nip)
                {
                    return compte;
                }
            }
            return null;
        }


        public static float RetraitCheque(string nip, float montant)
        {
            foreach (Cheque compte in comptesCheque)
            {
                if (compte.getNumeroNIP() == nip)
                {
                    compte.Retrait(montant);
                    return compte.getSoldeCompte();
                }
            }
            return -1;
        }

        public static float RetraitEpargne(string nip, float montant)
        {
            foreach (Epargne compte in comptesEpargne)
            {
                if (compte.getNumeroNIP() == nip)
                {
                    compte.Retrait(montant);
                    return compte.getSoldeCompte();
                }
            }
            return -1;
        }

        public static float DepotCheque(string nip, float montant)
        {
            foreach (Cheque compte in comptesCheque)
            {
                if (compte.getNumeroNIP() == nip)
                {
                    compte.Depot(montant);
                    return compte.getSoldeCompte();
                }
            }
            return -1;
        }

        public static float DepotEpargne(string nip, float montant)
        {
            foreach (Epargne compte in comptesEpargne)
            {
                if (compte.getNumeroNIP() == nip)
                {
                    compte.Depot(montant);
                    return compte.getSoldeCompte();
                }
            }
            return -1;
        }

        public static void VirementCheque(string nip, float montant)
        {
            float soldeCheque = getCheque(nip).getSoldeCompte();
            float soldeEpargne = getEpargne(nip).getSoldeCompte();

            if (montant % 10 != 0)
            {
                throw new Exception("Montant invalide. Multiple de 10$ seulement.");
            }

            if (montant > 100000)
            {
                throw new Exception("Montant superieure a la limite de virement autorisee (100000$).");
            }

            if (montant > soldeCheque)
            {
                throw new Exception("Montant indisponible.");
            }

            getCheque(nip).setSoldeCompte(soldeCheque - montant);
            getEpargne(nip).setSoldeCompte(soldeEpargne + montant);
        }

        public static void VirementEpargne(string nip, float montant)
        {
            float soldeEpargne = getEpargne(nip).getSoldeCompte();
            float soldeCheque = getCheque(nip).getSoldeCompte();

            if (montant % 10 != 0)
            {
                throw new Exception("Montant invalide. Multiple de 10$ seulement.");
            }

            if (montant > 100000)
            {
                throw new Exception("Montant superieure a la limite de virement autorisee (100000$).");
            }

            if (montant > soldeEpargne)
            {
                throw new Exception("Montant indisponible.");
            }

            getEpargne(nip).setSoldeCompte(soldeEpargne - montant);
            getCheque(nip).setSoldeCompte(soldeCheque + montant);
        }
    }
}
