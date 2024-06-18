using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Extensions;
using Bombones.Servicios.Intefaces;
using Bombones.Windows.Formularios;
using Bombones.Windows.Helpers;

namespace Bombones.Windows
{

    public partial class frmCiudades : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly IServiciosCiudades? _servicios;
        private List<CiudadListDto>? lista;
        public frmCiudades(IServiciosCiudades? servicios, IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _servicios = servicios;
            _serviceProvider = serviceProvider;
        }

        private void frmCiudades_Load(object sender, EventArgs e)
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
            frmCiudadesAE frm = new frmCiudadesAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                Ciudad? ciudad = frm.GetCiudad();
                if (ciudad is null) return;
                if (!_servicios?.Existe(ciudad) ?? false)
                {
                    _servicios?.Guardar(ciudad);
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    CiudadListDto ciudadDto = CiudadesExtensions
                        .ToCiudadListDto(ciudad);
                    GridHelper.SetearFila(r, ciudadDto);
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
            var ciudadDto = (CiudadListDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja la ciudad. {ciudadDto.NombreCiudad}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                if (!_servicios.EstaRelacionado(ciudadDto.CiudadId))
                {
                    _servicios.Borrar(ciudadDto.CiudadId);
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
            CiudadListDto ciudadDto = (CiudadListDto)r.Tag;
            Ciudad? ciudad = _servicios?.GetCiudadPorId(ciudadDto.CiudadId);
            if (ciudad is null) return;
            frmCiudadesAE frm = new frmCiudadesAE(_serviceProvider) { Text = "Editar Ciudad" };
            frm.SetCiudad(ciudad);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            ciudad = frm.GetCiudad();

            if (ciudad == null) return;
            try
            {
                if (!_servicios?.Existe(ciudad) ?? false)
                {
                    _servicios?.Guardar(ciudad);

                    ciudadDto = CiudadesExtensions
                        .ToCiudadListDto(ciudad);

                    GridHelper.SetearFila(r, ciudadDto);
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
