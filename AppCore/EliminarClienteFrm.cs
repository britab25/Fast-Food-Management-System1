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
    public partial class EliminarClienteFrm : Form
    {
        public EliminarClienteFrm()
        {
            InitializeComponent();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            string numeroDocumento = txtNumeroDocumento.Text.Trim();

            if (string.IsNullOrEmpty(numeroDocumento))
            {
                MessageBox.Show("Por favor, ingrese un número de documento.");
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5263/api/Cliente/");

                    HttpResponseMessage response = await client.DeleteAsync(numeroDocumento);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cliente eliminado exitosamente.");
                        this.Close();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("No se encontró un cliente con ese número de documento.");
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error al eliminar el cliente:\n{error}");
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
