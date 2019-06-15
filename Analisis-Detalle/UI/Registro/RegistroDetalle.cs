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
    public partial class RegistroDetalle : Form
    {
        public RegistroDetalle()
        {
            InitializeComponent();
            LlenarComboBox();
            LlenarComboBox1();
        }

        public void LlenarComboBox()
        {
            UsuarioComboBox.DataSource = null;
            UsuarioComboBox.DataSource = AnalisisBLL.GetList(x => true);
            UsuarioComboBox.ValueMember = "AnalisisId";
            UsuarioComboBox.DisplayMember = "Fecha";
            UsuarioComboBox.ValueMember = "UsuarioId";
        }
        public void LlenarComboBox1()
        {
            TipoAnalisisComboBox.DataSource = null;
            TipoAnalisisComboBox.DataSource = TiposAnalisisBLL.GetList(x => true);
            TipoAnalisisComboBox.ValueMember = "TipoId";
            TipoAnalisisComboBox.DisplayMember = "Descripcion";
        }
        
    
    }
}
