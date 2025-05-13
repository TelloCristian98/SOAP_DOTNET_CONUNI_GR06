using System.ServiceModel;
using ec.edu.monster.modelo;

namespace ec.edu.monster.controlador
{
    [ServiceContract]
    public interface IConversion
    {
        [OperationContract]
        bool Login(Credentials credentials);

        [OperationContract]
        double ConvertirCelsiusAFahrenheit(double celsius);

        [OperationContract]
        double ConvertirFahrenheitACelsius(double fahrenheit);
    }
}