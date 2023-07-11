using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;
using Domain;

namespace Imagina
{
    public partial class AgregarServicio : Form
    {
        ServiceModel serviceModel = new ServiceModel();

        public AgregarServicio(bool agregarModificar)
        {
            InitializeComponent();
            AgregarModificar = agregarModificar;
            DiferenciarInterfaz();
        }

        public string IdServicio { get; set; }
        public bool AgregarModificar { get; set; }
        public DateTime FechaServicio { get; set; }
        private void linkCancelar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void DiferenciarInterfaz()
        {
            if (AgregarModificar)
            {
                lblTitulo.Text = "Modificar Servicio";
                btnPrincipal.Text = "Modificar";
            }
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            int tipoServicio = 0;

            if (cboTipoServicio.SelectedItem == "Mantencion")
            {
                tipoServicio = 1;
            }
            else if (cboTipoServicio.SelectedItem == "Reparacion")
            {
                tipoServicio = 2;
            }

            string idServicio = Guid.NewGuid().ToString();
            DateTime fechaServicio = FechaDisponible.Value;
            string rutTecnico = UserLoginCache.Rut;

            if (!AgregarModificar)
            {
                if (cboTipoServicio.SelectedItem != null)
                {
                    bool registrar = serviceModel.RegistrarServicio(idServicio, "", "", rutTecnico, null, fechaServicio, tipoServicio);

                    if (registrar)
                    {
                        Close();
                    }
                    else error("No se pudo registrar");
                }
                else error("Debe seleccionar un tipo de servicio");
            }
            else
            {
                if (cboTipoServicio.SelectedItem != null)
                {
                    bool modificar = serviceModel.ModificarServicio(IdServicio, fechaServicio, tipoServicio);

                    if (modificar)
                    {
                        Close();
                    }
                }
                else error("Debe seleccionar un tipo de servicio");
            }
        }

        private void error(string mensaje)
        {
            lblError.Text = "      " + mensaje;
            lblError.Visible = true;
        }
    }
}
