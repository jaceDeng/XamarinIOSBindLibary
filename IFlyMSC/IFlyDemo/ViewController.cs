using System;
using IFlyMSC.iOS;
using UIKit;

namespace IFlyDemo
{
    public partial class ViewController : UIViewController
    {
        IFlyMSC.iOS.IFlySpeechRecognizer flySpeechRecognizer = new IFlyMSC.iOS.IFlySpeechRecognizer();
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            flySpeechRecognizer.SetParameter("json", IFlySpeechConstant.RESULT_TYPE);
            flySpeechRecognizer.SetParameter("1", "audio_source");
            flySpeechRecognizer.StartListening();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
