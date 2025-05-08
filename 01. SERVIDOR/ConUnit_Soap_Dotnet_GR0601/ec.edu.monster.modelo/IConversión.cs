using CoreWCF;
using System.ServiceModel;

namespace ConUnit_Soap_Dotnet_GR06.ec.edu.monster.modelo
{
    [ServiceContract]
    public interface IConversión
    {
        [OperationContract] double CelsiusToFahrenheit(double celsius);
        [OperationContract] double FahrenheitToCelsius(double fahrenheit);
    }

}
