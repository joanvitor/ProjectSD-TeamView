namespace TeamView
{
    partial class ServidorPorta
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
            this.label1 = new System.Windows.Forms.Label();
            this.textoPorta = new System.Windows.Forms.TextBox();
            this.BtnAbrirConexao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "PORTA:";
            // 
            // textoPorta
            // 
            this.textoPorta.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoPorta.Location = new System.Drawing.Point(113, 29);
            this.textoPorta.Name = "textoPorta";
            this.textoPorta.Size = new System.Drawing.Size(182, 35);
            this.textoPorta.TabIndex = 1;
            // 
            // BtnAbrirConexao
            // 
            this.BtnAbrirConexao.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAbrirConexao.Location = new System.Drawing.Point(17, 93);
            this.BtnAbrirConexao.Name = "BtnAbrirConexao";
            this.BtnAbrirConexao.Size = new System.Drawing.Size(278, 47);
            this.BtnAbrirConexao.TabIndex = 2;
            this.BtnAbrirConexao.Text = "Abrir Conexão";
            this.BtnAbrirConexao.UseVisualStyleBackColor = true;
            this.BtnAbrirConexao.Click += new System.EventHandler(this.BtnAbrirConexao_Click);
            // 
            // ServidorPorta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 161);
            this.Controls.Add(this.BtnAbrirConexao);
            this.Controls.Add(this.textoPorta);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(332, 200);
            this.MinimumSize = new System.Drawing.Size(332, 200);
            this.Name = "ServidorPorta";
            this.Text = "ServidorPorta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textoPorta;
        private System.Windows.Forms.Button BtnAbrirConexao;
    }
}