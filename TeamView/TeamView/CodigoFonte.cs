using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TeamView
{
    public partial class CodigoFonte : Form
    {
        public CodigoFonte()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
            => this.Close();

        private void button1_Click(object sender, EventArgs e)
            => Process.Start(new ProcessStartInfo("https://github.com/joanvitor/ProjectSD-TeamView"));
    }
}
