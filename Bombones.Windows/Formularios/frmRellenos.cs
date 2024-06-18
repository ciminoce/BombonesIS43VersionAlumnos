using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmRellenos : Form
    {
        private readonly IServiciosTiposDeRellenos _servicio;
        private List<TipoDeRelleno>? lista;
        public frmRellenos(IServiciosTiposDeRellenos servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private void frmRellenos_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicio.GetLista();
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
                foreach (var tipo in lista)
                {
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, tipo);
                    GridHelper.AgregarFila(r, dgvDatos);
                }

            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDeRelleno tipo)
        {
            r.Cells[colRelleno.Index].Value = tipo.Descripcion;

            r.Tag = tipo;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmRellenosAE frm = new frmRellenosAE() { Text = "Agregar Relleno" };
            DialogResult dr = frm.ShowDialog(this);
            try
            {
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                TipoDeRelleno? tipo = frm.GetRelleno();
                if (tipo is null) return;
                if (!_servicio.Existe(tipo))
                {
                    _servicio.Guardar(tipo);
                    DataGridViewRow r = ConstruirFila();
                    SetearFila(r, tipo);
                    AgregarFila(r);
                    MessageBox.Show("Registro agregado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("País Duplicado!!!",
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
            TipoDeRelleno tipo = (TipoDeRelleno)r.Tag;
            try
            {
                DialogResult dr = MessageBox.Show($@"¿Desea dar de baja el tipo {tipo.Descripcion}?",
                        "Confirmar Baja",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }
                if (!_servicio.EstaRelacionado(tipo.TipoDeRellenoId))
                {
                    _servicio.Borrar(tipo.TipoDeRellenoId);
                    QuitarFila(r);
                    MessageBox.Show("Registro eliminado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Registro relacionado\nBaja Denegada",
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

        private void QuitarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag is null) return;
            TipoDeRelleno? tipo = (TipoDeRelleno)r.Tag;
            frmRellenosAE frm = new frmRellenosAE() { Text = "Editar Nuez" };
            frm.SetRelleno(tipo);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            tipo = frm.GetRelleno();
            if (tipo is null) return;
            try
            {
                if (!_servicio.Existe(tipo))
                {
                    _servicio.Guardar(tipo);

                    SetearFila(r, tipo);
                    MessageBox.Show("Registro modificado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("País Duplicado!!!",
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
