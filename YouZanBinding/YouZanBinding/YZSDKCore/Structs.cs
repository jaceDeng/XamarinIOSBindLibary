using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace YZSDKCore
{
    static class CFunctions
    {
        // extern void YZSDKLog (NSString *format, ...);
        [DllImport("__Internal")]
       // [Verify(PlatformInvoke)]
        static extern void YZSDKLog(NSString format, IntPtr varArgs);
    }

    [Native]
    public enum YZSMBProgressHUDMode : long
    {
        Indeterminate,
        Determinate,
        DeterminateHorizontalBar,
        AnnularDeterminate,
        CustomView,
        Text
    }

    [Native]
    public enum YZSMBProgressHUDAnimation : long
    {
        Fade,
        Zoom,
        ZoomOut,
        ZoomIn
    }

    [Native]
    public enum YZSMBProgressHUDBackgroundStyle : long
    {
        SolidColor,
        Blur
    }

}

