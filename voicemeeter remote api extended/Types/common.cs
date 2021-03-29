namespace AtgDev.Voicemeeter.Types
{
    enum MacrobuttonMode
    {
        /// <summary>PUSH or RELEASE state</summary>
        Default = 0,
        /// <summary>change Displayed State only</summary>
        State = 2,
        /// <summary>change Trigger State</summary>
        Trigger = 3
    }

    enum VoicemeeterType
    {
        Standard = 1,
        Banana = 2,
        Potato = 3,
        // new in 3.0.1.7+
        Potato64 = 6
    }

    enum VoicemeeterLevelType
    {
        PreFader = 0,
        PostFader,
        PostMute,
        Output
    }

    enum DeviceType
    {
        MME = 1,
        WDM = 3,
        KS,
        ASIO
    }

    enum DeviceRoute
    {
        Input,
        Output
    }

    struct BasicDeviceInfo
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