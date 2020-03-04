namespace TeamView
{
    partial class Cliente
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textoIP = new System.Windows.Forms.TextBox();
            this.textoPorta = new System.Windows.Forms.TextBox();
            this.BtnConectar = new System.Windows.Forms.Button();
            this.BtnCompartilhar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(350, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "PORTA:";
            // 
            // textoIP
            // 
            this.textoIP.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoIP.Location = new System.Drawing.Point(17, 51);
            this.textoIP.Name = "textoIP";
            this.textoIP.Size = new System.Drawing.Size(301, 35);
            this.textoIP.TabIndex = 2;
            // 
            // textoPorta
            // 
            this.textoPorta.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoPorta.Location = new System.Drawing.Point(355, 51);
            this.textoPorta.Name = "textoPorta";
            this.textoPorta.Size = new System.Drawing.Size(158, 35);
            this.textoPorta.TabIndex = 3;
            // 
            // BtnConectar
            // 
            this.BtnConectar.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConectar.Location = new System.Drawing.Point(17, 112);
            this.BtnConectar.Name = "BtnConectar";
            this.BtnConectar.Size = new System.Drawing.Size(200, 42);
            this.BtnConectar.TabIndex = 4;
            this.BtnConectar.Text = "Conectar";
            this.BtnConectar.UseVisualStyleBackColor = true;
            this.BtnConectar.Click += new System.EventHandler(this.BtnConectar_Click);
            // 
            // BtnCompartilhar
            // 
            this.BtnCompartilhar.Enabled = false;
            this.BtnCompartilhar.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCompartilhar.Location = new System.Drawing.Point(248, 112);
            this.BtnCompartilhar.Name = "BtnCompartilhar";
            this.BtnCompartilhar.Size = new System.Drawing.Size(265, 42);
            this.BtnCompartilhar.TabIndex = 5;
            this.BtnCompartilhar.Text = "Compartilhar Tela";
            this.BtnCompartilhar.UseVisualStyleBackColor = true;
            this.BtnCompartilhar.Click += new System.EventHandler(this.BtnCompartilhar_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 207);
            this.Controls.Add(this.BtnCompartilhar);
            this.Controls.Add(this.BtnConectar);
            this.Controls.Add(this.textoPorta);
            this.Controls.Add(this.textoIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Cliente";
            this.Text = "Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textoIP;
        private System.Windows.Forms.TextBox textoPorta;
        private System.Windows.Forms.Button BtnConectar;
        private System.Windows.Forms.Button BtnCompartilhar;
        private System.Windows.Forms.Timer timer1;
    }
}

