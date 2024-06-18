using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Extensions;
using Bombones.Servicios.Intefaces;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmFabricas : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly IServiciosFabricas? _servicios;
        private List<FabricaListDto>? lista;
        public frmFabricas(IServiciosFabricas? servicios, IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _servicios = servicios;
            _serviceProvider = serviceProvider;
        }

        private void frmFabricas_Load(object sender, EventArgs e)
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmFabricasAE frm = new frmFabricasAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                Fabrica? fabrica = frm.GetFabrica();
                if (fabrica is null) return;
                if (!_servicios?.Existe(fabrica) ?? false)
                {
                    _servicios?.Guardar(fabrica);
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    FabricaListDto fabricaDto = FabricaExtensions
                        .ToFabricaListDto(fabrica);
                    GridHelper.SetearFila(r, fabricaDto);
                    GridHelper.AgregarFila(r, dgvDatos);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

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
            var fabricaDto = (FabricaListDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja la fabrica. {fabricaDto.NombreCiudad}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                if (!_servicios.EstaRelacionado(fabricaDto.FabricaId))
                {
                    _servicios.Borrar(fabricaDto.FabricaId);
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
            if (r.Tag == null) return;
            FabricaListDto fabricaDto = (FabricaListDto)r.Tag;
            Fabrica? fabrica = _servicios?.GetFabricaPorId(fabricaDto.FabricaId);
            if (fabrica is null) return;
            frmFabricasAE frm = new frmFabricasAE(_serviceProvider) { Text = "Editar Fabrica" };
            frm.SetFabrica(fabrica);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            fabrica = frm.GetFabrica();

            if (fabrica == null) return;
            try
            {
                if (!_servicios?.Existe(fabrica) ?? false)
                {
                    _servicios?.Guardar(fabrica);

                    fabricaDto = FabricaExtensions.ToFabricaListDto(fabrica);

                    GridHelper.SetearFila(r, fabricaDto);
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

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
