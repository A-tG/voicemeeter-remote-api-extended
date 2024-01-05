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
        None = 0,
        Standard,
        Banana,
        Potato,
        // new in 3.1.0.4+
        Standard64,
        Banana64,
        // new in 3.0.1.7+
        Potato64,
        // new in 3.1.0.4+
        DeviceCheck = 10,
        MacroButtons,
        StreamerView,
        BusMatrix8,
        BusGEQ15,
        VBAN2MIDI,
        CableControlPanel = 20,
        VMAUXControlPanel,
        VMVAIO3ControlPanel,
        VoicemeeterVAIOControlPanel
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
        None = 0,
        MME,
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

        public override string ToString()
        {
            string str = $"Device: {name}";
            if (!string.IsNullOrEmpty(hardwareID))
            {
                str += $", Hardware ID: { hardwareID}";
            }
            str += $", Type: {type}";
            return str;
        }
    }
}