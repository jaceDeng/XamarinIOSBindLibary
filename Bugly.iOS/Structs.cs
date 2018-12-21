using System;

namespace Bugly.iOS
{
     

   
    public enum BuglyLogLevel : ulong
    {
        Silent = 0,
        Error = 1,
        Warn = 2,
        Info = 3,
        Debug = 4,
        Verbose = 5
    }
}