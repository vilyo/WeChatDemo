using Android.App;
using Android.Widget;
using Android.OS;
using Com.Tencent.MM.Opensdk.Openapi;
using Com.Tencent.MM.Opensdk.Modelbase;
using Com.Tencent.MM.Opensdk.Modelmsg;
using System;
using Android.Graphics;
using System.IO;

namespace WeChat.Android.Samples
{
    [Activity(Label = "WeChat.Android.Samples", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IWXAPIEventHandler
    {
        // IWXAPI 是第三方app和微信通信的openapi接口
        private IWXAPI api;

        // APP_ID 替换为你的应用从官方网站申请到的合法appId
        public const string APP_ID = "wxd930ea5d5a258f4f";

        //最小支持朋友圈的版本
        private const int TIMELINE_SUPPORTED_VERSION = 0x21020001;

        public void OnReq(BaseReq p0)
        {
            throw new NotImplementedException();
        }

        public void OnResp(BaseResp p0)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // 通过WXAPIFactory工厂，获取IWXAPI的实例
            api = WXAPIFactory.CreateWXAPI(this, APP_ID, false);

            Button btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += BtnRegister_Click;
            Button btnText = FindViewById<Button>(Resource.Id.btnText);
            btnText.Click += BtnText_Click;
            Button btnHtml = FindViewById<Button>(Resource.Id.btnHtml);
            btnHtml.Click += BtnHtml_Click;
            Button btnImage = FindViewById<Button>(Resource.Id.btnImage);
            btnImage.Click += BtnImage_Click;
            Button btnVideo = FindViewById<Button>(Resource.Id.btnVideo);
            btnVideo.Click += BtnVideo_Click;
            Button btnMusic = FindViewById<Button>(Resource.Id.btnMusic);
            btnMusic.Click += BtnMusic_Click;
            Button btnProject = FindViewById<Button>(Resource.Id.btnProject);
            btnProject.Click += BtnProject_Click;
            Button btnOpenWeChat = FindViewById<Button>(Resource.Id.btnOpenWeChat);
            btnOpenWeChat.Click += BtnOpenWeChat_Click;
            Button btnIsMoments = FindViewById<Button>(Resource.Id.btnIsMoments);
            btnIsMoments.Click += BtnIsMoments_Click;
        }

        //是否支持朋友圈
        private void BtnIsMoments_Click(object sender, EventArgs e)
        {
            int wxSdkVersion = api.WXAppSupportAPI;
            if (wxSdkVersion >= TIMELINE_SUPPORTED_VERSION)
            {
                Toast.MakeText(this, "wxSdkVersion = " + wxSdkVersion + "\n支持", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "wxSdkVersion = " + wxSdkVersion + "\n不支持", ToastLength.Long).Show();
            }
        }

        //打开微信APP
        private void BtnOpenWeChat_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "launch result = " + api.OpenWXApp(), ToastLength.Long).Show();
        }

        //网页类型分享
        private void BtnHtml_Click(object sender, EventArgs e)
        {
            WXWebpageObject webObj = new WXWebpageObject();
            webObj.WebpageUrl = "https://www.xamarin.com/";

            WXMediaMessage msg = new WXMediaMessage(webObj);
            msg.Title = "Xamarin官网";
            msg.Description = "官方网站描述";

            //分享的缩略图
            Bitmap thumb = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.Icon);
            MemoryStream ms = new MemoryStream();
            thumb.Compress(Bitmap.CompressFormat.Png, 0, ms);
            byte[] bytes = ms.ToArray();

            //构造一个Req请求
            SendMessageToWX.Req req = new SendMessageToWX.Req();
            //唯一的请求标志
            req.Transaction = System.Guid.NewGuid().ToString();
            req.Message = msg;
            req.Scene = SendMessageToWX.Req.WXSceneTimeline;

