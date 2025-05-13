using ConUni_Soap_Dotnet_ClienteEscritorio_Gr06.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConUni_Soap_Dotnet_ClienteEscritorio_Gr06
{
    public partial class Form1 : Form
    {
        private readonly ConversionControlador controlador;
        public Form1(ConversionControlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out double celsius))
            {
                double fahrenheit = controlador.CelsiusToFahrenheit(celsius);
                label4.Text = "El resultado es: " + fahrenheit.ToString("F2") + " grados fahrenheit";
            }
            else
            {
                MessageBox.Show("Entrada no válida. Ingrese un número válido.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox2.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out double fahrenheit))
            {
                double celsius = controlador.FahrenheitToCelsius(fahrenheit);
                label7.Text = "El resultado es: " + celsius.ToString("F2") + " grados celsius";
            }
            else
            {
                MessageBox.Show("Entrada no válida. Ingrese un número válido.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            label7.Text = "";
        }
    }
}
