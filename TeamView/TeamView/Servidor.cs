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
        private TcpClient _Cliente;
        private TcpListener _Servidor;
        private NetworkStream MainStream;

        private readonly Thread Ouvindo;
        private readonly Thread GetImagem;

        public Servidor(int porta)
        {
            _porta = porta;
            _Cliente = new TcpClient();
            Ouvindo = new Thread(IniciarEscuta);
            GetImagem = new Thread(ReceberImagem);
            InitializeComponent();
        }

        private void IniciarEscuta()
        {
            try
            {
                while (!_Cliente.Connected)
                {
                    _Servidor.Start();
                    _Cliente = _Servidor.AcceptTcpClient();
                }
                GetImagem.Start();
            }
            catch (SocketException)
            {
                MessageBox.Show("Não abra novas conexões...!!!");
            }
        }

        private void PararEscuta()
        {
            _Servidor.Stop();
            _Cliente = null;
            if (Ouvindo.IsAlive) Ouvindo.Abort();
            if (GetImagem.IsAlive) GetImagem.Abort();
        }

        private void ReceberImagem()
        {
            BinaryFormatter binario = new BinaryFormatter();
            while (_Cliente.Connected)
            {
                MainStream = _Cliente.GetStream();
                caixaImagem.Image = (Image)binario.Deserialize(MainStream);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _Servidor = new TcpListener(IPAddress.Any, _porta);
            Ouvindo.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            PararEscuta();
        }

        private void CaixaImagem_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs) e;

            //var mouseEvent = string.Empty;
            //if (me.Button == MouseButtons.Right)
            //    mouseEvent = "Right Click";
            //if (me.Button == MouseButtons.Left)
            //    mouseEvent = "Right Click";

            //Console.WriteLine($"CLICK ESQUERDO {MouseButtons.Left.ToString()}");
            Point coordenadas = me.Location;
            //Console.WriteLine($"{coordenadas.X.ToString()}   {coordenadas.Y.ToString()}");
            var mensagem = "$" + coordenadas.X.ToString() + ";" + coordenadas.Y.ToString();
            SendMessageToClient(_Cliente, ConvertToBytes(mensagem));
        }

        private void SendMessageToClient(TcpClient _cliente, byte[] bytes)
        {
            if (_cliente != null && _cliente.Connected)
            {
                _Cliente
                    .GetStream()
                    .Write(bytes, 0, bytes.Length);
            }
        }

        private byte [] ConvertToBytes(string str) => Encoding.Unicode.GetBytes(str);

        private void Servidor_KeyUp(object sender, KeyEventArgs e) // click e solta
        {
            var teste = e.KeyCode.ConvertKeyToString();
            // var teclaServidor = (int)e.KeyCode;
            // envia pro cliente via sockete
            SendMessageToClient(_Cliente, ConvertToBytes("#" + teste.ToString()));

            // recebe no cliente
            // var teclaCLiente = (Keys)teclaServidor;
            // SendKeys.Send("{Q}");
        }


        /*
         MENSAGEM PRO CLIENTE
            TECLADO  ~>  #COD
            MOUSE    ~>  $COODX;COODY
            MOUSE L  ~>  $L$COODX;COODY 
            MOUSE R  ~>  $R$COODX;COODY
         */
    }
}
