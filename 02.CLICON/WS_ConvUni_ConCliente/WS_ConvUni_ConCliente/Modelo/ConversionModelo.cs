using System.Net;
using WS_ConvUni_ConCliente.ConversionServiceReference;

namespace WS_ConvUni_ConCliente.Modelo
{
    public class ConversionModelo
    {
        private ConversionClient _client;

        public ConversionModelo()
        {
            _client = new ConversionClient();
        }

        public bool Login(string usuario, string contrasena)
        {
            var credenciales = new Credentials
            {
                Username = usuario,
                Password = contrasena
            };
            return _client.Login(credenciales);
        }

        public double CelsiusAFahrenheit(double celsius)
        {
            return _client.ConvertirCelsiusAFahrenheit(celsius);
        }

        public double FahrenheitACelsius(double fahrenheit)
        {
            return _client.ConvertirFahrenheitACelsius(fahrenheit);
        }
    }
}
