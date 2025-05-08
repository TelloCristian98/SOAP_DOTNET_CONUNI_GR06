using System;
using System.ServiceModel;
using ConUnit_Soap_Dotnet_GR06.ec.edu.monster.modelo;

namespace ConUnit_Soap_Dotnet_GR06.ec.edu.monster.controlador
{
    public class Conversión : IConversión
    {
        public double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        public double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}