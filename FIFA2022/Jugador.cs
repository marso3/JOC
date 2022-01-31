using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFA2022
{
    class Jugador : Persona
    {
        string posicio;
        double valor;
        int rating;
        int velocitat;
        int xut;
        int passada;
        int regat;
        int defensa;
        int forca;
        public string Posicio
        {
            get { return posicio; }
        }
        public double Valor
        {
            get { return valor; }
        }
        public int Rating
        {
            get { return rating; }
        }
        public Jugador() : base()
        {
            var guid = Guid.NewGuid();
            var justNumbers = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            var seed = int.Parse(justNumbers.Substring(0, 4));
            Random random = new Random(seed);
            int valor0a100 = random.Next(0, 100);
            int boost1 = random.Next(1, 6);
            int boost2 = random.Next(1, 6);
            //Aixo el que fa es que posa unes estadistiques 30 punts amunt o abaix del rating aleatori que
            //li hagi tocat. Ho faig aixi perque abans habia fet que cada estadistica fos un random del 1 al
            //100 i despres el rating la mitjana. El que pasaba es que el rating sempre quedaba al voltant de
            //50. D'aquesta manera es genera mes dispersio
            if (valor0a100 < 30)
            {
                velocitat = random.Next(0, valor0a100 + 30);
                xut = random.Next(0, valor0a100 + 30);
                passada = random.Next(0, valor0a100 + 30);
                regat = random.Next(0, valor0a100 + 30);
                defensa = random.Next(0, valor0a100 + 30);
                forca = random.Next(0, valor0a100 + 30);
                BoostStat(boost1, random);
                BoostStat(boost2, random);
            }
            else if (valor0a100 > 70)
            {
                velocitat = random.Next(valor0a100 - 30, 100);
                xut = random.Next(valor0a100 - 30, 100);
                passada = random.Next(valor0a100 - 30, 100);
                regat = random.Next(valor0a100 - 30, 100);
                defensa = random.Next(valor0a100 - 30, 100);
                forca = random.Next(valor0a100 - 30, 100);
                BoostStat(boost1, random);
                BoostStat(boost2, random);
            }
            else
            {
                velocitat = random.Next(valor0a100 - 30, valor0a100 + 30);
                xut = random.Next(valor0a100 - 30, valor0a100 + 30);
                passada = random.Next(valor0a100 - 30, valor0a100 + 30);
                regat = random.Next(valor0a100 - 30, valor0a100 + 30);
                defensa = random.Next(valor0a100 - 30, valor0a100 + 30);
                forca = random.Next(valor0a100 - 30, valor0a100 + 30);
                BoostStat(boost1, random);
                BoostStat(boost2, random);
            }
            KeepValuesInRange();
            SetRatingAndPosition();
            valor = CalculateValue();
        }
        public Jugador(string nom, string cognom, double valor, double salari, DateTime datanaix) : base(nom, cognom, salari, datanaix)
        {
            this.valor = valor;
            SetRatingAndPosition();
        }

        public Jugador(string nom, string cognom, int velocitat, int xut, int passada, int regat, int defensa, int forca) : base(nom, cognom)
        {
            this.velocitat = velocitat;
            this.xut = xut;
            this.passada = passada;
            this.regat = regat;
            this.defensa = defensa;
            this.forca = forca;
            KeepValuesInRange();
            SetRatingAndPosition();
        }
        public Jugador(string nom, string cognom, double valor, double salari, int velocitat, int xut, int passada, int regat, int defensa, int forca, DateTime datanaix) : base(nom, cognom, salari, datanaix)
        {
            this.valor = valor;
            this.velocitat = velocitat;
            this.xut = xut;
            this.passada = passada;
            this.regat = regat;
            this.defensa = defensa;
            this.forca = forca;
            KeepValuesInRange();
            SetRatingAndPosition();
        }
        public void MostraJugador()
        {
            Console.WriteLine(this.ToString());
        }
        public override string ToString()
        {
            string stringJugador = "Nom:" + base.Nom +
                "\nCognom:" + base.Cognom +
                "\nEdat: " + Convert.ToString(CalculateAge(base.DataNaixement)) +
                "\nValor:" + valor +
                "\nSalari:" + base.Salari +
                "\nPosició:" + posicio +
                "\nRating:" + rating +
                "\nVelocitat:" + velocitat +
                "\nXut:" + xut +
                "\nPassada:" + passada +
                "\nRegat:" + regat +
            "\nDefensa:" + defensa +
            "\nforca:" + forca + "\n";
            return stringJugador;
        }
        //En funcio de les estadistiques randoms del jugador, s'escull amb quina posici� tindr� m�s mitjana
        //i se li assigna aquella posicio i rating
        void SetRatingAndPosition()
        {
            double tempRating, max;
            string tempPosicio;
            tempRating = 0.5 * defensa + 0.4 * forca + 0.1 * Math.Max(passada, velocitat);
            max = tempRating;
            tempPosicio = "Central";

            tempRating = 0.3 * defensa + 0.5 * velocitat + 0.2 * passada;
            if (tempRating > max)
            {
                max = tempRating;
                tempPosicio = "Lateral";
            }

            tempRating = 0.4 * defensa + 0.3 * Math.Max(passada, forca) + 0.3 * Math.Max(regat, velocitat);
            if (tempRating > max)
            {
                max = tempRating;
                tempPosicio = "Pivot";
            }

            tempRating = 0.4 * passada + 0.1 * forca + 0.3 * Math.Max(regat, velocitat) + 0.2 * Math.Max(defensa, xut);
            if (tempRating > max)
            {
                max = tempRating;
                tempPosicio = "Interior";
            }
            tempRating = 0.2 * passada + 0.2 * forca + 0.2 * regat + 0.2 * defensa + 0.2 * Math.Max(xut, velocitat);
            if (tempRating > max)
            {
                max = tempRating;
                tempPosicio = "Interior";
            }

            tempRating = 0.4 * regat + 0.3 * Math.Max(passada, velocitat) + 0.3 * xut;
            if (tempRating > max)
            {
                max = tempRating;
                tempPosicio = "MitjaPunta";
            }

            tempRating = 0.5 * xut + 0.2 * Math.Max(regat, passada) + 0.3 * Math.Max(forca, velocitat);
            if (tempRating > max)
            {
                max = tempRating;
                tempPosicio = "Davanter";
            }

            tempRating = 0.4 * velocitat + 0.3 * xut + 0.3 * Math.Max(passada, regat);
            if (tempRating > max)
            {
                max = tempRating;
                tempPosicio = "Extrem";
            }

            this.rating = (int)max;
            this.posicio = tempPosicio;
        }
        //Input: un numero entre l'1 i el 6 i la seed del random
        //Function: suma entre 5 i 20 a la stat que hagi sortit
        void BoostStat(int pos, Random random)
        {
            switch (pos)
            {
                case 1:
                    velocitat += random.Next(5, 21);
                    break;
                case 2:
                    xut += random.Next(5, 21);
                    break;
                case 3:
                    passada += random.Next(5, 21);
                    break;
                case 4:
                    regat += random.Next(5, 21);
                    break;
                case 5:
                    defensa += random.Next(5, 21);
                    break;
                case 6:
                    forca += random.Next(5, 21);
                    break;
            }
        }
        //Comprova que tots els valors de les estadistiques estiguin entre 0 i 99
        //i els arregla en cas contrari
        void KeepValuesInRange()
        {
            if (velocitat >= 100) velocitat = 99;
            else if (velocitat < 0) velocitat = 0;
            if (xut >= 100) xut = 99;
            else if (xut < 0) xut = 0;
            if (passada >= 100) passada = 99;
            else if (passada < 0) passada = 0;
            if (regat >= 100) regat = 99;
            else if (regat < 0) regat = 0;
            if (defensa >= 100) defensa = 99;
            else if (defensa < 0) defensa = 0;
            if (forca >= 100) forca = 99;
            else if (forca < 0) forca = 0;
        }
        double CalculateValue()
        {
            int edat = CalculateAge(base.DataNaixement);
            double multiplicadorEdat = 0;
            bool bbreak = false;
            double formula = (rating / 30 + Math.Pow(1.12, rating - 40) / 5) * 1000000;
            //multiplica el valor del jugador per 0.X segons l'edat descendentment
            for (int i = 40; i > 0 && !bbreak; i--)
            {
                if (i == edat) bbreak = true;
                multiplicadorEdat += 0.1;
            }
            return Math.Round(formula * multiplicadorEdat, 2);
        }
        int CalculateAge(DateTime data)
        {
            int age = 0;
            age = DateTime.Now.Year - data.Year;
            if (DateTime.Now.DayOfYear < data.DayOfYear) age--;
            return age;
        }
    }
}