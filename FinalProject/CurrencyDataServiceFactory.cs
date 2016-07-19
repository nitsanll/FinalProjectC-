namespace FinalProject
{
    //the services that are supported by the system
    public enum DataServices { OPEN_CURRENCIES_MAP };

    public class CurrencyDataServiceFactory
    {
        //returns a single specific currency data service
        public static ICurrencyDataService GetCurrencyDataService(DataServices service)
        {
            switch (service)
            {
                case DataServices.OPEN_CURRENCIES_MAP:
                    return CurrencyDataService.Instance;
                
                default:
                    throw new CurrencyDataServiceException("no such service supported");
            }
        }
    }
}
