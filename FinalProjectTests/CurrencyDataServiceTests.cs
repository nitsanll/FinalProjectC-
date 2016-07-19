using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace FinalProject.Tests
{
    [TestClass()]
    public class CurrencyDataServiceTests
    {
        [TestMethod()]
        public void getAllCountriesTest()
        {
            CurrencyDataService c = CurrencyDataService.Instance;
            c.getAllCountries();
            int expectedSize = 14;
            int dictionarySize = c.CountriesDictionary.Count;
            Assert.AreEqual(dictionarySize, expectedSize);
        }

        [TestMethod()]
        public void getCurrencyDataTest()
        {
            CurrencyDataService c = CurrencyDataService.Instance;
            c.getAllCountries();
            Country country = new Country("USA");
            CurrencyData checkedData = new CurrencyData();
            checkedData = c.getCurrencyData(country);
            CurrencyData expectedData = new CurrencyData("Dollar", "USD", "USA", 3.86);
            Assert.AreEqual(checkedData.Name, expectedData.Name);
            Assert.AreEqual(checkedData.CurrencyCode, expectedData.CurrencyCode);
            Assert.AreEqual(checkedData.Country, expectedData.Country);

        }

        [TestMethod()]
        public void ReadFromXmlTest()
        {
            CurrencyDataService c = CurrencyDataService.Instance;
            c.ReadFromXml();
            XDocument checkedfilexml = new XDocument();
            checkedfilexml = XDocument.Load("C:\\Users\\ניצן\\Documents\\Visual Studio 2015\\Projects\\FinalProject\\FinalProject\\bin\\Debug\\currency.xml");
            Assert.IsNotNull(checkedfilexml);
        }
    }
}