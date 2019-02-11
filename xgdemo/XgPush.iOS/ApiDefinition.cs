using System;
using Foundation;
using ObjCRuntime;
namespace XgPushiOS
{
    // @interface XGNotificationAction
    interface XGNotificationAction
    {
        // +(id _Nullable)actionWithIdentifier:(id)identifier title:(id)title options:(id)options;
        [Static]
        [Export("actionWithIdentifier:title:options:")]
        [return: NullAllowed]
        NSObject ActionWithIdentifier(NSObject identifier, NSObject title, NSObject options);

        // @property (readonly, copy, nonatomic) int * _Nullable identifier;
        [NullAllowed, Export("identifier", ArgumentSemantic.Copy)]
        unsafe int* Identifier { get; }

        // @property (readonly, copy, nonatomic) int * _Nullable title;
        [NullAllowed, Export("title", ArgumentSemantic.Copy)]
        unsafe int* Title { get; }

        // @property (readonly, nonatomic) int options;
        [Export("options")]
        int Options { get; }
    }

    // @interface XGNotificationCategory
    interface XGNotificationCategory
    {
        // +(id _Nullable)categoryWithIdentifier:(id)identifier actions:(id)actions intentIdentifiers:(id)intentIdentifiers options:(id)options;
        [Static]
        [Export("categoryWithIdentifier:actions:intentIdentifiers:options:")]
        [return: NullAllowed]
        NSObject CategoryWithIdentifier(NSObject identifier, NSObject actions, NSObject intentIdentifiers, NSObject options);

        // @property (readonly, copy, nonatomic) int * _Nonnull identifier;
        [Export("identifier", ArgumentSemantic.Copy)]
        unsafe int* Identifier { get; }

        // @property (readonly, nonatomic) int options;
        [Export("options")]
        int Options { get; }
    }
    [BaseType(typeof(NSObject))]
    // @interface XGNotificationConfigure
    interface XGNotificationConfigure
    {
        // +(instancetype _Nullable)configureNotificationWithCategories:(id)categories types:(id)types;
        [Static]
        [Export("configureNotificationWithCategories:types:")]
        [return: NullAllowed]
        XGNotificationConfigure ConfigureNotificationWithCategories(NSObject categories, NSObject types);

        // @property (readonly, nonatomic) int types;
        [Export("types")]
        int Types { get; }

        // @property (readonly, nonatomic) int defaultTypes;
        [Export("defaultTypes")]
        int DefaultTypes { get; }
    }

    // @protocol XGPushTokenManagerDelegate
    [Protocol, Model]
    interface XGPushTokenManagerDelegate
    {
        // @optional -(void)xgPushDidBindWithIdentifier:(id)identifier type:(id)type error:(id)error;
        [Export("xgPushDidBindWithIdentifier:type:error:")]
        void XgPushDidBindWithIdentifier(NSObject identifier, NSObject type, NSObject error);

        // @optional -(void)xgPushDidUnbindWithIdentifier:(id)identifier type:(id)type error:(id)error;
        [Export("xgPushDidUnbindWithIdentifier:type:error:")]
        void XgPushDidUnbindWithIdentifier(NSObject identifier, NSObject type, NSObject error);

        // @optional -(void)xgPushDidBindWithIdentifiers:(id)identifiers type:(id)type error:(id)error;
        [Export("xgPushDidBindWithIdentifiers:type:error:")]
        void XgPushDidBindWithIdentifiers(NSObject identifiers, NSObject type, NSObject error);

        // @optional -(void)xgPushDidUnbindWithIdentifiers:(id)identifiers type:(id)type error:(id)error;
        [Export("xgPushDidUnbindWithIdentifiers:type:error:")]
        void XgPushDidUnbindWithIdentifiers(NSObject identifiers, NSObject type, NSObject error);

        // @optional -(void)xgPushDidUpdatedBindedIdentifiers:(id)identifiers bindType:(id)type error:(id)error;
        [Export("xgPushDidUpdatedBindedIdentifiers:bindType:error:")]
        void XgPushDidUpdatedBindedIdentifiers(NSObject identifiers, NSObject type, NSObject error);

        // @optional -(void)xgPushDidClearAllIdentifiers:(id)type error:(id)error;
        [Export("xgPushDidClearAllIdentifiers:error:")]
        void XgPushDidClearAllIdentifiers(NSObject type, NSObject error);
    }

    // @interface XGPushTokenManager
    interface XGPushTokenManager
    {
        // +(instancetype _Nonnull)defaultTokenManager;
        [Static]
        [Export("defaultTokenManager")]
        XGPushTokenManager DefaultTokenManager();

        [Wrap("WeakDelegate")]
        [NullAllowed]
        XGPushTokenManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<XGPushTokenManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, copy, nonatomic) int * _Nullable deviceTokenString;
        [NullAllowed, Export("deviceTokenString", ArgumentSemantic.Copy)]
        unsafe int* DeviceTokenString { get; }

        // -(void)bindWithIdentifier:(id)identifier type:(id)type;
        [Export("bindWithIdentifier:type:")]
        void BindWithIdentifier(NSObject identifier, NSObject type);

        // -(void)unbindWithIdentifer:(id)identifier type:(id)type;
        [Export("unbindWithIdentifer:type:")]
        void UnbindWithIdentifer(NSObject identifier, NSObject type);

        // -(id)identifiersWithType:(id)type;
        [Export("identifiersWithType:")]
        NSObject IdentifiersWithType(NSObject type);

        // -(void)bindWithIdentifiers:(id)identifiers type:(id)type;
        [Export("bindWithIdentifiers:type:")]
        void BindWithIdentifiers(NSObject identifiers, NSObject type);

