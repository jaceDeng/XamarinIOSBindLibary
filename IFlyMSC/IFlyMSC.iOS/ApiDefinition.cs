using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
//using System;
using AVFoundation;
//using CoreGraphics;
//using Foundation;
//using ObjCRuntime;
//using UIKit;
//using iflyMSC;
namespace IFlyMSC.iOS
{
 

    // @interface IFlyAudioSession : NSObject
    [BaseType(typeof(NSObject))]
    interface IFlyAudioSession
    {
        // +(void)initPlayingAudioSession:(BOOL)isMPCenter;
        [Static]
        [Export("initPlayingAudioSession:")]
        void InitPlayingAudioSession(bool isMPCenter);

        // +(BOOL)initRecordingAudioSession;
        [Static]
        [Export("initRecordingAudioSession")]
        ////[Verify(MethodToProperty)]
        bool InitRecordingAudioSession { get; }
    }

    // @interface IFlyDataUploader : NSObject
    [BaseType(typeof(NSObject))]
    interface IFlyDataUploader
    {
        // @property (copy, nonatomic) NSString * dataName;
        [Export("dataName")]
        string DataName { get; set; }

        // @property (copy, nonatomic) NSString * data;
        [Export("data")]
        string Data { get; set; }

        // -(void)uploadDataWithCompletionHandler:(IFlyUploadDataCompletionHandler)completionHandler name:(NSString *)name data:(NSString *)data;
        [Export("uploadDataWithCompletionHandler:name:data:")]
        void UploadDataWithCompletionHandler(IFlyUploadDataCompletionHandler completionHandler, string name, string data);

        // -(void)setParameter:(NSString *)parameter forKey:(NSString *)key;
        [Export("setParameter:forKey:")]
        void SetParameter(string parameter, string key);
    }

    // typedef void (^IFlyUploadDataCompletionHandler)(NSString *, IFlySpeechError *);
    delegate void IFlyUploadDataCompletionHandler(string arg0, IFlySpeechError arg1);

    // @interface IFlyDebugLog : NSObject
    [BaseType(typeof(NSObject))]
    interface IFlyDebugLog
    {
        // +(void)showLog:(NSString *)format, ...;
        [Static, Internal]
        [Export("showLog:", IsVariadic = true)]
        void ShowLog(string format, IntPtr varArgs);

        // +(void)writeLog;
        [Static]
        [Export("writeLog")]
        void WriteLog();

        // +(void)setShowLog:(BOOL)showLog;
        [Static]
        [Export("setShowLog:")]
        void SetShowLog(bool showLog);
    }

    // @protocol IFlyISVDelegate
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface IFlyISVDelegate
    {
        // @required -(void)onResult:(NSDictionary *)dic;
        [Abstract]
        [Export("onResult:")]
        void OnResult(NSDictionary dic);

        // @required -(void)onCompleted:(IFlySpeechError *)errorCode;
        [Abstract]
        [Export("onCompleted:")]
        void OnCompleted(IFlySpeechError errorCode);

        // @optional -(void)onRecognition;
        [Export("onRecognition")]
        void OnRecognition();

        // @optional -(void)onVolumeChanged:(int)volume;
        [Export("onVolumeChanged:")]
        void OnVolumeChanged(int volume);
    }

    // @interface IFlyISVRecognizer : NSObject
    [BaseType(typeof(NSObject))]
    interface IFlyISVRecognizer
    {
        [Wrap("WeakDelegate")]
        IFlyISVDelegate Delegate { get; set; }

        // @property (assign) id<IFlyISVDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // +(instancetype)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        IFlyISVRecognizer SharedInstance();

        // -(NSString *)generatePassword:(int)length;
        [Export("generatePassword:")]
        string GeneratePassword(int length);

        // -(NSArray *)getPasswordList:(int)pwdt;
        [Export("getPasswordList:")]
      //  [Verify(StronglyTypedNSArray)]
        NSObject[] GetPasswordList(int pwdt);

        // -(BOOL)isListening;
        [Export("isListening")]
        //[Verify(MethodToProperty)]
        bool IsListening { get; }

        // -(BOOL)sendRequest:(NSString *)cmd authid:(NSString *)auth_id pwdt:(int)pwdt ptxt:(NSString *)ptxt vid:(NSString *)vid err:(int *)err;
        [Export("sendRequest:authid:pwdt:ptxt:vid:err:")]
        unsafe bool SendRequest(string cmd, string auth_id, int pwdt, string ptxt, string vid, int err);

        // -(BOOL)setParameter:(NSString *)value forKey:(NSString *)key;
        [Export("setParameter:forKey:")]
        bool SetParameter(string value, string key);

        // -(NSString *)getParameter:(NSString *)key;
        [Export("getParameter:")]
        string GetParameter(string key);

        // -(void)startListening;
        [Export("startListening")]
        void StartListening();

        // -(void)stopListening;
        [Export("stopListening")]
        void StopListening();

        // -(void)cancel;
        [Export("cancel")]
        void Cancel();
    }

    // @interface IFlyRecognizerView : UIView <NSObject>
    [BaseType(typeof(UIView))]
    interface IFlyRecognizerView
    {
        [Wrap("WeakDelegate")]
        IFlyRecognizerViewDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<IFlyRecognizerViewDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // -(id)initWithOrigin:(CGPoint)origin;
        [Export("initWithOrigin:")]
        IntPtr Constructor(CGPoint origin);

        // -(id)initWithCenter:(CGPoint)center;
        [Export("initWithCenter:")]
        IntPtr ConstructorWithCenter(CGPoint center);

        // -(void)setAutoRotate:(BOOL)autoRotate;
        [Export("setAutoRotate:")]
        void SetAutoRotate(bool autoRotate);

        // -(BOOL)setParameter:(NSString *)value forKey:(NSString *)key;
        [Export("setParameter:forKey:")]
        bool SetParameter(string value, string key);

        // -(NSString *)parameterForKey:(NSString *)key;
        [Export("parameterForKey:")]
        string ParameterForKey(string key);

        // -(BOOL)start;
        [Export("start")]
        //[Verify(MethodToProperty)]
        bool Start { get; }

        // -(void)cancel;
        [Export("cancel")]
        void Cancel();
    }

