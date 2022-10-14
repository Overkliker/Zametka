using System;

namespace Zametk
{
    public class Programm
    {
        public static bool checKeys(string dk, Dictionary<string, List<Zametka>> d1)
        {
            if (d1.Keys.Contains(dk))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Main(string[] argrs)
        {
            int pose = 1;
            Dictionary<string, List<Zametka>> all = new Dictionary<string, List<Zametka>>();
            MenuMain();
            foreach (var i in StandartZap())
            {
                if (checKeys(i.date, all))
                {
                    all[i.date].Add(i);
                }
                else
                {
                    all.Add(i.date, new List<Zametka>() {i});
                }
            }



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

                if (key.Key == ConsoleKey.Enter && pose == 1)
                {
                    viewZam(all);
                }
                else if (key.Key == ConsoleKey.Enter && pose == 2)
                {
                    all = Zapis(all);
                    MenuMain();

                }
            }


        }

        static void MenuMain()
        {
            Console.WriteLine("Что хотите сделать?");
            Console.WriteLine("   Заметки");
            Console.WriteLine("   Создать заметку");
        }

        public static Dictionary<string, List<Zametka>> Zapis(Dictionary<string, List<Zametka>> d1)
        {
            Console.Clear();
            Console.WriteLine("Введите название заметки:");
            string name = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Введите её описание:");
            string description = Console.ReadLine();
            Console.Clear();

            string date = DateTime.Today.ToString().Substring(0, 10);

            Console.WriteLine("Введите срок выполнения:");
            string deadline = Console.ReadLine();
            Console.Clear();

            Zametka nw = new Zametka(name, date, description, deadline);

            if (checKeys(date, d1))
            {
                d1[date].Add(nw);
            }
            else
            {
                d1.Add(date, new List<Zametka>() { nw });
            }
            return d1;
        }

        public static List<Zametka> StandartZap()
        { 
            List<Zametka> l1 = new List<Zametka>();

            l1.Add(new Zametka("День рождение кота",
                                "07.10.2022",
                                "Поздравить кота с др.",
                                "12.12.2022"));

            l1.Add(new Zametka("Практическая по Дискретной математике",
                               "07.10.2022",
                               "Файл ЭЛЕМЕНТЫ ТЕОРИИ МНОЖЕСТВ \n 1.Подмножества (просмотреть основные понятия, примеры) стр.11-12.Выполнить упражнения на стр.13-14",
                               "16.10.2022"));

            l1.Add(new Zametka("Практическая по AAC",
                                "09.10.2022",
                                "1. Необходимо установить программу Handy Recovery 5.5 (программное решение, предназначенное для восстановления данных, которое может помочь вернуть случайно удаленные файлы со всех типов дисков);\r\n2. Создайте файл, удалите его, а затем восстановите его с помощью данной программы.\r\n3. Составить отчёт по проделанной работе с добавлением скриншотов из программы",
                                "20.11.2022"));
            return l1;
        }
        public static void viewZam(Dictionary<string, List<Zametka>> d1)
        {
            bool flag = false;
            int pose = 1;
            int ct = 0;
            Dictionary<int, Zametka> d2 = new Dictionary<int, Zametka>();

            foreach (var k in d1.Keys)
            {
                foreach (var j in d1[k])
                {
                    Console.WriteLine($"  {j.name}");
                    ct++;
                }
            }

            ConsoleKeyInfo key = Console.ReadKey();
            while (!flag)
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    flag = true;
                    Console.Clear();
                    MenuMain();
                    break;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (pose <= 1)
                    {
                        pose = ct;
                    }
                    else
                    {
                        pose--;
                    }

                }
                else if (key.Key == ConsoleKey.DownArrow)
                {

                    if (pose >= ct)
                    {
                        pose = 1;
                    }
                    else
                    {
                        pose++;
                    }

                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    printZam(d2[pose], key);
                }

                ct = 0;
                d2.Clear();
                Console.Clear();
                Console.WriteLine("Ваши заметки: ");
                foreach (var k in d1.Keys)
                {
                    foreach (var j in d1[k])
                    {
                        Console.WriteLine($"   {j.name}");
                        ct++;
                        d2.Add(ct, j);
                    }
                }

                Console.SetCursorPosition(0, pose);
                Console.Write("->");
                
            }

        }

        public static void printZam(Zametka list, ConsoleKeyInfo key)
        {
            while (key.Key != ConsoleKey.Escape)
            {
                
                key = Console.ReadKey();
                Console.Clear();
                Console.WriteLine(list.name);
                Console.WriteLine();
                Console.WriteLine(list.description);
                Console.WriteLine();
                Console.WriteLine("Написано: " + list.date);
                Console.WriteLine("Сделать до: " + list.deadline);

            }
        }
    }
}