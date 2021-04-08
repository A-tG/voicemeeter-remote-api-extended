using System;

namespace AtgDev.Voicemeeter.Types
{
    struct VoicemeeterVersion : IComparable<VoicemeeterVersion>, IEquatable<VoicemeeterVersion>
    {
        public uint v1;
        public uint v2;
        public uint v3;
        public uint v4;

        public VoicemeeterVersion(uint ver1, uint ver2, uint ver3, uint ver4)
        {
            v1 = v2 = v3 = v4 = 0;
            Assign(ver1, ver2, ver3, ver4);
        }

        public VoicemeeterVersion(Int32 version)
        {
            v1 = v2 = v3 = v4 = 0;
            Assign(version);
        }

        public VoicemeeterVersion(string version)
        {
            v1 = v2 = v3 = v4 = 0;
            if (!TryParse(version))
            {
                v1 = v2 = v3 = v4 = 0;
            }
        }

        public void Assign(uint ver1, uint ver2, uint ver3, uint ver4)
        {
            v1 = ver1;
            v2 = ver2;
            v3 = ver3;
            v4 = ver4;
        }

        public void Assign(Int32 version)
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

        public bool TryParse(string version)
        {
            bool result = false;
            const int maxLen = 15;
            const int numbers = 4;
            if (version.Length <= maxLen)
            {
                var versionSplit = version.Split('.');
                if (versionSplit.Length <= numbers)
                {
                    var isValidNumber = uint.TryParse(versionSplit[0], out v1);
                    isValidNumber &= uint.TryParse(versionSplit[1], out v2);
                    isValidNumber &= uint.TryParse(versionSplit[2], out v3);
                    isValidNumber &= uint.TryParse(versionSplit[3], out v4);
                    if (isValidNumber)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public static explicit operator VoicemeeterVersion(Int32 n)
        {
            var version = new VoicemeeterVersion(n);
            return version;
        }

        public override string ToString()
        {
            return $"{v1}.{v2}.{v3}.{v4}";
        }

        public bool Equals(VoicemeeterVersion version)
        {
            return (v1 == version.v1) &&
                (v2 == version.v2) &&
                (v3 == version.v3) &&
                (v4 == version.v4);
        }

        public int CompareTo(VoicemeeterVersion other)
        {
            uint[] thisVersion = { v1, v2, v3, v4 };
            uint[] otherVersion = { other.v1, other.v2, other.v3, other.v4 };
            uint thisV;
            uint otherV;
            for (var i = 0; i < thisVersion.Length; i++)
            {
                thisV = thisVersion[i];
                otherV = otherVersion[i];
                if (thisV != otherV)
                {
                    if (thisV > otherV)
                        return 1;
                    else
                        return -1;
                }
            }
            return 0;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(VoicemeeterVersion left, VoicemeeterVersion right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(VoicemeeterVersion left, VoicemeeterVersion right)
        {
            return !(left == right);
        }

        public static bool operator >(VoicemeeterVersion left, VoicemeeterVersion right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <(VoicemeeterVersion left, VoicemeeterVersion right)
        {
            return right > left;
        }

        public static bool operator <=(VoicemeeterVersion left, VoicemeeterVersion right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(VoicemeeterVersion left, VoicemeeterVersion right)
        {
            return right <= left;
        }
    }
}