namespace AtgDev.Voicemeeter.Types
{
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

        public static bool operator ==(VoicemeeterVersion ver1, VoicemeeterVersion ver2)
        {
            return ver1.Equals(ver2);
        }

        public static bool operator !=(VoicemeeterVersion ver1, VoicemeeterVersion ver2)
        {
            return !ver1.Equals(ver2);
        }
    }
}