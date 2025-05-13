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
    public partial class Login : Form
    {
        private readonly ConversionControlador controlador;
        public Login()
        {
            InitializeComponent();
            controlador = new ConversionControlador(this);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string contrasena = textBox2.Text;

            if (usuario == "monster" && contrasena == "monster")
            {
                Form1 conversionForm = new Form1(controlador);
                conversionForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Intente nuevamente.");
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