    // @protocol IFlyRecognizerViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IFlyRecognizerViewDelegate
    {
        // @required -(void)onResult:(NSArray *)resultArray isLast:(BOOL)isLast;
        [Abstract]
        [Export("onResult:isLast:")]
       // [Verify(StronglyTypedNSArray)]
        void OnResult(NSObject[] resultArray, bool isLast);

        // @required -(void)onCompleted:(IFlySpeechError *)error;
        [Abstract]
        [Export("onCompleted:")]
        void OnCompleted(IFlySpeechError error);
    }

    // @interface IFlyResourceUtil : NSObject
    [BaseType(typeof(NSObject))]
    interface IFlyResourceUtil
    {
        // +(NSString *)ENGINE_START;
        [Static]
        [Export("ENGINE_START")]
        //[Verify(MethodToProperty)]
        string ENGINE_START { get; }

        // +(NSString *)ENGINE_DESTROY;
        [Static]
        [Export("ENGINE_DESTROY")]
        //[Verify(MethodToProperty)]
        string ENGINE_DESTROY { get; }

        // +(NSString *)ASR_RES_PATH;
        [Static]
        [Export("ASR_RES_PATH")]
        //[Verify(MethodToProperty)]
        string ASR_RES_PATH { get; }

        // +(NSString *)GRM_BUILD_PATH;
        [Static]
        [Export("GRM_BUILD_PATH")]
        //[Verify(MethodToProperty)]
        string GRM_BUILD_PATH { get; }

        // +(NSString *)TTS_RES_PATH;
        [Static]
        [Export("TTS_RES_PATH")]
        //[Verify(MethodToProperty)]
        string TTS_RES_PATH { get; }

        // +(NSString *)IVW_RES_PATH;
        [Static]
        [Export("IVW_RES_PATH")]
        //[Verify(MethodToProperty)]
        string IVW_RES_PATH { get; }

        // +(NSString *)GRAMMARTYPE;
        [Static]
        [Export("GRAMMARTYPE")]
        //[Verify(MethodToProperty)]
        string GRAMMARTYPE { get; }

        // +(NSString *)PLUS_LOCAL_DEFAULT_RES_PATH;
        [Static]
        [Export("PLUS_LOCAL_DEFAULT_RES_PATH")]
        //[Verify(MethodToProperty)]
        string PLUS_LOCAL_DEFAULT_RES_PATH { get; }

        // +(NSString *)generateResourcePath:(NSString *)path;
        [Static]
        [Export("generateResourcePath:")]
        string GenerateResourcePath(string path);

        // +(NSString *)identifierForVoiceName:(NSString *)voiceName;
        [Static]
        [Export("identifierForVoiceName:")]
        string IdentifierForVoiceName(string voiceName);
    }

    // @interface IFlySetting : NSObject
    [BaseType(typeof(NSObject))]
    interface IFlySetting
    {
        // +(NSString *)getVersion;
        [Static]
        [Export("getVersion")]
      //  //[Verify(MethodToProperty)]
        string Version { get; }

        // +(LOG_LEVEL)logLvl;
        [Static]
        [Export("logLvl")]
        ////[Verify(MethodToProperty)]
        LogLevel LogLvl { get; }

        // +(void)showLogcat:(BOOL)showLog;
        [Static]
        [Export("showLogcat:")]
        void ShowLogcat(bool showLog);

        // +(void)setLogFile:(LOG_LEVEL)level;
        [Static]
        [Export("setLogFile:")]
        void SetLogFile(LogLevel level);

        // +(void)setLogFilePath:(NSString *)path;
        [Static]
        [Export("setLogFilePath:")]
        void SetLogFilePath(string path);
    }

    // @interface IFlySpeechConstant : NSObject
    [BaseType(typeof(NSObject))]
    interface IFlySpeechConstant
    {
        // +(NSString *)APPID;
        [Static]
        [Export("APPID")]
      //  //[Verify(MethodToProperty)]
        string APPID { get; }

        // +(NSString *)ACCENT;
        [Static]
        [Export("ACCENT")]
        ////[Verify(MethodToProperty)]
        string ACCENT { get; }

        // +(NSString *)ACCENT_MANDARIN;
        [Static]
        [Export("ACCENT_MANDARIN")]
        //[Verify(MethodToProperty)]
        string ACCENT_MANDARIN { get; }

        // +(NSString *)ACCENT_HENANESE;
        [Static]
        [Export("ACCENT_HENANESE")]
        ////[Verify(MethodToProperty)]
        string ACCENT_HENANESE { get; }

        // +(NSString *)ACCENT_SICHUANESE;
        [Static]
        [Export("ACCENT_SICHUANESE")]
      //  //[Verify(MethodToProperty)]
        string ACCENT_SICHUANESE { get; }

        // +(NSString *)ACCENT_CANTONESE;
        [Static]
        [Export("ACCENT_CANTONESE")]
      //  //[Verify(MethodToProperty)]
        string ACCENT_CANTONESE { get; }

        // +(NSString *)LANGUAGE;
        [Static]
        [Export("LANGUAGE")]
        ////[Verify(MethodToProperty)]
        string LANGUAGE { get; }

        // +(NSString *)LANGUAGE_CHINESE;
        [Static]
        [Export("LANGUAGE_CHINESE")]
      //  //[Verify(MethodToProperty)]
        string LANGUAGE_CHINESE { get; }

        // +(NSString *)LANGUAGE_CHINESE_TW;
        [Static]
        [Export("LANGUAGE_CHINESE_TW")]
      //  //[Verify(MethodToProperty)]
        string LANGUAGE_CHINESE_TW { get; }

        // +(NSString *)LANGUAGE_ENGLISH;
        [Static]
        [Export("LANGUAGE_ENGLISH")]
       // //[Verify(MethodToProperty)]
        string LANGUAGE_ENGLISH { get; }

        // +(NSString *)RESULT_TYPE;
        [Static]
        [Export("RESULT_TYPE")]
      //  //[Verify(MethodToProperty)]
        string RESULT_TYPE { get; }

        // +(NSString *)IFLY_DOMAIN;
        [Static]
        [Export("IFLY_DOMAIN")]
       // //[Verify(MethodToProperty)]
        string IFLY_DOMAIN { get; }

        // +(NSString *)DATA_TYPE;
        [Static]
        [Export("DATA_TYPE")]
        //[Verify(MethodToProperty)]
        string DATA_TYPE { get; }

