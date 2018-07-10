using System;
using ObjCRuntime;

namespace YZBaseSDK
{
    [Native]
    public enum YZWebViewType : ulong
    {
        UIWebView,
        WKWebView
    }

    [Native]
    public enum YZNoticeType : ulong
    {
        Other = 0,
        Login,
        Share,
        Ready
    }

    [Introduced(PlatformName.iOS, 2, 0, message: "use YZNoticeType instead")]
    [Deprecated(PlatformName.iOS, 2, 0, message: "use YZNoticeType instead")]
    [Native]
    public enum YouzanNotice : ulong
    {
        NotYouzanNotice = (1 << 0),
        IsYouzanNotice = (1 << 1),
        YouzanNoticeLogin = (1 << 2),
        YouzanNoticeShare = (1 << 3),
        YouzanNoticeReady = (1 << 4),
        YouzanNoticeWXWapPay = (1 << 5),
        YouzanNoticeOther = (1 << 6)
    }

}

