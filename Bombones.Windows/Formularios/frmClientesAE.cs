using Bombones.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bombones.Windows.Formularios
{
    public partial class frmClientesAE : Form
    {
        private readonly IServiceProvider? _servicios;
        private Cliente? cliente;

        public frmClientesAE(IServiceProvider? servicios)
        {
            InitializeComponent();
            _servicios = servicios;
        }

        public frmClientesAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (cliente is not null)
            {
                txtDocumento.Text = cliente.Documento.ToString();
                txtApellido.Text = cliente.Apellido;
                txtNombre.Text = cliente.Nombres;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cliente is null)
            {
                cliente = new Cliente();
            }
            cliente.Nombres = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Documento = int.Parse(txtDocumento.Text);

            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        public Cliente? GetCliente()
        {
            return cliente;
        }

        public void SetCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }
    }
}
