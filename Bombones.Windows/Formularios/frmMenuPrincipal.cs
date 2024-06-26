using Bombones.Servicios.Intefaces;
using Bombones.Windows.Formularios;
using Microsoft.Extensions.DependencyInjection;

namespace Bombones.Windows
{
    public partial class frmMenuPrincipal : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        public frmMenuPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        private void btnChocolates_Click(object sender, EventArgs e)
        {
            var frm = new frmChocolates(_serviceProvider);   // Crea frm, un objeto del tipo formulario frmChocolates
            frm.ShowDialog();       // muestra frm de forma modal
        }

        private void btnPaises_Click(object sender, EventArgs e)
        {
            var frm = new frmPaises(_serviceProvider);
            frm.ShowDialog();
        }

        private void btnRellenos_Click(object sender, EventArgs e)
        {
            var frm = new frmRellenos(
                _serviceProvider
                .GetService<IServiciosTiposDeRellenos>());
            frm.ShowDialog();
        }

        private void btnNueces_Click(object sender, EventArgs e)
        {
            var frm = new frmNueces(
                _serviceProvider
                .GetService<IServiciosTiposDeNueces>());
            frm.ShowDialog();
        }

        private void btnProvinciasEstados_Click(object sender, EventArgs e)
        {
            var frm = new frmProvinciasEstados(
                _serviceProvider
                .GetService<IServiciosProvinciasEstados>(),
                _serviceProvider);
            frm.ShowDialog();
        }

        private void btnCiudades_Click(object sender, EventArgs e)
        {
            var frm = new frmCiudades(
                    _serviceProvider.GetService<IServiciosCiudades>(),
                    _serviceProvider);
            frm.ShowDialog();

        }

        private void btnFabricas_Click(object sender, EventArgs e)
        {
            var frm = new frmFabricas(
        _serviceProvider.GetService<IServiciosFabricas>(),
        _serviceProvider);
            frm.ShowDialog();

        }
    }
}
