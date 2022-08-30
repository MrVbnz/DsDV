namespace ZsDV
{
    partial class MainFrom
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_VideoDevices = new System.Windows.Forms.ListBox();
            this.btn_RefreshDevices = new System.Windows.Forms.Button();
            this.gb_Devices = new System.Windows.Forms.GroupBox();
            this.lbl_SelectedAudio = new System.Windows.Forms.Label();
            this.lbl_SelectedVideo = new System.Windows.Forms.Label();
            this.lbl_AudioDevs = new System.Windows.Forms.Label();
            this.lbl_VideoDevs = new System.Windows.Forms.Label();
            this.lb_AudioDevices = new System.Windows.Forms.ListBox();
            this.btn_Record = new System.Windows.Forms.Button();
            this.gb_OutputSelection = new System.Windows.Forms.GroupBox();
            this.gb_Devices.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_VideoDevices
            // 
            this.lb_VideoDevices.FormattingEnabled = true;
            this.lb_VideoDevices.Location = new System.Drawing.Point(8, 91);
            this.lb_VideoDevices.Name = "lb_VideoDevices";
            this.lb_VideoDevices.Size = new System.Drawing.Size(245, 121);
            this.lb_VideoDevices.TabIndex = 0;
            this.lb_VideoDevices.SelectedIndexChanged += new System.EventHandler(this.lb_VideoDevices_SelectedIndexChanged);
            // 
            // btn_RefreshDevices
            // 
            this.btn_RefreshDevices.Location = new System.Drawing.Point(6, 19);
            this.btn_RefreshDevices.Name = "btn_RefreshDevices";
            this.btn_RefreshDevices.Size = new System.Drawing.Size(92, 32);
            this.btn_RefreshDevices.TabIndex = 1;
            this.btn_RefreshDevices.Text = "Refresh";
            this.btn_RefreshDevices.UseVisualStyleBackColor = true;
            this.btn_RefreshDevices.Click += new System.EventHandler(this.btn_RefreshDevices_Click);
            // 
            // gb_Devices
            // 
            this.gb_Devices.Controls.Add(this.lbl_SelectedAudio);
            this.gb_Devices.Controls.Add(this.lbl_SelectedVideo);
            this.gb_Devices.Controls.Add(this.lbl_AudioDevs);
            this.gb_Devices.Controls.Add(this.lbl_VideoDevs);
            this.gb_Devices.Controls.Add(this.lb_AudioDevices);
            this.gb_Devices.Controls.Add(this.btn_RefreshDevices);
            this.gb_Devices.Controls.Add(this.lb_VideoDevices);
            this.gb_Devices.Location = new System.Drawing.Point(12, 12);
            this.gb_Devices.Name = "gb_Devices";
            this.gb_Devices.Size = new System.Drawing.Size(510, 218);
            this.gb_Devices.TabIndex = 2;
            this.gb_Devices.TabStop = false;
            this.gb_Devices.Text = "Device selection";
            // 
            // lbl_SelectedAudio
            // 
            this.lbl_SelectedAudio.AutoSize = true;
            this.lbl_SelectedAudio.Location = new System.Drawing.Point(104, 38);
            this.lbl_SelectedAudio.Name = "lbl_SelectedAudio";
            this.lbl_SelectedAudio.Size = new System.Drawing.Size(98, 13);
            this.lbl_SelectedAudio.TabIndex = 6;
            this.lbl_SelectedAudio.Text = "Audio: NO DEVICE";
            // 
            // lbl_SelectedVideo
            // 
            this.lbl_SelectedVideo.AutoSize = true;
            this.lbl_SelectedVideo.Location = new System.Drawing.Point(104, 19);
            this.lbl_SelectedVideo.Name = "lbl_SelectedVideo";
            this.lbl_SelectedVideo.Size = new System.Drawing.Size(98, 13);
            this.lbl_SelectedVideo.TabIndex = 5;
            this.lbl_SelectedVideo.Text = "Video: NO DEVICE";
            // 
            // lbl_AudioDevs
            // 
            this.lbl_AudioDevs.AutoSize = true;
            this.lbl_AudioDevs.Location = new System.Drawing.Point(256, 75);
            this.lbl_AudioDevs.Name = "lbl_AudioDevs";
            this.lbl_AudioDevs.Size = new System.Drawing.Size(74, 13);
            this.lbl_AudioDevs.TabIndex = 4;
            this.lbl_AudioDevs.Text = "Audio devices";
            // 
            // lbl_VideoDevs
            // 
            this.lbl_VideoDevs.AutoSize = true;
            this.lbl_VideoDevs.Location = new System.Drawing.Point(6, 75);
            this.lbl_VideoDevs.Name = "lbl_VideoDevs";
            this.lbl_VideoDevs.Size = new System.Drawing.Size(74, 13);
            this.lbl_VideoDevs.TabIndex = 3;
            this.lbl_VideoDevs.Text = "Video devices";
            // 
            // lb_AudioDevices
            // 
            this.lb_AudioDevices.FormattingEnabled = true;
            this.lb_AudioDevices.Location = new System.Drawing.Point(259, 91);
            this.lb_AudioDevices.Name = "lb_AudioDevices";
            this.lb_AudioDevices.Size = new System.Drawing.Size(245, 121);
            this.lb_AudioDevices.TabIndex = 2;
            this.lb_AudioDevices.SelectedIndexChanged += new System.EventHandler(this.lb_AudioDevices_SelectedIndexChanged);
            // 
            // btn_Record
            // 
            this.btn_Record.Location = new System.Drawing.Point(528, 21);
            this.btn_Record.Name = "btn_Record";
            this.btn_Record.Size = new System.Drawing.Size(44, 32);
            this.btn_Record.TabIndex = 3;
            this.btn_Record.Text = "REC";
            this.btn_Record.UseVisualStyleBackColor = true;
            this.btn_Record.Click += new System.EventHandler(this.btn_Record_Click);
            // 
            // gb_OutputSelection
            // 
            this.gb_OutputSelection.Location = new System.Drawing.Point(12, 236);
            this.gb_OutputSelection.Name = "gb_OutputSelection";
            this.gb_OutputSelection.Size = new System.Drawing.Size(510, 218);
            this.gb_OutputSelection.TabIndex = 4;
            this.gb_OutputSelection.TabStop = false;
            this.gb_OutputSelection.Text = "Output settings";
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 590);
            this.Controls.Add(this.gb_OutputSelection);
            this.Controls.Add(this.btn_Record);
            this.Controls.Add(this.gb_Devices);
            this.Name = "MainFrom";
            this.Text = "ZsDV";
            this.Load += new System.EventHandler(this.MainFrom_Load);
            this.gb_Devices.ResumeLayout(false);
            this.gb_Devices.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_VideoDevices;
        private System.Windows.Forms.Button btn_RefreshDevices;
        private System.Windows.Forms.GroupBox gb_Devices;
        private System.Windows.Forms.Label lbl_AudioDevs;
        private System.Windows.Forms.Label lbl_VideoDevs;
        private System.Windows.Forms.ListBox lb_AudioDevices;
        private System.Windows.Forms.Label lbl_SelectedAudio;
        private System.Windows.Forms.Label lbl_SelectedVideo;
        private System.Windows.Forms.Button btn_Record;
        private System.Windows.Forms.GroupBox gb_OutputSelection;
    }
}

