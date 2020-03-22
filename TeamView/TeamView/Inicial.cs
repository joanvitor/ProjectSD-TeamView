using System;
using System.Windows.Forms;

namespace TeamView
{
    public partial class Inicial : Form
    {
        public Inicial()
        {
            InitializeComponent();
        }

        private void BtnCliente_Click(object sender, EventArgs e)
            => new Cliente().Show();

        private void BtnServidor_Click(object sender, EventArgs e)
            => new ServidorPorta().Show();

        private void códigoFonteToolStripMenuItem_Click(object sender, EventArgs e)
            => new CodigoFonte().Show();

        private void contatoToolStripMenuItem_Click(object sender, EventArgs e)
            => new Contato().Show();

        private void oQueÉToolStripMenuItem_Click(object sender, EventArgs e)
            => new SobreSoftware().Show();
    }
}
