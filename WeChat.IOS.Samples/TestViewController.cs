using Foundation;
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

        //分享网页
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

        //分享文本
        partial void UIButton9_TouchUpInside(UIButton sender)
        {
            try
            {
                SendMessageToWXReq req = new SendMessageToWXReq();
                req.Text = @"微信分享及收藏是指第三方App通过接入该功能，让用户可以从App分享文字、图片、音乐、视频、网页至微信好友会话、朋友圈或添加到微信收藏。
                         微信分享及收藏功能已向全体开发者开放，开发者在微信开放平台帐号下申请App并通过审核后，即可获得微信分享及收藏权限。
                         微信分享及收藏目前支持文字、图片、音乐、视频、网页共五种类型。开发者在App中在集成微信SDK后，可调用接口实现，以下依次是文字分享、图片分享、音乐分享、视频分享、网站分享的示例。";
                req.BText = true;
                req.Scene = (int)WXScene.Session;

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

        //分享图片
        partial void UIButton12_TouchUpInside(UIButton sender)
        {
            try
            {
                //初始化一个WXImageObject对象，设置要分享的图片
                WXImageObject imageObj = new WXImageObject();
                NSData data = NSData.FromFile("icon.png");
                imageObj.ImageData = data;

                //设置WXMediaMessage对象
                WXMediaMessage msg = new WXMediaMessage();
                msg.SetThumbImage(UIImage.FromFile("icon.png"));
                msg.MediaObject = imageObj;

                //构造SendMessageToWXReq请求
                SendMessageToWXReq req = new SendMessageToWXReq();
                req.BText = false;
                req.Message = msg;
                req.Scene = (int)WXScene.Timeline;

                //发送数据
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

        //分享音乐
        partial void UIButton10_TouchUpInside(UIButton sender)
        {
            try
            {
                //初始化一个WXMusicObject对象，设置分享音乐的属性
                WXMusicObject musicObj = new WXMusicObject();
                musicObj.MusicUrl = "http://www.qq.com";

                //设置WXMediaMessage对象
                WXMediaMessage msg = new WXMediaMessage();
                msg.Title = "音乐标题";
                msg.Description = "音乐描述";
                msg.SetThumbImage(UIImage.FromFile("icon.png"));
                msg.MediaObject = musicObj;

                //构造SendMessageToWXReq请求
                SendMessageToWXReq req = new SendMessageToWXReq();
                req.BText = false;
                req.Message = msg;
                req.Scene = (int)WXScene.Timeline;

                //发送数据
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

        //分享视频
        partial void UIButton11_TouchUpInside(UIButton sender)
        {
            try
            {
                //初始化一个WXVideoObject对象，设置分享视频的属性
                WXVideoObject videoObj = new WXVideoObject();
                videoObj.VideoUrl = "http://www.qq.com";

                //设置WXMediaMessage对象
                WXMediaMessage msg = new WXMediaMessage();
                msg.Title = "视频标题";
                msg.Description = "视频描述";
                msg.SetThumbImage(UIImage.FromFile("icon.png"));
                msg.MediaObject = videoObj;

                //构造SendMessageToWXReq请求
                SendMessageToWXReq req = new SendMessageToWXReq();
                req.BText = false;
                req.Message = msg;
                req.Scene = (int)WXScene.Timeline;

                //发送数据
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