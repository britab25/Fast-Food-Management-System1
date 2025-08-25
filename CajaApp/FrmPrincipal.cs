using System;
using System.Windows.Forms;

namespace CajaApp
{
    public partial class FrmPrincipal : Form
    {
        private readonly string _nombreCajero;
        private readonly string _token;
        private readonly int _usuarioId;
        private int aperturaId;

        public FrmPrincipal(string nombreCajero, string token, int usuarioId)
        {
            InitializeComponent();
            _nombreCajero = nombreCajero;
            _token = token;
            _usuarioId = usuarioId;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = $"Principal - Usuario: {_nombreCajero} (ID: {_usuarioId})";
            // Aquí puedes usar _token o _usuarioId según necesites en el formulario.
            timer1.Start();
        }

        // Ejemplo de uso en botones:


        private void btnVender_Click_1(object sender, EventArgs e)
        {
            var form = new FrmVentaFritura(_token);
            form.ShowDialog();
        }

        private void btnImprimirRecibo_Click(object sender, EventArgs e)
        {
            var form = new FrmImprimirRecibo(_nombreCajero, _token, _usuarioId);
            form.ShowDialog();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            var form = new FrmHistorialDia(_token);
            form.ShowDialog();
        }

        private void btnCierreDia_Click(object sender, EventArgs e)
        {
            var form = new FrmCierreDia(_nombreCajero, _token, _usuarioId, aperturaId);
            form.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }
    }
}
