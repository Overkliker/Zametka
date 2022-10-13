using System;

namespace Zametk
{
    public class Programm
    {
        static void Main(string[] argrs)
        {
            int pose = 1;
            Dictionary<string, List<List<Zametka>>> all = new Dictionary<string, List<List<Zametka>>>();
            MenuMain();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (pose <= 1)
                    {
                        pose++;
                    }
                    else
                    {
                        pose--;
                    }
                    
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {

                    if (pose >= 2)
                    {
                        pose--;
                    }
                    else
                    {
                        pose++;
                    }

                }
                Console.Clear();
                MenuMain();
                Console.SetCursorPosition(0, pose);
                Console.Write("->");
            }


        }

        static void MenuMain()
        {
            Console.WriteLine("Что хотите сделать?");
            Console.WriteLine("   Заметки");
            Console.WriteLine("   Создать заметку");
        }

        public static void Zapis()
        {

        }

        public static void StandartZap()
        {
            for (int i = 0; i < 3; i++)
            {
                List<List<Zametka>> l1 = new List<List<Zametka>>();
                Zametka nw = new Zametka("прийти на пары " + i, "arg", );
                l1
            }
        }
    }
}