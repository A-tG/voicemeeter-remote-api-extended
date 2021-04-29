namespace AtgDev.Voicemeeter.Types
{
    public enum MacrobuttonMode
    {
        /// <summary>PUSH or RELEASE state</summary>
        Default = 0,
        /// <summary>change Displayed State only</summary>
        State = 2,
        /// <summary>change Trigger State</summary>
        Trigger = 3
    }

    public enum VoicemeeterType
    {
        Standard = 1,
        Banana = 2,
        Potato = 3,
        // new in 3.0.1.7+
        Potato64 = 6
    }

    public enum VoicemeeterLevelType
    {
        PreFader = 0,
        PostFader,
        PostMute,
        Output
    }

    public enum DeviceType
    {
        MME = 1,
        WDM = 3,
        KS,
        ASIO
    }

    public enum DeviceRoute
    {
        Input,
        Output
    }

    public struct BasicDeviceInfo
    {
        public BasicDeviceInfo(string name, string hardwareID, DeviceType type)
        {
            this.name = name;
            this.hardwareID = hardwareID;
            this.type = type;
        }

        public string name;
        public string hardwareID;
        public DeviceType type;

        public override string ToString() => $"Device: {name}, Hardware ID: {hardwareID}, Type: {type}";
    }
}