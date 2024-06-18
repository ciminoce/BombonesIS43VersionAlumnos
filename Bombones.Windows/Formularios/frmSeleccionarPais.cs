using Bombones.Entidades.Entidades;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmSeleccionarPais : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Pais? paisSeleccionado;
        public frmSeleccionarPais(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        public Pais? GetPais()
        {
            return paisSeleccionado;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper
                .CargarComboPaises(ref cboPaises, _serviceProvider);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboPaises.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar un país");
            }
            return valido;
        }

        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            paisSeleccionado = (Pais?)cboPaises.SelectedItem ?? null;
        }
    }
}