        // -(void)unbindWithIdentifers:(id)identifiers type:(id)type;
        [Export("unbindWithIdentifers:type:")]
        void UnbindWithIdentifers(NSObject identifiers, NSObject type);

        // -(void)updateBindedIdentifiers:(id)identifiers bindType:(id)type;
        [Export("updateBindedIdentifiers:bindType:")]
        void UpdateBindedIdentifiers(NSObject identifiers, NSObject type);

        // -(void)clearAllIdentifiers:(id)type;
        [Export("clearAllIdentifiers:")]
        void ClearAllIdentifiers(NSObject type);
    }

    // @protocol XGPushDelegate
  
    [BaseType(typeof(NSObject))]
    [Model]
    interface XGPushDelegate
    {
        // @optional -(void)xgPushDidReceiveRemoteNotification:(id _Nonnull)notification withCompletionHandler:(id)completionHandler;
        [Export("xgPushDidReceiveRemoteNotification:withCompletionHandler:")]
        void XgPushDidReceiveRemoteNotification(NSObject notification, NSObject completionHandler);

        // @optional -(void)xgPushUserNotificationCenter:(id)center willPresentNotification:(id)notification withCompletionHandler:(void (^ _Nonnull)(int))completionHandler;
        [Export("xgPushUserNotificationCenter:willPresentNotification:withCompletionHandler:")]
        void XgPushUserNotificationCenter(NSObject center, NSObject notification, Action<int> completionHandler);

        // @optional -(void)xgPushUserNotificationCenter:(id)center didReceiveNotificationResponse:(id)response withCompletionHandler:(void (^ _Nonnull)(void))completionHandler;
        [Export("xgPushUserNotificationCenter:didReceiveNotificationResponse:withCompletionHandler:")]
        void XgPushUserNotificationCenter(NSObject center, NSObject response, Action completionHandler);

        // @optional -(void)xgPushDidFinishStart:(id)isSuccess error:(id)error;
        [Export("xgPushDidFinishStart:error:")]
        void XgPushDidFinishStart(NSObject isSuccess, NSObject error);

        // @optional -(void)xgPushDidFinishStop:(id)isSuccess error:(id)error;
        [Export("xgPushDidFinishStop:error:")]
        void XgPushDidFinishStop(NSObject isSuccess, NSObject error);

        // @optional -(void)xgPushDidReportNotification:(id)isSuccess error:(id)error;
        [Export("xgPushDidReportNotification:error:")]
        void XgPushDidReportNotification(NSObject isSuccess, NSObject error);

        // @optional -(void)xgPushDidSetBadge:(id)isSuccess error:(id)error;
        [Export("xgPushDidSetBadge:error:")]
        void XgPushDidSetBadge(NSObject isSuccess, NSObject error);

        // @optional -(void)xgPushDidRegisteredDeviceToken:(id)deviceToken error:(id)error;
        [Export("xgPushDidRegisteredDeviceToken:error:")]
        void XgPushDidRegisteredDeviceToken(NSObject deviceToken, NSObject error);
    }
    [BaseType(typeof(NSObject))]
    // @interface XGPush
    interface XGPush
    {
        // +(instancetype _Nonnull)defaultManager;
        [Static]
        [Export("defaultManager")]
        XGPush DefaultManager { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        XGPushDelegate Delegate { get; }

        // @property (readonly, nonatomic, weak) id<XGPushDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; }

        // @property (nonatomic, strong) XGNotificationConfigure * _Nullable notificationConfigure;
        [NullAllowed, Export("notificationConfigure", ArgumentSemantic.Strong)]
        XGNotificationConfigure NotificationConfigure { get; set; }

        // @property (getter = isEnableDebug, assign) int enableDebug;
        [Export("enableDebug")]
        int EnableDebug { [Bind("isEnableDebug")] get; set; }

        // @property (readonly, assign) int xgNotificationStatus;
        [Export("xgNotificationStatus")]
        int XgNotificationStatus { get; }

        // @property (readonly, assign) int deviceDidRegisteredXG;
        [Export("deviceDidRegisteredXG")]
        int DeviceDidRegisteredXG { get; }

        // @property (nonatomic) int xgApplicationBadgeNumber;
        [Export("xgApplicationBadgeNumber")]
        int XgApplicationBadgeNumber { get; set; }

        // -(void)startXGWithAppID:(id)appID appKey:(id)appKey delegate:(id<XGPushDelegate> _Nullable)delegate;
        [Export("startXGWithAppID:appKey:delegate:")]
        void StartXGWithAppID(NSString appID, NSString appKey, [NullAllowed] XGPushDelegate @delegate);

        // -(void)stopXGNotification;
        [Export("stopXGNotification")]
        void StopXGNotification();

        // -(void)reportXGNotificationInfo:(id)info;
        [Export("reportXGNotificationInfo:")]
        void ReportXGNotificationInfo(NSObject info);

        // -(void)reportLocationWithLatitude:(double)latitude longitude:(double)longitude;
        [Export("reportLocationWithLatitude:longitude:")]
        void ReportLocationWithLatitude(double latitude, double longitude);

        // -(void)setBadge:(id)badgeNumber;
        [Export("setBadge:")]
        void SetBadge(NSObject badgeNumber);

        // -(void)reportXGNotificationResponse:(id)response;
        [Export("reportXGNotificationResponse:")]
        void ReportXGNotificationResponse(NSObject response);

        // -(void)deviceNotificationIsAllowed:(void (^ _Nonnull)(int))handler;
        [Export("deviceNotificationIsAllowed:")]
        void DeviceNotificationIsAllowed(Action<int> handler);

        // -(id)sdkVersion;
        [Export("sdkVersion")]
       // [Verify(MethodToProperty)]
        NSObject SdkVersion { get; }
    }
}