using System;
using System.Net;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace postalCodeTranslator
{
    class PostalCodeTranslator
    {
        private WebClient webClient = new WebClient();
        private const string URL = "https://services.datafordeler.dk/DAR/DAR/1/rest/postnummer?postnr=";

        public void run()
        {
            Console.Write("Enter zip code: ");
            string zipCode = Console.ReadLine();

            string jsonString = requestJson(zipCode);
            
            JObject json = convertToJson(jsonString);
            Console.WriteLine("The name of the city is: " + json["navn"]);
        }

        private string requestJson(string zipCode)
        {
            Stream data = webClient.OpenRead (URL + zipCode);
            StreamReader reader = new StreamReader (data);
            string s = reader.ReadToEnd();
            data.Close ();
            reader.Close ();
            return s;
        }

        private JObject convertToJson(string jsonString)
        {
            jsonString = jsonString.Remove(0, 1);
            jsonString = jsonString.Remove(jsonString.Length -1, 1);
            return JObject.Parse(jsonString);

        }
    }
}
