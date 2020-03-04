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
            this.BtnCliente = new System.Windows.Forms.Button();
            this.BtnServidor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnCliente
            // 
            this.BtnCliente.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCliente.Location = new System.Drawing.Point(12, 12);
            this.BtnCliente.Name = "BtnCliente";
            this.BtnCliente.Size = new System.Drawing.Size(271, 77);
            this.BtnCliente.TabIndex = 0;
            this.BtnCliente.Text = "Cliente";
            this.BtnCliente.UseVisualStyleBackColor = true;
            this.BtnCliente.Click += new System.EventHandler(this.BtnCliente_Click);
            // 
            // BtnServidor
            // 
            this.BtnServidor.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnServidor.Location = new System.Drawing.Point(12, 104);
            this.BtnServidor.Name = "BtnServidor";
            this.BtnServidor.Size = new System.Drawing.Size(271, 77);
            this.BtnServidor.TabIndex = 1;
            this.BtnServidor.Text = "Servidor";
            this.BtnServidor.UseVisualStyleBackColor = true;
            this.BtnServidor.Click += new System.EventHandler(this.BtnServidor_Click);
            // 
            // Inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 193);
            this.Controls.Add(this.BtnServidor);
            this.Controls.Add(this.BtnCliente);
            this.Name = "Inicial";
            this.Text = "Inicial";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCliente;
        private System.Windows.Forms.Button BtnServidor;
    }
}