using System;
using System.Windows.Forms;

namespace AppUCA.UI
{
    public partial class Form1 : Form
    {
        public bool IsLogged { get; set; }

        public Form1()
        {
            InitializeComponent();
            IsLogged = false;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            // validación de inicio de sesión 
            bool confirm =
                emailTxt.Text == "CorreoAdministrador@uca.edu.sv" &&
                passwordTxt.Text == "uca123";
            if(confirm)
            { 
                // Login logic
                IsLogged = true;
                Close();
            } 
            else
                MessageBox.Show(text: "Datos no validos!", caption: "Inscripcion de Cursos UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