            //发送数据
            api.SendReq(req);
        }

        //文字类型分享
        private void BtnText_Click(object sender, EventArgs e)
        {
            //初始化一个WXTextObject对象，填写分享的文本内容
            WXTextObject textObj = new WXTextObject();
            textObj.Text = "Hello Xamarin";

            //用WXTextObject对象初始化一个WXMediaMessage对象
            WXMediaMessage msg = new WXMediaMessage();
            msg.MyMediaObject = textObj;
            msg.Description = "Hello World";

            //构造一个Req请求
            SendMessageToWX.Req req = new SendMessageToWX.Req();
            //唯一的请求标志
            req.Transaction = System.Guid.NewGuid().ToString();
            req.Message = msg;
            req.Scene = SendMessageToWX.Req.WXSceneSession;

            //发送数据
            api.SendReq(req);
        }

        //分享图片类型
        private void BtnImage_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.Icon);

            //设置缩略图
            Bitmap thumb = Bitmap.CreateScaledBitmap(bitmap, 50, 50, true);
            bitmap.Recycle();
            MemoryStream ms = new MemoryStream();
            thumb.Compress(Bitmap.CompressFormat.Png, 0, ms);
            byte[] bytes = ms.ToArray();

            //初始化WXImageObject，设置分享的图片
            WXImageObject imgObj = new WXImageObject(bitmap);

            //初始化WXMediaMessage对象
            WXMediaMessage msg = new WXMediaMessage();
            msg.MyMediaObject = imgObj;
            msg.ThumbData = bytes;

            //构造一个Req请求
            SendMessageToWX.Req req = new SendMessageToWX.Req();
            req.Transaction = Guid.NewGuid().ToString();
            req.Message = msg;
            req.Scene = SendMessageToWX.Req.WXSceneSession;

            //发送数据
            api.SendReq(req);
        }

        //分享视频类型
        private void BtnVideo_Click(object sender, EventArgs e)
        {
            //初始化一个WXVideoObject对象，填写视频url
            WXVideoObject videoObj = new WXVideoObject();
            //视频地址
            videoObj.VideoUrl = "https://www.qq.com";

            //设置WXMediaMessage对象
            WXMediaMessage msg = new WXMediaMessage(videoObj);
            msg.Title = "测试视频";
            msg.Description = "测试视频描述";
            //设置缩略图
            Bitmap thumb = BitmapFactory.DecodeResource(Resources, Resource.Drawable.Icon);
            MemoryStream ms = new MemoryStream();
            thumb.Compress(Bitmap.CompressFormat.Png, 0, ms);
            byte[] bytes = ms.ToArray();
            msg.ThumbData = bytes;

            //构造一个Req请求
            SendMessageToWX.Req req = new SendMessageToWX.Req();
            req.Transaction = Guid.NewGuid().ToString();
            req.Message = msg;
            req.Scene = SendMessageToWX.Req.WXSceneTimeline;

            //发送数据
            api.SendReq(req);
        }

        //分享音乐类型
        private void BtnMusic_Click(object sender, EventArgs e)
        {
            //初始化一个WXMusicObject对象，填写音乐地址
            WXMusicObject musicObj = new WXMusicObject();
            //音乐url
            musicObj.MusicUrl = "http://www.qq.com";

            //设置WXMediaMessage对象
            WXMediaMessage msg = new WXMediaMessage();
            msg.MyMediaObject = musicObj;
            msg.Title = "音乐标题";
            msg.Description = "音乐描述";
            //设置缩略图
            Bitmap thumb = BitmapFactory.DecodeResource(Resources, Resource.Drawable.Icon);
            MemoryStream ms = new MemoryStream();
            thumb.Compress(Bitmap.CompressFormat.Png, 0, ms);
            byte[] bytes = ms.ToArray();
            msg.ThumbData = bytes;

            //构造一个Req
            SendMessageToWX.Req req = new SendMessageToWX.Req();
            req.Transaction = Guid.NewGuid().ToString();
            req.Message = msg;
            req.Scene = SendMessageToWX.Req.WXSceneTimeline;

            //发送数据
            api.SendReq(req);
        }

        //分享小程序
        private void BtnProject_Click(object sender, EventArgs e)
        {
            //初始化一个WXMiniProgramObject对象，设置小程序url和ID
            WXMiniProgramObject miniProgram = new WXMiniProgramObject();
            //低版本微信将打开url
            miniProgram.WebpageUrl = "http://www.qq.com";
            //跳转的小程序原始ID
            miniProgram.UserName = "gh_d43f693ca31f";
            //小程序的Path
            miniProgram.Path = "";

            //设置WXMediaMessage对象
            WXMediaMessage msg = new WXMediaMessage(miniProgram);
            msg.Title = "小程序标题";
            msg.Description = "小程序的描述";
            //设置缩略图
            Bitmap thumb = BitmapFactory.DecodeResource(Resources, Resource.Drawable.Icon);
            MemoryStream ms = new MemoryStream();
            thumb.Compress(Bitmap.CompressFormat.Png, 0, ms);
            byte[] bytes = ms.ToArray();
            msg.ThumbData = bytes;

            //构造一个Req对象
            SendMessageToWX.Req req = new SendMessageToWX.Req();
            req.Transaction = Guid.NewGuid().ToString();
            req.Message = msg;
            req.Scene = SendMessageToWX.Req.WXSceneTimeline;

            //发送数据
            api.SendReq(req);
        }

        // 将该app注册到微信
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            var result = api.RegisterApp(APP_ID);
            Toast.MakeText(this, "注册结果:" + result, ToastLength.Short).Show();
        }
    }
}

