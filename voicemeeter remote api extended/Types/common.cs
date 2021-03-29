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

#pragma warning disable CS0660, CS0661
    struct VoicemeeterVersion
    {
        public uint v1;
        public uint v2;
        public uint v3;
        public uint v4;

        public void Assign(uint ver1, uint ver2, uint ver3, uint ver4)
        {
            v1 = ver1;
            v2 = ver2;
            v3 = ver3;
            v4 = ver4;
        }

        public void Assign(int version)
        {
            var ver = (version & 0xFF000000) >> 24;
            v1 = (uint)ver;
            ver = (version & 0x00FF0000) >> 16;
            v2 = (uint)ver;
            ver = (version & 0x0000FF00) >> 8;
            v3 = (uint)ver;
            ver = version & 0x000000FF;
            v4 = (uint)ver;
        }

        public static explicit operator VoicemeeterVersion(int n)
        {
            var version = new VoicemeeterVersion();
            version.Assign(n);
            return version;
        }

        public override string ToString()
        {
            return $"{v1}.{v2}.{v3}.{v4}";
        }

        public bool Equals(VoicemeeterVersion version)
        {
            return ((v1 == version.v1) &&
                (v2 == version.v2) &&
                (v3 == version.v3) &&
                (v4 == version.v4));
        }

        public static bool operator==(VoicemeeterVersion ver1, VoicemeeterVersion ver2)
        {
            return ver1.Equals(ver2);
        }

        public static bool operator !=(VoicemeeterVersion ver1, VoicemeeterVersion ver2)
        {
            return !ver1.Equals(ver2);
        }
    }
#pragma warning restore CS0660, CS0661

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