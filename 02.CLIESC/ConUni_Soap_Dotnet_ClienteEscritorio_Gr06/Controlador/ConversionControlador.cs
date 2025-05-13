using ConUni_Soap_Dotnet_ClienteEscritorio_Gr06.ConversionServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConUni_Soap_Dotnet_ClienteEscritorio_Gr06.Controlador
{
    public class ConversionControlador
    {
        private readonly ConversionClient modelo;
        private Login loginForm;
        private Form1 conversionForm;

        public ConversionControlador(Login loginForm)
        {
            modelo = new ConversionClient();
            this.loginForm = loginForm;
        }

        public double ConvertirCelsiusAFahrenheitAsync(double celsius)
        {
            return modelo.ConvertirCelsiusAFahrenheit(celsius);
        }

        public double ConvertirFahrenheitACelsiusAsync(double fahrenheit)
        {
            return modelo.ConvertirFahrenheitACelsius(fahrenheit);
        }
    }
}
