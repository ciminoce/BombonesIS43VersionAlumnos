namespace Bombones.Windows.Formularios
{
    partial class frmClientesAE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientesAE));
            label4 = new Label();
            label3 = new Label();
            btnCancelar = new Button();
            btnOk = new Button();
            txtApellido = new TextBox();
            txtDocumento = new TextBox();
            txtNombre = new TextBox();
            label6 = new Label();
            tabCliente = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            dataGridView1 = new DataGridView();
            tabPage3 = new TabPage();
            colCalle = new DataGridViewTextBoxColumn();
            colPais = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colCiudad = new DataGridViewTextBoxColumn();
            colDetalle = new DataGridViewButtonColumn();
            btnAgregarDireccion = new Button();
            btnBorrarDireccion = new Button();
            btnEditarDireccion = new Button();
            splitContainer1 = new SplitContainer();
            dataGridView2 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            label1 = new Label();
            textBox1 = new TextBox();
            cboTipoTelefono = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            tabCliente.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 63);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 40;
            label4.Text = "Apellido:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 18);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 41;
            label3.Text = "Documento:";
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(462, 488);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 54);
            btnCancelar.TabIndex = 36;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(50, 488);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(289, 54);
            btnOk.TabIndex = 35;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(135, 60);
            txtApellido.MaxLength = 50;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(412, 23);
            txtApellido.TabIndex = 31;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(135, 15);
            txtDocumento.MaxLength = 8;
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(148, 23);
            txtDocumento.TabIndex = 30;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(135, 103);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(412, 23);
            txtNombre.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 106);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 40;
            label6.Text = "Nombre:";
            // 
            // tabCliente
            // 
            tabCliente.Controls.Add(tabPage1);
            tabCliente.Controls.Add(tabPage2);
            tabCliente.Controls.Add(tabPage3);
            tabCliente.Location = new Point(12, 23);
            tabCliente.Name = "tabCliente";
            tabCliente.SelectedIndex = 0;
            tabCliente.Size = new Size(934, 415);
            tabCliente.TabIndex = 42;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(txtDocumento);
            tabPage1.Controls.Add(txtApellido);
            tabPage1.Controls.Add(txtNombre);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(926, 387);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Datos Cliente";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Controls.Add(btnEditarDireccion);
            tabPage2.Controls.Add(btnBorrarDireccion);
            tabPage2.Controls.Add(btnAgregarDireccion);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(926, 387);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Direcciones";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colCalle, colPais, colEstado, colCiudad, colDetalle });
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(920, 278);
            dataGridView1.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(splitContainer1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(926, 387);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Teléfonos";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // colCalle
            // 
            colCalle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCalle.HeaderText = "Calle";
            colCalle.Name = "colCalle";
            colCalle.ReadOnly = true;
            // 
            // colPais
            // 
            colPais.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPais.HeaderText = "País";
            colPais.Name = "colPais";
            colPais.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // colCiudad
            // 
            colCiudad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCiudad.HeaderText = "Ciudad";
            colCiudad.Name = "colCiudad";
            colCiudad.ReadOnly = true;
            // 
            // colDetalle
            // 
            colDetalle.HeaderText = "Detalle";
            colDetalle.Name = "colDetalle";
            colDetalle.ReadOnly = true;
            // 
            // btnAgregarDireccion
            // 
            btnAgregarDireccion.Image = Properties.Resources.add_28px;
            btnAgregarDireccion.Location = new Point(19, 301);
            btnAgregarDireccion.Name = "btnAgregarDireccion";
            btnAgregarDireccion.Size = new Size(119, 54);
            btnAgregarDireccion.TabIndex = 35;
            btnAgregarDireccion.Text = "Ok";
            btnAgregarDireccion.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAgregarDireccion.UseVisualStyleBackColor = true;
            // 
            // btnBorrarDireccion
            // 
            btnBorrarDireccion.Image = Properties.Resources.delete_sign_28px;
            btnBorrarDireccion.Location = new Point(144, 301);
            btnBorrarDireccion.Name = "btnBorrarDireccion";
            btnBorrarDireccion.Size = new Size(119, 54);
            btnBorrarDireccion.TabIndex = 35;
            btnBorrarDireccion.Text = "Ok";
            btnBorrarDireccion.TextImageRelation = TextImageRelation.ImageAboveText;
            btnBorrarDireccion.UseVisualStyleBackColor = true;
            // 
            // btnEditarDireccion
            // 
            btnEditarDireccion.Image = Properties.Resources.edit_28px1;
            btnEditarDireccion.Location = new Point(269, 301);
            btnEditarDireccion.Name = "btnEditarDireccion";
            btnEditarDireccion.Size = new Size(119, 54);
            btnEditarDireccion.TabIndex = 35;
            btnEditarDireccion.Text = "Ok";
            btnEditarDireccion.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEditarDireccion.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(button3);
            splitContainer1.Panel1.Controls.Add(cboTipoTelefono);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(textBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridView2);
            splitContainer1.Size = new Size(920, 381);
            splitContainer1.SplitterDistance = 103;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewButtonColumn1 });
            dataGridView2.Location = new Point(0, -2);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.Size = new Size(920, 278);
            dataGridView2.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.HeaderText = "Calle";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.HeaderText = "País";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn3.HeaderText = "Estado";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn4.HeaderText = "Ciudad";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewButtonColumn1.HeaderText = "Detalle";
            dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            dataGridViewButtonColumn1.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 46);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 43;
            label1.Text = "Teléfono:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(141, 43);
            textBox1.MaxLength = 8;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(311, 23);
            textBox1.TabIndex = 42;
            // 
            // cboTipoTelefono
            // 
            cboTipoTelefono.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoTelefono.FormattingEnabled = true;
            cboTipoTelefono.Location = new Point(141, 11);
            cboTipoTelefono.Name = "cboTipoTelefono";
            cboTipoTelefono.Size = new Size(311, 23);
            cboTipoTelefono.TabIndex = 49;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 14);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 50;
            label2.Text = "Tipo Teléfono:";
            // 
            // button1
            // 
            button1.Image = Properties.Resources.edit_28px1;
            button1.Location = new Point(750, 12);
            button1.Name = "button1";
            button1.Size = new Size(119, 54);
            button1.TabIndex = 51;
            button1.Text = "Ok";
            button1.TextImageRelation = TextImageRelation.ImageAboveText;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.delete_sign_28px;
            button2.Location = new Point(625, 12);
            button2.Name = "button2";
            button2.Size = new Size(119, 54);
            button2.TabIndex = 52;
            button2.Text = "Ok";
            button2.TextImageRelation = TextImageRelation.ImageAboveText;
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Image = Properties.Resources.add_28px;
            button3.Location = new Point(500, 12);
            button3.Name = "button3";
            button3.Size = new Size(119, 54);
            button3.TabIndex = 53;
            button3.Text = "Ok";
            button3.TextImageRelation = TextImageRelation.ImageAboveText;
            button3.UseVisualStyleBackColor = true;
            // 
            // frmClientesAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(971, 566);
            Controls.Add(tabCliente);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Name = "frmClientesAE";
            Text = "frmClientesAE";
            tabCliente.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage3.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label4;
        private Label label3;
        private Button btnCancelar;
        private Button btnOk;
        private TextBox txtApellido;
        private TextBox txtDocumento;
        private TextBox txtNombre;
        private Label label6;
        private TabControl tabCliente;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private TabPage tabPage3;
        private DataGridViewTextBoxColumn colCalle;
        private DataGridViewTextBoxColumn colPais;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colCiudad;
        private DataGridViewButtonColumn colDetalle;
        private Button btnAgregarDireccion;
        private Button btnEditarDireccion;
        private Button btnBorrarDireccion;
        private SplitContainer splitContainer1;
        private Label label1;
        private TextBox textBox1;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewButtonColumn dataGridViewButtonColumn1;
        private ComboBox cboTipoTelefono;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}