using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFA2022
{
    class Equip
    {
        string nom;
        static int numJugadors = 11;
        Jugador[] jugadors;
        int ratingMitja;
        public string Nom
        {
            get { return nom; }
        }
        public int RatingMitja
        {
            get { return ratingMitja; }
            set
            {
                ratingMitja = value;
                //for (int i = 0; i < jugadors.Length; i++)
                //{
                //    ratingMitja += jugadors[i].Rating;
                //}
                //ratingMitja /= numJugadors;
            }
        }
        public Equip(string nom)
        {
            this.nom = nom;
            Genera11Jugadors();
        }
        public void Genera11Jugadors()
        {
            jugadors = new Jugador[numJugadors];
            for (int i = 0; i < numJugadors; i++)
            {
                jugadors[i] = new Jugador();
            }
        }
        public void MostraPlantilla()
        {
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine("Jugador " + (i + 1) + ":");
                jugadors[i].MostraJugador();
            }
        }
    }
}