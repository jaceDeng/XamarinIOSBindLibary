//
//  YZWebViewProtocol.h
//  YZWebViewFramework
//
//  Created by Pan on 2017/11/14.
//  Copyright © 2017年 Youzan. All rights reserved.
//

#ifndef YZWebViewProtocol_h
#define YZWebViewProtocol_h

#import <UIKit/UIKit.h>
#import <JavaScriptCore/JavaScriptCore.h>

NS_ASSUME_NONNULL_BEGIN

@protocol YZWebView;

@protocol YZWebViewDelegate <NSObject>

@optional
- (BOOL)webView:(id<YZWebView>)webView shouldStartLoadWithRequest:(NSURLRequest *)request navigationType:(UIWebViewNavigationType)navigationType;
- (void)webViewDidStartLoad:(id<YZWebView>)webView;
- (void)webViewDidFinishLoad:(id<YZWebView>)webView;
- (void)webView:(id<YZWebView>)webView didFailLoadWithError:(NSError *)error;

@end

@protocol YZWebView <NSObject>

/**
 代理对象，实现它来监听 YZNotice, 在得到对应通知的时候，做对应的操作。
 */
@property (nonatomic, weak, nullable) id<YZWebViewDelegate> delegate;

@property (nonatomic, strong, readonly) UIScrollView *scrollView;
@property (nonatomic, strong, readonly, nullable) NSURLRequest *originRequest;    //webview页面初始请求
@property (nonatomic, strong, readonly, nullable) NSURLRequest *currentRequest;
@property (nonatomic, strong, readonly, nullable) NSURL *URL;
@property (nonatomic, strong, readonly, nullable) JSContext *jsContext;
@property (nonatomic, assign, readonly,getter=isLoading) BOOL loading;
@property (nonatomic, assign, readonly) BOOL canGoBack;
@property (nonatomic, assign, readonly) BOOL canGoForward;

@property (nonatomic, assign) BOOL scalesPageToFit;

// TODO: 这个属性不能 KVO 看看有没有办法解决
@property (nonatomic, readonly) double estimatedProgress;

- (void)loadRequest:(NSURLRequest *)request;
- (void)loadHTMLString:(NSString *)string baseURL:(nullable NSURL *)baseURL;
- (void)loadData:(NSData *)data
MIMEType:(NSString *)MIMEType
textEncodingName:(NSString *)textEncodingName
baseURL:(NSURL *)baseURL;

- (void)reload;
- (void)reloadFromOrigin;
- (void)stopLoading;

- (void)goBack;
- (void)goForward;
- (void)gobackWithStep:(NSInteger)step;

- (NSInteger)countOfHistory;

- (NSString *)stringByEvaluatingJavaScriptFromString:(NSString *)javaScriptString;
- (void)evaluateJavaScript:(NSString *)javaScriptString
         completionHandler:(void (^ _Nullable)(id _Nullable response, NSError *_Nullable error))completionHandler;
@end

NS_ASSUME_NONNULL_END

#endif /* YZWebViewProtocol_h */

