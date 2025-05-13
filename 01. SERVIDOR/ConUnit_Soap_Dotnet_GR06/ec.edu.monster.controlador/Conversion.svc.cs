using System;
using ec.edu.monster.modelo;

namespace ec.edu.monster.controlador
{
    public class Conversion : IConversion
    {
        private bool isAuthenticated = false;

        public bool Login(Credentials credentials)
        {
            // Verifica las credenciales (usuario: monster, contraseña: monster)
            if (credentials != null &&
                credentials.Username == "monster" &&
                credentials.Password == "monster")
            {
                isAuthenticated = true;
                return true;
            }
            isAuthenticated = false;
            return false;
        }

        public double ConvertirCelsiusAFahrenheit(double celsius)
        {
            // Verifica si el usuario está autenticado
            //if (!isAuthenticated)
            //{
            //    throw new UnauthorizedAccessException("Acceso no autorizado. Debe iniciar sesión primero.");
            //}
            return (celsius * 9 / 5) + 32;
        }

        public double ConvertirFahrenheitACelsius(double fahrenheit)
        {
            // Verifica si el usuario está autenticado
            //if (!isAuthenticated)
            //{
            //    throw new UnauthorizedAccessException("Acceso no autorizado. Debe iniciar sesión primero.");
            //}
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}