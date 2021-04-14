﻿using System;

namespace AtgDev.Voicemeeter.Types
{
    struct VoicemeeterVersion : IComparable<VoicemeeterVersion>, IEquatable<VoicemeeterVersion>
    {
        public int v1;
        public int v2;
        public int v3;
        public int v4;

        public VoicemeeterVersion(int ver1, int ver2, int ver3, int ver4)
        {
            v1 = v2 = v3 = v4 = 0;
            Assign(ver1, ver2, ver3, ver4);
        }

        public VoicemeeterVersion(Int32 version)
        {
            v1 = v2 = v3 = v4 = 0;
            SingleNumber = version;
        }

        public VoicemeeterVersion(string version)
        {
            v1 = v2 = v3 = v4 = 0;
            TryParse(version);
        }

        public void Assign(int ver1, int ver2, int ver3, int ver4)
        {
            v1 = ver1;
            v2 = ver2;
            v3 = ver3;
            v4 = ver4;
        }

        public Int32 SingleNumber
        {
            get
            {
                int result = (v4 & 0x000000FF);
                result |= (v3 << 8) & 0x0000FF00;
                result |= (v2 << 16) & 0x00FF0000;
                result |= (int)((v1 << 24) & 0xFF000000);
                return result;
            }
            set
            {
                var ver = (int)((value & 0xFF000000) >> 24);
                v1 = ver;
                ver = (value & 0x00FF0000) >> 16;
                v2 = ver;
                ver = (value & 0x0000FF00) >> 8;
                v3 = ver;
                ver = value & 0x000000FF;
                v4 = ver;
            }
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
                    var isValidNumber = int.TryParse(versionSplit[0], out int ver1);
                    isValidNumber &= int.TryParse(versionSplit[1], out int ver2);
                    isValidNumber &= int.TryParse(versionSplit[2], out int ver3);
                    isValidNumber &= int.TryParse(versionSplit[3], out int ver4);
                    if (isValidNumber)
                    {
                        v1 = ver1;
                        v2 = ver2;
                        v3 = ver3;
                        v4 = ver4;
                        result = true;
                    }
                }
            }
            return result;
        }

        public static explicit operator VoicemeeterVersion(int n)
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
            int[] thisVersion = { v1, v2, v3, v4 };
            int[] otherVersion = { other.v1, other.v2, other.v3, other.v4 };
            int thisV;
            int otherV;
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