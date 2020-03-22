using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TeamView
{
    public partial class Contato : Form
    {
        public Contato()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
            => Process.Start(new ProcessStartInfo("https://api.whatsapp.com/send?phone=999103068&text=Olá!!!"));

        private void button1_Click(object sender, EventArgs e)
            => Process.Start(new ProcessStartInfo("https://api.whatsapp.com/send?phone=999052115&text=Olá!!!"));

        private void button3_Click(object sender, EventArgs e)
            => Process.Start(new ProcessStartInfo("https://api.whatsapp.com/send?phone=996010273&text=Olá!!!"));

        private void button4_Click(object sender, EventArgs e)
            => Process.Start(new ProcessStartInfo("https://instagram.com/bruno_vqr/"));

        private void button5_Click(object sender, EventArgs e)
            => Process.Start(new ProcessStartInfo("https://www.instagram.com/_joanvitor/"));

        private void button6_Click(object sender, EventArgs e)
            => Process.Start(new ProcessStartInfo("https://instagram.com/renee.bolivar/"));

        private void button7_Click(object sender, EventArgs e)
            => MessageBox.Show("Email: brunosantana094@gmail.com");

        private void button8_Click(object sender, EventArgs e)
            => MessageBox.Show("Email: joanvitor97@yahoo.com ou j.v.m.j.97@gmail.com");

        private void button9_Click(object sender, EventArgs e)
            => MessageBox.Show("Email: reneegois@hotmail.com.br");
    }
}
