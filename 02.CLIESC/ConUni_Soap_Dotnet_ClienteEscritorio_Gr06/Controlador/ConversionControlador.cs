using ConUni_Soap_Dotnet_ClienteEscritorio_Gr06.ConversionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConUni_Soap_Dotnet_ClienteEscritorio_Gr06.Controlador
{
    public class ConversionControlador
    {
        private readonly ConversiónClient modelo;
        private Login loginForm;
        private Form1 conversionForm;

        public ConversionControlador(Login loginForm)
        {
            modelo = new ConversiónClient();
            this.loginForm = loginForm;
        }

        public double CelsiusToFahrenheit(double celsius)
        {
            return modelo.CelsiusToFahrenheit(celsius);
        }

        public double FahrenheitToCelsius(double fahrenheit)
        {
            return modelo.FahrenheitToCelsius(fahrenheit);
        }
    }
}