        // +(NSString *)SPEECH_TIMEOUT;
        [Static]
        [Export("SPEECH_TIMEOUT")]
        //[Verify(MethodToProperty)]
        string SPEECH_TIMEOUT { get; }

        // +(NSString *)NET_TIMEOUT;
        [Static]
        [Export("NET_TIMEOUT")]
        //[Verify(MethodToProperty)]
        string NET_TIMEOUT { get; }

        // +(NSString *)SUBJECT;
        [Static]
        [Export("SUBJECT")]
        //[Verify(MethodToProperty)]
        string SUBJECT { get; }

        // +(NSString *)PARAMS;
        [Static]
        [Export("PARAMS")]
       // //[Verify(MethodToProperty)]
        string PARAMS { get; }

        // +(NSString *)PROT_TYPE;
        [Static]
        [Export("PROT_TYPE")]
      //  //[Verify(MethodToProperty)]
        string PROT_TYPE { get; }

        // +(NSString *)SSL_CERT;
        [Static]
        [Export("SSL_CERT")]
      //  //[Verify(MethodToProperty)]
        string SSL_CERT { get; }

        // +(NSString *)POWER_CYCLE;
        [Static]
        [Export("POWER_CYCLE")]
        //[Verify(MethodToProperty)]
        string POWER_CYCLE { get; }

        // +(NSString *)SAMPLE_RATE;
        [Static]
        [Export("SAMPLE_RATE")]
        //[Verify(MethodToProperty)]
        string SAMPLE_RATE { get; }

        // +(NSString *)SAMPLE_RATE_8K;
        [Static]
        [Export("SAMPLE_RATE_8K")]
        //[Verify(MethodToProperty)]
        string SAMPLE_RATE_8K { get; }

        // +(NSString *)SAMPLE_RATE_16K;
        [Static]
        [Export("SAMPLE_RATE_16K")]
      //  //[Verify(MethodToProperty)]
        string SAMPLE_RATE_16K { get; }

        // +(NSString *)ENGINE_TYPE;
        [Static]
        [Export("ENGINE_TYPE")]
      //  //[Verify(MethodToProperty)]
        string ENGINE_TYPE { get; }

        // +(NSString *)TYPE_LOCAL;
        [Static]
        [Export("TYPE_LOCAL")]
      //  //[Verify(MethodToProperty)]
        string TYPE_LOCAL { get; }

        // +(NSString *)TYPE_CLOUD;
        [Static]
        [Export("TYPE_CLOUD")]
        //[Verify(MethodToProperty)]
        string TYPE_CLOUD { get; }

        // +(NSString *)TYPE_MIX;
        [Static]
        [Export("TYPE_MIX")]
        //[Verify(MethodToProperty)]
        string TYPE_MIX { get; }

        // +(NSString *)TYPE_AUTO;
        [Static]
        [Export("TYPE_AUTO")]
      //  //[Verify(MethodToProperty)]
        string TYPE_AUTO { get; }

        // +(NSString *)TEXT_ENCODING;
        [Static]
        [Export("TEXT_ENCODING")]
      //  //[Verify(MethodToProperty)]
        string TEXT_ENCODING { get; }

        // +(NSString *)RESULT_ENCODING;
        [Static]
        [Export("RESULT_ENCODING")]
       // //[Verify(MethodToProperty)]
        string RESULT_ENCODING { get; }

        // +(NSString *)PLAYER_INIT;
        [Static]
        [Export("PLAYER_INIT")]
        ////[Verify(MethodToProperty)]
        string PLAYER_INIT { get; }

        // +(NSString *)PLAYER_DEACTIVE;
        [Static]
        [Export("PLAYER_DEACTIVE")]
      //  //[Verify(MethodToProperty)]
        string PLAYER_DEACTIVE { get; }

        // +(NSString *)RECORDER_INIT;
        [Static]
        [Export("RECORDER_INIT")]
   //     //[Verify(MethodToProperty)]
        string RECORDER_INIT { get; }

        // +(NSString *)RECORDER_DEACTIVE;
        [Static]
        [Export("RECORDER_DEACTIVE")]
        //[Verify(MethodToProperty)]
        string RECORDER_DEACTIVE { get; }

        // +(NSString *)SPEED;
        [Static]
        [Export("SPEED")]
        //[Verify(MethodToProperty)]
        string SPEED { get; }

        // +(NSString *)PITCH;
        [Static]
        [Export("PITCH")]
        //[Verify(MethodToProperty)]
        string PITCH { get; }

        // +(NSString *)TTS_AUDIO_PATH;
        [Static]
        [Export("TTS_AUDIO_PATH")]
    //    //[Verify(MethodToProperty)]
        string TTS_AUDIO_PATH { get; }

        // +(NSString *)VAD_ENABLE;
        [Static]
        [Export("VAD_ENABLE")]
    //    //[Verify(MethodToProperty)]
        string VAD_ENABLE { get; }

        // +(NSString *)VAD_BOS;
        [Static]
        [Export("VAD_BOS")]
    //    //[Verify(MethodToProperty)]
        string VAD_BOS { get; }

        // +(NSString *)VAD_EOS;
        [Static]
        [Export("VAD_EOS")]
        //[Verify(MethodToProperty)]
        string VAD_EOS { get; }

        // +(NSString *)VOICE_NAME;
        [Static]
        [Export("VOICE_NAME")]
        //[Verify(MethodToProperty)]
        string VOICE_NAME { get; }

        // +(NSString *)VOICE_ID;
        [Static]
        [Export("VOICE_ID")]
        //[Verify(MethodToProperty)]
        string VOICE_ID { get; }

        // +(NSString *)VOICE_LANG;
        [Static]
        [Export("VOICE_LANG")]
        //[Verify(MethodToProperty)]
        string VOICE_LANG { get; }

        // +(NSString *)VOLUME;
        [Static]
        [Export("VOLUME")]
        //[Verify(MethodToProperty)]
        string VOLUME { get; }

        // +(NSString *)TTS_BUFFER_TIME;
        [Static]
        [Export("TTS_BUFFER_TIME")]
        //[Verify(MethodToProperty)]
        string TTS_BUFFER_TIME { get; }

        // +(NSString *)TTS_DATA_NOTIFY;
        [Static]
        [Export("TTS_DATA_NOTIFY")]
        //[Verify(MethodToProperty)]
        string TTS_DATA_NOTIFY { get; }

