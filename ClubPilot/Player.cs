using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubPilot
{
    class Player
    {
        private String nom;
        private String posicio;
        private bool disponibilitat;
        private int dorsal;

        public string getNom { get; set; }
        public string getPosicio { get; set; }
        public bool isDisponibilitat { get; set; }
        public int getDorsal { get; set; }

        public Player() { }

        public Player(String nom,String posicio,bool disponibilitat,int dorsal)
        {
            this.nom = nom;
            this.posicio = posicio;
            this.dorsal = dorsal;
            this.disponibilitat = disponibilitat;
        }
    }
}