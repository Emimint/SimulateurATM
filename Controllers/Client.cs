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
        public string ImagePath { get; set; }

        public Client(string nom, string prenom, string username, string numeroNIP)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.username = username;
            this.numeroNIP = numeroNIP;

            ImagePath = "client.png"; 
        }

        public string getNom() { return nom; }

        public string getPrenom() {  return prenom; }

        public string getUsername() { return username; }

        public string getNumeroNIP() {  return numeroNIP; }

        public string DisplayInfo => $"Nom du client: {getNom()}, Prenom du client: {getPrenom()}";

    }
}
