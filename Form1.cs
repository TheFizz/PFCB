using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PFCB
{
    public partial class Form1 : Form
    {
        PFCB bot;
        public bool connectState = false;
        public Form1()
        {
            InitializeComponent();
            CreateBot();
        }

        public void UpdateDataGrid()
        {
            try
            {
                BindingSource bSource = new BindingSource();
                bSource.DataSource = bot.tracks;
                bSource.AllowNew = false;
                dgvTracklist.DataSource = bSource;
                dgvTracklist.Columns["trackPath"].Visible = false;
                dgvTracklist.Columns["trackCommand"].HeaderText = "Command";
                dgvTracklist.Columns["trackCommand"].Width = 80;
                dgvTracklist.Columns["trackName"].HeaderText = "Filename";
                dgvTracklist.Columns["trackName"].Width = 117;
            }
            catch
            {

            }
        }

        public void CreateBot()
        {
            bot = new PFCB(this);
            LoadTracks();
            bot.volume = tbVolume.Value;
        }

        public void AppendLogLine(string text)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendLogLine), new object[] { text });
                return;
            }
            DebugLog.Text += text + "\n";
        }

        public void LoadTracks()
        {
           if(File.Exists("tracks.ptl"))
                DeserializeTracks();
        }

        public void LockControls(bool state)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(LockControls), new object[] { state });
                return;
            }
            tbChannel.Enabled = !state;
            btnConnect.Enabled = !state;
        }

        public void ModifyButton(string text, bool enabled)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string, bool>(ModifyButton), new object[] { text, enabled });
                return;
            }
            btnConnect.Text = text;
            btnConnect.Enabled = enabled;
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (!connectState)
            {
                LockControls(true);
                bot.Connect(tbChannel.Text);
            }
            if (connectState)
                bot.Disconnect();
        }

        private void BtnAddTrack_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = openFileDialog1.SafeFileName;
                using (var form = new Form2())
                {
                    form.tracks = bot.tracks;
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string val = form.ReturnValue1;
                        bot.tracks.Add(new PlayableTrack { trackCommand = val, trackPath = openFileDialog1.FileName, trackName = openFileDialog1.SafeFileName });
                        SerializeTracks();
                    }
                }
            }
        }
        public void SerializeTracks()
        {
            StreamWriter writer = File.CreateText("tracks.ptl");
            var json = JsonSerializer.CreateDefault();
            json.Serialize(writer, bot.tracks);
            writer.Close();
            UpdateDataGrid();
        }

        public void DeserializeTracks()
        {
            StreamReader reader = new StreamReader("tracks.ptl");
            var json = JsonSerializer.CreateDefault();
            bot.tracks = JsonConvert.DeserializeObject<List<PlayableTrack>>(reader.ReadToEnd());
            reader.Close();
            UpdateDataGrid();
        }

        private void BtnRemoveTrack_Click(object sender, EventArgs e)
        {
            try
            {
                bot.tracks.RemoveAt(dgvTracklist.CurrentRow.Index);
                SerializeTracks();
                UpdateDataGrid();
            }
            catch
            {

            }
        }

        private void DebugLog_TextChanged(object sender, EventArgs e)
        {
            DebugLog.SelectionStart = DebugLog.Text.Length;
            DebugLog.ScrollToCaret();
            if(DebugLog.Text.Length > 10000)
            {
                DebugLog.Text = DebugLog.Text.Remove(0, 2000);
                int idx = DebugLog.Text.IndexOf('\n');
                if (idx != -1) DebugLog.Text = DebugLog.Text.Remove(0, idx);
            }
        }

        private void TbVolume_Scroll(object sender, EventArgs e)
        {
            bot.volume = tbVolume.Value;
        }
    }
}
