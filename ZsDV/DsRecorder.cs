using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DirectShowLib;
using DirectShowLib.BDA;
using DirectShowLib.DES;
using DirectShowLib.DMO;
using DirectShowLib.Dvd;
using DirectShowLib.SBE;

namespace ZsDV
{
    internal class DvRecorder
    {
        public DsDevice Video;
        public DsDevice Audio;
        private IBaseFilter videoFilter;
        private IBaseFilter audioFilter;
        private IAMExtDevice externalCam;
        private IAMExtTransport transport;       
        private IAMTimecodeReader timecodeReader;

        IFilterGraph3 graph;

        public DvRecorder()
        {
            graph = new FilterGraph() as IFilterGraph3;
        }

        public bool IsBinded() => videoFilter != null && audioFilter != null;

        public void StartRecord()
        {
            BindDevices();
            BindDVControls();
        }

        private void BindDVControls()
        {          
            externalCam = (IAMExtDevice)videoFilter;
            externalCam.GetCapability(ExtDeviceCaps.DeviceType, 
                out ExtDeviceCaps caps, 
                out double old);
            if (caps != ExtDeviceCaps.VCR)
                throw new Exception("Device is not VCR/VTR");

            transport = (IAMExtTransport)videoFilter;
            timecodeReader = (IAMTimecodeReader)audioFilter;           
        }

        public void BindDevices()
        {
            if (Video == null)
                throw new Exception("No video device");
            if (Audio == null)
                throw new Exception("No audio device");
            var baseFilterGuid = typeof(IBaseFilter).GUID;
            Video.Mon.BindToObject(null, null, baseFilterGuid, out object video);
            Audio.Mon.BindToObject(null, null, baseFilterGuid, out object audio);
            videoFilter = video as IBaseFilter;
            audioFilter = audio as IBaseFilter;
        }
    }

    public class DeviceManager
    {
        public static List<DsDevice> GetVideoDevices() =>
            DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice).ToList();
        public static List<DsDevice> GetAudioDevices() =>
            DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice).ToList();
    }
}
