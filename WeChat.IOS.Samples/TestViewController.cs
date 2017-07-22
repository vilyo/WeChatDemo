using System;

using UIKit;
using WeChat.IOS;

namespace WeChat.IOS.Samples
{
    public partial class TestViewController : UIViewController
    {
        public TestViewController() : base("TestViewController", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
        }

        partial void UIButton5_TouchUpInside(UIButton sender)
        {
            try
            {                
                WXMediaMessage msg = new WXMediaMessage();
                msg.Title = "Xamarin官方网站";
                msg.Description = "Xamarin官方网站的描述";
                msg.SetThumbImage(UIImage.FromFile("icon.png"));

                WXWebpageObject webObj = new WXWebpageObject();
                webObj.WebpageUrl = "https://www.xamarin.com";
                msg.MediaObject = webObj;

                SendMessageToWXReq req = new SendMessageToWXReq();
                req.BText = false;
                req.Message = msg;
                req.Scene = (int)WXScene.Timeline;

                var result = WXApi.SendReq(req);

                UIAlertView alertView = new UIAlertView("", "分享结果:" + result, null, "取消");
                alertView.Show();
            }
            catch (Exception ex)
            {
                UIAlertView alertView = new UIAlertView("", "异常:" + ex, null, "取消");
                alertView.Show();
            }
        }
    }
}