namespace FinalProject
{
    //class contains the currency data
    public class CurrencyData
    {
        private string name, currencyCode, country; 
        private double rate;

        public CurrencyData(string Name, string CurrencyCode, string Country, double Rate)
        {
            name = Name;
            currencyCode = CurrencyCode;
            country = Country;
            rate = Rate;
        }

        public CurrencyData()
        {
            name = Name;
            currencyCode = CurrencyCode;
            country = Country;
            rate = Rate;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string CurrencyCode
        {
            get { return currencyCode; }
            set { currencyCode = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public string toString()
        {
            return "Name = " + Name + "\n" +
                "CurrencyCode = " + CurrencyCode + "\n" + 
                "Rate = " + Rate + "\n";
        }
    }
}
