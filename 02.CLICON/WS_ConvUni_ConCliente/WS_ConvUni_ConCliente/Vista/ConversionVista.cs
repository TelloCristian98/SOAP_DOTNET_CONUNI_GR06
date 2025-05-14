using System;

namespace WS_ConvUni_ConCliente.Vista
{
    public class ConversionVista
    {
        public string SolicitarTexto(string mensaje)
        {
            Console.Write(mensaje);
            return Console.ReadLine();
        }

        public double SolicitarDecimal(string mensaje)
        {
            double numero;
            bool esValido;
            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine().Replace(',', '.');
                esValido = double.TryParse(entrada, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out numero);

                if (!esValido)
                {
                    Console.WriteLine("Entrada no válida. Asegúrese de ingresar un número válido.");
                }

            } while (!esValido);

            return numero;
        }

        public void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
