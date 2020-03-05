using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamView
{
    public partial class Servidor : Form
    {
        public int _porta;
        private TcpClient cliente;
        private TcpListener servidor;
        private NetworkStream mainStream;

        private readonly Thread ouvindo;
        private readonly Thread getImagem;

        public Servidor(int porta)
        {
            _porta = porta;
            cliente = new TcpClient();
            ouvindo = new Thread(IniciarEscuta);
            getImagem = new Thread(ReceberImagem);
            InitializeComponent();
        }

        private void IniciarEscuta()
        {
            try
            {
                while (!cliente.Connected)
                {
                    servidor.Start();
                    cliente = servidor.AcceptTcpClient();
                }
                getImagem.Start();
            }
            catch (SocketException)
            {
                MessageBox.Show("Não abra novas conexões...!!!");
            }
        }

        private void PararEscuta()
        {
            servidor.Stop();
            cliente = null;
            if (ouvindo.IsAlive) ouvindo.Abort();
            if (getImagem.IsAlive) getImagem.Abort();
        }

        private void ReceberImagem()
        {
            BinaryFormatter binario = new BinaryFormatter();
            while (cliente.Connected)
            {
                mainStream = cliente.GetStream();
                caixaImagem.Image = (Image) binario.Deserialize(mainStream);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            servidor = new TcpListener(IPAddress.Any, _porta);
            ouvindo.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            PararEscuta();
        }
    }
}
