using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace Bugly.iOS
{


    // @interface BuglyLog : NSObject
    [BaseType(typeof(NSObject))]
    interface BuglyLog
    {
        // +(void)initLogger:(BuglyLogLevel)level consolePrint:(BOOL)printConsole;
        [Static]
        [Export("initLogger:consolePrint:")]
        void InitLogger(BuglyLogLevel level, bool printConsole);

        // +(void)log:(NSString *)format, ... __attribute__((format(NSString, 1, 2)));
        [Static, Internal]
        [Export("log:", IsVariadic = true)]
        void Log(string format, IntPtr varArgs);

        // +(void)level:(BuglyLogLevel)level logs:(NSString *)message;
        [Static]
        [Export("level:logs:")]
        void Level(BuglyLogLevel level, string message);

        // +(void)level:(BuglyLogLevel)level log:(NSString *)format, ... __attribute__((format(NSString, 2, 3)));
        [Static, Internal]
        [Export("level:log:", IsVariadic = true)]
        void Level(BuglyLogLevel level, string format, IntPtr varArgs);

        // +(void)level:(BuglyLogLevel)level tag:(NSString *)tag log:(NSString *)format, ... __attribute__((format(NSString, 3, 4)));
        [Static, Internal]
        [Export("level:tag:log:", IsVariadic = true)]
        void Level(BuglyLogLevel level, string tag, string format, IntPtr varArgs);
    }

    // @protocol BuglyDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BuglyDelegate
    {
        // @optional -(NSString * _Nullable)attachmentForException:(NSException * _Nullable)exception;
        [Export("attachmentForException:")]
        [return: NullAllowed]
        string AttachmentForException([NullAllowed] NSException exception);
    }

    // @interface BuglyConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface BuglyConfig
    {
        // @property (assign, nonatomic) BOOL debugMode;
        [Export("debugMode")]
        bool DebugMode { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull channel;
        [Export("channel")]
        string Channel { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull version;
        [Export("version")]
        string Version { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull deviceIdentifier;
        [Export("deviceIdentifier")]
        string DeviceIdentifier { get; set; }

        // @property (nonatomic) BOOL blockMonitorEnable;
        [Export("blockMonitorEnable")]
        bool BlockMonitorEnable { get; set; }

        // @property (nonatomic) NSTimeInterval blockMonitorTimeout;
        [Export("blockMonitorTimeout")]
        double BlockMonitorTimeout { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull applicationGroupIdentifier;
        [Export("applicationGroupIdentifier")]
        string ApplicationGroupIdentifier { get; set; }

        // @property (nonatomic) BOOL symbolicateInProcessEnable;
        [Export("symbolicateInProcessEnable")]
        bool SymbolicateInProcessEnable { get; set; }

        // @property (nonatomic) BOOL unexpectedTerminatingDetectionEnable;
        [Export("unexpectedTerminatingDetectionEnable")]
        bool UnexpectedTerminatingDetectionEnable { get; set; }

        // @property (nonatomic) BOOL viewControllerTrackingEnable;
        [Export("viewControllerTrackingEnable")]
        bool ViewControllerTrackingEnable { get; set; }

        [Wrap("WeakDelegate")]
        BuglyDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<BuglyDelegate> _Nonnull delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (assign, nonatomic) BuglyLogLevel reportLogLevel;
        [Export("reportLogLevel", ArgumentSemantic.Assign)]
        BuglyLogLevel ReportLogLevel { get; set; }

        // @property (copy, nonatomic) NSArray * _Nonnull excludeModuleFilter;
        [Export("excludeModuleFilter", ArgumentSemantic.Copy)]
      //  [Verify(StronglyTypedNSArray)]
        NSObject[] ExcludeModuleFilter { get; set; }

        // @property (assign, nonatomic) BOOL consolelogEnable;
        [Export("consolelogEnable")]
        bool ConsolelogEnable { get; set; }

        // @property (assign, nonatomic) NSUInteger crashAbortTimeout;
        [Export("crashAbortTimeout")]
        nuint CrashAbortTimeout { get; set; }
    }

    // @interface Bugly : NSObject
    [BaseType(typeof(NSObject))]
    interface Bugly
    {
        // +(void)startWithAppId:(NSString * _Nullable)appId;
        [Static]
        [Export("startWithAppId:")]
        void StartWithAppId([NullAllowed] string appId);

        // +(void)startWithAppId:(NSString * _Nullable)appId config:(BuglyConfig * _Nullable)config;
        [Static]
        [Export("startWithAppId:config:")]
        void StartWithAppId([NullAllowed] string appId, [NullAllowed] BuglyConfig config);

        // +(void)startWithAppId:(NSString * _Nullable)appId developmentDevice:(BOOL)development config:(BuglyConfig * _Nullable)config;
        [Static]
        [Export("startWithAppId:developmentDevice:config:")]
        void StartWithAppId([NullAllowed] string appId, bool development, [NullAllowed] BuglyConfig config);

        // +(void)setUserIdentifier:(NSString * _Nonnull)userId;
        [Static]
        [Export("setUserIdentifier:")]
        void SetUserIdentifier(string userId);

        // +(void)updateAppVersion:(NSString * _Nonnull)version;
        [Static]
        [Export("updateAppVersion:")]
        void UpdateAppVersion(string version);

        // +(void)setUserValue:(NSString * _Nonnull)value forKey:(NSString * _Nonnull)key;
        [Static]
        [Export("setUserValue:forKey:")]
        void SetUserValue(string value, string key);

        // +(NSDictionary * _Nullable)allUserValues;
        [Static]
        [NullAllowed, Export("allUserValues")]
       // [Verify(MethodToProperty)]
        NSDictionary AllUserValues { get; }

        // +(void)setTag:(NSUInteger)tag;
        [Static]
        [Export("setTag:")]
        void SetTag(nuint tag);

        // +(NSUInteger)currentTag;
        [Static]
        [Export("currentTag")]
        //[Verify(MethodToProperty)]
        nuint CurrentTag { get; }

        // +(NSString * _Nonnull)buglyDeviceId;
        [Static]
        [Export("buglyDeviceId")]
      //  [Verify(MethodToProperty)]
        string BuglyDeviceId { get; }

        // +(void)reportException:(NSException * _Nonnull)exception;
        [Static]
        [Export("reportException:")]
        void ReportException(NSException exception);

        // +(void)reportError:(NSError * _Nonnull)error;
        [Static]
        [Export("reportError:")]
        void ReportError(NSError error);

        // +(void)reportExceptionWithCategory:(NSUInteger)category name:(NSString * _Nonnull)aName reason:(NSString * _Nonnull)aReason callStack:(NSArray * _Nonnull)aStackArray extraInfo:(NSDictionary * _Nonnull)info terminateApp:(BOOL)terminate;
        [Static]
        [Export("reportExceptionWithCategory:name:reason:callStack:extraInfo:terminateApp:")]
      //  [Verify(StronglyTypedNSArray)]
        void ReportExceptionWithCategory(nuint category, string aName, string aReason, NSObject[] aStackArray, NSDictionary info, bool terminate);

        // +(NSString * _Nonnull)sdkVersion;
        [Static]
        [Export("sdkVersion")]
      //  [Verify(MethodToProperty)]
        string SdkVersion { get; }

        // +(BOOL)isAppCrashedOnStartUpExceedTheLimit;
        [Static]
        [Export("isAppCrashedOnStartUpExceedTheLimit")]
     //   [Verify(MethodToProperty)]
        bool IsAppCrashedOnStartUpExceedTheLimit { get; }
    }

}