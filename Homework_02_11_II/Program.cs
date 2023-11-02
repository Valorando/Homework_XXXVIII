using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_02_11_II
{
    public class Bank
    {
        private int money = 15000;
        private string name = "User";
        private int percent = 25;

        private void ToFile()
        {
            using (StreamWriter sw = File.CreateText("bank.txt"))
            {
                sw.WriteLine($"Money: {money}");
                sw.WriteLine($"Name: {name}");
                sw.WriteLine($"Percent: {percent}");
            }
        }

        public int Money
        {
            get
            {
                return money;
            }

            set
            {
                Thread t = new Thread(() =>
                {
                    money = value;
                    ToFile();
                });

                t.Start();
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                Thread t = new Thread(() =>
                {
                    name = value;
                    ToFile();
                });

                t.Start();
            }
        }

        public int Percent
        {
            get
            {
                return percent;
            }

            set
            {
                Thread t = new Thread(() =>
                {
                    percent = value;
                    ToFile();
                });

                t.Start();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Внести изменения");
                Console.WriteLine("2 - Выйти");
                Console.WriteLine();
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - Изменить Money");
                    Console.WriteLine("2 - Изменить Name");
                    Console.WriteLine("3 - Изменить Percent");
                    Console.WriteLine("4 - В основное меню");
                    Console.WriteLine();
                    ConsoleKeyInfo key_two = Console.ReadKey();

                    if (key_two.Key == ConsoleKey.D1)
                    {
                        try
                        {
                            Console.WriteLine();
                            Console.Write("Введите новое значение: ");
                            int money = Convert.ToInt16(Console.ReadLine());
                            bank.Money = money;
                            Console.WriteLine("Значение заменено, обновлённый файл создан.");
                            Console.WriteLine();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Ошибка: {ex.Message}");
                            Console.WriteLine();
                        }
                    }

                    if (key_two.Key == ConsoleKey.D2)
                    {
                        try
                        {
                            Console.WriteLine();
                            Console.Write("Введите новое значение: ");
                            string name = Console.ReadLine();
                            bank.Name = name;
                            Console.WriteLine("Значение заменено, обновлённый файл создан.");
                            Console.WriteLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Ошибка: {ex.Message}");
                            Console.WriteLine();
                        }
                    }

                    if (key_two.Key == ConsoleKey.D3)
                    {
                        try
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Введите новое значение: ");
                            int precent = Convert.ToInt16(Console.ReadLine());
                            bank.Percent = precent;
                            Console.WriteLine("Значение заменено, обновлённый файл создан.");
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Ошибка: {ex.Message}");
                            Console.WriteLine();
                        }
                    }

                    if (key_two.Key == ConsoleKey.D4)
                    {
                        
                    }
                }

                if (key.Key == ConsoleKey.D2)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
