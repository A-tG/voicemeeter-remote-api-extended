using System;

namespace AtgDev.Voicemeeter.Types
{
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
}