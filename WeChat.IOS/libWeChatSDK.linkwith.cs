using ObjCRuntime;

[assembly: LinkWith("libWeChatSDK.a", ForceLoad = true, SmartLink = true,
    Frameworks = "CFNetwork CoreTelephony Security SystemConfiguration",
    LinkerFlags = "-ObjC -all_load -lc++ -lsqlite3.0 -lz")]
