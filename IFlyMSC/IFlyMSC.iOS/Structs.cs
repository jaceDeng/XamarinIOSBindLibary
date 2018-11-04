using System; 
using ObjCRuntime;
namespace IFlyMSC.iOS
{
  

    [Native]
    public enum LogLevel : long
    {
        All = -1,
        Detail = 31,
        Normal = 15,
        Low = 7,
        None = 0
    }

    [Native]
    public enum IFlySpeechEventType : ulong
    {
        NetPref = 10001,
        ISTAudioFile = 10004,
        ISTUploadBytes = 10006,
        ISTCacheLeft = 10007,
        ISTResultTime = 10008,
        ISTSyncID = 10009,
        SessionBegin = 10010,
        SessionEnd = 10011,
        Volume = 10012,
        VadEOS = 10013,
        SessionID = 20001,
        TTSBuffer = 21001,
        TTSCancel = 21002,
        IVWResult = 22001,
        SpeechStart = 22002,
        RecordStop = 22003,
        AudioUrl = 23001,
        VoiceChangeResult = 24001
    }

    [Native]
    public enum IFlyEngineMode : ulong
    {
        Auto = 0,
        Msc,
        Plus
    }

    [Native]
    public enum IFlySpeechPlusServiceType : ulong
    {
        None = 0,
        Tts,
        Isr,
        Ivw
    }

}
