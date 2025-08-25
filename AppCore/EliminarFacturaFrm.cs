using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCore
{
    public partial class EliminarFacturaFrm : Form
    {
        public EliminarFacturaFrm()
        {
            InitializeComponent();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(txtFacturaId.Text.Trim(), out int facturaId))
            {
                MessageBox.Show("Ingrese un ID de factura válido.");
                return;
            }

            var confirm = MessageBox.Show("¿Estás seguro de que deseas eliminar esta factura?", "Confirmar eliminación", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/Factura/") };

                var response = await client.DeleteAsync($"EliminarFactura/{facturaId}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Factura eliminada correctamente.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Factura no encontrada.");
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Error al eliminar la factura:\n" + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:\n" + ex.Message);
            }
        }
    }
}
