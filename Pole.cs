using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGameCat
{

    internal class Pole
    {
        private int[,] maspole;
        private int x;
        public Cat cat;
        public Pole(int X)
        {
            x = X;
            maspole = new int[X, X];
            x = X;
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    maspole[i, j] = 0;
                }
            }
            cat = new Cat(10, X / 2, X / 2, X);

            maspole[X / 2, X / 2] = 2;
        }
        public void SetCatPosition()
        {
            int flag = 1;
            for (int i = 0; i < x; i++)
            {
                if (flag == 0) break;
                for (int j = 0; j < x; j++)
                {
                    if (maspole[i, j] == 2)
                    {

                        maspole[i, j] = 0;
                        CheckPosition();
                        maspole[cat.CordX, cat.CordY] = 2;
                        flag = 0;
                        break;
                    }
                }
            }
        }
        public delegate void HealthUp();
        public event HealthUp UpHeal;
        public void CheckPosition()
        {
            if (maspole[cat.CordX, cat.CordY] == 1)
            {
                UpHeal();
            }
        }

        /*private int RandomSpawn()
        {
            Random random = new Random();
            int minRange = 0;
            int maxRange = x - 1;
            int rand1 = random.Next(minRange, maxRange);
            return rand1;
        }*/


        private void RandomSpawnEat()
        {
            Random random = new Random();
            int minRange = 0;
            int maxRange = x - 1;
            while (true)
            {
                int rand1 = random.Next(minRange, maxRange);
                int rand2 = random.Next(minRange, maxRange);
                if (maspole[rand1, rand2] == 1) continue;
                else
                {
                    maspole[rand1, rand2] = 1;
                    break;
                }
            }


        }

        public void Spawneat()
        {
            int counteat = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (maspole[i, j] == 1)
                    {
                        counteat++;
                    }
                }
            }
            if (counteat < 5)
            {
                for (int i = 0; i < 5 - counteat; i++) RandomSpawnEat();
            }
        }

        public void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < x; i++)
            {
                UpPrint(0);
                for (int j = 0; j < x; j++)
                {
                    Console.Write("|");
                    PrintHelper(maspole[i, j]);
                    if (j + 1 == x) PrintHelper(5);
                }
                if (i + 1 == x) UpPrint(1);
            }
        }
        private void UpPrint(int y)
        {

            for (int i = 0; i < x; i++)
            {
                Console.Write("--");
                if (y == 0 && i + 2 == x)
                {
                    Console.Write("-\n");
                    break;
                }
                else if (y == 1 && i + 2 == x)
                {
                    Console.Write("-\t Health: " + cat.Xp + "\n");
                    break;
                }
            }

        }
        

        private void PrintHelper(int i)
        {
            switch (i)
            {
                case 0:
                    Console.Write(" ");
                    break;
                case 1:
                    Console.Write("*");
                    break;
                case 2:
                    Console.Write("@");
                    break;
                default:
                    Console.Write("\n");
                    break;
            }
        }

    }
}

