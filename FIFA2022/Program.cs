using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFA2022
{
    class Program
    {
        static void Main(string[] args)
        {
            int numEquips = 0;
            Equip[] equips = new Equip[10];
            char selector;
            do
            {
                Console.Clear();
                Console.WriteLine("FIFA 2022+" +
                    "\nTria una opció" +
                    "\n1.Crea Un Equip" +
                    "\n2.Mostra els equips" +
                    "\n3.Disputa Partit(funcionalitat no disponible)" +
                    "\n0.Exit");
                selector = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (selector)
                {
                    case '1':
                        CreaEquip();
                        break;
                    case '2':
                        MenuEquips();
                        break;
                    case '3':
                        DisputaPartit();
                        break;
                }

            } while (selector != '0');
            void CreaEquip()
            {
                Console.WriteLine("Quin nom vols per l'equip");
                string nomEquip = Console.ReadLine();
                equips[numEquips] = new Equip(nomEquip);
                numEquips++;
            }
            void MenuEquips()
            {
                int selectorEquip = -1;
                MostraEquips();
                Console.WriteLine("Si vols sortir pulsa qualsevol tecla." +
                    "\nSi vols veure els Jugadors d'un equip escriu el numero 1,2,3...");
                selectorEquip = Convert.ToInt32(Console.ReadKey().KeyChar) - '0' - 1;
                if (selectorEquip >= 0 && selectorEquip < numEquips)
                {
                    Console.Clear();
                    equips[selectorEquip].MostraPlantilla();
                    Console.WriteLine("Pulsa la lletra d per borrar l'equip" +
                        "\nPulsa qualsevol altre tecla per sortir...");
                    if (Console.ReadKey().KeyChar == 'd') BorraEquip(selectorEquip);
                }
            }
            void MostraEquips()
            {
                Console.WriteLine("Llistat dels equips:");
                for (int i = 0; i < numEquips; i++)
                {
                    Console.WriteLine((i + 1) + ". " + equips[i].Nom);
                }
            }
            void DisputaPartit()
            {
                if (numEquips > 1)
                {
                    MostraEquips();
                    Console.Write("Escull els dos equips que vols que juguin:" +
                        "\nEquip 1: ");
                    int ne1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Equip 2: ");
                    int ne2 = Convert.ToInt32(Console.ReadLine());
                    string resultat;
                    if (ne1 != ne2 && ne2 <= numEquips && ne1 <= numEquips)
                    {
                        Partit p1 = new Partit(equips[ne1 - 1], equips[ne2 - 1]);
                        resultat = p1.DisputarPartit();
                        Console.WriteLine("Final: " + resultat);
                        Console.WriteLine("Pulsa qualsevol tecla per sortir...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("No es posible fer un partit amb aquests equips");
                        Console.WriteLine("Pulsa qualsevol tecla per sortir...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Has de tenir minim dos equips per poder jugar un partit;");
                    Console.WriteLine("Pulsa qualsevol tecla per sortir...");
                    Console.ReadKey();
                }

            }
            void BorraEquip(int selectorEquip)
            {
                for (int i = selectorEquip; i < numEquips; i++)
                {
                    equips[i] = equips[i + 1];
                }
                numEquips--;
            }
        }
    }
}
