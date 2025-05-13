using ConUni_Soap_Dotnet_ClienteEscritorio_Gr06.ConversionServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConUni_Soap_Dotnet_ClienteEscritorio_Gr06.Modelo
{
    public class ConversionModelo
    {
        private ConversionClient _client;

        public ConversionModelo()
        {
            _client = new ConversionClient();
        }

        public double ConvertirCelsiusAFahrenheitAsync(double celsius)
        {
            return _client.ConvertirCelsiusAFahrenheit(celsius);
        }

        public double ConvertirFahrenheitACelsiusAsync(double fahrenheit)
        {
            return _client.ConvertirFahrenheitACelsius(fahrenheit);
        }
    }
}
