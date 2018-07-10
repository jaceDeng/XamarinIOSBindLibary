using System;
using Foundation;
using JavaScriptCore;
using ObjCRuntime;
using UIKit;

namespace YZBaseSDK
{
    // The first step to creating a binding is to add your native library ("libNativeLibrary.a")
    // to the project by right-clicking (or Control-clicking) the folder containing this source
    // file and clicking "Add files..." and then simply select the native library (or libraries)
    // that you want to bind.
    //
    // When you do that, you'll notice that MonoDevelop generates a code-behind file for each
    // native library which will contain a [LinkWith] attribute. VisualStudio auto-detects the
    // architectures that the native library supports and fills in that information for you,
    // however, it cannot auto-detect any Frameworks or other system libraries that the
    // native library may depend on, so you'll need to fill in that information yourself.
    //
    // Once you've done that, you're ready to move on to binding the API...
    //
    //
    // Here is where you'd define your API definition for the native Objective-C library.
    //
    // For example, to bind the following Objective-C class:
    //
    //     @interface Widget : NSObject {
    //     }
    //
    // The C# binding would look like this:
    //
    //     [BaseType (typeof (NSObject))]
    //     interface Widget {
    //     }
    //
    // To bind Objective-C properties, such as:
    //
    //     @property (nonatomic, readwrite, assign) CGPoint center;
    //
    // You would add a property definition in the C# interface like so:
    //
    //     [Export ("center")]
    //     CGPoint Center { get; set; }
    //
    // To bind an Objective-C method, such as:
    //
    //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
    //
    // You would add a method definition to the C# interface like so:
    //
    //     [Export ("doSomething:atIndex:")]
    //     void DoSomething (NSObject object, int index);
    //
    // Objective-C "constructors" such as:
    //
    //     -(id)initWithElmo:(ElmoMuppet *)elmo;
    //
    // Can be bound as:
    //
    //     [Export ("initWithElmo:")]
    //     IntPtr Constructor (ElmoMuppet elmo);
    //
    // For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_types
    //
    [Static]
   // [Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern double YZBaseSDKVersionNumber;
        [Field("YZBaseSDKVersionNumber", "__Internal")]
        double YZBaseSDKVersionNumber { get; }

