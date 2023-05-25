using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imagina
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            agregarDiaAnio();
        }

        private void agregarDiaAnio()
        {
            int anio = DateTime.Now.Year;
            int anioMinimo = anio - 123;
            for (int i = 1; i <= 31; i++)
            {
                cmbDia.Items.Add(i);
            }
            for (int i = anio; i >= anioMinimo; i--)
            {
                cmbAnio.Items.Add(i);
            }
        }
    }
}
