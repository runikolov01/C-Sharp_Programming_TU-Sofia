using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace E02
{
    public class Contact
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string PhoneNumber { get; set; }
    }

    class Task02
    {
        public static void Execute()
        {
            string inputFileName = "input-02.txt";
            string outputFileName = "output.xml";

            List<Contact> contacts = new List<Contact>();

            // Прочитаме входния файл
            string[] lines = File.ReadAllLines(inputFileName);

            Contact currentContact = null;

            foreach (string line in lines)
            {
                // Проверяваме дали редът е име или ID
                if (line.Contains("\t"))
                {
                    // Разделяме реда по табулация
                    string[] parts = line.Split("\t");

                    // Ако имаме вече запазен контакт, го добавяме към списъка
                    if (currentContact != null)
                    {
                        contacts.Add(currentContact);
                    }

                    // Създаваме нов контакт и му присвояваме името и ID-то
                    currentContact = new Contact
                    {
                        Name = parts[0].Trim(),
                        ID = parts[1].Trim()
                    };
                }
                else if (line.StartsWith("+395")) // Проверяваме дали редът съдържа телефонен номер
                {
                    // Добавяме телефонния номер към текущия контакт
                    currentContact.PhoneNumber = line.Trim();
                }
            }

            // Добавяме последния контакт към списъка
            if (currentContact != null)
            {
                contacts.Add(currentContact);
            }

            // Създаваме XML файл съдържащ структурираните данни и TimeStamp
            XElement xmlContacts = new XElement("Contacts");

            foreach (var contact in contacts)
            {
                XElement xmlContact = new XElement("Contact",
                    new XElement("Name", contact.Name),
                    new XElement("ID", contact.ID),
                    new XElement("PhoneNumber", contact.PhoneNumber)
                );

                xmlContacts.Add(xmlContact);
            }

            // Добавяме TimeStamp към XML структурата
            xmlContacts.Add(new XElement("TimeStamp", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")));

            // Записваме XML файла
            xmlContacts.Save(outputFileName);

            Console.WriteLine("XML файлът (output.xml) е записан успешно.");
        }
    }
}