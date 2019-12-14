namespace ChizzBot
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbChannel = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.DebugLog = new System.Windows.Forms.RichTextBox();
            this.dgvTracklist = new System.Windows.Forms.DataGridView();
            this.btnAddTrack = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnRemoveTrack = new System.Windows.Forms.Button();
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tbVolume = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracklist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // tbChannel
            // 
            this.tbChannel.Location = new System.Drawing.Point(12, 12);
            this.tbChannel.Name = "tbChannel";
            this.tbChannel.Size = new System.Drawing.Size(132, 20);
            this.tbChannel.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(144, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(68, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // DebugLog
            // 
            this.DebugLog.Location = new System.Drawing.Point(250, 10);
            this.DebugLog.Name = "DebugLog";
            this.DebugLog.ReadOnly = true;
            this.DebugLog.Size = new System.Drawing.Size(214, 172);
            this.DebugLog.TabIndex = 2;
            this.DebugLog.TabStop = false;
            this.DebugLog.Text = "";
            this.DebugLog.TextChanged += new System.EventHandler(this.DebugLog_TextChanged);
            // 
            // dgvTracklist
            // 
            this.dgvTracklist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTracklist.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTracklist.Location = new System.Drawing.Point(12, 38);
            this.dgvTracklist.MultiSelect = false;
            this.dgvTracklist.Name = "dgvTracklist";
            this.dgvTracklist.RowHeadersVisible = false;
            this.dgvTracklist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTracklist.Size = new System.Drawing.Size(200, 100);
            this.dgvTracklist.TabIndex = 3;
            this.dgvTracklist.TabStop = false;
            // 
            // btnAddTrack
            // 
            this.btnAddTrack.Location = new System.Drawing.Point(12, 144);
            this.btnAddTrack.Name = "btnAddTrack";
            this.btnAddTrack.Size = new System.Drawing.Size(68, 38);
            this.btnAddTrack.TabIndex = 4;
            this.btnAddTrack.TabStop = false;
            this.btnAddTrack.Text = "Add New";
            this.btnAddTrack.UseVisualStyleBackColor = true;
            this.btnAddTrack.Click += new System.EventHandler(this.BtnAddTrack_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Tracks (mp3)|*.mp3|All|*.*";
            // 
            // btnRemoveTrack
            // 
            this.btnRemoveTrack.Location = new System.Drawing.Point(144, 142);
            this.btnRemoveTrack.Name = "btnRemoveTrack";
            this.btnRemoveTrack.Size = new System.Drawing.Size(68, 40);
            this.btnRemoveTrack.TabIndex = 5;
            this.btnRemoveTrack.TabStop = false;
            this.btnRemoveTrack.Text = "Remove selected";
            this.btnRemoveTrack.UseVisualStyleBackColor = true;
            this.btnRemoveTrack.Click += new System.EventHandler(this.BtnRemoveTrack_Click);
            // 
            // numTimeout
            // 
            this.numTimeout.Location = new System.Drawing.Point(86, 158);
            this.numTimeout.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTimeout.Name = "numTimeout";
            this.numTimeout.Size = new System.Drawing.Size(52, 20);
            this.numTimeout.TabIndex = 6;
            this.numTimeout.TabStop = false;
            this.numTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTimeout.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(80, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Timeout (s)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbVolume
            // 
            this.tbVolume.AutoSize = false;
            this.tbVolume.Location = new System.Drawing.Point(221, 54);
            this.tbVolume.Maximum = 100;
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbVolume.Size = new System.Drawing.Size(26, 128);
            this.tbVolume.TabIndex = 8;
            this.tbVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbVolume.Value = 50;
            this.tbVolume.Scroll += new System.EventHandler(this.TbVolume_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "vol";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 188);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbVolume);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numTimeout);
            this.Controls.Add(this.btnRemoveTrack);
            this.Controls.Add(this.btnAddTrack);
            this.Controls.Add(this.dgvTracklist);
            this.Controls.Add(this.DebugLog);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbChannel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChizzBot";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracklist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbChannel;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.RichTextBox DebugLog;
        private System.Windows.Forms.DataGridView dgvTracklist;
        private System.Windows.Forms.Button btnAddTrack;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnRemoveTrack;
        public System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbVolume;
        private System.Windows.Forms.Label label2;
    }
}

