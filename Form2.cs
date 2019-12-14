using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ChizzBot
{
    public partial class Form2 : Form
    {
        public List<PlayableTrack> tracks { get; set; }
        public string ReturnValue1 { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool repeat = false;
            foreach (PlayableTrack track in tracks)
            {
                if (track.trackCommand == textBox1.Text)
                {
                    repeat = true;
                    break;
                }
            }
            if (textBox1.Text.All(Char.IsLetter) && !repeat)
            {
                this.ReturnValue1 = textBox1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Command input incorrect. Retry?", "Incorrect input", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
                textBox1.Focus();
                textBox1.SelectAll();
            }
        }
    }
}
