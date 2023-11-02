using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_02_11_III
{
    internal class Program
    {
        
        static async Task Main(string[] args)
        {
            Random random = new Random();
            int delaySeconds = random.Next(5, 31);
            Console.WriteLine($"Приготовьтесь!");
            await Task.Delay(delaySeconds * 1000);

            Console.WriteLine("Нажмите на любую клавишу!");
            DateTime startTime = DateTime.Now;
            bool keyPressed = false;

            var keyTask = Task.Run(() => Console.ReadKey(intercept: true));

            while (!keyPressed && !keyTask.IsCompleted)
            {
                if (Console.KeyAvailable)
                {
                    keyTask.Wait();
                    keyPressed = true;
                }
            }

            if (keyPressed = true)
            {
                DateTime endTime = DateTime.Now;
                TimeSpan duration = endTime - startTime;
                Console.WriteLine($"Вам потребовалось {duration.TotalSeconds:F2} секунд для нажатия клавиши.");
                Console.Read();
            }
        }
    }
}
