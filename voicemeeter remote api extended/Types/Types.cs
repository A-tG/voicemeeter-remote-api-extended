using System;

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

    struct VoicemeeterLevel
    {
        public VoicemeeterLevel(VoicemeeterLevelType type, VoicemeeterChannel channel, Single value)
        {
            this.type = type;
            this.channel = channel;
            this.value = value;
        }

        public VoicemeeterLevel(VoicemeeterLevelType type, VoicemeeterChannel channel)
        {
            this.type = type;
            this.channel = channel;
            this.value = 0;
        }

        public VoicemeeterLevelType type;
        public VoicemeeterChannel channel;
        public Single value;

        public override string ToString() => $"{value}, channel: {(int)channel}, {type:g}";
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

        public override string ToString() => $"Device: {name}, Hardware ID: {hardwareID}, Type: {type:g}";
    }
}