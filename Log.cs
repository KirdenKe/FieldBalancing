using System;

namespace FeildBalancing
{
    public enum DeviceName
    {
        Unrecognized_Device = -1,
        FieldBalancing1
    }
    public enum DeviceType
    {
        UnrecognizedDevice = -1,
        FieldBalancing
    }
    public enum LoginStatus
    {
        Success,
        AccountPasswordWrong,
        OnlyAccountPairs,
        PermissionDenied,
        FailedWithName,
        Failed
    }
    public class Log
    {
        private string _DeviceID;
        public string DeviceID { set { _DeviceID = value; } get => _DeviceID; }
        private string _UserName;
        public string UserName { get => _UserName; }
        public string log { get; set; }
        private DateTime dateTime;
        private string _UserPassword;
        public string UserPassword { get => _UserPassword; }
        public DeviceName GetDeviceName()
        {
            switch(_DeviceID)
            {
                case "DESKTOP-LP0UGI9":
                    return DeviceName.FieldBalancing1;
                /*本機測試*/
                //case "LAPTOP-L53CFE5A":
                //    return DeviceName.FieldBalancing1;
                default:
                    return DeviceName.Unrecognized_Device;
            }
        }
        public string GetDeviceChName()
        {
            switch(_DeviceID)
            {
                case "DESKTOP-LP0UGI9":
                    return "平衡校正機 1";
                /*本機測試*/
                //case "LAPTOP-L53CFE5A":
                //    return "本機測試";
                default:
                    return "Unrecognized Device";
            }
        }
        public DeviceType GetDeviceType()
        {
            switch (_DeviceID)
            {
                case "DESKTOP-LP0UGI9":
                    return DeviceType.FieldBalancing;
                /*本機測試*/
                //case "LAPTOP-L53CFE5A":
                //    return DeviceType.FieldBalancing;
                default:
                    return DeviceType.UnrecognizedDevice;
            }
        }
        public DateTime GetDateTime()
        {
            dateTime = DateTime.Now;
            return dateTime;
        }
        public Log(string userName, string userPassword)
        {
            _UserName = userName;
            _UserPassword = userPassword;
        }
        public Log(string DeviceID) 
        {
            _DeviceID = DeviceID;
        }
    }
    public class Login
    {
        private DeviceName _deviceName;
        public DeviceName deviceName { get => _deviceName; }
        private int _LeftTimes;
        public int LeftTimes { get => _LeftTimes; }
        public LoginStatus loginStatus { get; set; }
        public Login(DeviceName deviceName)
        {
            _deviceName = deviceName;
            _LeftTimes = 2;
        }
        public void LoginFailed()
        {
            _LeftTimes -= 1;
        }
    }
    public static class Extension
    {
        //非同步委派更新UI
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)//在非當前執行緒內 使用委派
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
