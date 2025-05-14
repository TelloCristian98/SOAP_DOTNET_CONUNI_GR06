using WS_ConvUni_ConCliente.Modelo;
using WS_ConvUni_ConCliente.Vista;

namespace WS_ConvUni_ConCliente.Controlador
{
    public class ConversionControlador
    {
        private readonly ConversionModelo modelo;
        private readonly ConversionVista vista;

        public ConversionControlador()
        {
            modelo = new ConversionModelo();
            vista = new ConversionVista();
        }

        public void IniciarPrograma()
        {
            bool isAuthenticated = false;

            // Repetir login hasta que sea exitoso
            do
            {
                string usuario = vista.SolicitarTexto("Ingrese usuario: ");
                string contrasena = vista.SolicitarTexto("Ingrese contraseña: ");

                isAuthenticated = modelo.Login(usuario, contrasena);

                if (!isAuthenticated)
                {
                    vista.MostrarMensaje("Credenciales incorrectas. Por favor, intente nuevamente.\n");
                }

            } while (!isAuthenticated);

            vista.MostrarMensaje("¡Login exitoso!");

            // Menú de opciones
            while (true)
            {
                vista.MostrarMensaje("\nSeleccione una opción:");
                vista.MostrarMensaje("1. Convertir de Celsius a Fahrenheit");
                vista.MostrarMensaje("2. Convertir de Fahrenheit a Celsius");
                vista.MostrarMensaje("3. Salir");

                string opcion = vista.SolicitarTexto("Opción: ");

                if (opcion == "1")
                {
                    double celsius = vista.SolicitarDecimal("Ingrese el valor en Celsius: ");
                    double fahrenheit = modelo.CelsiusAFahrenheit(celsius);
                    vista.MostrarMensaje($"El resultado es: {fahrenheit} °F");
                }
                else if (opcion == "2")
                {
                    double fahrenheit = vista.SolicitarDecimal("Ingrese el valor en Fahrenheit: ");
                    double celsius = modelo.FahrenheitACelsius(fahrenheit);
                    vista.MostrarMensaje($"El resultado es: {celsius} °C");
                }
                else if (opcion == "3")
                {
                    vista.MostrarMensaje("Gracias por usar el programa. ¡Hasta luego!");
                    break;
                }
                else
                {
                    vista.MostrarMensaje("Opción inválida. Intente nuevamente.");
                }
            }
        }
    }
}
