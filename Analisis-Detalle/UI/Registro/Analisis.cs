using Analisis_Detalle.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analisis_Detalle.UI.Registro
{
    public partial class Analisis : Form
    {
        public Analisis()
        {
            InitializeComponent();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int Id;
            Entidades.Analisis Analisis = new Entidades.Analisis();
            int.TryParse(IdNumericUpDown.Text, out Id);
            Limpiar();
            Analisis = AnalisisBLL.Buscar(Id);
            if (Analisis != null)
            {
                MessageBox.Show("Tipo  encontrado");
                LlenaCampo(Analisis);
            }
            else
            {
                MessageBox.Show("analisis no encontrado");
            }
        }

        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            UsuarioTextBox.Text = string.Empty;
            FechaDateTimePicker.Text = string.Empty;

        }
        private void LlenaCampo(Entidades.Analisis analisis)
        {
               IdNumericUpDown.Value = analisis.AnalisisId;
            UsuarioTextBox.Text = analisis.UsuarioId;

        }
        private Entidades.Analisis LlenaClase()
        {
            Entidades.Analisis Analisis = new Entidades.Analisis();
            Analisis.AnalisisId = Convert.ToInt32(IdNumericUpDown);
            Analisis.UsuarioId = UsuarioTextBox.Text;
            return Analisis;
        }
       

        private bool ExixteEnLaBseDeDatos()
        {
            Entidades.TiposAnalisis tiposAnalisis = new Entidades.TiposAnalisis();
            return (tiposAnalisis != null);
        }

      
        private void GuardarButton_Click_1(object sender, EventArgs e)
        {
            Entidades.Analisis Analisis;
            bool paso = false;

            Analisis = LlenaClase();
            Limpiar();
            if (IdNumericUpDown.Value == 0)
                paso = AnalisisBLL.Guardar(Analisis);
            else
            {
                if (!ExixteEnLaBseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un analisis que no exixtes", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = AnalisisBLL.Modificar(Analisis);
            }
            if (paso)
                MessageBox.Show("Guardado", "exito", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("no fue posible guardar", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void EliminarButton_Click_1(object sender, EventArgs e)
        {

            MyErrorProvider.Clear();
            int Id;
            int.TryParse(IdNumericUpDown.Text, out Id);
            Limpiar();
            if (AnalisisBLL.Eliminar(Id))
                MessageBox.Show("elimando corretamente", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IdNumericUpDown, "Nose se pudo elimimar");
        }
    }
}