        // +(NSString *)NEXT_TEXT;
        [Static]
        [Export("NEXT_TEXT")]
        //[Verify(MethodToProperty)]
        string NEXT_TEXT { get; }

        // +(NSString *)MPPLAYINGINFOCENTER;
        [Static]
        [Export("MPPLAYINGINFOCENTER")]
        //[Verify(MethodToProperty)]
        string MPPLAYINGINFOCENTER { get; }

        // +(NSString *)AUDIO_SOURCE;
        [Static]
        [Export("AUDIO_SOURCE")]
        //[Verify(MethodToProperty)]
        string AUDIO_SOURCE { get; }

        // +(NSString *)ASR_AUDIO_PATH;
        [Static]
        [Export("ASR_AUDIO_PATH")]
        //[Verify(MethodToProperty)]
        string ASR_AUDIO_PATH { get; }

        // +(NSString *)ASR_SCH;
        [Static]
        [Export("ASR_SCH")]
        //[Verify(MethodToProperty)]
        string ASR_SCH { get; }

        // +(NSString *)ASR_PTT;
        [Static]
        [Export("ASR_PTT")]
        //[Verify(MethodToProperty)]
        string ASR_PTT { get; }

        // +(NSString *)ASR_PTT_HAVEDOT;
        [Static]
        [Export("ASR_PTT_HAVEDOT")]
        //[Verify(MethodToProperty)]
        string ASR_PTT_HAVEDOT { get; }

        // +(NSString *)ASR_PTT_NODOT;
        [Static]
        [Export("ASR_PTT_NODOT")]
        //[Verify(MethodToProperty)]
        string ASR_PTT_NODOT { get; }

        // +(NSString *)LOCAL_GRAMMAR;
        [Static]
        [Export("LOCAL_GRAMMAR")]
        //[Verify(MethodToProperty)]
        string LOCAL_GRAMMAR { get; }

        // +(NSString *)CLOUD_GRAMMAR;
        [Static]
        [Export("CLOUD_GRAMMAR")]
        //[Verify(MethodToProperty)]
        string CLOUD_GRAMMAR { get; }

        // +(NSString *)GRAMMAR_TYPE;
        [Static]
        [Export("GRAMMAR_TYPE")]
        //[Verify(MethodToProperty)]
        string GRAMMAR_TYPE { get; }

        // +(NSString *)GRAMMAR_CONTENT;
        [Static]
        [Export("GRAMMAR_CONTENT")]
        //[Verify(MethodToProperty)]
        string GRAMMAR_CONTENT { get; }

        // +(NSString *)LEXICON_CONTENT;
        [Static]
        [Export("LEXICON_CONTENT")]
        //[Verify(MethodToProperty)]
        string LEXICON_CONTENT { get; }

        // +(NSString *)LEXICON_NAME;
        [Static]
        [Export("LEXICON_NAME")]
        //[Verify(MethodToProperty)]
        string LEXICON_NAME { get; }

        // +(NSString *)GRAMMAR_LIST;
        [Static]
        [Export("GRAMMAR_LIST")]
        //[Verify(MethodToProperty)]
        string GRAMMAR_LIST { get; }

        // +(NSString *)NLP_VERSION;
        [Static]
        [Export("NLP_VERSION")]
        //[Verify(MethodToProperty)]
        string NLP_VERSION { get; }

        // +(NSString *)IVW_THRESHOLD;
        [Static]
        [Export("IVW_THRESHOLD")]
        //[Verify(MethodToProperty)]
        string IVW_THRESHOLD { get; }

        // +(NSString *)IVW_SST;
        [Static]
        [Export("IVW_SST")]
        //[Verify(MethodToProperty)]
        string IVW_SST { get; }

        // +(NSString *)IVW_ONESHOT;
        [Static]
        [Export("IVW_ONESHOT")]
        //[Verify(MethodToProperty)]
        string IVW_ONESHOT { get; }

        // +(NSString *)KEEP_ALIVE;
        [Static]
        [Export("KEEP_ALIVE")]
        //[Verify(MethodToProperty)]
        string KEEP_ALIVE { get; }

        // +(NSString *)IVW_AUDIO_PATH;
        [Static]
        [Export("IVW_AUDIO_PATH")]
        //[Verify(MethodToProperty)]
        string IVW_AUDIO_PATH { get; }

        // +(NSString *)ISE_CATEGORY;
        [Static]
        [Export("ISE_CATEGORY")]
        //[Verify(MethodToProperty)]
        string ISE_CATEGORY { get; }

        // +(NSString *)ISE_RESULT_LEVEL;
        [Static]
        [Export("ISE_RESULT_LEVEL")]
        //[Verify(MethodToProperty)]
        string ISE_RESULT_LEVEL { get; }

        // +(NSString *)ISE_RESULT_TYPE;
        [Static]
        [Export("ISE_RESULT_TYPE")]
        //[Verify(MethodToProperty)]
        string ISE_RESULT_TYPE { get; }

        // +(NSString *)ISE_AUDIO_PATH;
        [Static]
        [Export("ISE_AUDIO_PATH")]
        //[Verify(MethodToProperty)]
        string ISE_AUDIO_PATH { get; }

        // +(NSString *)ISE_AUTO_TRACKING;
        [Static]
        [Export("ISE_AUTO_TRACKING")]
        //[Verify(MethodToProperty)]
        string ISE_AUTO_TRACKING { get; }

        // +(NSString *)ISE_TRACK_TYPE;
        [Static]
        [Export("ISE_TRACK_TYPE")]
        //[Verify(MethodToProperty)]
        string ISE_TRACK_TYPE { get; }

        // +(NSString *)PLUS_LOCAL_ALL;
        [Static]
        [Export("PLUS_LOCAL_ALL")]
        //[Verify(MethodToProperty)]
        string PLUS_LOCAL_ALL { get; }

        // +(NSString *)PLUS_LOCAL_TTS;
        [Static]
        [Export("PLUS_LOCAL_TTS")]
        //[Verify(MethodToProperty)]
        string PLUS_LOCAL_TTS { get; }

        // +(NSString *)PLUS_LOCAL_ASR;
        [Static]
        [Export("PLUS_LOCAL_ASR")]
        //[Verify(MethodToProperty)]
        string PLUS_LOCAL_ASR { get; }

