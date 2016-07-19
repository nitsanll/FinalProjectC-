namespace FinalProject
{
    //class representing a country
    public class Country
    {
        private string countryName;

        public Country(string CountryName)
        {
            countryName = CountryName;
        }

        public Country()
        {
            countryName = CountryName;
        }

        public string CountryName
        {
            get { return countryName; }
            set { countryName = value; }
        }

        public string toString()
        {
            return "Country: " + CountryName;
        }
    }
}
