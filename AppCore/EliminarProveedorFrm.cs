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
    public partial class EliminarProveedorFrm : Form
    {
        public EliminarProveedorFrm()
        {
            InitializeComponent();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtEliminarProveedorId.Text, out int codigoProveedor))
            {
                MessageBox.Show("Por favor, ingresa un ID válido.");
                return;
            }

            var confirm = MessageBox.Show("¿Estás seguro de que deseas eliminar este proveedor?",
                                           "Confirmar eliminación",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5263/api/Proveedor/");
                    HttpResponseMessage response = await client.DeleteAsync($"EliminarProveedor/{codigoProveedor}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Proveedor eliminado correctamente.");
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("Proveedor no encontrado.");
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error al eliminar proveedor:\n{errorContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }
    }
}