        // +(NSString *)PLUS_LOCAL_IVW;
        [Static]
        [Export("PLUS_LOCAL_IVW")]
        //[Verify(MethodToProperty)]
        string PLUS_LOCAL_IVW { get; }

        // +(NSString *)MFV_AUTH_ID;
        [Static]
        [Export("MFV_AUTH_ID")]
        //[Verify(MethodToProperty)]
        string MFV_AUTH_ID { get; }

        // +(NSString *)MFV_SUB;
        [Static]
        [Export("MFV_SUB")]
        //[Verify(MethodToProperty)]
        string MFV_SUB { get; }

        // +(NSString *)MFV_SST;
        [Static]
        [Export("MFV_SST")]
        //[Verify(MethodToProperty)]
        string MFV_SST { get; }

        // +(NSString *)MFV_VCM;
        [Static]
        [Export("MFV_VCM")]
        //[Verify(MethodToProperty)]
        string MFV_VCM { get; }

        // +(NSString *)MFV_SCENES;
        [Static]
        [Export("MFV_SCENES")]
        //[Verify(MethodToProperty)]
        string MFV_SCENES { get; }

        // +(NSString *)MFV_AFC;
        [Static]
        [Export("MFV_AFC")]
        //[Verify(MethodToProperty)]
        string MFV_AFC { get; }

        // +(NSString *)MFV_DATA_PATH;
        [Static]
        [Export("MFV_DATA_PATH")]
        //[Verify(MethodToProperty)]
        string MFV_DATA_PATH { get; }

        // +(NSString *)MFV_RGN;
        [Static]
        [Export("MFV_RGN")]
        //[Verify(MethodToProperty)]
        string MFV_RGN { get; }

        // +(NSString *)MFV_TSD;
        [Static]
        [Export("MFV_TSD")]
        //[Verify(MethodToProperty)]
        string MFV_TSD { get; }

        // +(NSString *)MFV_PTXT;
        [Static]
        [Export("MFV_PTXT")]
        //[Verify(MethodToProperty)]
        string MFV_PTXT { get; }

        // +(NSString *)MFV_PWDT;
        [Static]
        [Export("MFV_PWDT")]
        //[Verify(MethodToProperty)]
        string MFV_PWDT { get; }

        // +(NSString *)MFV_FIN;
        [Static]
        [Export("MFV_FIN")]
        //[Verify(MethodToProperty)]
        string MFV_FIN { get; }

        // +(NSString *)MFV_WTT;
        [Static]
        [Export("MFV_WTT")]
        //[Verify(MethodToProperty)]
        string MFV_WTT { get; }

        // +(NSString *)MFV_DATA_FORMAT;
        [Static]
        [Export("MFV_DATA_FORMAT")]
        //[Verify(MethodToProperty)]
        string MFV_DATA_FORMAT { get; }

        // +(NSString *)MFV_DATA_ENCODING;
        [Static]
        [Export("MFV_DATA_ENCODING")]
        //[Verify(MethodToProperty)]
        string MFV_DATA_ENCODING { get; }

        // +(NSString *)FACE_SUB;
        [Static]
        [Export("FACE_SUB")]
        //[Verify(MethodToProperty)]
        string FACE_SUB { get; }

        // +(NSString *)FACE_WFR;
        [Static]
        [Export("FACE_WFR")]
        //[Verify(MethodToProperty)]
        string FACE_WFR { get; }

        // +(NSString *)FACE_SST;
        [Static]
        [Export("FACE_SST")]
        //[Verify(MethodToProperty)]
        string FACE_SST { get; }

        // +(NSString *)FACE_REG;
        [Static]
        [Export("FACE_REG")]
        //[Verify(MethodToProperty)]
        string FACE_REG { get; }

        // +(NSString *)FACE_VERIFY;
        [Static]
        [Export("FACE_VERIFY")]
        //[Verify(MethodToProperty)]
        string FACE_VERIFY { get; }

        // +(NSString *)FACE_DETECT;
        [Static]
        [Export("FACE_DETECT")]
        //[Verify(MethodToProperty)]
        string FACE_DETECT { get; }

        // +(NSString *)FACE_ALIGN;
        [Static]
        [Export("FACE_ALIGN")]
        //[Verify(MethodToProperty)]
        string FACE_ALIGN { get; }

        // +(NSString *)FACE_ATTR;
        [Static]
        [Export("FACE_ATTR")]
        //[Verify(MethodToProperty)]
        string FACE_ATTR { get; }

        // +(NSString *)FACE_AUE;
        [Static]
        [Export("FACE_AUE")]
        //[Verify(MethodToProperty)]
        string FACE_AUE { get; }

        // +(NSString *)FACE_RAW;
        [Static]
        [Export("FACE_RAW")]
        //[Verify(MethodToProperty)]
        string FACE_RAW { get; }

        // +(NSString *)FACE_PSET;
        [Static]
        [Export("FACE_PSET")]
        //[Verify(MethodToProperty)]
        string FACE_PSET { get; }

        // +(NSString *)FACE_SKIP;
        [Static]
        [Export("FACE_SKIP")]
        //[Verify(MethodToProperty)]
        string FACE_SKIP { get; }

        // +(NSString *)FACE_GID;
        [Static]
        [Export("FACE_GID")]
        //[Verify(MethodToProperty)]
        string FACE_GID { get; }

        // +(NSString *)FACE_AUTH_ID;
        [Static]
        [Export("FACE_AUTH_ID")]
        //[Verify(MethodToProperty)]
        string FACE_AUTH_ID { get; }

        // +(NSString *)FACE_DVC;
        [Static]
        [Export("FACE_DVC")]
        //[Verify(MethodToProperty)]
        string FACE_DVC { get; }
    }

    // @interface IFlySpeechError : NSObject
    [BaseType(typeof(NSObject))]
    interface IFlySpeechError
    {
        // @property (assign, nonatomic) int errorCode;
        [Export("errorCode")]
        int ErrorCode { get; set; }

        // @property (assign, nonatomic) int errorType;
        [Export("errorType")]
        int ErrorType { get; set; }

        // @property (retain, nonatomic) NSString * errorDesc;
        [Export("errorDesc", ArgumentSemantic.Retain)]
        string ErrorDesc { get; set; }

        // +(instancetype)initWithError:(int)errorCode;
        [Static]
        [Export("initWithError:")]
        IFlySpeechError InitWithError(int errorCode);
    }

    // @protocol IFlySpeechEvaluatorDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IFlySpeechEvaluatorDelegate
    {
        // @required -(void)onVolumeChanged:(int)volume buffer:(NSData *)buffer;
        [Abstract]
        [Export("onVolumeChanged:buffer:")]
        void OnVolumeChanged(int volume, NSData buffer);

        // @required -(void)onBeginOfSpeech;
        [Abstract]
        [Export("onBeginOfSpeech")]
        void OnBeginOfSpeech();

        // @required -(void)onEndOfSpeech;
        [Abstract]
        [Export("onEndOfSpeech")]
        void OnEndOfSpeech();

        // @required -(void)onCancel;
        [Abstract]
        [Export("onCancel")]
        void OnCancel();

        // @required -(void)onCompleted:(IFlySpeechError *)errorCode;
        [Abstract]
        [Export("onCompleted:")]
        void OnCompleted(IFlySpeechError errorCode);

        // @required -(void)onResults:(NSData *)results isLast:(BOOL)isLast;
        [Abstract]
        [Export("onResults:isLast:")]
        void OnResults(NSData results, bool isLast);
    }

    // @interface IFlySpeechEvaluator : NSObject <IFlySpeechEvaluatorDelegate>
    [BaseType(typeof(NSObject))]
    interface IFlySpeechEvaluator : IFlySpeechEvaluatorDelegate
    {
        [Wrap("WeakDelegate")]
        IFlySpeechEvaluatorDelegate Delegate { get; set; }

        // @property (assign) id<IFlySpeechEvaluatorDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // +(instancetype)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        IFlySpeechEvaluator SharedInstance();

        // -(BOOL)destroy;
        [Export("destroy")]
        //[Verify(MethodToProperty)]
        bool Destroy { get; }

        // -(BOOL)setParameter:(NSString *)value forKey:(NSString *)key;
        [Export("setParameter:forKey:")]
        bool SetParameter(string value, string key);

        // -(NSString *)parameterForKey:(NSString *)key;
        [Export("parameterForKey:")]
        string ParameterForKey(string key);

        // -(BOOL)startListening:(NSData *)data params:(NSString *)params;
        [Export("startListening:params:")]
        bool StartListening(NSData data, string @params);

        // -(void)stopListening;
        [Export("stopListening")]
        void StopListening();

        // -(void)cancel;
        [Export("cancel")]
        void Cancel();
    }

    // @interface IFlyStreamISERecognizer (IFlySpeechEvaluator)
    [Category]
    [BaseType(typeof(IFlySpeechEvaluator))]
    interface IFlySpeechEvaluator_IFlyStreamISERecognizer
    {
        // -(BOOL)writeAudio:(NSData *)audioData;
        [Export("writeAudio:")]
        bool WriteAudio(NSData audioData);
    }

    [Static]
   // [Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const KCIFlySpeechEventKeyISTUploadComplete;
        [Field("KCIFlySpeechEventKeyISTUploadComplete", "__Internal")]
        NSString KCIFlySpeechEventKeyISTUploadComplete { get; }

        // extern NSString *const KCIFlySpeechEventKeySessionID;
        [Field("KCIFlySpeechEventKeySessionID", "__Internal")]
        NSString KCIFlySpeechEventKeySessionID { get; }

        // extern NSString *const KCIFlySpeechEventKeyTTSBuffer;
        [Field("KCIFlySpeechEventKeyTTSBuffer", "__Internal")]
        NSString KCIFlySpeechEventKeyTTSBuffer { get; }

        // extern NSString *const KCIFlySpeechEventKeyIVWResult;
        [Field("KCIFlySpeechEventKeyIVWResult", "__Internal")]
        NSString KCIFlySpeechEventKeyIVWResult { get; }

