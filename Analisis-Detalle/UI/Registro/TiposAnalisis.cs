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
    public partial class TiposAnalisis : Form
    {
        public TiposAnalisis()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            TipoIdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = string.Empty;

        }
        private void LlenaCampo (Entidades.TiposAnalisis tiposAnalisis)
        {
            TipoIdNumericUpDown.Value=tiposAnalisis.TiposId;
            DescripcionTextBox.Text = tiposAnalisis.Descripcion;

        }
        private  Entidades.TiposAnalisis LlenaClase()
        {
            Entidades.TiposAnalisis tiposAnalisis = new Entidades.TiposAnalisis();
            tiposAnalisis.TiposId = Convert.ToInt32(TipoIdNumericUpDown);
            tiposAnalisis.Descripcion = DescripcionTextBox.Text;
            return tiposAnalisis;
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private bool ExixteEnLaBseDeDatos()
        {
            Entidades.TiposAnalisis tiposAnalisis = new Entidades.TiposAnalisis();
            return (tiposAnalisis != null);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
            int Id;
            int.TryParse(TipoIdNumericUpDown.Text, out Id);
            Limpiar();
            if (TiposAnalisisBLL.Eliminar(Id))
                MessageBox.Show("elimando corretamente", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(TipoIdNumericUpDown, "Nose se pudo elimimar");
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int Id;
            Entidades.TiposAnalisis tiposAnalisis = new Entidades.TiposAnalisis();
            int.TryParse(TipoIdNumericUpDown.Text, out Id);
            Limpiar();
            tiposAnalisis = TiposAnalisisBLL.Buscar(Id);
            if (tiposAnalisis != null)
            {
                MessageBox.Show("Tipo  encontrado");
                LlenaCampo(tiposAnalisis);
            }
            else
            {
                MessageBox.Show("analisis no encontrado");
            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Entidades.TiposAnalisis tiposAnalisis;
            bool paso = false;

            tiposAnalisis = LlenaClase();
            Limpiar();
            if (TipoIdNumericUpDown.Value == 0)
                paso = TiposAnalisisBLL.Guardar(tiposAnalisis);
            else
            {
                if (!ExixteEnLaBseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un analisis que no exixtes", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = TiposAnalisisBLL.Modificar(tiposAnalisis);
            }
            if (paso)
                MessageBox.Show("Guardado", "exito", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("no fue posible guardar", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
