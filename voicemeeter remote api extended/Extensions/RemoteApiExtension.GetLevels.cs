using System;
using AtgDev.Voicemeeter.Types;

namespace AtgDev.Voicemeeter.Extensions
{
    static partial class RemoteApiExtension
    {
        /// <inheritdoc cref="RemoteApiWrapper.GetLevel(int, int, out float)" path="/summary"/>
        /// <param name="level">Variable to put level's value</param>
        /// <inheritdoc cref="RemoteApiWrapper.GetLevel(int, int, out float)" path="/returns"/>
        public static Int32 GetLevel(this RemoteApiWrapper api, ref VoicemeeterLevel level)
        {
            var resp = api.GetLevel(level.type, level.channel, out Single val);
            level.Value = val;
            return resp;
        }

        /// <param name="type">What type of level to read</param>
        /// <param name="channel">Audio channel</param>
        /// <param name="val">The variable receiving the wanted value.</param>
        /// <inheritdoc cref="GetLevel(RemoteApiWrapper, ref VoicemeeterLevel)"/>
        public static Int32 GetLevel(this RemoteApiWrapper api, 
            VoicemeeterLevelType type, VoicemeeterChannel channel, out Single val)
        {
            return api.GetLevel((int)type, (int)channel, out val);
        }
    }
}