namespace TeamView
{
    partial class Inicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicial));
            this.BtnCliente = new System.Windows.Forms.Button();
            this.BtnServidor = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oQueÉToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoColaboradoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.okToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.códigoFonteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCliente
            // 
            this.BtnCliente.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.BtnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCliente.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCliente.Image = ((System.Drawing.Image)(resources.GetObject("BtnCliente.Image")));
            this.BtnCliente.Location = new System.Drawing.Point(280, 109);
            this.BtnCliente.Name = "BtnCliente";
            this.BtnCliente.Size = new System.Drawing.Size(140, 171);
            this.BtnCliente.TabIndex = 0;
            this.BtnCliente.Text = "Cliente";
            this.BtnCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCliente.UseVisualStyleBackColor = true;
            this.BtnCliente.Click += new System.EventHandler(this.BtnCliente_Click);
            // 
            // BtnServidor
            // 
            this.BtnServidor.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.BtnServidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnServidor.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnServidor.Image = ((System.Drawing.Image)(resources.GetObject("BtnServidor.Image")));
            this.BtnServidor.Location = new System.Drawing.Point(51, 109);
            this.BtnServidor.Name = "BtnServidor";
            this.BtnServidor.Size = new System.Drawing.Size(140, 171);
            this.BtnServidor.TabIndex = 1;
            this.BtnServidor.Text = "Servidor";
            this.BtnServidor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnServidor.UseVisualStyleBackColor = true;
            this.BtnServidor.Click += new System.EventHandler(this.BtnServidor_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem,
            this.okToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoSoftwareToolStripMenuItem,
            this.infoColaboradoresToolStripMenuItem});
            this.sobreToolStripMenuItem.Font = new System.Drawing.Font("Roboto", 11F);
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.sobreToolStripMenuItem.Text = "Ajuda";
            // 
            // infoSoftwareToolStripMenuItem
            // 
            this.infoSoftwareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oQueÉToolStripMenuItem});
            this.infoSoftwareToolStripMenuItem.Name = "infoSoftwareToolStripMenuItem";
            this.infoSoftwareToolStripMenuItem.Size = new System.Drawing.Size(211, 24);
            this.infoSoftwareToolStripMenuItem.Text = "Info Software";
            // 
            // oQueÉToolStripMenuItem
            // 
            this.oQueÉToolStripMenuItem.Name = "oQueÉToolStripMenuItem";
            this.oQueÉToolStripMenuItem.Size = new System.Drawing.Size(271, 24);
            this.oQueÉToolStripMenuItem.Text = "O que é ? e como executar ?";
            this.oQueÉToolStripMenuItem.Click += new System.EventHandler(this.oQueÉToolStripMenuItem_Click);
            // 
            // infoColaboradoresToolStripMenuItem
            // 
            this.infoColaboradoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contatoToolStripMenuItem});
            this.infoColaboradoresToolStripMenuItem.Name = "infoColaboradoresToolStripMenuItem";
            this.infoColaboradoresToolStripMenuItem.Size = new System.Drawing.Size(211, 24);
            this.infoColaboradoresToolStripMenuItem.Text = "Info Colaboradores";
            // 
            // contatoToolStripMenuItem
            // 
            this.contatoToolStripMenuItem.Name = "contatoToolStripMenuItem";
            this.contatoToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.contatoToolStripMenuItem.Text = "Contato";
            this.contatoToolStripMenuItem.Click += new System.EventHandler(this.contatoToolStripMenuItem_Click);
            // 
            // okToolStripMenuItem
            // 
            this.okToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.códigoFonteToolStripMenuItem});
            this.okToolStripMenuItem.Font = new System.Drawing.Font("Roboto", 11F);
            this.okToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.okToolStripMenuItem.Name = "okToolStripMenuItem";
            this.okToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.okToolStripMenuItem.Text = "Consultar";
            // 
            // códigoFonteToolStripMenuItem
            // 
            this.códigoFonteToolStripMenuItem.Name = "códigoFonteToolStripMenuItem";
            this.códigoFonteToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.códigoFonteToolStripMenuItem.Text = "Código Fonte";
            this.códigoFonteToolStripMenuItem.Click += new System.EventHandler(this.códigoFonteToolStripMenuItem_Click);
            // 
            // Inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.BtnServidor);
            this.Controls.Add(this.BtnCliente);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(500, 400);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "Inicial";
            this.Text = "Inicial";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCliente;
        private System.Windows.Forms.Button BtnServidor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem okToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem códigoFonteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoSoftwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oQueÉToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoColaboradoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contatoToolStripMenuItem;
    }
}