namespace TeamView
{
    partial class Servidor
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
            this.caixaImagem = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.caixaImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // caixaImagem
            // 
            this.caixaImagem.BackColor = System.Drawing.Color.Gray;
            this.caixaImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.caixaImagem.Location = new System.Drawing.Point(0, 0);
            this.caixaImagem.Name = "caixaImagem";
            this.caixaImagem.Size = new System.Drawing.Size(484, 321);
            this.caixaImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.caixaImagem.TabIndex = 0;
            this.caixaImagem.TabStop = false;
            this.caixaImagem.Click += new System.EventHandler(this.CaixaImagem_Click);
            this.caixaImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CaixaImagem_MouseMove);
            // 
            // Servidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 321);
            this.Controls.Add(this.caixaImagem);
            this.Name = "Servidor";
            this.Text = "Servidor";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Servidor_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.caixaImagem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox caixaImagem;
    }
}