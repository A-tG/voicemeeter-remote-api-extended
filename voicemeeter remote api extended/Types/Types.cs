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
        Potato = 3
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

    struct BasicDeviceInfo
    {
        public BasicDeviceInfo(string name, string hardwareID, DeviceType type)
        {
            Name = name;
            HardwareID = hardwareID;
            Type = type;
        }

        public string Name { get; set; }
        public string HardwareID { get; set; }
        public DeviceType Type { get; set; }

        public override string ToString() => $"Device: {Name}, Hardware ID: {HardwareID}, Type: {Type:g}";
    }
}