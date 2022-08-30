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
using DirectShowLib.MultimediaStreaming;

namespace ZsDV
{
    internal class DvRecorder
    {
        public DsDevice Video { get; private set; }
        public DsDevice Audio { get; private set; }

        private IBaseFilter videoFilter;
        private IBaseFilter audioFilter;

        private IAMExtDevice externalCam;
        private IAMExtTransport transport;
        private IAMTimecodeReader timecodeReader;

        private IBaseFilter DVSplitter;
        private IBaseFilter DVVideoCodec;

        private IFilterGraph2 graph;
        private ICaptureGraphBuilder2 captureGraphBuilder;


        public DvRecorder()
        {
            graph = new FilterGraph() as IFilterGraph2;
            captureGraphBuilder = new CaptureGraphBuilder2() as ICaptureGraphBuilder2;
            captureGraphBuilder.SetFiltergraph(graph);
        }

        public bool IsReady() =>
            videoFilter != null &&
            audioFilter != null &&
            externalCam != null &&
            transport != null &&
            timecodeReader != null &&
            DVSplitter != null &&
            DVVideoCodec != null;

        public void StartRecord()
        {
            BindDVControls();
            CreateNodes();
            BuildGraph();
        }

        private void BuildGraph()
        {
            if (!IsReady())
                throw new Exception("Filter initialization error!");

            graph.AddFilter(videoFilter, "VideoInput");
            graph.AddFilter(DVSplitter, "Splitter");
            graph.AddFilter(DVVideoCodec, "Codec");
            captureGraphBuilder.RenderStream(PinCategory.Preview, MediaType.Video, videoFilter, null, null);
        }

        private void CreateNodes()
        {
            DVSplitter = new DVSplitter() as IBaseFilter;
            DVVideoCodec = new DVVideoCodec() as IBaseFilter;
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

        public void BindVideoDevice(DsDevice device)
        {
            if (device == null)
                throw new ArgumentNullException();
            var baseFilterGuid = typeof(IBaseFilter).GUID;
            Video = device;
            Video.Mon.BindToObject(null, null, baseFilterGuid, out object video);
            videoFilter = video as IBaseFilter;
        }

        public void BindAudioDevice(DsDevice device)
        {
            if (device == null)
                throw new ArgumentNullException();
            var baseFilterGuid = typeof(IBaseFilter).GUID;
            Audio = device;
            Audio.Mon.BindToObject(null, null, baseFilterGuid, out object audio);
            audioFilter = audio as IBaseFilter;
        }

        private static List<string> GetPinIds(IBaseFilter filter)
        {
            filter.EnumPins(out IEnumPins enumerator);
            var result = new List<string>();
            var pins = new IPin[1];
            while (enumerator.Next(1, pins, (IntPtr)0) == 0)
            {
                pins[0].QueryDirection(out PinDirection pinDirection);
                pins[0].QueryId(out string id);
                result.Add(id);
            }
            return result;
        }

        public List<string> GetVideoPinIds()
        {
            return GetPinIds(videoFilter);
        }

        public List<string> GetAudioPinIds()
        {
            return GetPinIds(audioFilter);
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
