using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace E02
{
    public class Task03
    {
        public class Tag
        {
            public string Name { get; set; }
            public Dictionary<string, string> Attributes { get; set; }
            public Tag Connection { get; set; } // Връзка към друг таг

            public Tag()
            {
                Attributes = new Dictionary<string, string>();
            }
        }

        public static void Execute()
        {
            string filePath = "input-03.dae"; // Пътят към XML файла
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            XmlNode root = xmlDoc.DocumentElement;
            Tag rootTag = ParseXmlNode(root);

            string json = JsonConvert.SerializeObject(rootTag, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
        }

        // Рекурсивен метод за парсване на XML таговете и тяхната връзка
        private static Tag ParseXmlNode(XmlNode node)
        {
            Tag tag = new Tag();
            tag.Name = node.Name;

            if (node.Attributes != null)
            {
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    if (attribute.Value.StartsWith("#"))
                    {
                        // Ако атрибута започва с '#', търсим таг с такъв идентификатор
                        string id = attribute.Value.Substring(1);
                        XmlNode referencedNode = node.SelectSingleNode($"//*[@id='{id}']");
                        if (referencedNode != null)
                        {
                            tag.Connection = ParseXmlNode(referencedNode);
                        }
                    }
                    else
                    {
                        // В противен случай добавяме атрибута към текущия таг
                        tag.Attributes.Add(attribute.Name, attribute.Value);
                    }
                }
            }

            // Рекурсивно парсваме всички деца на текущия таг
            foreach (XmlNode childNode in node.ChildNodes)
            {
                Tag childTag = ParseXmlNode(childNode);
                // Добавяме детето като част от текущия таг
                tag.Connection = childTag;
            }

            return tag;
        }
    }
}