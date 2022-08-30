using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectShowLib;
using DirectShowLib.BDA;
using DirectShowLib.DES;
using DirectShowLib.DMO;

namespace ZsDV
{
    public partial class MainFrom : Form
    {
        private DvRecorder recorder;
        private string state = "...";

        private void RefreshDevices()
        {
            UpdateListBox(lb_VideoDevices, DeviceManager.GetVideoDevices().Select(a => new DsDeviceListItem(a)));
            UpdateListBox(lb_AudioDevices, DeviceManager.GetAudioDevices().Select(a => new DsDeviceListItem(a)));
        }

        private void UpdateLabels()
        {
            var v = recorder.Video == null ? "NO DEVICE" : recorder.Video.Name;
            var a = recorder.Audio == null ? "NO DEVICE" : recorder.Audio.Name;

            lbl_SelectedVideo.Text = $"Video device: {v}";
            lbl_SelectedAudio.Text = $"Audio device: {a}";
        }

        private void UpdateCaption()
        {
            Text = $"ZsDV  -  {state}";
#if DEBUG
            Text = $"{Text} | DEBUG Build time: {Properties.Resources.BuildDate}";
#endif
        }

        public MainFrom()
        {
            recorder = new DvRecorder();
            InitializeComponent();
        }

        private void MainFrom_Load(object sender, EventArgs e)
        {
            RefreshDevices();
            UpdateLabels();
            UpdateCaption();
        }

        private void btn_RefreshDevices_Click(object sender, EventArgs e)
        {
            RefreshDevices();
        }

        private void lb_VideoDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_VideoDevices.SelectedItem == null)
                return;                        
            recorder.BindVideoDevice((lb_VideoDevices.SelectedItem as DsDeviceListItem).DsDevice);
            UpdateListBox(lb_VideoPins, recorder.GetVideoPinIds());
            UpdateLabels();
        }

        private void lb_AudioDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_AudioDevices.SelectedItem == null)
                return;
            recorder.BindAudioDevice((lb_AudioDevices.SelectedItem as DsDeviceListItem).DsDevice);
            UpdateListBox(lb_AudioPins, recorder.GetAudioPinIds());
            UpdateLabels();
        }

        private void UpdateListBox<T>(ListBox lb, IEnumerable<T> list)
        {
            lb.Items.Clear();
            foreach (var item in list)            
                lb.Items.Add(item);            
        }

        private void btn_Record_Click(object sender, EventArgs e)
        {
            try
            {
                recorder.StartRecord();
                state = "Recording";
                UpdateCaption();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, exc.TargetSite.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class DsDeviceListItem
    {
        public DsDevice DsDevice;
        public DsDeviceListItem(DsDevice dev) => DsDevice = dev;
        public override string ToString() => DsDevice.Name;
    }
}
