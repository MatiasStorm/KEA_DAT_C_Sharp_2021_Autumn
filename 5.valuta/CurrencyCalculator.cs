using System;
using System.Net;
using System.Xml;
using System.Collections.Generic;

namespace valuta
{
    class CurrencyCalculator
    {
        private Dictionary<string, Currency> currencyDict = new Dictionary<string, Currency>();
        private string url = "https://www.nationalbanken.dk/_vti_bin/DN/DataService.svc/CurrencyRatesXML?lang=da";

        public CurrencyCalculator()
        {
            this.loadCurrencies();
        }

        public void run()
        {
            Console.Write("Amount of DKK: ");
            string input = Console.ReadLine();
            double dkk = Convert.ToDouble( Console.ReadLine() );

            string currencyCode = this.pickCurrency();
            double rate = currencyDict[currencyCode].Rate;
            double tranlatedValue = Math.Round(dkk / rate, 2);

            Console.WriteLine(dkk + " DKK is worth " + tranlatedValue + " " + currencyCode);
        }

        private void loadCurrencies(){
            Console.WriteLine("Fetching latest currency data...\n");

            WebClient webClient = new WebClient();
            string data = webClient.DownloadString(url);
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);

            string code, description;
            double rate;
            
            foreach(XmlNode node in doc.DocumentElement.ChildNodes[0].ChildNodes){
                code = node.Attributes["code"].InnerText;
                description = node.Attributes["desc"].InnerText;
                rate = Convert.ToDouble(node.Attributes["rate"].InnerText.Replace(",", ".")) / 100.0;
                this.currencyDict[code] = new Currency(code, description, rate);
            }
        }

        private void listCurrencies(){
            Console.WriteLine();
            foreach(Currency c in this.currencyDict.Values){
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine();
        }

        private string pickCurrency(){
            this.listCurrencies();
            Console.Write("Type currency code: ");
            string code = Console.ReadLine();
            return code.ToUpper();
        }
    }
}