        // extern NSString *const KCIFlySpeechEventKeyAudioUrl;
        [Field("KCIFlySpeechEventKeyAudioUrl", "__Internal")]
        NSString KCIFlySpeechEventKeyAudioUrl { get; }
    }

    // typedef void (^IFlyOnBuildFinishCompletionHandler)(NSString *, IFlySpeechError *);
    delegate void IFlyOnBuildFinishCompletionHandler(string arg0, IFlySpeechError arg1);

    // @protocol IFlySpeechRecognizerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IFlySpeechRecognizerDelegate
    {
        // @required -(void)onCompleted:(IFlySpeechError *)errorCode;
        [Abstract]
        [Export("onCompleted:")]
        void OnCompleted(IFlySpeechError errorCode);

        // @required -(void)onResults:(NSArray *)results isLast:(BOOL)isLast;
        [Abstract]
        [Export("onResults:isLast:")]
      // [Verify(StronglyTypedNSArray)]
        void OnResults(NSObject[] results, bool isLast);

        // @optional -(void)onVolumeChanged:(int)volume;
        [Export("onVolumeChanged:")]
        void OnVolumeChanged(int volume);

        // @optional -(void)onBeginOfSpeech;
        [Export("onBeginOfSpeech")]
        void OnBeginOfSpeech();

        // @optional -(void)onEndOfSpeech;
        [Export("onEndOfSpeech")]
        void OnEndOfSpeech();

        // @optional -(void)onCancel;
        [Export("onCancel")]
        void OnCancel();

        // @optional -(void)onEvent:(int)eventType arg0:(int)arg0 arg1:(int)arg1 data:(NSData *)eventData;
        [Export("onEvent:arg0:arg1:data:")]
        void OnEvent(int eventType, int arg0, int arg1, NSData eventData);
    }

    // @interface IFlySpeechRecognizer : NSObject <IFlySpeechRecognizerDelegate>
    [BaseType(typeof(NSObject))]
    interface IFlySpeechRecognizer : IFlySpeechRecognizerDelegate
    {
        [Wrap("WeakDelegate")]
        IFlySpeechRecognizerDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<IFlySpeechRecognizerDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // +(instancetype)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        IFlySpeechRecognizer SharedInstance();

        // -(BOOL)destroy;
        [Export("destroy")]
        //[Verify(MethodToProperty)]
        bool Destroy { get; }

        // -(BOOL)setParameter:(NSString *)value forKey:(NSString *)key;
        [Export("setParameter:forKey:")]
        bool SetParameter(string value, string key);

        // -(NSString *)parameterForKey:(NSString *)key;
        [Export("parameterForKey:")]
        string ParameterForKey(string key);

        // -(BOOL)startListening;
        [Export("startListening")]
        //[Verify(MethodToProperty)]
        bool StartListening();

        // -(void)stopListening;
        [Export("stopListening")]
        void StopListening();

        // -(void)cancel;
        [Export("cancel")]
        void Cancel();

        // -(int)buildGrammarCompletionHandler:(IFlyOnBuildFinishCompletionHandler)completionHandler grammarType:(NSString *)grammarType grammarContent:(NSString *)grammarContent;
        [Export("buildGrammarCompletionHandler:grammarType:grammarContent:")]
        int BuildGrammarCompletionHandler(IFlyOnBuildFinishCompletionHandler completionHandler, string grammarType, string grammarContent);

        // @property (readonly, nonatomic) BOOL isListening;
        [Export("isListening")]
        bool IsListening { get; }
    }

    // @interface IFlyStreamRecognizer (IFlySpeechRecognizer)
    [Category]
    [BaseType(typeof(IFlySpeechRecognizer))]
    interface IFlySpeechRecognizer_IFlyStreamRecognizer
    {
        // -(BOOL)writeAudio:(NSData *)audioData;
        [Export("writeAudio:")]
        bool WriteAudio(NSData audioData);
    }

    // @protocol IFlySpeechSynthesizerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IFlySpeechSynthesizerDelegate
    {
        // @required -(void)onCompleted:(IFlySpeechError *)error;
        [Abstract]
        [Export("onCompleted:")]
        void OnCompleted(IFlySpeechError error);

        // @optional -(void)onSpeakBegin;
        [Export("onSpeakBegin")]
        void OnSpeakBegin();

        // @optional -(void)onBufferProgress:(int)progress message:(NSString *)msg;
        [Export("onBufferProgress:message:")]
        void OnBufferProgress(int progress, string msg);

        // @optional -(void)onSpeakProgress:(int)progress beginPos:(int)beginPos endPos:(int)endPos;
        [Export("onSpeakProgress:beginPos:endPos:")]
        void OnSpeakProgress(int progress, int beginPos, int endPos);

        // @optional -(void)onSpeakPaused;
        [Export("onSpeakPaused")]
        void OnSpeakPaused();

        // @optional -(void)onSpeakResumed;
        [Export("onSpeakResumed")]
        void OnSpeakResumed();

        // @optional -(void)onSpeakCancel;
        [Export("onSpeakCancel")]
        void OnSpeakCancel();

        // @optional -(void)onEvent:(int)eventType arg0:(int)arg0 arg1:(int)arg1 data:(NSData *)eventData;
        [Export("onEvent:arg0:arg1:data:")]
        void OnEvent(int eventType, int arg0, int arg1, NSData eventData);
    }

    // @interface IFlySpeechSynthesizer : NSObject
    [BaseType(typeof(NSObject))]
    interface IFlySpeechSynthesizer
    {
        [Wrap("WeakDelegate")]
        IFlySpeechSynthesizerDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<IFlySpeechSynthesizerDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // +(instancetype)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        IFlySpeechSynthesizer SharedInstance();

        // +(BOOL)destroy;
        [Static]
        [Export("destroy")]
        //[Verify(MethodToProperty)]
        bool Destroy { get; }

        // -(BOOL)setParameter:(NSString *)value forKey:(NSString *)key;
        [Export("setParameter:forKey:")]
        bool SetParameter(string value, string key);

        // -(NSString *)parameterForKey:(NSString *)key;
        [Export("parameterForKey:")]
        string ParameterForKey(string key);

        // -(void)startSpeaking:(NSString *)text;
        [Export("startSpeaking:")]
        void StartSpeaking(string text);

        // -(void)synthesize:(NSString *)text toUri:(NSString *)uri;
        [Export("synthesize:toUri:")]
        void Synthesize(string text, string uri);

        // -(void)pauseSpeaking;
        [Export("pauseSpeaking")]
        void PauseSpeaking();

        // -(void)resumeSpeaking;
        [Export("resumeSpeaking")]
        void ResumeSpeaking();

        // -(void)stopSpeaking;
        [Export("stopSpeaking")]
        void StopSpeaking();

        // @property (readonly, nonatomic) BOOL isSpeaking;
        [Export("isSpeaking")]
        bool IsSpeaking { get; }
    }

    // @protocol IFlySpeechplusDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IFlySpeechplusDelegate
    {
        // @required -(void)onCompleted:(int)errorCode;
        [Abstract]
        [Export("onCompleted:")]
        void OnCompleted(int errorCode);

        // @required -(void)onCompleted;
        [Abstract]
        [Export("onCompleted")]
        void OnCompleted();
    }

    // @interface IFlySpeechUtility : NSObject
    [BaseType(typeof(NSObject))]
    interface IFlySpeechUtility
    {
        // +(IFlySpeechUtility *)createUtility:(NSString *)params;
        [Static]
        [Export("createUtility:")]
        IFlySpeechUtility CreateUtility(string @params);

        // +(BOOL)destroy;
        [Static]
        [Export("destroy")]
        //[Verify(MethodToProperty)]
        bool Destroy { get; }

        // +(IFlySpeechUtility *)getUtility;
        [Static]
        [Export("getUtility")]
        //[Verify(MethodToProperty)]
        IFlySpeechUtility Utility { get; }

        // -(BOOL)setParameter:(NSString *)value forKey:(NSString *)key;
        [Export("setParameter:forKey:")]
        bool SetParameter(string value, string key);

        // -(NSString *)parameterForKey:(NSString *)key;
        [Export("parameterForKey:")]
        string ParameterForKey(string key);

        // @property (readonly, nonatomic) IFlyEngineMode engineMode;
        [Export("engineMode")]
        IFlyEngineMode EngineMode { get; }

        [Wrap("WeakDelegate")]
        IFlySpeechplusDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<IFlySpeechplusDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }
    }

    // @interface SpeechPlus (IFlySpeechUtility)
    [Category]
    [BaseType(typeof(IFlySpeechUtility))]
    interface IFlySpeechUtility_SpeechPlus
    {
        // +(BOOL)checkServiceInstalled;
        [Static]
        [Export("checkServiceInstalled")]
        //[Verify(MethodToProperty)]
        bool CheckServiceInstalled { get; }

        // +(NSString *)componentUrl;
        [Static]
        [Export("componentUrl")]
        //[Verify(MethodToProperty)]
        string ComponentUrl { get; }

        // -(BOOL)handleOpenURL:(NSURL *)url;
        [Export("handleOpenURL:")]
        bool HandleOpenURL(NSUrl url);

        // -(BOOL)openSpeechPlus:(IFlySpeechPlusServiceType)serviceType;
        [Export("openSpeechPlus:")]
        bool OpenSpeechPlus(IFlySpeechPlusServiceType serviceType);
    }

    // @interface IFlyUserWords : NSObject
    [BaseType(typeof(NSObject))]
    interface IFlyUserWords
    {
        // -(id)initWithJson:(NSString *)json;
        [Export("initWithJson:")]
        IntPtr Constructor(string json);

        // -(NSString *)toString;
        [Export("toString")]
        //[Verify(MethodToProperty)]
        string ToString { get; }

        // -(NSArray *)getWords:(NSString *)key;
        [Export("getWords:")]
      //  [Verify(StronglyTypedNSArray)]
        NSObject[] GetWords(string key);

        // -(BOOL)putWord:(NSString *)key value:(NSString *)value;
        [Export("putWord:value:")]
        bool PutWord(string key, string value);

        // -(BOOL)putwords:(NSString *)key words:(NSArray *)words;
        [Export("putwords:words:")]
       // [Verify(StronglyTypedNSArray)]
        bool Putwords(string key, NSObject[] words);

        // -(BOOL)containsKey:(NSString *)key;
        [Export("containsKey:")]
        bool ContainsKey(string key);
    }

    // @protocol IFlyPcmRecorderDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IFlyPcmRecorderDelegate
    {
        // @required -(void)onIFlyRecorderBuffer:(const void *)buffer bufferSize:(int)size;
        [Abstract]
        [Export("onIFlyRecorderBuffer:bufferSize:")]
        unsafe void OnIFlyRecorderBuffer(IntPtr buffer, int size);

        // @required -(void)onIFlyRecorderError:(IFlyPcmRecorder *)recoder theError:(int)error;
        [Abstract]
        [Export("onIFlyRecorderError:theError:")]
        void OnIFlyRecorderError(IFlyPcmRecorder recoder, int error);

        // @optional -(void)onIFlyRecorderVolumeChanged:(int)power;
        [Export("onIFlyRecorderVolumeChanged:")]
        void OnIFlyRecorderVolumeChanged(int power);
    }

    // @interface IFlyPcmRecorder : NSObject <AVAudioSessionDelegate>
    [BaseType(typeof(NSObject))]
    interface IFlyPcmRecorder : IAVAudioSessionDelegate
    {
        [Wrap("WeakDelegate")]
        IFlyPcmRecorderDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<IFlyPcmRecorderDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (assign, nonatomic) BOOL isNeedDeActive;
        [Export("isNeedDeActive")]
        bool IsNeedDeActive { get; set; }

        // +(instancetype)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        IFlyPcmRecorder SharedInstance();

        // -(BOOL)start;
        [Export("start")]
        //[Verify(MethodToProperty)]
        bool Start { get; }

        // -(void)stop;
        [Export("stop")]
        void Stop();

        // -(void)setSample:(NSString *)rate;
        [Export("setSample:")]
        void SetSample(string rate);

        // -(void)setPowerCycle:(float)cycle;
        [Export("setPowerCycle:")]
        void SetPowerCycle(float cycle);

        // -(void)setSaveAudioPath:(NSString *)savePath;
        [Export("setSaveAudioPath:")]
        void SetSaveAudioPath(string savePath);

        // -(BOOL)isCompleted;
        [Export("isCompleted")]
        //[Verify(MethodToProperty)]
        bool IsCompleted { get; }
    }

    // @protocol IFlyVoiceWakeuperDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IFlyVoiceWakeuperDelegate
    {
        // @optional -(void)onBeginOfSpeech;
        [Export("onBeginOfSpeech")]
        void OnBeginOfSpeech();

        // @optional -(void)onEndOfSpeech;
        [Export("onEndOfSpeech")]
        void OnEndOfSpeech();

        // @optional -(void)onCompleted:(IFlySpeechError *)error;
        [Export("onCompleted:")]
        void OnCompleted(IFlySpeechError error);

        // @optional -(void)onResult:(NSMutableDictionary *)resultDic;
        [Export("onResult:")]
        void OnResult(NSMutableDictionary resultDic);

        // @optional -(void)onVolumeChanged:(int)volume;
        [Export("onVolumeChanged:")]
        void OnVolumeChanged(int volume);

        // @optional -(void)onEvent:(int)eventType isLast:(BOOL)isLast arg1:(int)arg1 data:(NSMutableDictionary *)eventData;
        [Export("onEvent:isLast:arg1:data:")]
        void OnEvent(int eventType, bool isLast, int arg1, NSMutableDictionary eventData);
    }

    // @interface IFlyVoiceWakeuper : NSObject
    [BaseType(typeof(NSObject))]
    interface IFlyVoiceWakeuper
    {
        [Wrap("WeakDelegate")]
        IFlyVoiceWakeuperDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<IFlyVoiceWakeuperDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic) BOOL isListening;
        [Export("isListening")]
        bool IsListening { get; }

        // +(instancetype)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        IFlyVoiceWakeuper SharedInstance();

      
        // -(BOOL)startListening;
        [Export("startListening")]
        //[Verify(MethodToProperty)]
        bool StartListening( );

      
        // -(BOOL)stopListening;
        [Export("stopListening")]
        //[Verify(MethodToProperty)]
        bool StopListening();

        // -(BOOL)cancel;
        [Export("cancel")]
        //[Verify(MethodToProperty)]
        bool Cancel();

        // -(NSString *)getParameter:(NSString *)key;
        [Export("getParameter:")]
        string GetParameter(string key);

        // -(BOOL)setParameter:(NSString *)value forKey:(NSString *)key;
        [Export("setParameter:forKey:")]
        bool SetParameter(string value, string key);
    }

    // @interface IFlyStreamVoiceWakeuper (IFlyVoiceWakeuper)
    [Category]
    [BaseType(typeof(IFlyVoiceWakeuper))]
    interface IFlyVoiceWakeuper_IFlyStreamVoiceWakeuper
    {
        // -(BOOL)writeAudio:(NSData *)audioData;
        [Export("writeAudio:")]
        bool WriteAudio(NSData audioData);
    }

}
