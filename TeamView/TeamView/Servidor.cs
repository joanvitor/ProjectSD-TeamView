using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TeamView
{
    public partial class Servidor : Form
    {
        public int _porta;
        private TcpClient _Cliente;
        private TcpListener _Servidor;
        private NetworkStream MainStream;
        private readonly Metodos _metodos;

        private readonly Thread Ouvindo;
        private readonly Thread GetImagem;

        private double ProporcaoImagem_X = 1.0;
        private double ProporcaoImagem_Y = 1.0;

        public Servidor(int porta)
        {
            _porta = porta;
            _Cliente = new TcpClient();
            Ouvindo = new Thread(IniciarEscuta);
            GetImagem = new Thread(ReceberImagem);
            _metodos = new Metodos();
            this.WindowState = FormWindowState.Normal;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.MaximizeBox = false;
            //this.MinimumSize
        }

        private void IniciarEscuta()
        {
            bool RecebeuValorJframe = false;
            try
            {
                while (!_Cliente.Connected)
                {
                    _Servidor.Start();
                    _Cliente = _Servidor.AcceptTcpClient();
                }
                if (!RecebeuValorJframe)
                {
                    GetValueToJFrameActualized();
                    RecebeuValorJframe = true;
                }
                
                GetImagem.Start();
            }
            catch (SocketException)
            {
                MessageBox.Show("Não abra novas conexões...!!!");
            }
        }

        private void GetValueToJFrameActualized()
        {
            int bytesize = 1024;
            if(_Cliente.Connected && _Cliente != null)
            {
                try
                {
                    var stream = _Cliente.GetStream();
                    var messageBytes = new byte[bytesize];
                    stream.Read(messageBytes, 0, messageBytes.Length);
                    var messageString = _metodos.LimparMessage(_metodos.ConvertToString(messageBytes));
                    ProcessarSizeJFrame(messageString);
                }
                catch (Exception)
                {
                    Console.WriteLine("Servidor desconectado...");
                }
            }
        }

        private void ProcessarSizeJFrame(string msg) //SD1020;780
        {
            if (msg.StartsWith("SD"))
            {
                var coord = msg.Replace("SD",""); //1020;780
                var splitCoord = coord.Split(';');
                (var LarguraCliente, var AlturaCliente) = (int.Parse(splitCoord[0]), int.Parse(splitCoord[1]));
                (var LarguraServidor, var AlturaServidor) = _metodos.SizeDesktop();

                (var Width, var Height) = NewValueJFrame(LarguraCliente, AlturaCliente, LarguraServidor, AlturaServidor);
                
                // Ajuste do Frame
                this.Size = new Size(Width, Height);
                this.MinimumSize = new Size(Width, Height);
            }
        }
        /// <summary>
        /// Return Width e Heigth respectivamente
        /// </summary>
        private (int, int) NewValueJFrame(int xCliente, int yCliente, int xServidor, int yServidor)
        {
            if (xCliente <= xServidor && yCliente <= yServidor)
                return (xCliente, yCliente);
            if (xCliente >= xServidor && yCliente >= yServidor)
            {
                (ProporcaoImagem_X, ProporcaoImagem_Y) = ProporcaoParaImagem(xCliente, yCliente, xServidor, yServidor, "XY");
                return (xServidor, yServidor); // Faz divisão do cliente pelo servidor para saber a proporção
            }
            if (xCliente <= xServidor && yCliente >= yServidor)
            {
                (ProporcaoImagem_X, ProporcaoImagem_Y) = ProporcaoParaImagem(xCliente, yCliente, xServidor, yServidor, "Y");
                return (xCliente, yServidor); // Divide o yCliente pelo yServidor, apenas proporção para Y
            }
            if (xCliente >= xServidor && yCliente <= yServidor)
            {
                (ProporcaoImagem_X, ProporcaoImagem_Y) = ProporcaoParaImagem(xCliente, yCliente, xServidor, yServidor, "X");
                return (xServidor, yCliente); // Divide o xCliente pelo xServidor, apenas proporçaõ para X
            }

            return (0, 0);
        }

        /// <summary>
        /// Retorna a proporção da imagem para X e para Y
        /// </summary>
        private (double, double) ProporcaoParaImagem(int xCliente, int yCliente, int xServidor, int yServidor, string Type)
        {
            if(Type.Equals("XY"))
                return ((xCliente / xServidor), (yCliente / yServidor));
            if (Type.Equals("Y"))
                return (1.0, (yCliente / yServidor));
            if (Type.Equals("X"))
                return ((xCliente / xServidor), 1.0);

            return (1.0, 1.0);
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
            var Mensagem = MouseClick + "$" + coordenadas.X.ToString() + ";" + coordenadas.Y.ToString();
            _metodos.SendMessageToComputer(_Cliente, _metodos.ConvertToBytes(Mensagem));
        }

        private void CaixaImagem_MouseMove(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs) e;
            Point coordenadas = me.Location;
            (var X, var Y) = (coordenadas.X * ProporcaoImagem_X, coordenadas.Y * ProporcaoImagem_Y);
            //var Mensagem = "$" + coordenadas.X.ToString() + ";" + coordenadas.Y.ToString();
            var Mensagem = "$" + X.ToString() + ";" + Y.ToString();
            _metodos.SendMessageToComputer(_Cliente, _metodos.ConvertToBytes(Mensagem));
        }

        private void Servidor_KeyUp(object sender, KeyEventArgs e) // click e solta
        {
            var TeclaServidor = (int) e.KeyCode;
            // envia pro cliente via sockete
            _metodos.SendMessageToComputer(_Cliente, _metodos.ConvertToBytes("#" + GetTeclaInMapaKeys(TeclaServidor)));
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
