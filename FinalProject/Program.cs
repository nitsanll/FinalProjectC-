using System;

namespace FinalProject
{
    class Program
    {
        //a simple client gui showing the functionality
        static void Main(string[] args)
        {
            for (;;)
            {
                ICurrencyDataService service = CurrencyDataServiceFactory.
                        GetCurrencyDataService(DataServices.OPEN_CURRENCIES_MAP);
                service.ReadFromXml();
                service.getAllCountries();
                int chosenCountry;
                Console.Write("Please choose country to watch its currency details \n");
                Console.Write("1.USA" + '\n' + "2.Great Britain" + '\n' + "3.Japan" + '\n' + "4.EMU" + '\n'
                                 + "5.Australia" + '\n' + "6.Canada" + '\n' + "7.Denmark" + '\n' + "8.Norway" +
                                 '\n' + "9.South Africa" + '\n' + "10.Sweden" + '\n' + "11.Switzerland" + '\n' + "12.Jordan" + '\n'
                                 + "13.Lebanon" + '\n' + "14.Egypt" + '\n');
                chosenCountry = Int32.Parse(Console.ReadLine());
                Country country = new Country();
                switch (chosenCountry) 
                {
                    case 1://USA currency
                        country.CountryName = "USA";
                        break;
                    case 2://Great Britain currency
                        country.CountryName = "Great Britain";
                        break;
                    case 3://Japan currency
                        country.CountryName = "Japan";
                        break;
                    case 4://EMU currency
                        country.CountryName = "EMU";
                        break;
                    case 5://Australia currency
                        country.CountryName = "Australia";
                        break;
                    case 6://Canada currency
                        country.CountryName = "Canada";
                        break;
                    case 7: //Denmark currency
                        country.CountryName = "Denmark";
                        break;
                    case 8://Norway currency
                        country.CountryName = "Norway";
                        break;
                    case 9://South Africa currency
                        country.CountryName = "South Africa";
                        break;
                    case 10://Sweden currency
                        country.CountryName = "Sweden";
                        break;
                    case 11://Switzerland currency
                        country.CountryName = "Switzerland";
                        break;
                    case 12://Jordan currency
                        country.CountryName = "Jordan";
                        break;
                    case 13://Lebanon currency
                        country.CountryName = "Lebanon";
                        break;
                    case 14://Egypt currency
                        country.CountryName = "Egypt";
                        break;
                }
                CurrencyData answer = service.getCurrencyData(country);
                Console.WriteLine("\n" + country.CountryName + "'s currency: \n" + answer.toString());
            }
        }
    }
}
