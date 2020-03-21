﻿using System;
using System.Windows.Forms;

namespace TeamView
{
    public partial class ServidorPorta : Form
    {
        public ServidorPorta()
        {
            InitializeComponent();
        }

        private void BtnAbrirConexao_Click(object sender, EventArgs e)
        {
            try
            {
                int porta = int.Parse(textoPorta.Text);
                Servidor server = new Servidor(porta);
                server.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Informe o número da porta...!!!");
            }
        }
    }
}
