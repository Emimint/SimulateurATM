using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace SimulateurATM.Controllers
{
    public abstract class Compte
    {
        protected string numeroNIP;
        protected string numeroCompte;
        protected float soldeCompte;

        public Compte(string numeroNIP, string numeroCompte, float soldeCompte)
        {
            this.numeroNIP= numeroNIP;
            this.numeroCompte = numeroCompte;
            this.soldeCompte = soldeCompte;
        }

        public string getNumeroNIP() { return numeroNIP; }

        public string getNumeroCompte() { return numeroCompte; }

        public float getSoldeCompte() { return soldeCompte; }



        public void Retrait(float montant)
        {
            if(montant % 10 != 0)
            {
                throw new Exception("Montant invalide.");
            }

            if (montant > 1000)
            {
                throw new Exception("Montant superieure a la limite autorisee (1000$).");
            }

            if (soldeCompte < montant)
            {
                throw new Exception("Solde insuffisant."); 
            }

            soldeCompte -= montant;
        }

        public void Depot(float montant)
        {
            soldeCompte += montant;
        }
    }
}

