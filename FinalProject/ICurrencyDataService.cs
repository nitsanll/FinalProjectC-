namespace FinalProject
{
    public interface ICurrencyDataService
    {
        CurrencyData getCurrencyData(Country country);
        void getAllCountries();
        void ReadFromXml();
    }
}
