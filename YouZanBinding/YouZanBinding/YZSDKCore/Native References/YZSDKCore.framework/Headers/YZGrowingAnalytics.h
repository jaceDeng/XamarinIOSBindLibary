//
//  YZGrowingAnalytics.h
//  Pods-YZGrowingAnalytics_Example
//
//  Created by chenshaoqiu on 2017/10/12.
//

#import <Foundation/Foundation.h>

@interface YZGrowingAnalytics : NSObject

/**
 *  @method    enableAutomaticPageEvent: 能自动统计页面事件（注：必须在 sessionStarted:withChannelId 之前调用）
 */
+ (void)enableAutomaticPageEvent;

/**
 *  @method enabledCrashReport
 *  是否捕捉程序崩溃记录（可选）
 如果需要记录程序崩溃日志，并且在调用sessionStarted:withChannelId:之前调用此函数
 */
+ (void)enabledCrashReport;

/**
 *  @method    sessionStarted:withChannelId:
 *  初始化统计实例，请在application:didFinishLaunchingWithOptions:方法里调用
 *  @param  appId      应用的唯一标识，统计后台注册得到
 *  @param  channelId   渠道名，如“app store”（可选）
 */
+ (void)sessionStarted:(NSString *)appId withChannelId:(NSString *)channelId;

/**
 *  @method trackEvent
 *  统计自定义事件（可选），如购买动作
 *  @param  eventId     事件名称（自定义）
 */
+ (void)trackEvent:(NSString *)eventId;

/**
 *  @method trackEvent:label:
 *  统计带标签的自定义事件（可选），可用标签来区别同一个事件的不同应用场景
 如购买某一特定的商品
 *  @param  eventId     事件Id（自定义）
 *  @param  eventLabel  事件标签（自定义）
 */
+ (void)trackEvent:(NSString *)eventId label:(NSString *)eventLabel;

/**
 *  @method    trackEvent:label:parameters
 *  统计带二级参数的自定义事件，单次调用的参数数量不能超过10个
 *  @param  eventId     事件Id（自定义）
 *  @param  eventLabel  事件标签（自定义）
 *  @param  parameters  事件参数 (key只支持NSString, value支持NSString和NSNumber)
 */
+ (void)trackEvent:(NSString *)eventId
             label:(NSString *)eventLabel
        parameters:(NSDictionary *)parameters;

/**
 *  @method    trackEvent:eventName:label:parameters
 *  统计带二级参数的自定义事件，单次调用的参数数量不能超过10个
 *  @param  eventId     事件Id（自定义）
 *  @param  eventName   事件名称
 *  @param  eventLabel  事件标签（自定义）
 *  @param  parameters  事件参数 (key只支持NSString, value支持NSString和NSNumber)
 */
+ (void)trackEvent:(NSString *)eventId
         eventName:(NSString *)eventName
             label:(NSString *)eventLabel
        parameters:(NSDictionary *)parameters;

/**
 *  @method    trackEventRightNow:label:parameters
 *  统计带二级参数的自定义事件，单次调用的参数数量不能超过10个
 *  @param  eventId     事件Id（自定义）
 *  @param  eventLabel  事件标签（自定义）
 *  @param  parameters  事件参数 (key只支持NSString, value支持NSString和NSNumber)
 */
+ (void)trackEventRightNow:(NSString *)eventId
                eventLabel:(NSString *)eventLabel
                parameters:(NSDictionary *)parameters;

/**
 *  @method    trackEventRightNow:label:parameters
 *  统计带二级参数的自定义事件，单次调用的参数数量不能超过10个
 *  @param  eventId     事件Id（自定义）
 *  @param  eventLabel  事件标签（自定义）没有传 nil 或者 @""
 *  @param  eventName   事件名称（自定义）没有传 nil 或者 @""
 *  @param  parameters  事件参数 (key只支持NSString, value支持NSString和NSNumber) 没有传 @{}
 */
+ (void)trackEventRightNow:(NSString *)eventId
                  eventLabel:(NSString *)eventLabel
                   eventName:(NSString *)eventName
                  parameters:(NSDictionary *)parameters;

/**
 * 性能接口
 *  @method    trackPerformanceEventId:label:parameters
 *  统计带二级参数的自定义事件，单次调用的参数数量不能超过10个
 *  @param  eventId     事件Id（自定义）
 *  @param  eventLabel  事件标签（自定义）没有传 nil 或者 @""
 *  @param  eventName   事件名称（自定义）没有传 nil 或者 @""
 *  @param  parameters  事件参数 (key只支持NSString, value支持NSString和NSNumber) 没有传 @{}
 */
+ (void)trackPerformanceEventId:(NSString *)eventId
                eventLabel:(NSString *)eventLabel
                 eventName:(NSString *)eventName
                parameters:(NSDictionary *)parameters;

/**
 *  @method    trackPageBegin
 *  开始跟踪某一页面（可选），记录页面打开时间
 建议在viewWillAppear或者viewDidAppear方法里调用
 *  @param  pageName    页面名称
 */
+ (void)trackPageBegin:(NSString *)pageName;

/**
 *  @method trackPageEnd
 *  结束某一页面的跟踪（可选），记录页面的关闭时间
 此方法与trackPageBegin方法结对使用，
 在iOS应用中建议在viewWillDisappear或者viewDidDisappear方法里调用
 在Watch应用中建议在DidDeactivate方法里调用
 *  @param  pageName    页面名称，请跟trackPageBegin方法的页面名称保持一致
 */
+ (void)trackPageEnd:(NSString *)pageName;

/**
 设置店铺的Id
 @param shopId shopId
 */
+ (void)setShopId:(NSString *)shopId;

/**
 设置手机号
 @param mobile mobile
 */
+ (void)setMobile:(NSString *)mobile;

/**
 登录接口
 @param accountID accountID
 */
+ (void)setAccountID:(NSString *)accountID;

/**
 @param context context
 */
+ (void)setContext:(NSDictionary *)context;

@end
