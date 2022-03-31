using System;
using AtgDev.Voicemeeter.Types;

namespace AtgDev.Voicemeeter
{
    partial class RemoteApiExtender
    {
        /// <inheritdoc cref="RemoteApiWrapper.GetLevel(int, int, out float)" path="/summary"/>
        /// <param name="level">Variable to put level's value</param>
        /// <inheritdoc cref="RemoteApiWrapper.GetLevel(int, int, out float)" path="/returns"/>
        public Int32 GetLevel(ref VoicemeeterLevel level)
        {
            var resp = GetLevel(level.type, level.channel, out Single val);
            level.Value = val;
            return resp;
        }

        /// <param name="type">What type of level to read</param>
        /// <param name="channel">Audio channel</param>
        /// <param name="val">The variable receiving the wanted value.</param>
        /// <inheritdoc cref="GetLevel(ref VoicemeeterLevel)"/>
        public Int32 GetLevel(VoicemeeterLevelType type, VoicemeeterChannel channel, out Single val)
        {
            return GetLevel((int)type, (int)channel, out val);
        }
    }
}