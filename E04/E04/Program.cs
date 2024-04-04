using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Добре дошли в чат стаята!");

        ChatRoom room = new ChatRoom("General");

        Console.WriteLine("Въведете имената на двамата потребители:");

        Contact user1 = new Contact();
        Console.Write("Име на потребител 1: ");
        user1.Name = Console.ReadLine();
        room.AddUser(user1);

        Contact user2 = new Contact();
        Console.Write("Име на потребител 2: ");
        user2.Name = Console.ReadLine();
        room.AddUser(user2);

        Console.WriteLine($"Можете да започнете да пишете съобщения като '{user1.Name}' или '{user2.Name}' (за да приключите, въведете 'E', за да излезете от програмата, въведете 'Q'):");
        string input;
        int currentUserIndex = 0;
        while ((input = Console.ReadLine()) != null && input.ToUpper() != "Q")
        {
            if (input.ToUpper() == "E")
            {
                var statistics = room.GetRoomStatistics();
                Console.WriteLine($"Потребител с най-много съобщения: {statistics.Item1}");
                Console.WriteLine($"Брой съобщения: {statistics.Item2}");
                Console.WriteLine($"Най-късото съобщение: {statistics.Item3}");

                Console.WriteLine("Натиснете Enter, за да продължите или 'Q' за да излезете...");
                if (Console.ReadLine()?.ToUpper() == "Q")
                    break;
            }
            else
            {
                string currentUser = room.Users[currentUserIndex].Name;
                Console.Write("[{0}] {1}: ", DateTime.Now.ToString("HH:mm:ss"), currentUser);
                string message = input; // Взимаме вече въведения от потребителя текст
                room.AddMessage(new Message(currentUser, message));

                currentUserIndex = (currentUserIndex + 1) % room.Users.Count;
            }
        }



        Console.WriteLine("Благодарим, че използвахте чат стаята!");
    }
}