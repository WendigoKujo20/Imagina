﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Common.Cache;

namespace Imagina
{
    public partial class Inicio : Form
    {
        bool barraLateralExpand = true;
        bool serviceCollapsed = true;
        bool gestionCollapsed = true;
        int tipoUsuario = UserLoginCache.IdTipoUsuario;
        public Inicio()
        {
            InitializeComponent();
            DiferenciarInterfaz(tipoUsuario);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void TimerBarra_Tick(object sender, EventArgs e)
        {
            if (barraLateralExpand)
            {
                BarraLateral.Width -= 10;
                if (BarraLateral.Width == BarraLateral.MinimumSize.Width)
                {
                    barraLateralExpand = false;
                    TimerBarra.Stop();
                }
            }
            else
            {
                BarraLateral.Width += 10;
                if (BarraLateral.Width == BarraLateral.MaximumSize.Width)
                {
                    barraLateralExpand = true;
                    TimerBarra.Stop();
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            TimerBarra.Start();
        }

        private void Inicio_MouseDown(object sender, MouseEventArgs e)
        {
            MoverVentanas();
        }

        private void BarraLateral_MouseDown(object sender, MouseEventArgs e)
        {
            MoverVentanas();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MoverVentanas()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            ServicesTimer.Start();
        }

        private void btnGestionar_Click(object sender, EventArgs e)
        {
            GestionTimer.Start();
        }

        private void ServicesTimer_Tick(object sender, EventArgs e)
        {
            if (serviceCollapsed)
            {
                servicesContainer.Height += 10;
                if (servicesContainer.Height == servicesContainer.MaximumSize.Height)
                {
                    serviceCollapsed = false;
                    ServicesTimer.Stop();
                }
            }
            else
            {
                servicesContainer.Height -= 10;
                if (servicesContainer.Height == servicesContainer.MinimumSize.Height)
                {
                    serviceCollapsed = true;
                    ServicesTimer.Stop();
                }
            }
        }

        private void GestionTimer_Tick(object sender, EventArgs e)
        {
            if (gestionCollapsed)
            {
                gestionContainer.Height += 10;
                if (gestionContainer.Height == gestionContainer.MaximumSize.Height)
                {
                    gestionCollapsed = false;
                    GestionTimer.Stop();
                }
            }
            else
            {
                gestionContainer.Height -= 10;
                if (gestionContainer.Height == gestionContainer.MinimumSize.Height)
                {
                    gestionCollapsed = true;
                    GestionTimer.Stop();
                }
            }
        }

        private void DiferenciarInterfaz(int tipoUsuario)
        {
            if (tipoUsuario == 1)
            {
                servicesContainer.Visible = false;
                pnlRelleno.Size = new Size(210, 265);
            }
            else if (tipoUsuario == 2)
            {
                gestionContainer.Visible = false;
                pnlRelleno.Size = new Size(210, 265);
            }
            else if (tipoUsuario == 3)
            {
                servicesContainer.Visible = false;
                gestionContainer.Visible = false;
                pnlRelleno.Size = new Size(210, 324);
            }

        }
    }
}