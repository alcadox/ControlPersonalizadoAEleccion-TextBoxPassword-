using System;
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
            Controls.Add(txtPassword);

            // Configuración del botón
            btnMostrar = new Button
            {
                Width = 30,
                Dock = DockStyle.Right,
                Image = Properties.Resources.ojoAbierto,
                ImageAlign = ContentAlignment.MiddleCenter
            };

            btnMostrar.Image = new Bitmap(Properties.Resources.ojoAbierto, btnMostrar.Width - 10, btnMostrar.Height - 6);
            btnMostrar.Click += BtnMostrar_Click;
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
        public override string Text
        {
            get => txtPassword.Text;
            set => txtPassword.Text = value;
        }

        public Boolean prohibirEspacios
        {
            get => txtPassword.ShortcutsEnabled;
            set => txtPassword.ShortcutsEnabled = !value;
        }

        public int maximoCaracteres
        {
            get => txtPassword.MaxLength;
            set => txtPassword.MaxLength = value;
        }
    }
}