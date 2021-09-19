using System;

namespace zipCodeTranlatorErrorPrunin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program translate from a zip code to a city- name");
            Console.Write("input your zip-code: ");
            string zipCode = Console.ReadLine();
            System.Net.WebClient wc = new System.Net.WebClient();
            string webData = wc.DownloadString("https://services.datafordeler.dk/DAR/DAR/1/rest/postnummer?postnr="+zipCode);
            try 
            {
                Console.WriteLine("\nPostcode: " + zipCode + " City: " + webData.Substring(webData.IndexOf("navn") + 7, webData.IndexOf("postnr") - webData.IndexOf("navn") -3 -7));
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Postnummeret er ugyldigt.");
            }
        }
    }
}
