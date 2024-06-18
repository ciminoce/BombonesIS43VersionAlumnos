namespace Bombones.Windows.Formularios
{
    partial class frmFabricas
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFabricas));
            panel1 = new Panel();
            dgvDatos = new DataGridView();
            colFabrica = new DataGridViewTextBoxColumn();
            colDireccion = new DataGridViewTextBoxColumn();
            colCiudad = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colPais = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbBorrar = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbFiltrar = new ToolStripButton();
            tsbActualizar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbImprimir = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            tsbOrdenar = new ToolStripDropDownButton();
            aZPorPaísToolStripMenuItem = new ToolStripMenuItem();
            aZPorEstadoToolStripMenuItem = new ToolStripMenuItem();
            zAPorPaísToolStripMenuItem = new ToolStripMenuItem();
            zAPorEstadoToolStripMenuItem = new ToolStripMenuItem();
            tsbCerrar = new ToolStripButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvDatos);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 62);
            panel1.Name = "panel1";
            panel1.Size = new Size(1018, 388);
            panel1.TabIndex = 7;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colFabrica, colDireccion, colCiudad, colEstado, colPais });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(1018, 388);
            dgvDatos.TabIndex = 0;
            // 
            // colFabrica
            // 
            colFabrica.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFabrica.HeaderText = "Fábrica";
            colFabrica.Name = "colFabrica";
            colFabrica.ReadOnly = true;
            // 
            // colDireccion
            // 
            colDireccion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDireccion.HeaderText = "Dirección";
            colDireccion.Name = "colDireccion";
            colDireccion.ReadOnly = true;
            // 
            // colCiudad
            // 
            colCiudad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCiudad.HeaderText = "Ciudad";
            colCiudad.Name = "colCiudad";
            colCiudad.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEstado.HeaderText = "Prov./Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // colPais
            // 
            colPais.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPais.HeaderText = "País";
            colPais.Name = "colPais";
            colPais.ReadOnly = true;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbBorrar, tsbEditar, toolStripSeparator1, tsbFiltrar, tsbActualizar, toolStripSeparator2, tsbImprimir, toolStripSeparator3, tsbOrdenar, tsbCerrar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1018, 62);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbNuevo
            // 
            tsbNuevo.Image = (Image)resources.GetObject("tsbNuevo.Image");
            tsbNuevo.ImageScaling = ToolStripItemImageScaling.None;
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(46, 59);
            tsbNuevo.Text = "Nuevo";
            tsbNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbBorrar
            // 
            tsbBorrar.Image = (Image)resources.GetObject("tsbBorrar.Image");
            tsbBorrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbBorrar.ImageTransparentColor = Color.Magenta;
            tsbBorrar.Name = "tsbBorrar";
            tsbBorrar.Size = new Size(44, 59);
            tsbBorrar.Text = "Borrar";
            tsbBorrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbBorrar.Click += tsbBorrar_Click;
            // 
            // tsbEditar
            // 
            tsbEditar.Image = (Image)resources.GetObject("tsbEditar.Image");
            tsbEditar.ImageScaling = ToolStripItemImageScaling.None;
            tsbEditar.ImageTransparentColor = Color.Magenta;
            tsbEditar.Name = "tsbEditar";
            tsbEditar.Size = new Size(44, 59);
            tsbEditar.Text = "Editar";
            tsbEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbEditar.Click += tsbEditar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 62);
            // 
            // tsbFiltrar
            // 
            tsbFiltrar.Image = (Image)resources.GetObject("tsbFiltrar.Image");
            tsbFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbFiltrar.ImageTransparentColor = Color.Magenta;
            tsbFiltrar.Name = "tsbFiltrar";
            tsbFiltrar.Size = new Size(44, 59);
            tsbFiltrar.Text = "Filtrar";
            tsbFiltrar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // tsbActualizar
            // 
            tsbActualizar.Image = (Image)resources.GetObject("tsbActualizar.Image");
            tsbActualizar.ImageScaling = ToolStripItemImageScaling.None;
            tsbActualizar.ImageTransparentColor = Color.Magenta;
            tsbActualizar.Name = "tsbActualizar";
            tsbActualizar.Size = new Size(63, 59);
            tsbActualizar.Text = "Actualizar";
            tsbActualizar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 62);
            // 
            // tsbImprimir
            // 
            tsbImprimir.Image = (Image)resources.GetObject("tsbImprimir.Image");
            tsbImprimir.ImageScaling = ToolStripItemImageScaling.None;
            tsbImprimir.ImageTransparentColor = Color.Magenta;
            tsbImprimir.Name = "tsbImprimir";
            tsbImprimir.Size = new Size(57, 59);
            tsbImprimir.Text = "Imprimir";
            tsbImprimir.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 62);
            // 
            // tsbOrdenar
            // 
            tsbOrdenar.DropDownItems.AddRange(new ToolStripItem[] { aZPorPaísToolStripMenuItem, aZPorEstadoToolStripMenuItem, zAPorPaísToolStripMenuItem, zAPorEstadoToolStripMenuItem });
            tsbOrdenar.Image = Properties.Resources.list_40px;
            tsbOrdenar.ImageScaling = ToolStripItemImageScaling.None;
            tsbOrdenar.ImageTransparentColor = Color.Magenta;
            tsbOrdenar.Name = "tsbOrdenar";
            tsbOrdenar.Size = new Size(63, 59);
            tsbOrdenar.Text = "Ordenar";
            tsbOrdenar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // aZPorPaísToolStripMenuItem
            // 
            aZPorPaísToolStripMenuItem.Image = Properties.Resources.alphabetical_sorting_16px;
            aZPorPaísToolStripMenuItem.Name = "aZPorPaísToolStripMenuItem";
            aZPorPaísToolStripMenuItem.Size = new Size(156, 22);
            aZPorPaísToolStripMenuItem.Text = "A-Z por Fábrica";
            // 
            // aZPorEstadoToolStripMenuItem
            // 
            aZPorEstadoToolStripMenuItem.Image = Properties.Resources.alphabetical_sorting_16px;
            aZPorEstadoToolStripMenuItem.Name = "aZPorEstadoToolStripMenuItem";
            aZPorEstadoToolStripMenuItem.Size = new Size(156, 22);
            aZPorEstadoToolStripMenuItem.Text = "A-Z por País";
            // 
            // zAPorPaísToolStripMenuItem
            // 
            zAPorPaísToolStripMenuItem.Image = Properties.Resources.alphabetical_sorting_2_16px;
            zAPorPaísToolStripMenuItem.Name = "zAPorPaísToolStripMenuItem";
            zAPorPaísToolStripMenuItem.Size = new Size(156, 22);
            zAPorPaísToolStripMenuItem.Text = "Z-A por Fábrica";
            // 
            // zAPorEstadoToolStripMenuItem
            // 
            zAPorEstadoToolStripMenuItem.Image = Properties.Resources.alphabetical_sorting_2_16px;
            zAPorEstadoToolStripMenuItem.Name = "zAPorEstadoToolStripMenuItem";
            zAPorEstadoToolStripMenuItem.Size = new Size(156, 22);
            zAPorEstadoToolStripMenuItem.Text = "Z-A por País";
            // 
            // tsbCerrar
            // 
            tsbCerrar.Image = (Image)resources.GetObject("tsbCerrar.Image");
            tsbCerrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbCerrar.ImageTransparentColor = Color.Magenta;
            tsbCerrar.Name = "tsbCerrar";
            tsbCerrar.Size = new Size(44, 59);
            tsbCerrar.Text = "Cerrar";
            tsbCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbCerrar.Click += tsbCerrar_Click;
            // 
            // frmFabricas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 450);
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Name = "frmFabricas";
            Text = "frmFabricas";
            Load += frmFabricas_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvDatos;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbBorrar;
        private ToolStripButton tsbEditar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbFiltrar;
        private ToolStripButton tsbActualizar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbImprimir;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripDropDownButton tsbOrdenar;
        private ToolStripMenuItem aZPorPaísToolStripMenuItem;
        private ToolStripMenuItem aZPorEstadoToolStripMenuItem;
        private ToolStripMenuItem zAPorPaísToolStripMenuItem;
        private ToolStripMenuItem zAPorEstadoToolStripMenuItem;
        private ToolStripButton tsbCerrar;
        private DataGridViewTextBoxColumn colFabrica;
        private DataGridViewTextBoxColumn colDireccion;
        private DataGridViewTextBoxColumn colCiudad;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colPais;
    }
}