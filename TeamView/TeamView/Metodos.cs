using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace TeamView
{
    public class Metodos
    {
        /// <summary>
        /// Metódo que retorna o width e o height respectivamente da janela do desktop e não do windows forms.
        /// </summary>
        public (int, int) SizeDesktop()
        {
            var Width = Screen.PrimaryScreen.WorkingArea.Width;
            var Height = Screen.PrimaryScreen.WorkingArea.Height;
            return (Width, Height);
        }

        /// <summary>
        /// Metódo para envio de mensagem em formato de um array de bytes a uma conexão especificada
        /// </summary>
        public void SendMessageToComputer(TcpClient conexao, byte[] bytes)
        {
            if (conexao != null && conexao.Connected)
            {
                conexao
                    .GetStream()
                    .Write(bytes, 0, bytes.Length);
            }
        }

        public byte[] ConvertToBytes(string str) => Encoding.Unicode.GetBytes(str);

        public string ConvertToString(byte[] bytes) => Encoding.Unicode.GetString(bytes);

        public string LimparMessage(string message)
        {
            var str = string.Empty;
            foreach (var _char in message)
                if (_char != '\0')
                    str += _char;
            return str;
        }
    }
}
