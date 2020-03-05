﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamView
{
    public partial class Cliente : Form
    {
        private readonly TcpClient cliente = new TcpClient();
        private NetworkStream mainStream;
        private int NumeroPorta;

        private static Image getImagemDesktop()
        {
            Rectangle limiteRetangulo = Screen.PrimaryScreen.Bounds;
            Bitmap capturaTela =
                new Bitmap(limiteRetangulo.Width, limiteRetangulo.Height, PixelFormat.Format32bppArgb);
            Graphics grafico = Graphics.FromImage(capturaTela);
            grafico.CopyFromScreen(limiteRetangulo.X, limiteRetangulo.Y, 0, 0, limiteRetangulo.Size, CopyPixelOperation.SourceCopy);
            return capturaTela;
        }

        private void EnviarImagemDesktop()
        {
            BinaryFormatter binario = new BinaryFormatter();
            try
            {
                mainStream = cliente.GetStream();
                binario.Serialize(mainStream, getImagemDesktop());
            }
            catch (Exception)
            {
                Close();
                MessageBox.Show("Falha de conexão...!!! Tente novamente...");
            }
        }

        public Cliente()
        {
            InitializeComponent();
        }

        private void BtnConectar_Click(object sender, EventArgs e)
        {
            
            try
            {
                NumeroPorta = int.Parse(textoPorta.Text);
                cliente.Connect(textoIP.Text, NumeroPorta);
                MessageBox.Show("Conectado...!!!");
                BtnCompartilhar.Enabled = true;
            }
            catch (SocketException)
            {
                MessageBox.Show("Falha na conexão...!!!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Informe o número da porta e/ou IP...!!!");
            }
        }

        private void BtnCompartilhar_Click(object sender, EventArgs e)
        {
            if (BtnCompartilhar.Text.StartsWith("Compartilhar"))
            {
                timer1.Start();
                BtnCompartilhar.Text = "Parar de Compartilhar";
            }
            else
            {
                timer1.Stop();
                BtnCompartilhar.Text = "Compartilhar Tela";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            EnviarImagemDesktop();
        }
    }
}
