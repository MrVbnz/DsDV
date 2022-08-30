using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ZsDV
{
    public struct Timecode
    {
        public ulong qw;
    }

    public struct TimecodeData
    {
        public ushort wFrameRate;
        public ushort wFrameFract;
        public uint dwFrames;
    }

    public struct TimecodeSample
    {
        public long qwTick;
        public Timecode timecode;
        public uint dwUser;
        public uint dwFlags;
    }

    public struct TimecodeDataSample
    {
        public long qwTick;
        public TimecodeData timecode;
        public uint dwUser;
        public uint dwFlags;
    }


    [ComImport]
    [Guid("9b496ce1-811b-11cf-8c77-00aa006b6814")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [SuppressUnmanagedCodeSecurity]
    public interface IAMTimecodeReader
    {
        [PreserveSig]
        int GetTCRMode(long Param, out long pValue);
        [PreserveSig]
        int SetTCRMode(long Param, long Value);
        [PreserveSig]
        int put_VITCLine(long Line);
        [PreserveSig]
        int get_VITCLine(out long pLine);
        [PreserveSig]
        int GetTimecode(TimecodeSample pTimecodeSample);
    }
}
