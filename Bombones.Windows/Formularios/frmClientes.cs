﻿using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Extensions;
using Bombones.Servicios.Intefaces;
using Bombones.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Bombones.Windows.Formularios
{
    public partial class frmClientes : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly IServiciosClientes? _servicios;
        private List<ClienteListDto>? lista;
        public frmClientes(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            if (serviceProvider == null)
            {
                throw new ApplicationException("Dependencias no cargadas");
            }
            _servicios = serviceProvider?.GetService<IServiciosClientes>();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmClientesAE frm = new frmClientesAE();
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Cliente? cliente = frm.GetCliente();
                if (cliente == null) {return; }
                if (_servicios is null)
                {
                    throw new ApplicationException("Dependencia no cargada");
                }
                if (!_servicios.Existe(cliente))
                {
                    _servicios.Guardar(cliente);
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    ClienteListDto clienteDto = ClientesExtensions.ToClienteListDto(cliente);
                    GridHelper.SetearFila(r, clienteDto);
                    GridHelper.AgregarFila(r, dgvDatos);
                    clienteDto = ClientesExtensions.ToClienteListDto(cliente);
                    MessageBox.Show("Registro agregado",
                                    "Mensaje",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro existente\nAlta denegada",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicios?.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (lista is not null)
            {
                foreach (var c in lista)
                {
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, c);
                    GridHelper.AgregarFila(r, dgvDatos);
                }

            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag is null) return;

            var clienteDto = (ClienteListDto)r.Tag;

            try
            {
                DialogResult dr = MessageBox.Show($@"¿Desea dar de baja al cliente {clienteDto.Nombres}?",
                        "Confirmar Baja",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }

                if (dr == DialogResult.Yes)
                {
                    _servicios.Borrar(clienteDto.ClienteId);
                    GridHelper.QuitarFila(r, dgvDatos);
                    MessageBox.Show("Registro eliminado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }



                else
                {
                    MessageBox.Show("Baja Denegada",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag == null) return;
            ClienteListDto clienteDto = (ClienteListDto)r.Tag;
            Cliente? cliente = _servicios?.GetClientePorId(clienteDto.ClienteId);
            if (cliente is null) return;
            frmClientesAE frm = new frmClientesAE(_serviceProvider) { Text = "Editar Cliente" };
            frm.SetCliente(cliente);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            cliente = frm.GetCliente();

            if (cliente == null) return;
            try
            {
                if (!_servicios?.Existe(cliente) ?? false)
                {
                    _servicios?.Guardar(cliente);

                    clienteDto = ClientesExtensions.ToClienteListDto(cliente);

                    GridHelper.SetearFila(r, clienteDto);
                    MessageBox.Show("Registro editado",
                                    "Mensaje",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro existente\nEdición denegada",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                lista = _servicios?.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
