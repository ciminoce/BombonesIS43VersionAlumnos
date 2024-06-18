using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using Bombones.Entidades.Extensions;
using Bombones.Servicios.Intefaces;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmProvinciasEstados : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly IServiciosProvinciasEstados _servicios;
        private List<ProvinciaEstadoListDto>? lista;
        private Orden orden = Orden.Ninguno;
        public frmProvinciasEstados(IServiciosProvinciasEstados servicios,
                IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _servicios = servicios;
            _serviceProvider = serviceProvider;
        }

        private void frmProvinciasEstados_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicios.GetLista();
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
                foreach (var item in lista)
                {
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, item);
                    GridHelper.AgregarFila(r, dgvDatos);
                }

            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmProvinciasEstadosAE frm = new frmProvinciasEstadosAE(_serviceProvider)
            { Text = "Agregar Prov./Estado" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                ProvinciaEstado pe = frm.GetProvEstado();
                if (!_servicios.Existe(pe))
                {
                    _servicios.Guardar(pe);
                    ProvinciaEstadoListDto peDto = ProvinciaEstadoExtensions
                        .ToListDto(pe);
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, peDto);
                    GridHelper.AgregarFila(r, dgvDatos);
                    MessageBox.Show("Registro agregado satisfactoriamente!!!");
                }
                else
                {
                    MessageBox.Show("Registro duplicado!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                throw;
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
            var peDto = (ProvinciaEstadoListDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el/la estado/pcia. {peDto.NombreProvinciaEstado}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                if (!_servicios.EstaRelacionado(peDto.ProvinciaEstadoId))
                {
                    _servicios.Borrar(peDto.ProvinciaEstadoId);
                    GridHelper.QuitarFila(r, dgvDatos);
                    MessageBox.Show("Registro eliminado!!", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro relacionado!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag is null) return;
            var peDto = (ProvinciaEstadoListDto)r.Tag;
            var pe = _servicios.GetProvinciaEstadoPorId(peDto.ProvinciaEstadoId); ;
            if (pe is null) return;
            frmProvinciasEstadosAE frm = new frmProvinciasEstadosAE(_serviceProvider) { Text = "Editar Prov/Estado" };
            frm.SetProvEstado(pe);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                pe = frm.GetProvEstado();
                if (pe is null) return;
                if (!_servicios.Existe(pe))
                {
                    _servicios.Guardar(pe);
                    GridHelper.SetearFila(r, ProvinciaEstadoExtensions
                        .ToListDto(pe));

                    MessageBox.Show("Registro editado!!", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro existente!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            frmSeleccionarPais frm = new frmSeleccionarPais(_serviceProvider) { Text = "Seleccionar Pais para Filtrar" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            var paisSeleccionado = frm.GetPais();
            if (paisSeleccionado is null) return;

            lista = _servicios.GetLista(orden, paisSeleccionado);
            MostrarDatosEnGrilla();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            lista = _servicios.GetLista();
            MostrarDatosEnGrilla();
        }


        private void aZPorPaísToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orden = Orden.PaisAZ;
            lista = _servicios.GetLista(orden);
            MostrarDatosEnGrilla();

        }
    }
}
