using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurATM.Controllers
{
    public class Client
    {
       private string nom, prenom, username, numeroNIP;

        public Client(string nom, string prenom, string username, string numeroNIP)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.username = username;
            this.numeroNIP = numeroNIP;
        }


        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Username { get; set; }
        public string NumeroNIP { get; set; }

    }
}