        // extern const unsigned char [] YZBaseSDKVersionString;
        [Field("YZBaseSDKVersionString", "__Internal")]
        NSString YZBaseSDKVersionString { get; }
    }

    // @protocol YZSDKDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YZSDKDelegate
    {
        // @required -(void)yzsdk:(YZSDK * _Nonnull)sdk needInitToken:(void (^ _Nonnull)(NSString * _Nullable))callback;
        [Abstract]
        [Export("yzsdk:needInitToken:")]
        void NeedInitToken(YZSDK sdk, Action<NSString> callback);
    }

    // @interface YZSDK : NSObject
    [BaseType(typeof(NSObject))]
    interface YZSDK
    {
        // @property (readonly, strong, class) YZSDK * _Nonnull shared;
        [Static]
        [Export("shared", ArgumentSemantic.Strong)]
        YZSDK Shared { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        YZSDKDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<YZSDKDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic) NSString * _Nullable accessToken;
        [NullAllowed, Export("accessToken")]
        string AccessToken { get; }

        // @property (readonly, nonatomic) YZConfig * _Nonnull config;
        [Export("config")]
        YZConfig Config { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull version;
        [Export("version")]
        string Version { get; }

        // -(void)initializeSDKWithConfig:(YZConfig * _Nonnull)config;
        [Export("initializeSDKWithConfig:")]
        void InitializeSDKWithConfig(YZConfig config);

        // -(void)synchronizeAccessToken:(NSString * _Nonnull)token cookieKey:(NSString * _Nullable)key cookieValue:(NSString * _Nullable)value;
        [Export("synchronizeAccessToken:cookieKey:cookieValue:")]
        void SynchronizeAccessToken(string token, [NullAllowed] string key, [NullAllowed] string value);

        // -(void)logout;
        [Export("logout")]
        void Logout();

        // -(void)preloadURLs:(NSArray<NSURL *> * _Nonnull)urls;
        [Export("preloadURLs:")]
        void PreloadURLs(NSUrl[] urls);
    }

    // @interface YZConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface YZConfig
    {
        // @property (readonly, nonatomic) NSString * _Nonnull clientId;
        [Export("clientId")]
        string ClientId { get; }

        // @property (copy, nonatomic) NSString * _Nullable scheme;
        [NullAllowed, Export("scheme")]
        string Scheme { get; set; }

        // @property (assign, nonatomic) BOOL enableLog;
        [Export("enableLog")]
        bool EnableLog { get; set; }

        // @property (nonatomic, strong) YZHTMLConfig * _Nullable htmlCacheConfig;
        [NullAllowed, Export("htmlCacheConfig", ArgumentSemantic.Strong)]
        YZHTMLConfig HtmlCacheConfig { get; set; }

        // -(instancetype _Nonnull)initWithClientId:(NSString * _Nonnull)clientId __attribute__((objc_designated_initializer));
        [Export("initWithClientId:")]
        [DesignatedInitializer]
        IntPtr Constructor(string clientId);
    }

    // @interface YZHTMLConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface YZHTMLConfig
    {
        // @property (assign, nonatomic) BOOL htmlCacheEnable;
        [Export("htmlCacheEnable")]
        bool HtmlCacheEnable { get; set; }

        // @property (assign, nonatomic) NSInteger htmlCacheValidTime;
        [Export("htmlCacheValidTime")]
        nint HtmlCacheValidTime { get; set; }
    }

    // @protocol YZWebViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IYZWebViewDelegate
    {
        // @optional -(BOOL)webView:(id<YZWebView> _Nonnull)webView shouldStartLoadWithRequest:(NSURLRequest * _Nonnull)request navigationType:(UIWebViewNavigationType)navigationType;
        [Export("webView:shouldStartLoadWithRequest:navigationType:")]
        bool WebView(YZWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType);

        // @optional -(void)webViewDidStartLoad:(id<YZWebView> _Nonnull)webView;
        [Export("webViewDidStartLoad:")]
        void WebViewDidStartLoad(YZWebView webView);

        // @optional -(void)webViewDidFinishLoad:(id<YZWebView> _Nonnull)webView;
        [Export("webViewDidFinishLoad:")]
        void WebViewDidFinishLoad(YZWebView webView);

        // @optional -(void)webView:(id<YZWebView> _Nonnull)webView didFailLoadWithError:(NSError * _Nonnull)error;
        [Export("webView:didFailLoadWithError:")]
        void WebView(YZWebView webView, NSError error);
    }

    // @protocol YZWebView <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IYZWebView
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
         IYZWebViewDelegate Delegate { get; set; }

        // @required @property (nonatomic, weak) id<YZWebViewDelegate> _Nullable delegate;
        [Abstract]
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @required @property (readonly, nonatomic, strong) UIScrollView * _Nonnull scrollView;
        [Abstract]
        [Export("scrollView", ArgumentSemantic.Strong)]
        UIScrollView ScrollView { get; }

        // @required @property (readonly, nonatomic, strong) NSURLRequest * _Nullable originRequest;
        [Abstract]
        [NullAllowed, Export("originRequest", ArgumentSemantic.Strong)]
        NSUrlRequest OriginRequest { get; }

        // @required @property (readonly, nonatomic, strong) NSURLRequest * _Nullable currentRequest;
        [Abstract]
        [NullAllowed, Export("currentRequest", ArgumentSemantic.Strong)]
        NSUrlRequest CurrentRequest { get; }

        // @required @property (readonly, nonatomic, strong) NSURL * _Nullable URL;
        [Abstract]
        [NullAllowed, Export("URL", ArgumentSemantic.Strong)]
        NSUrl URL { get; }

        // @required @property (readonly, nonatomic, strong) JSContext * _Nullable jsContext;
        [Abstract]
        [NullAllowed, Export("jsContext", ArgumentSemantic.Strong)]
        JSContext JsContext { get; }

        // @required @property (readonly, getter = isLoading, assign, nonatomic) BOOL loading;
        [Abstract]
        [Export("loading")]
        bool Loading { [Bind("isLoading")] get; }

        // @required @property (readonly, assign, nonatomic) BOOL canGoBack;
        [Abstract]
        [Export("canGoBack")]
        bool CanGoBack { get; }

        // @required @property (readonly, assign, nonatomic) BOOL canGoForward;
        [Abstract]
        [Export("canGoForward")]
        bool CanGoForward { get; }

        // @required @property (assign, nonatomic) BOOL scalesPageToFit;
        [Abstract]
        [Export("scalesPageToFit")]
        bool ScalesPageToFit { get; set; }

        // @required @property (readonly, nonatomic) double estimatedProgress;
        [Abstract]
        [Export("estimatedProgress")]
        double EstimatedProgress { get; }

        // @required -(void)loadRequest:(NSURLRequest * _Nonnull)request;
        [Abstract]
        [Export("loadRequest:")]
        void LoadRequest(NSUrlRequest request);

        // @required -(void)loadHTMLString:(NSString * _Nonnull)string baseURL:(NSURL * _Nullable)baseURL;
        [Abstract]
        [Export("loadHTMLString:baseURL:")]
        void LoadHTMLString(string @string, [NullAllowed] NSUrl baseURL);

        // @required -(void)loadData:(NSData * _Nonnull)data MIMEType:(NSString * _Nonnull)MIMEType textEncodingName:(NSString * _Nonnull)textEncodingName baseURL:(NSURL * _Nonnull)baseURL;
        [Abstract]
        [Export("loadData:MIMEType:textEncodingName:baseURL:")]
        void LoadData(NSData data, string MIMEType, string textEncodingName, NSUrl baseURL);

        // @required -(void)reload;
        [Abstract]
        [Export("reload")]
        void Reload();

        // @required -(void)reloadFromOrigin;
        [Abstract]
        [Export("reloadFromOrigin")]
        void ReloadFromOrigin();

        // @required -(void)stopLoading;
        [Abstract]
        [Export("stopLoading")]
        void StopLoading();

        // @required -(void)goBack;
        [Abstract]
        [Export("goBack")]
        void GoBack();

        // @required -(void)goForward;
        [Abstract]
        [Export("goForward")]
        void GoForward();

        // @required -(void)gobackWithStep:(NSInteger)step;
        [Abstract]
        [Export("gobackWithStep:")]
        void GobackWithStep(nint step);

        // @required -(NSInteger)countOfHistory;
        [Abstract]
        [Export("countOfHistory")]
       // [Verify(MethodToProperty)]
        nint CountOfHistory { get; }

        // @required -(NSString * _Nonnull)stringByEvaluatingJavaScriptFromString:(NSString * _Nonnull)javaScriptString;
        [Abstract]
        [Export("stringByEvaluatingJavaScriptFromString:")]
        string StringByEvaluatingJavaScriptFromString(string javaScriptString);

        // @required -(void)evaluateJavaScript:(NSString * _Nonnull)javaScriptString completionHandler:(void (^ _Nullable)(id _Nullable, NSError * _Nullable))completionHandler;
        [Abstract]
        [Export("evaluateJavaScript:completionHandler:")]
        void EvaluateJavaScript(string javaScriptString, [NullAllowed] Action<NSObject, NSError> completionHandler);
    }

    // @interface YZWebViewBase : UIView <YZWebView, YZWebViewDelegate>
    [BaseType(typeof(UIView))]
    interface YZWebViewBase : IYZWebView, IYZWebViewDelegate
    {
        // -(instancetype _Nonnull)initWithWebViewType:(YZWebViewType)type;
        [Export("initWithWebViewType:")]
        IntPtr Constructor(YZWebViewType type);
    }

    // @protocol YZWebViewNoticeDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YZWebViewNoticeDelegate
    {
        // @required -(void)webView:(id<YZWebView> _Nonnull)webView didReceiveNotice:(YZNotice * _Nonnull)notice;
        [Abstract]
        [Export("webView:didReceiveNotice:")]
        void DidReceiveNotice(YZWebView webView, YZNotice notice);
    }

    // @interface YZWebView : YZWebViewBase <YZWebView>
    [BaseType(typeof(YZWebViewBase))]
    interface YZWebView :IYZWebView 
    {
        [Wrap("WeakNoticeDelegate")]
        [NullAllowed]
        YZWebViewNoticeDelegate NoticeDelegate { get; set; }

        // @property (nonatomic, weak) id<YZWebViewNoticeDelegate> _Nullable noticeDelegate;
        [NullAllowed, Export("noticeDelegate", ArgumentSemantic.Weak)]
        NSObject WeakNoticeDelegate { get; set; }

        // -(void)share;
        [Export("share")]
        void Share();
    }

    // @interface YZNotice : NSObject
    [BaseType(typeof(NSObject))]
    interface YZNotice
    {
        // -(instancetype _Nullable)initWithURL:(NSURL * _Nonnull)url __attribute__((objc_designated_initializer));
        [Export("initWithURL:")]
        [DesignatedInitializer]
        IntPtr Constructor(NSUrl url);

        // @property (assign, nonatomic) YZNoticeType type;
        [Export("type", ArgumentSemantic.Assign)]
        YZNoticeType Type { get; set; }

        // @property (nonatomic, strong) id _Nullable response;
        [NullAllowed, Export("response", ArgumentSemantic.Strong)]
        NSObject Response { get; set; }

        // @property (assign, nonatomic) YouzanNotice notice __attribute__((availability(ios, introduced=2.0, deprecated=2.0)));
        [Introduced(PlatformName.iOS, 2, 0, message: "use type instead")]
        [Deprecated(PlatformName.iOS, 2, 0, message: "use type instead")]
        [Export("notice", ArgumentSemantic.Assign)]
        YouzanNotice Notice { get; set; }
    }
}

