using System;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
namespace YZSDKCore
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
  

    // @interface YZSLog : NSObject
    [BaseType(typeof(NSObject))]
    interface YZSLog
    {
        // +(void)setLogEnabled:(BOOL)enable;
        [Static]
        [Export("setLogEnabled:")]
        void SetLogEnabled(bool enable);

        // +(BOOL)isEnable;
        [Static]
        [Export("isEnable")]
      //  [Verify(MethodToProperty)]
        bool IsEnable { get; }
    }

    // @interface YZSHUD : NSObject
    [BaseType(typeof(NSObject))]
    interface YZSHUD
    {
        // +(void)showMessage:(NSString *)message;
        [Static]
        [Export("showMessage:")]
        void ShowMessage(string message);

        // +(void)showProgress;
        [Static]
        [Export("showProgress")]
        void ShowProgress();

        // +(void)showProgressWithMessage:(NSString *)message;
        [Static]
        [Export("showProgressWithMessage:")]
        void ShowProgressWithMessage(string message);

        // +(void)hide;
        [Static]
        [Export("hide")]
        void Hide();

        // +(void)showMessage:(NSString *)message toView:(UIView *)view;
        [Static]
        [Export("showMessage:toView:")]
        void ShowMessage(string message, UIView view);

        // +(void)showProgressWithMessage:(NSString *)message toView:(UIView *)view;
        [Static]
        [Export("showProgressWithMessage:toView:")]
        void ShowProgressWithMessage(string message, UIView view);

        // +(void)hideFromView:(UIView *)view;
        [Static]
        [Export("hideFromView:")]
        void HideFromView(UIView view);
    }

    [Static]
   // [Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const CGFloat YZSMBProgressMaxOffset;
        [Field("YZSMBProgressMaxOffset", "__Internal")]
        nfloat YZSMBProgressMaxOffset { get; }


        [Field("YZSDKCoreVersionNumber", "__Internal")]
        double YZSDKCoreVersionNumber { get; }

        // extern const unsigned char [] YZSDKCoreVersionString;
        [Field("YZSDKCoreVersionString", "__Internal")]
        NSString YZSDKCoreVersionString { get; }
    }

    // typedef void (^YZSMBProgressHUDCompletionBlock)();
    delegate void YZSMBProgressHUDCompletionBlock();

    // @interface YZSMBProgressHUD : UIView
    [BaseType(typeof(UIView))]
    interface YZSMBProgressHUD
    {
        // +(instancetype _Nonnull)showHUDAddedTo:(UIView * _Nonnull)view animated:(BOOL)animated;
        [Static]
        [Export("showHUDAddedTo:animated:")]
        YZSMBProgressHUD ShowHUDAddedTo(UIView view, bool animated);

        // +(BOOL)hideHUDForView:(UIView * _Nonnull)view animated:(BOOL)animated;
        [Static]
        [Export("hideHUDForView:animated:")]
        bool HideHUDForView(UIView view, bool animated);

        // +(YZSMBProgressHUD * _Nullable)HUDForView:(UIView * _Nonnull)view;
        [Static]
        [Export("HUDForView:")]
        [return: NullAllowed]
        YZSMBProgressHUD HUDForView(UIView view);

        // -(instancetype _Nonnull)initWithView:(UIView * _Nonnull)view;
        [Export("initWithView:")]
        IntPtr Constructor(UIView view);

        // -(void)showAnimated:(BOOL)animated;
        [Export("showAnimated:")]
        void ShowAnimated(bool animated);

        // -(void)hideAnimated:(BOOL)animated;
        [Export("hideAnimated:")]
        void HideAnimated(bool animated);

        // -(void)hideAnimated:(BOOL)animated afterDelay:(NSTimeInterval)delay;
        [Export("hideAnimated:afterDelay:")]
        void HideAnimated(bool animated, double delay);

        [Wrap("WeakDelegate")]
        [NullAllowed]
        YZSMBProgressHUDDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<YZSMBProgressHUDDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (copy) YZSMBProgressHUDCompletionBlock _Nullable completionBlock;
        [NullAllowed, Export("completionBlock", ArgumentSemantic.Copy)]
        YZSMBProgressHUDCompletionBlock CompletionBlock { get; set; }

        // @property (assign, nonatomic) NSTimeInterval graceTime;
        [Export("graceTime")]
        double GraceTime { get; set; }

        // @property (assign, nonatomic) NSTimeInterval minShowTime;
        [Export("minShowTime")]
        double MinShowTime { get; set; }

        // @property (assign, nonatomic) BOOL removeFromSuperViewOnHide;
        [Export("removeFromSuperViewOnHide")]
        bool RemoveFromSuperViewOnHide { get; set; }

        // @property (assign, nonatomic) YZSMBProgressHUDMode mode;
        [Export("mode", ArgumentSemantic.Assign)]
        YZSMBProgressHUDMode Mode { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable contentColor __attribute__((annotate("ui_appearance_selector")));
        [NullAllowed, Export("contentColor", ArgumentSemantic.Strong)]
        UIColor ContentColor { get; set; }

        // @property (assign, nonatomic) YZSMBProgressHUDAnimation animationType __attribute__((annotate("ui_appearance_selector")));
        [Export("animationType", ArgumentSemantic.Assign)]
        YZSMBProgressHUDAnimation AnimationType { get; set; }

        // @property (assign, nonatomic) CGPoint offset __attribute__((annotate("ui_appearance_selector")));
        [Export("offset", ArgumentSemantic.Assign)]
        CGPoint Offset { get; set; }

        // @property (assign, nonatomic) CGFloat margin __attribute__((annotate("ui_appearance_selector")));
        [Export("margin")]
        nfloat Margin { get; set; }

        // @property (assign, nonatomic) CGSize minSize __attribute__((annotate("ui_appearance_selector")));
        [Export("minSize", ArgumentSemantic.Assign)]
        CGSize MinSize { get; set; }

        // @property (getter = isSquare, assign, nonatomic) BOOL square __attribute__((annotate("ui_appearance_selector")));
        [Export("square")]
        bool Square { [Bind("isSquare")] get; set; }

        // @property (getter = areDefaultMotionEffectsEnabled, assign, nonatomic) BOOL defaultMotionEffectsEnabled __attribute__((annotate("ui_appearance_selector")));
        [Export("defaultMotionEffectsEnabled")]
        bool DefaultMotionEffectsEnabled { [Bind("areDefaultMotionEffectsEnabled")] get; set; }

        // @property (assign, nonatomic) float progress;
        [Export("progress")]
        float Progress { get; set; }

        // @property (nonatomic, strong) NSProgress * _Nullable progressObject;
        [NullAllowed, Export("progressObject", ArgumentSemantic.Strong)]
        NSProgress ProgressObject { get; set; }

        // @property (readonly, nonatomic, strong) YZSMBBackgroundView * _Nonnull bezelView;
        [Export("bezelView", ArgumentSemantic.Strong)]
        YZSMBBackgroundView BezelView { get; }

        // @property (readonly, nonatomic, strong) YZSMBBackgroundView * _Nonnull backgroundView;
        [Export("backgroundView", ArgumentSemantic.Strong)]
        YZSMBBackgroundView BackgroundView { get; }

        // @property (nonatomic, strong) UIView * _Nullable customView;
        [NullAllowed, Export("customView", ArgumentSemantic.Strong)]
        UIView CustomView { get; set; }

        // @property (readonly, nonatomic, strong) UILabel * _Nonnull label;
        [Export("label", ArgumentSemantic.Strong)]
        UILabel Label { get; }

        // @property (readonly, nonatomic, strong) UILabel * _Nonnull detailsLabel;
        [Export("detailsLabel", ArgumentSemantic.Strong)]
        UILabel DetailsLabel { get; }

        // @property (readonly, nonatomic, strong) UIButton * _Nonnull button;
        [Export("button", ArgumentSemantic.Strong)]
        UIButton Button { get; }
    }

    // @protocol YZSMBProgressHUDDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YZSMBProgressHUDDelegate
    {
        // @optional -(void)hudWasHidden:(YZSMBProgressHUD * _Nonnull)hud;
        [Export("hudWasHidden:")]
        void HudWasHidden(YZSMBProgressHUD hud);
    }

    // @interface YZSMBRoundProgressView : UIView
    [BaseType(typeof(UIView))]
    interface YZSMBRoundProgressView
    {
        // @property (assign, nonatomic) float progress;
        [Export("progress")]
        float Progress { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull progressTintColor;
        [Export("progressTintColor", ArgumentSemantic.Strong)]
        UIColor ProgressTintColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull backgroundTintColor;
        [Export("backgroundTintColor", ArgumentSemantic.Strong)]
        UIColor BackgroundTintColor { get; set; }

        // @property (getter = isAnnular, assign, nonatomic) BOOL annular;
        [Export("annular")]
        bool Annular { [Bind("isAnnular")] get; set; }
    }

    // @interface YZSMBBarProgressView : UIView
    [BaseType(typeof(UIView))]
    interface YZSMBBarProgressView
    {
        // @property (assign, nonatomic) float progress;
        [Export("progress")]
        float Progress { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull lineColor;
        [Export("lineColor", ArgumentSemantic.Strong)]
        UIColor LineColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull progressRemainingColor;
        [Export("progressRemainingColor", ArgumentSemantic.Strong)]
        UIColor ProgressRemainingColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull progressColor;
        [Export("progressColor", ArgumentSemantic.Strong)]
        UIColor ProgressColor { get; set; }
    }

    // @interface YZSMBBackgroundView : UIView
    [BaseType(typeof(UIView))]
    interface YZSMBBackgroundView
    {
        // @property (nonatomic) YZSMBProgressHUDBackgroundStyle style;
        [Export("style", ArgumentSemantic.Assign)]
        YZSMBProgressHUDBackgroundStyle Style { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull color;
        [Export("color", ArgumentSemantic.Strong)]
        UIColor Color { get; set; }
    }

    // @interface Deprecated (YZSMBProgressHUD)
    [Category]
    [BaseType(typeof(YZSMBProgressHUD))]
    interface YZSMBProgressHUD_Deprecated
    {
        // +(NSArray * _Nonnull)allHUDsForView:(UIView * _Nonnull)view __attribute__((deprecated("Store references when using more than one HUD per view.")));
        [Static]
        [Export("allHUDsForView:")]
       // [Verify(StronglyTypedNSArray)]
        NSObject[] AllHUDsForView(UIView view);

        // +(NSUInteger)hideAllHUDsForView:(UIView * _Nonnull)view animated:(BOOL)animated __attribute__((deprecated("Store references when using more than one HUD per view.")));
       [Static]
        [Export("hideAllHUDsForView:animated:")]
        nuint HideAllHUDsForView(UIView view, bool animated);

        // -(id _Nonnull)initWitIhWindow:(UIWindow * _Nonnull)window __attribute__((deprecated("Use initWithView: instead.")));
        [Export("initWithWindow:")]
        IntPtr InitWithWindow(UIWindow window);

        // -(void)show:(BOOL)animated __attribute__((deprecated("Use showAnimated: instead.")));
        [Export("show:")]
        void Show(bool animated);

        // -(void)hide:(BOOL)animated __attribute__((deprecated("Use hideAnimated: instead.")));
        [Export("hide:")]
        void Hide(bool animated);

        // -(void)hide:(BOOL)animated afterDelay:(NSTimeInterval)delay __attribute__((deprecated("Use hideAnimated:afterDelay: instead.")));
        [Export("hide:afterDelay:")]
        void Hide(bool animated, double delay);

        // -(void)showWhileExecuting:(SEL _Nonnull)method onTarget:(id _Nonnull)target withObject:(id _Nonnull)object animated:(BOOL)animated __attribute__((deprecated("Use GCD directly.")));
        [Export("showWhileExecuting:onTarget:withObject:animated:")]
        void ShowWhileExecuting(Selector method, NSObject target, NSObject @object, bool animated);

        // -(void)showAnimated:(BOOL)animated whileExecutingBlock:(dispatch_block_t _Nonnull)block __attribute__((deprecated("Use GCD directly.")));
        [Export("showAnimated:whileExecutingBlock:")]
        void ShowAnimated(bool animated, Action block);

        // -(void)showAnimated:(BOOL)animated whileExecutingBlock:(dispatch_block_t _Nonnull)block completionBlock:(YZSMBProgressHUDCompletionBlock _Nullable)completion __attribute__((deprecated("Use GCD directly.")));
        [Export("showAnimated:whileExecutingBlock:completionBlock:")]
        void ShowAnimated(bool animated, Action block, [NullAllowed] YZSMBProgressHUDCompletionBlock completion);

        // -(void)showAnimated:(BOOL)animated whileExecutingBlock:(dispatch_block_t _Nonnull)block onQueue:(dispatch_queue_t _Nonnull)queue __attribute__((deprecated("Use GCD directly.")));
        [Export("showAnimated:whileExecutingBlock:onQueue:")]
        void ShowAnimated(bool animated, Action block, DispatchQueue queue);

        // -(void)showAnimated:(BOOL)animated whileExecutingBlock:(dispatch_block_t _Nonnull)block onQueue:(dispatch_queue_t _Nonnull)queue completionBlock:(YZSMBProgressHUDCompletionBlock _Nullable)completion __attribute__((deprecated("Use GCD directly.")));
        [Export("showAnimated:whileExecutingBlock:onQueue:completionBlock:")]
        void ShowAnimated(bool animated, Action block, DispatchQueue queue, [NullAllowed] YZSMBProgressHUDCompletionBlock completion);

        // @property (assign) BOOL taskInProgress __attribute__((deprecated("No longer needed.")));
        [Export("taskInProgress")]
        bool TaskInProgress();
        [Export("settaskInProgress")]
        void SetTaskInProgress(bool b);

        // @property (copy, nonatomic) NSString * _Nonnull labelText __attribute__((deprecated("Use label.text instead.")));
        [Export("labelText")]
        string LabelText();
        [Export("labelText")]
        void SetLabelText(string v);

        // @property (nonatomic, strong) UIFont * _Nonnull labelFont __attribute__((deprecated("Use label.font instead.")));
        [Export("labelFont", ArgumentSemantic.Strong)]
        UIFont LabelFont();


        [Export("setlabelFont", ArgumentSemantic.Strong)]
        void SetLabelFont(UIFont font);

        // @property (nonatomic, strong) UIColor * _Nonnull labelColor __attribute__((deprecated("Use label.textColor instead.")));
        [Export("labelColor")]
        UIColor LabelColor();
        [Export("setlabelColor")]
        UIColor LabelColor(UIColor color);
        // @property (copy, nonatomic) NSString * _Nonnull detailsLabelText __attribute__((deprecated("Use detailsLabel.text instead.")));
        [Export("detailsLabelText")]
        string DetailsLabelText();


        [Export("setdetailsLabelText")]
        void  SetDetailsLabelText();


        // @property (nonatomic, strong) UIFont * _Nonnull detailsLabelFont __attribute__((deprecated("Use detailsLabel.font instead.")));
        [Export("detailsLabelFont", ArgumentSemantic.Strong)]
        UIFont DetailsLabelFont();

        [Export("setdetailsLabelFont", ArgumentSemantic.Strong)]
        void SetDetailsLabelFont(UIFont font);


        // @property (nonatomic, strong) UIColor * _Nonnull detailsLabelColor __attribute__((deprecated("Use detailsLabel.textColor instead.")));
        [Export("detailsLabelColor", ArgumentSemantic.Strong)]
        UIColor DetailsLabelColor();
        [Export("setdetailsLabelColor", ArgumentSemantic.Strong)]
        void SetDetailsLabelColor(UIColor color);

        // @property (assign, nonatomic) CGFloat opacity __attribute__((deprecated("Customize bezelView properties instead.")));
        [Export("opacity")]
        nfloat Opacity();

        [Export("setopacity")]
        void SetOpacity(nfloat v);

        // @property (nonatomic, strong) UIColor * _Nonnull color __attribute__((deprecated("Customize the bezelView color instead.")));
        [Export("color", ArgumentSemantic.Strong)]
        UIColor Color();


        [Export("setcolor", ArgumentSemantic.Strong)]
        void SetColor(UIColor  color);

        // @property (assign, nonatomic) CGFloat xOffset __attribute__((deprecated("Set offset.x instead.")));
        [Export("xOffset")]
        nfloat XOffset();

        [Export("setxOffset")]
        void SetXOffset(nfloat v);

        // @property (assign, nonatomic) CGFloat yOffset __attribute__((deprecated("Set offset.y instead.")));
        [Export("yOffset")]
        nfloat YOffset();

        [Export("setyOffset")]
        void SetYOffset(nfloat v);


        // @property (assign, nonatomic) CGFloat cornerRadius __attribute__((deprecated("Set bezelView.layer.cornerRadius instead.")));
        [Export("cornerRadius")]
        nfloat CornerRadius();
        [Export("setcornerRadius")]
        void SetCornerRadius(nfloat val);


        // @property (assign, nonatomic) BOOL dimBackground __attribute__((deprecated("Customize HUD background properties instead.")));
        [Export("dimBackground")]
        bool DimBackground();

        [Export("setdimBackground")]
        void SetDimBackground();
        // @property (nonatomic, strong) UIColor * _Nonnull activityIndicatorColor __attribute__((deprecated("Use UIAppearance to customize UIActivityIndicatorView. E.g.: [UIActivityIndicatorView appearanceWhenContainedIn:[YZSMBProgressHUD class], nil].color = [UIColor redColor];")));
        [Export("activityIndicatorColor")]
        UIColor ActivityIndicatorColor();
        [Export("setactivityIndicatorColor")]
        UIColor SetActivityIndicatorColor(UIColor color);

        // @property (readonly, assign, atomic) CGSize size __attribute__((deprecated("Get the bezelView.frame.size instead.")));
        [Export("size", ArgumentSemantic.Assign)]
        CGSize Size();
    }

    // @interface YZSURLHelper (NSURL)
    [Category]
    [BaseType(typeof(NSUrl))]
    interface NSURL_YZSURLHelper
    {
        // @property (nonatomic, strong) NSDictionary * yz_querys;
        [Export("yz_querys")]
        NSDictionary Yz_querys();

        [Export("setyz_querys")]
        NSDictionary Yz_querys(NSDictionary keyValues);

        [Export("yz_queryValueForKey:")]
        string Yz_queryValueForKey(string key);

        // -(NSString *)objectForKeyedSubscript:(NSString *)key;
        [Export("objectForKeyedSubscript:")]
        string ObjectForKeyedSubscript(string key);
    }

    // @interface YZGrowingAnalytics : NSObject
    [BaseType(typeof(NSObject))]
    interface YZGrowingAnalytics
    {
        // +(void)enableAutomaticPageEvent;
        [Static]
        [Export("enableAutomaticPageEvent")]
        void EnableAutomaticPageEvent();

        // +(void)enabledCrashReport;
        [Static]
        [Export("enabledCrashReport")]
        void EnabledCrashReport();

        // +(void)sessionStarted:(NSString *)appId withChannelId:(NSString *)channelId;
        [Static]
        [Export("sessionStarted:withChannelId:")]
        void SessionStarted(string appId, string channelId);

        // +(void)trackEvent:(NSString *)eventId;
        [Static]
        [Export("trackEvent:")]
        void TrackEvent(string eventId);

        // +(void)trackEvent:(NSString *)eventId label:(NSString *)eventLabel;
        [Static]
        [Export("trackEvent:label:")]
        void TrackEvent(string eventId, string eventLabel);

        // +(void)trackEvent:(NSString *)eventId label:(NSString *)eventLabel parameters:(NSDictionary *)parameters;
        [Static]
        [Export("trackEvent:label:parameters:")]
        void TrackEvent(string eventId, string eventLabel, NSDictionary parameters);

        // +(void)trackEvent:(NSString *)eventId eventName:(NSString *)eventName label:(NSString *)eventLabel parameters:(NSDictionary *)parameters;
        [Static]
        [Export("trackEvent:eventName:label:parameters:")]
        void TrackEvent(string eventId, string eventName, string eventLabel, NSDictionary parameters);

        // +(void)trackEventRightNow:(NSString *)eventId eventLabel:(NSString *)eventLabel parameters:(NSDictionary *)parameters;
        [Static]
        [Export("trackEventRightNow:eventLabel:parameters:")]
        void TrackEventRightNow(string eventId, string eventLabel, NSDictionary parameters);

        // +(void)trackEventRightNow:(NSString *)eventId eventLabel:(NSString *)eventLabel eventName:(NSString *)eventName parameters:(NSDictionary *)parameters;
        [Static]
        [Export("trackEventRightNow:eventLabel:eventName:parameters:")]
        void TrackEventRightNow(string eventId, string eventLabel, string eventName, NSDictionary parameters);

        // +(void)trackPerformanceEventId:(NSString *)eventId eventLabel:(NSString *)eventLabel eventName:(NSString *)eventName parameters:(NSDictionary *)parameters;
        [Static]
        [Export("trackPerformanceEventId:eventLabel:eventName:parameters:")]
        void TrackPerformanceEventId(string eventId, string eventLabel, string eventName, NSDictionary parameters);

        // +(void)trackPageBegin:(NSString *)pageName;
        [Static]
        [Export("trackPageBegin:")]
        void TrackPageBegin(string pageName);

        // +(void)trackPageEnd:(NSString *)pageName;
        [Static]
        [Export("trackPageEnd:")]
        void TrackPageEnd(string pageName);

        // +(void)setShopId:(NSString *)shopId;
        [Static]
        [Export("setShopId:")]
        void SetShopId(string shopId);

        // +(void)setMobile:(NSString *)mobile;
        [Static]
        [Export("setMobile:")]
        void SetMobile(string mobile);

        // +(void)setAccountID:(NSString *)accountID;
        [Static]
        [Export("setAccountID:")]
        void SetAccountID(string accountID);

        // +(void)setContext:(NSDictionary *)context;
        [Static]
        [Export("setContext:")]
        void SetContext(NSDictionary context);
    }
}

