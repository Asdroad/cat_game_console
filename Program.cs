using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGameCat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pole pole = new Pole(10);
            pole.UpHeal += pole.cat.HealUpper;
            pole.cat.Shag += pole.SetCatPosition;

            while (true)
            {
                pole.Spawneat();
                pole.Print();
                pole.cat.SetPosition();
                

             

                if (pole.cat.Health() == 1)
                {
                    break;
                }
                Console.Clear();
            }
        }
    }
}