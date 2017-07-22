using System;

namespace WeChat.IOS
{
    public enum AuthErrCode
    {
        Ok = 0,
        NormalErr = -1,
        NetworkErr = -2,
        GetQrcodeFailed = -3,
        Cancel = -4,
        Timeout = -5
    }

    public enum WXErrCode
    {
        Success = 0,
        ErrCodeCommon = -1,
        ErrCodeUserCancel = -2,
        ErrCodeSentFail = -3,
        ErrCodeAuthDeny = -4,
        ErrCodeUnsupport = -5
    }

    public enum WXScene : uint
    {
        Session = 0,
        Timeline = 1,
        Favorite = 2
    }

    public enum WXAPISupport : uint
    {
        WXAPISupportSession = 0
    }

    public enum WXBizProfileType : uint
    {
        Normal = 0,
        Device = 1
    }

    public enum WXMPWebviewType : uint
    {
        WXMPWebviewType_Ad = 0
    }

    public enum enAppSupportContentFlag : ulong
    {
        Nocontent = 0,
        Text = 1,
        Picture = 2,
        Location = 4,
        Video = 8,
        Audio = 16,
        Webpage = 32,
        Doc = 64,
        Docx = 128,
        Ppt = 256,
        Pptx = 512,
        Xls = 1024,
        Xlsx = 2048,
        Pdf = 4096
    }
}
