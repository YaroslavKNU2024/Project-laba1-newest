using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace LabaOOP1
{
    public partial class Saver : Form
    {
        public Saver() => InitializeComponent();

        private void SetFileName_Click(object sender, EventArgs e)
        {
            FileName.path = textBox1.Text;
            MessageBox.Show("Ім'я записано вдало");
            Hide();
            string json = JsonConvert.SerializeObject(FileName.Cell.ToArray());
            File.WriteAllText(FileName.path, json);
        }
    }
}
