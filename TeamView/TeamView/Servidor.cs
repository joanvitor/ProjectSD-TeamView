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

            var MouseClick = string.Empty;
            if (me.Button == MouseButtons.Right)
                MouseClick = "$R";
            if (me.Button == MouseButtons.Left)
                MouseClick = "$L";

            Point coordenadas = me.Location;
            //Console.WriteLine($"{coordenadas.X.ToString()}   {coordenadas.Y.ToString()}");
            var Mensagem = MouseClick + "$" + coordenadas.X.ToString() + ";" + coordenadas.Y.ToString();
            SendMessageToClient(_Cliente, ConvertToBytes(Mensagem));
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
            //var teste = e.KeyCode.ConvertKeyToString();
            //Console.WriteLine(teste);
            var TeclaServidor = (int) e.KeyCode;
            // envia pro cliente via sockete
            SendMessageToClient(_Cliente, ConvertToBytes("#" + GetTeclaInMapaKeys(TeclaServidor)));

            // recebe no cliente
            // var teclaCLiente = (Keys)teclaServidor;
            // SendKeys.Send("{Q}");
        }

        private string GetTeclaInMapaKeys(int codKey)
        {
            Dictionary<int, string> MapeamentoKeys = new Dictionary<int, string>()
            {
                { 1, "{LButton}"},
                { 2, "{RButton}"},
                { 4, "{MButton}"},
                { 5, "{XButton1}"},
                { 6, "{XButton2}"},
                { 20, "{CapsLock}"},
                { 32, "{Space}"},
                { 9, "{Tab}"},
                //{ 13, "{Enter}"},
                { 13, "{Return}"},
                { 27, "{Escape}"},
                { 46, "{Delete}"},
                { 45, "{Insert}"},
                { 36, "{Home}"},
                { 35, "{End}"},
                { 33, "{PgUp}"},
                { 34, "{PgDn}"},
                { 38, "{Up}"},
                { 40, "{Down}"},
                { 37, "{Left}"},
                { 39, "{Right}"},
                { 96, "{Numpad0}"},
                { 97, "{Numpad1}"},
                { 98, "{Numpad2}"},
                { 99, "{Numpad3}"},
                { 100, "{Numpad4}"},
                { 101, "{Numpad5}"},
                { 102, "{Numpad6}"},
                { 103, "{Numpad7}"},
                { 104, "{Numpad8}"},
                { 105, "{Numpad9}"},
                { 144, "{NumLock}"},
                { 91, "{LWin}"},
                { 92, "{RWin}"},
                { 131072, "{Ctrl}"},
                { 262144, "{Alt}"},
                { 65536, "{Shift}"},
                { 162, "{LControl}"},
                { 163, "{RControl}"},
                { 160, "{LShift}"},
                { 161, "{RShift}"},
                { 44, "{PrintScreen}"},
                { 65, "{A}"},
                { 66, "{B}"},
                { 67, "{C}"},
                { 68, "{D}"},
                { 69, "{E}"},
                { 70, "{F}"},
                { 71, "{G}"},
                { 72, "{H}"},
                { 73, "{I}"},
                { 74, "{J}"},
                { 75, "{K}"},
                { 76, "{L}"},
                { 77, "{M}"},
                { 78, "{N}"},
                { 79, "{O}"},
                { 80, "{P}"},
                { 81, "{Q}"},
                { 82, "{R}"},
                { 83, "{S}"},
                { 84, "{T}"},
                { 85, "{U}"},
                { 86, "{V}"},
                { 87, "{W}"},
                { 88, "{X}"},
                { 89, "{Y}"},
                { 90, "{Z}"},
                { 111, "{NumpadDiv}"},
                { 106, "{NumpadMult}"},
                { 107, "{NumpadAdd}"},
                { 109, "{NumpadSub}"},
                { 112, "{F1}"},
                { 113, "{F2}"},
                { 114, "{F3}"},
                { 115, "{F4}"},
                { 116, "{F5}"},
                { 117, "{F6}"},
                { 118, "{F7}"},
                { 119, "{F8}"},
                { 120, "{F9}"},
                { 121, "{F10}"},
                { 122, "{F11}"},
                { 123, "{F12}"},
                { 124, "{F13}"},
                { 125, "{F14}"},
                { 126, "{F15}"},
                { 127, "{F16}"},
                { 128, "{F17}"},
                { 129, "{F18}"},
                { 130, "{F19}"},
                { 131, "{F20}"},
                { 132, "{F21}"},
                { 133, "{F22}"},
                { 134, "{F23}"},
                { 135, "{F24}"},
                { 221,"{]}"},
                { 188,"{,}"},
                { 189,"{-}"},
                { 219,"{[}"},
                { 190,"{.}"},
                { 220,"{/}"},
                { 187,"{+}"},
                { 191,"{?}"},
                { 222,"{'}"},
                //{ 222, "{"+'"'+"}"},
                { 186,"{;}"},
                { 192,"{~}"}
            };
            var NameKey = string.Empty;
            MapeamentoKeys.TryGetValue(codKey, out NameKey);
            //Console.WriteLine($"Dictionary: {NameKey}");
            return NameKey;
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
