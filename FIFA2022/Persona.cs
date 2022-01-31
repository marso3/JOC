using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFA2022
{
    class Persona
    {
        string nom;
        string cognom;
        double salari;
        DateTime dataNaixement;
        static string[] noms = new string[] { "Hugo", "Martín", "Lucas", "Mateo", "Leo", "Daniel", "Alejandro", "Pablo", "Manue", "Álvaro", "Adrián", "David", "Mario", "Enzo", "Diego", "Marcos", "Iza", "Javier", "Marco", "Álex", "Bruno", "Oliver", "Miguel", "Thiago", "Antonio", "Marc", "Carlos", "Ángel", "Juan", "Gonzalo", "Gael", "Sergio", "Nicolás", "Dylan", "Gabriel", "Jorge", "José", "Adam", "Liam", "Eric", "Samuel", "Darío", "Héctor", "Luca", "Iker", "Amir", "Rodrigo", "Saúl", "Víctor", "Francisco", "Iván", "Jesús", "Jaime", "Aarón", "Rubén", "Ian", "Guillermo", "Erik", "Mohamed", "Julen", "Luis", "Pau", "Unai", "Rafael", "Joel", "Alberto", "Pedro", "Raúl", "Aitor", "Santiago", "Rayan", "Pol", "Nil", "Noah", "Jan", "Asier", "Fernando", "Alonso", "Matías", "Biel", "Andrés", "Axel", "Ismael", "Martí", "Arnau", "Imran", "Luka", "Ignacio", "Aleix", "Alan", "Elías", "Omar", "Isaac", "Youssef", "Jon", "Teo", "Mauro", "Óscar", "Cristian", "Leonard" };
        public string Nom
        {
            get { return nom; }
        }
        public string Cognom
        {
            get { return cognom; }
        }
        public double Salari
        {
            get { return salari; }
        }
        public DateTime DataNaixement
        {
            get { return dataNaixement; }
        }
        public Persona()
        {
            var guid = Guid.NewGuid();
            var justNumbers = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            var seed = int.Parse(justNumbers.Substring(0, 4));
            Random random = new Random(seed);
            nom = noms[random.Next(0, 99)];
            cognom = noms[random.Next(0, 99)];
            salari = random.Next(0, 100000) * 1000;
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            dataNaixement = start.AddDays(random.Next(range));
        }
        public Persona(string nom, string cognom)
        {
            this.nom = nom;
            this.cognom = cognom;
        }
        public Persona(string nom, string cognom, double salari, DateTime dataNaixement)
        {
            this.nom = nom;
            this.cognom = cognom;
            this.salari = salari;
            this.dataNaixement = dataNaixement;
        }

    }
}
