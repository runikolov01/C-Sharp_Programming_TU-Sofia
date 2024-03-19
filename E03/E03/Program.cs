using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Моля, изберете опция:");
            Console.WriteLine("1. Something like Whois");
            Console.WriteLine("2. Current Local Time");
            Console.WriteLine("3. Scrape data from a Website");
            Console.WriteLine("0. Изход");
            Console.Write("Вашият избор е номер: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Whois();
                    break;
                case "2":
                    CurrentLocalTime();
                    break;
                case "3":
                    ScrapeWebsiteData();
                    break;
                case "0":
                    Console.WriteLine("Довиждане!");
                    return;
                default:
                    Console.WriteLine("Невалиден избор. Моля, опитайте отново.");
                    break;
            }
        }
    }

    static void Whois()
    {
        Console.Write("Моля, въведете IP адрес: ");
        string ipAddress = Console.ReadLine();
        string country = GetCountryFromIP(ipAddress);

        if (!string.IsNullOrEmpty(country))
        {
            Console.WriteLine($"Държава: {country}");
        }
        else
        {
            Console.WriteLine("Държавата не може да бъде намерена.");
        }
    }

    static string GetCountryFromIP(string ip)
    {
        string url = $"https://ipinfo.io/{ip}";
        try
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            var countryNode = doc.DocumentNode.SelectSingleNode("//td[text()='Country']/following-sibling::td/a");
            if (countryNode != null)
            {
                return countryNode.InnerText.Trim();
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Не може да се свърже със сървъра.");
        }
        return null;
    }


    static void CurrentLocalTime()
    {
        string url = "https://www.timeanddate.com/worldclock/bulgaria/sofia";

        // Изтегляме целия HTML на страницата
        string html = GetResponse(url);

        // Инициализираме HtmlDocument с HtmlAgilityPack
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);

        // Използваме XPath, за да извлечем часът от тага с id="ct" и клас "h1"
        HtmlNode node = doc.DocumentNode.SelectSingleNode("//span[@id='ct' and @class='h1']");

        if (node != null)
        {
            string currentTime = node.InnerText.Trim();
            Console.WriteLine($"Текущо местно време в София: {currentTime}");
        }
        else
        {
            Console.WriteLine("Не може да бъде намерено текущо местно време.");
        }
    }

    static void ScrapeWebsiteData()
    {
        {
            string url = "https://www.mediapool.bg/";

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            var articles = doc.DocumentNode.SelectNodes("//li[@class='l-grid__cell l-grid__cell_size_50 l-grid__cell_size-tiny_100']");

            if (articles != null)
            {
                foreach (var article in articles)
                {
                    var titleNode = article.SelectSingleNode(".//h3[@class='c-article-item__title']");
                    var dateNode = article.SelectSingleNode(".//time[@class='c-article-item__date']");

                    if (titleNode != null && dateNode != null)
                    {
                        string title = titleNode.InnerText.Trim();
                        string dateTime = dateNode.GetAttributeValue("datetime", "");

                        // Проверка за наличие на забранени думи в заглавието
                        if (!title.Contains("Covid-19") && !title.Contains("корона вирус") && !title.Contains("пандемия"))
                        {
                            DateTime publishDate = DateTime.Parse(dateTime);

                            Console.WriteLine("Title: " + title);
                            Console.WriteLine("Publish Date: " + publishDate.ToString("yyyy-MM-dd HH:mm"));
                            Console.WriteLine();
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No articles found.");
            }
        }
    }

    static string GetResponse(string url)
    {
        string responseText;
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                responseText = sr.ReadToEnd();
            }

            response.Close();
        }
        catch (Exception e)
        {
            responseText = $"Грешка: {e.Message}";
        }

        return responseText;
    }
}
