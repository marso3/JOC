using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FIFA2022
{
    class Partit
    {
        Equip local;
        Equip visitant;
        int golsLocal;
        int golsVisitant;
        //Es podria crear una variable que sigui:
        bool partitDisputat = false;
        //I un cop es cridi a la funció DisputarPartit es comprovi si el partit ja estat disputat
        //Perque sino es sumaran gols a una partit ja disputat i aixi també tenim nosaltres una variable
        //que ens permeti saberho

        public Equip Local
        {
            set { local = value; }
        }
        public Equip Visitant
        {
            set { visitant = value; }
        }
        //Si no m'equivoco no cal posar Equip perque la propietat que has creat no te un get per tant
        //no fa cap return
        public Partit(Equip local, Equip visitant)
        {
            this.local = local;
            this.visitant = visitant;
        }
        //Aquest metode si no m'equivoco no serveix per res
        public string DisputarPartit()
        {
            Random rnd = new Random();
            string resultat;
            int diferenciaRatings = local.RatingMitja - visitant.RatingMitja;
            int temps = 0, probabilitat;
            bool atacant;
            Console.WriteLine("------COMEEEENÇA EL PARTIT!!-------");
            while (temps <= 90)
            {
                atacant = EscollirAtacant(diferenciaRatings, rnd);
                if (atacant) Console.WriteLine("Ataca l'equip LOCAL     <---");
                else Console.WriteLine("Ataca l'equip VISITANT  --->");
                probabilitat = rnd.Next(0, 100);
                if (probabilitat >= 0 && probabilitat < 20)
                {
                    Console.WriteLine("El defensa ha robat la pilota");
                }
                else if (probabilitat >= 20 && probabilitat < 40)
                {
                    Console.WriteLine("El defensa roba la pilota");
                }
                else if (probabilitat >= 40 && probabilitat < 60)
                {
                    Console.WriteLine("El davanter xuta i va a fora");
                }
                else if (probabilitat >= 60 && probabilitat < 80)
                {
                    Console.WriteLine("El davanter xuta però va al pal");
                }
                else if (probabilitat >= 80 && probabilitat < 95)
                {
                    Console.WriteLine("Gol normalet");
                    if (atacant) golsLocal += 1;
                    else golsVisitant += 1;
                }
                else
                {
                    Console.WriteLine("GOLASOOOO!!!");
                    if (atacant) golsLocal += 1;
                    else golsVisitant += 1;
                }
                Console.WriteLine("Minut " + temps);
                Console.WriteLine("----[" + golsLocal + "-" + golsVisitant + "]----");
                temps += 10;
                Thread.Sleep(4000);
            }
            resultat = $"{golsLocal} - {golsVisitant}";
            return resultat;
        }
        private bool EscollirAtacant(int diferenciaRatings, Random rnd)
        {
            bool equip;
            int probabilitat = 50 + diferenciaRatings;
            if (probabilitat > rnd.Next(0, 100))
            {
                equip = true;
            }
            else
            {
                equip = false;
            }
            return equip;
        }
    }
}
