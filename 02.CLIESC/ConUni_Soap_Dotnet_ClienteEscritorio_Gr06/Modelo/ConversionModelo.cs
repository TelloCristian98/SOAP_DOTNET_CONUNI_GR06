using ConUni_Soap_Dotnet_ClienteEscritorio_Gr06.ConversionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConUni_Soap_Dotnet_ClienteEscritorio_Gr06.Modelo
{
    public class ConversionModelo
    {
        private ConversiónClient _client;

        public ConversionModelo()
        {
            _client = new ConversiónClient();
        }

        public double CelsiusToFahrenheit(double celsius)
        {
            return _client.CelsiusToFahrenheit(celsius);
        }

        public double FahrenheitToCelsius(double fahrenheit)
        {
            return _client.FahrenheitToCelsius(fahrenheit);
        }
    }
}
