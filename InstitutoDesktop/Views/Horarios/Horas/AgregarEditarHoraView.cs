﻿using InstitutoDesktop.Services;
using InstitutoServices.Interfaces;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Services;
using InstitutoServices.Services.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstitutoDesktop.Views.Horarios
{
    public partial class AgregarEditarHoraView : Form
    {
        private Hora hora;
        private readonly MemoryCacheServiceWinForms _memoryCache;

        public AgregarEditarHoraView(MemoryCacheServiceWinForms memoryCacheService)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            hora = new Hora();
        }

        public AgregarEditarHoraView(MemoryCacheServiceWinForms memoryCacheService, Hora hora)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            this.hora = hora;
            CargarDatosEnPantalla();
        }

        private async void CargarDatosEnPantalla()
        {
            txtNombre.Text = hora.Nombre;
            //definimos el valor de la fecha como actual y la hora y minutos como los de la hora
            dateTimeDesde.Value = new DateTime(1800, 1, 1, hora.Desde.Hour, hora.Desde.Minute, 0);
            dateTimeHasta.Value = new DateTime(1800, 1, 1, hora.Hasta.Hour, hora.Hasta.Minute, 0);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            LeerValoresDePantalla();

            if (hora.Id == 0)
            {
                //await horarioService.AddAsync(hora);
                await _memoryCache.AddCacheAsync<Hora>(hora, "Horas");
            }
            else
            {
                //await horarioService.UpdateAsync(hora);
                await _memoryCache.UpdateCacheAsync<Hora>(hora, "Horas");
            }

            this.Close();
        }

        private void LeerValoresDePantalla()
        {
            //obtenemos exclusivamente del datetime la hora y los minutos y definimos la fecha como 1/1/1 y los milisegundos como 0
            hora.Desde = new DateTime(1, 1, 1, dateTimeDesde.Value.Hour, dateTimeDesde.Value.Minute, 0);
            hora.Hasta = new DateTime(1, 1, 1, dateTimeHasta.Value.Hour, dateTimeHasta.Value.Minute, 0);


            txtNombre.Text = hora.Nombre;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkRecreo_CheckedChanged(object sender, EventArgs e)
        {
            LeerValoresDePantalla();
        }



        private void dateTimeDesde_Leave(object sender, EventArgs e)
        {
            LeerValoresDePantalla();
        }

        private void dateTimeHasta_Leave(object sender, EventArgs e)
        {
            LeerValoresDePantalla();
        }
    }
}
