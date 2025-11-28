using System;
using System.Drawing;
using System.Drawing.Drawing2D; 
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.Data.SqlClient; 
using BE;
using BLL;
using growshiUI.UsuarioForms; 

namespace growshiUI
{
    public partial class Login : MetroForm
    {
        #region Campos y Propiedades

        private readonly UsuarioBLL usuarioBLL;
        public Usuario UsuarioLogueado { get; private set; }

        public int IntentosLoginContador = 0;
        private int segundosRestantes;

        #endregion

        #region Constructor e Inicialización

        public Login()
        {
            InitializeComponent();
            usuarioBLL = new UsuarioBLL();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            CentrarTarjeta();
            RedondearControl(panelTarjeta, 30);         
            RedondearControl(buttonIniciarSesion, 20);  
            RedondearControl(pictureBoxLogo, 100);      

            this.Refresh();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.textBoxUsuario.Focus();
        }

        #endregion

        #region Lógica de Diseño (UI)

        private void panelFondo_Paint(object sender, PaintEventArgs e)
        {
            Color colorArriba = Color.FromArgb(30, 60, 40);
            Color colorAbajo = Color.FromArgb(50, 160, 100);

            using (LinearGradientBrush brush = new LinearGradientBrush(this.panelFondo.ClientRectangle, colorArriba, colorAbajo, 65F))
            {
                e.Graphics.FillRectangle(brush, this.panelFondo.ClientRectangle);
            }
        }

        private void panelFondo_Resize(object sender, EventArgs e)
        {
            CentrarTarjeta();
            this.panelFondo.Invalidate(); 
        }

        private void CentrarTarjeta()
        {
            if (panelTarjeta != null && panelFondo != null)
            {
                panelTarjeta.Location = new Point(
                    (panelFondo.Width - panelTarjeta.Width) / 2,
                    (panelFondo.Height - panelTarjeta.Height) / 2
                );
            }
        }

        private void RedondearControl(Control control, int radio)
        {
            Rectangle bounds = new Rectangle(0, 0, control.Width, control.Height);
            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, radio, radio, 180, 90);
            path.AddArc(bounds.X + bounds.Width - radio, bounds.Y, radio, radio, 270, 90);
            path.AddArc(bounds.X + bounds.Width - radio, bounds.Y + bounds.Height - radio, radio, radio, 0, 90);
            path.AddArc(bounds.X, bounds.Y + bounds.Height - radio, radio, radio, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);
        }

        #endregion

        #region Lógica de Negocio (Login)

        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        
        {
            string usuario = textBoxUsuario.Text;
            string password = textBoxContraseña.Text;

            // Validación básica
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MetroMessageBox.Show(this, "Por favor completa todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UsuarioLogueado = usuarioBLL.Login(usuario, password);

                if (UsuarioLogueado != null)
                {
                    IntentosLoginContador = 0;

                    MetroMessageBox.Show(this,
                        $"¡Bienvenido, {UsuarioLogueado.NombreUsuario}!",
                        "Login Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Question);

                    this.DialogResult = DialogResult.OK;

                    this.Hide();

                    InicioUsuario inicioUsuario = new InicioUsuario();
                    inicioUsuario.ShowDialog();

                    this.Close();
                }
                else
                {
                    ManejarFallo();
                }
            }
            catch (CuentaBloqueadaException ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Cuenta Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BloquearForm();
            }
            catch (ArgumentException ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Datos Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                MetroMessageBox.Show(this,
                    $"Error de conexión con la base de datos.\n\nDetalle: {ex.Message}",
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Error técnico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManejarFallo()
        {
            IntentosLoginContador++;
            MetroMessageBox.Show(this, "Credenciales incorrectas.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (IntentosLoginContador >= 3)
            {
                BloquearForm();
            }
        }

        private void buttonOlvideMiContraseña_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "Contacte a Soporte Técnico.", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Lógica de Seguridad (Bloqueo)

        public void BloquearForm()
        {
            segundosRestantes = 5;

            textBoxUsuario.Enabled = false;
            textBoxContraseña.Enabled = false;
            buttonIniciarSesion.Enabled = false;
            buttonIniciarSesion.BackColor = Color.Gray;
            buttonIniciarSesion.Text = "ESPERE...";

            progressBar.Visible = true;
            progressBar.Maximum = 5;
            progressBar.Value = 5;

            temporizadorBloqueo.Start();
        }

        private void temporizadorBloqueo_Tick(object sender, EventArgs e)
        {
            segundosRestantes--;

            if (segundosRestantes >= 0)
                progressBar.Value = segundosRestantes;

            if (segundosRestantes <= 0)
            {
                temporizadorBloqueo.Stop();

                // Reactivar controles
                textBoxUsuario.Enabled = true;
                textBoxContraseña.Enabled = true;
                buttonIniciarSesion.Enabled = true;

                buttonIniciarSesion.BackColor = Color.FromArgb(76, 175, 80);
                buttonIniciarSesion.Text = "INICIAR SESIÓN";

                progressBar.Visible = false;
                textBoxUsuario.Focus();
            }
        }

        #endregion
    }
}