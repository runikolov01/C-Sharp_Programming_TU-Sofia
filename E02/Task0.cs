using System;

namespace E02
{
    class Task0
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Изберете задача номер:");
            Console.WriteLine("1. Обработка на географски координати");
            Console.WriteLine("2. Телефонни контакти");
            Console.WriteLine("3. Чете се .xml файл (input3.dae), описващ 3D сцена");
            Console.Write("Въведете номер на задачата: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Task01.Execute();
                        break;
                    case 2:
                        Task02.Execute();
                        break;
                    case 3:
                        Task03.Execute();
                        break;
                    default:
                        Console.WriteLine("Невалиден избор.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Невалиден избор.");
            }
        }
    }
}