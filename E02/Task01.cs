using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace E02
{

    public struct GeoCoordinate
    {
        public float lat;
        public float lng;
    }

    class Task01
    {
        public static void Execute()
        {
            string inputFileName = "input-01.txt";
            string outputFileName = "output.json";

            // Прочитаме входния файл и създаваме масив от географски координати
            string[] lines = File.ReadAllLines(inputFileName);
            var coordinates = new GeoCoordinate[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                string[] latLng = parts[0].Split(',');

                coordinates[i] = new GeoCoordinate
                {
                    lat = float.Parse(latLng[0], CultureInfo.InvariantCulture),
                    lng = float.Parse(latLng[1], CultureInfo.InvariantCulture)
                };
            }

            // Конвертираме масива от географски координати в JSON низ
            string json = JsonConvert.SerializeObject(coordinates, Newtonsoft.Json.Formatting.Indented);

            // Добавяме текущата дата и час в JSON низа
            json = json.Insert(1, $@"""timestamp"": ""{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}""{Environment.NewLine}");

            // Записваме JSON низа в изходен файл
            File.WriteAllText(outputFileName, json);

            Console.WriteLine("JSON низът е записан във файл: " + outputFileName);
        }
    }
}