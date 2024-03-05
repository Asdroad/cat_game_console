using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGameCat
{
    internal class Cat
    {
        private int xp;
        private int cordX;
        private int cordY;
        private int Size;
        public int Xp
        {
            get { return xp; }
            set { /*if(value > 4 && value < 7)*/ xp = value; }
        }
        public Cat(int Xp, int cordx, int cordy, int Size)
        {
            this.Size = Size;
            this.Xp = Xp;
            CordX = cordx;
            CordY = cordy;
        }
        // Геттер и сеттер для CordX
        public int CordX
        {
            get { return cordX; }
            set
            {
                if (value >= 0 && value < Size)
                { cordX = value; Xp = Xp - 1; }
            }
        }

        // Геттер и сеттер для CordY
        public int CordY
        {
            get { return cordY; }
            set { if (value >= 0 && value < Size - 1) { cordY = value; Xp = Xp - 1; } }
        }
        
        public int Health()
        {
            int End = 0;
            if (xp < 2 || xp > 25)
            {
                End = 1;
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\n\n\t\t\tИгра окончена!\n");
                Console.ReadLine();
            }

            return End;
        }

        public delegate void CatPos();
        public event CatPos Shag;

        public void SetPosition()
        {

            while (true)
            {
                char k = Console.ReadKey().KeyChar;
                switch (k)
                {
                    case 'w':
                        Up();
                        Shag();
                        break;
                    case 's':
                        Down();
                        Shag();
                        break;
                    case 'a':
                        Left();
                        Shag();
                        break;
                    case 'd':
                        Right();
                        Shag();
                        break;
                    default:
                        k = Console.ReadKey().KeyChar;
                        break;

                }
                break;
            }

        }

        public void HealUpper()
        {
            Xp += 3;
        }
        private void Up()
        {
            CordX = CordX - 1;

        }
        private void Down()
        {
            CordX = CordX + 1;

        }
        private void Left()
        {
            CordY = CordY - 1;

        }
        private void Right()
        {
            CordY = CordY + 1;

        }



    }
}
