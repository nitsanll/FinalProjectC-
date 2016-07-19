using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace FinalProject
{
    public class CurrencyDataService : ICurrencyDataService
    {
        //creating singletone instance
        private static CurrencyDataService instance;
        private CurrencyDataService() { }
        public static CurrencyDataService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CurrencyDataService();
                }
                return instance;
            }
        }

        //creating a dictionary for each country and its currency data
        private Dictionary<Country, CurrencyData> countriesDictionary;

        public Dictionary<Country, CurrencyData> CountriesDictionary
        {
            get { return countriesDictionary; }
           // set { name = value; }
        }

        //initiating the dictionary from XML file with each country and its currency data
        public void getAllCountries()
        {
            XDocument filexml = new XDocument();
            Dictionary<Country, CurrencyData> dictionary = new Dictionary<Country, CurrencyData>();
            try
            {
                filexml = XDocument.Load("C:\\Users\\ניצן\\Documents\\Visual Studio 2015\\Projects\\FinalProject\\FinalProject\\bin\\Debug\\currency.xml");
            }
            catch (IOException)
            {
                throw new CurrencyDataServiceException("couldn't find the file in the specified path!");
            }

            try
            {
                // Linq is being used to get attributes. Convert XML to LINQ
                XElement currenciesNode = filexml.Element("CURRENCIES");

                var allCurrenciesQuery = from currency in currenciesNode.Elements("CURRENCY")
                                         select currency;

                // initializing the dictionary
                foreach (var currency in allCurrenciesQuery)
                {
                    CurrencyData c = new CurrencyData();
                    c.Name = currency.Element("NAME").Value;
                    c.CurrencyCode = currency.Element("CURRENCYCODE").Value;
                    c.Country = currency.Element("COUNTRY").Value;
                    c.Rate = double.Parse(currency.Element("RATE").Value);
                    Country co = new Country();
                    co.CountryName = currency.Element("COUNTRY").Value;
                    dictionary.Add(co, c);
                }
                countriesDictionary = dictionary;
            }
            catch (Exception)
            {
                throw new CurrencyDataServiceException("could not parse the XML file");
            }
        }

        //get currency data of a specific country
        public CurrencyData getCurrencyData(Country country)
        {
            try
            {
                foreach (CurrencyData c in countriesDictionary.Values)
                {
                    if (String.Equals(c.Country, country.CountryName)) return c;
                }
                throw new Exception();
            }
            catch (Exception)
            {
                throw new CurrencyDataServiceException("country does not exist!");
            }
        }

        //reading data from the service XML file
        public void ReadFromXml()
        {
            XElement filexml;
            try
            {
                //loading the page 
                filexml = XElement.Load("http://www.boi.org.il/currency.xml");
                IEnumerable<XElement> CURRENCIES = filexml.Elements();

                //reading XML and saving it locally
                foreach (var CURRENCY in CURRENCIES)
                {
                    filexml.Save("currency.xml");
                }
            }
            //case no connection to internet
            catch (Exception)
            {
                throw new CurrencyDataServiceException("Failed to load currency rates XML - no connection." + '\n' + '\n');
            }
        }
    }
}


