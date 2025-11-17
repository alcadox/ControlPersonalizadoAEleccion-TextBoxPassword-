using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ControlPersonalizadoAEleccion
{
    public partial class TextBoxPassword : UserControl
    {

        private TextBox txtPassword;
        private Button btnMostrar;

        public TextBoxPassword()
        {
            InitializeComponent();
            InitializeCustomControl();
        }

        // Inicialización del control personalizado
        private void InitializeCustomControl()
        {
            // Configuración del TextBox
            txtPassword = new TextBox
            {
                UseSystemPasswordChar = true,
                Font = new Font("Segoe UI Variable", 12),
                ForeColor = Color.Black,
                BackColor = Color.White,
                Dock = DockStyle.Fill
            };
            // Añadir el TextBox al UserControl
            Controls.Add(txtPassword);

            // Configuración del botón
            btnMostrar = new Button
            {
                Width = 30,
                Dock = DockStyle.Right,
                Image = Properties.Resources.ojoAbierto,
                ImageAlign = ContentAlignment.MiddleCenter
            };

            // Ajustar el tamaño de la imagen
            btnMostrar.Image = new Bitmap(Properties.Resources.ojoAbierto, btnMostrar.Width - 10, btnMostrar.Height - 6);
            
            // Evento Click del botón
            btnMostrar.Click += BtnMostrar_Click;

            // Añadir el botón al UserControl
            Controls.Add(btnMostrar);

            // Ajustes del UserControl
            Height = txtPassword.Height;
            Width = 200;
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            var img = txtPassword.UseSystemPasswordChar ? Properties.Resources.ojoAbierto : Properties.Resources.ojoCerrado;
            btnMostrar.Image = new Bitmap(img, btnMostrar.Width - 10, btnMostrar.Height - 6);
        }

        // Propiedad para acceder al texto
        [Category("Datos")]
        [Description("Obtiene o establece el texto del cuadro de contraseña.")]
        public override string Text
        {
            get => txtPassword.Text;
            set => txtPassword.Text = value;
        }

        // Propiedad para prohibir espacios
        [Category("Comportamiento")]
        [Description("Indica si se deben prohibir los espacios dentro del control.")]
        public Boolean ProhibirEspacios
        {
            get => txtPassword.ShortcutsEnabled;
            set => txtPassword.ShortcutsEnabled = !value;
        }

        // Propiedad para establecer el máximo de caracteres
        [Category("Comportamiento")]
        [Description("Establece el número máximo de caracteres permitidos en el cuadro de contraseña.")]
        public int MaximoCaracteres
        {
            get => txtPassword.MaxLength;
            set => txtPassword.MaxLength = value;
        }
    }
}