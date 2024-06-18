namespace Bombones.Windows
{
    partial class frmMenuPrincipal
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
            btnRellenos = new Button();
            btnChocolates = new Button();
            btnNueces = new Button();
            btnPaises = new Button();
            btnFabricas = new Button();
            btnBombones = new Button();
            btnProvinciasEstados = new Button();
            btnCiudades = new Button();
            btnCajas = new Button();
            btnUsuarios = new Button();
            btnRoles = new Button();
            btnPermisos = new Button();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // btnRellenos
            // 
            btnRellenos.Location = new Point(24, 196);
            btnRellenos.Name = "btnRellenos";
            btnRellenos.Size = new Size(139, 123);
            btnRellenos.TabIndex = 0;
            btnRellenos.Text = "Tipos de Relleno";
            btnRellenos.UseVisualStyleBackColor = true;
            btnRellenos.Click += btnRellenos_Click;
            // 
            // btnChocolates
            // 
            btnChocolates.Location = new Point(205, 196);
            btnChocolates.Name = "btnChocolates";
            btnChocolates.Size = new Size(139, 123);
            btnChocolates.TabIndex = 0;
            btnChocolates.Text = "Tipos de Chocolate";
            btnChocolates.UseVisualStyleBackColor = true;
            btnChocolates.Click += btnChocolates_Click;
            // 
            // btnNueces
            // 
            btnNueces.Location = new Point(400, 196);
            btnNueces.Name = "btnNueces";
            btnNueces.Size = new Size(139, 123);
            btnNueces.TabIndex = 0;
            btnNueces.Text = "Tipos de Nuez";
            btnNueces.UseVisualStyleBackColor = true;
            btnNueces.Click += btnNueces_Click;
            // 
            // btnPaises
            // 
            btnPaises.Location = new Point(24, 344);
            btnPaises.Name = "btnPaises";
            btnPaises.Size = new Size(139, 123);
            btnPaises.TabIndex = 0;
            btnPaises.Text = "Países";
            btnPaises.UseVisualStyleBackColor = true;
            btnPaises.Click += btnPaises_Click;
            // 
            // btnFabricas
            // 
            btnFabricas.Location = new Point(24, 518);
            btnFabricas.Name = "btnFabricas";
            btnFabricas.Size = new Size(139, 123);
            btnFabricas.TabIndex = 0;
            btnFabricas.Text = "Fábricas";
            btnFabricas.UseVisualStyleBackColor = true;
            btnFabricas.Click += btnFabricas_Click;
            // 
            // btnBombones
            // 
            btnBombones.Location = new Point(205, 518);
            btnBombones.Name = "btnBombones";
            btnBombones.Size = new Size(139, 123);
            btnBombones.TabIndex = 0;
            btnBombones.Text = "Bombones";
            btnBombones.UseVisualStyleBackColor = true;
            // 
            // btnProvinciasEstados
            // 
            btnProvinciasEstados.Location = new Point(205, 344);
            btnProvinciasEstados.Name = "btnProvinciasEstados";
            btnProvinciasEstados.Size = new Size(139, 123);
            btnProvinciasEstados.TabIndex = 0;
            btnProvinciasEstados.Text = "Prov./Estados";
            btnProvinciasEstados.UseVisualStyleBackColor = true;
            btnProvinciasEstados.Click += btnProvinciasEstados_Click;
            // 
            // btnCiudades
            // 
            btnCiudades.Location = new Point(400, 344);
            btnCiudades.Name = "btnCiudades";
            btnCiudades.Size = new Size(139, 123);
            btnCiudades.TabIndex = 0;
            btnCiudades.Text = "Ciudades";
            btnCiudades.UseVisualStyleBackColor = true;
            btnCiudades.Click += btnCiudades_Click;
            // 
            // btnCajas
            // 
            btnCajas.Location = new Point(400, 518);
            btnCajas.Name = "btnCajas";
            btnCajas.Size = new Size(139, 123);
            btnCajas.TabIndex = 0;
            btnCajas.Text = "Cajas";
            btnCajas.UseVisualStyleBackColor = true;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(400, 35);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(139, 123);
            btnUsuarios.TabIndex = 0;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnRellenos_Click;
            // 
            // btnRoles
            // 
            btnRoles.Location = new Point(24, 35);
            btnRoles.Name = "btnRoles";
            btnRoles.Size = new Size(139, 123);
            btnRoles.TabIndex = 0;
            btnRoles.Text = "Roles";
            btnRoles.UseVisualStyleBackColor = true;
            btnRoles.Click += btnChocolates_Click;
            // 
            // btnPermisos
            // 
            btnPermisos.Location = new Point(205, 35);
            btnPermisos.Name = "btnPermisos";
            btnPermisos.Size = new Size(139, 123);
            btnPermisos.TabIndex = 0;
            btnPermisos.Text = "Permisos";
            btnPermisos.UseVisualStyleBackColor = true;
            btnPermisos.Click += btnNueces_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(583, 35);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(205, 123);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnNueces_Click;
            // 
            // frmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 710);
            Controls.Add(btnCajas);
            Controls.Add(btnBombones);
            Controls.Add(btnFabricas);
            Controls.Add(btnCiudades);
            Controls.Add(btnProvinciasEstados);
            Controls.Add(btnPaises);
            Controls.Add(btnLogin);
            Controls.Add(btnPermisos);
            Controls.Add(btnRoles);
            Controls.Add(btnNueces);
            Controls.Add(btnUsuarios);
            Controls.Add(btnChocolates);
            Controls.Add(btnRellenos);
            Name = "frmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Principal";
            ResumeLayout(false);
        }

        #endregion

        private Button btnRellenos;
        private Button btnChocolates;
        private Button btnNueces;
        private Button btnPaises;
        private Button btnFabricas;
        private Button btnBombones;
        private Button btnProvinciasEstados;
        private Button btnCiudades;
        private Button btnCajas;
        private Button btnUsuarios;
        private Button btnRoles;
        private Button btnPermisos;
        private Button btnLogin;
    }
}