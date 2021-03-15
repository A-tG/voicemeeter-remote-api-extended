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

    enum DeviceRoute
    {
        Input,
        Output
    }

    struct VoicemeeterVersion
    {
        public int v1;
        public int v2;
        public int v3;
        public int v4;

        public override string ToString()
        {
            return $"{v1}.{v2}.{v3}.{v4}";
        }
    }

    struct VoicemeeterLevel
    {
        public VoicemeeterLevel(VoicemeeterLevelType type, VoicemeeterChannel channel, Single value)
        {
            this.type = type;
            this.channel = channel;
            m_value = value;
        }

        public VoicemeeterLevel(VoicemeeterLevelType type, VoicemeeterChannel channel)
        {
            this.type = type;
            this.channel = channel;
            m_value = 0;
        }

        public VoicemeeterLevelType type;
        public VoicemeeterChannel channel;

        private Single m_value;

        public Single Value
        {
            get => m_value;
            set => m_value = Math.Abs(value);
        }

        public double ValueDB
        {
            get => 20 * Math.Log10(m_value);
            set => m_value = (float)Math.Pow(10, value / 20);
        }

        public override string ToString() 
        {
            return $"{m_value}, {ValueDB:0.#}db channel: {(int)channel}, {type}";
        }
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