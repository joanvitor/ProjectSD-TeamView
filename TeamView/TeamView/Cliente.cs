using System;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamView
{
    public partial class Cliente : Form
    {
        private readonly TcpClient Servidor = new TcpClient();
        private NetworkStream MainStream;
        private int NumeroPorta;
        private Thread T_point;

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
                MainStream = Servidor.GetStream();
                binario.Serialize(MainStream, getImagemDesktop());
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
                Servidor.Connect(textoIP.Text, NumeroPorta);
                MessageBox.Show("Conectado...!!!");
                BtnCompartilhar.Enabled = true;

                T_point = new Thread(() => GetMessageServer());
                T_point.Start();
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            EnviarImagemDesktop();
        }

        private void GetMessageServer()
        {
            int bytesize = 1024;
            while (Servidor.Connected)
            {
                try
                {
                    var stream = Servidor.GetStream();
                    var messageBytes = new byte[bytesize];
                    stream.Read(messageBytes, 0, messageBytes.Length);

                    var messageString = LimparMessage(ConvertToString(messageBytes));
                    //Console.WriteLine($"Cliente: {messageString}");
                    ProcessarInput(messageString);
                }
                catch (Exception)
                {
                    Console.WriteLine("Servidor desconectado...");
                }
            }
        }

        private string ConvertToString(byte[] bytes) => Encoding.Unicode.GetString(bytes);

        private string LimparMessage(string message)
        {
            var str = string.Empty;
            foreach(var _char in message)
                if (_char != '\0')
                    str += _char;
            return str;
        }

        private void ProcessarInput(string msg)
        {
            if (msg.StartsWith("#")) // é teclado
                ProcessarInputTeclado(msg);

            if (msg.StartsWith("$")) // é mouse
                ProcessarInputMouse(msg);
        }

        private void ProcessarInputMouse(string msg)
        {
            var cood = msg.Replace("$", "");

            var strSplit = cood.Split(';');
            Console.WriteLine($"X: {strSplit[0]} Y: {strSplit[1]}");
        }

        private void ProcessarInputTeclado(string msg)
        {
            var key = msg.Replace("#", "");
            SendKeys.SendWait(key);
        }
    }
}
