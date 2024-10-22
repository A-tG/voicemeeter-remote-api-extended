using System;
using AtgDev.Voicemeeter.Types;

namespace AtgDev.Voicemeeter.Extensions
{
    static partial class RemoteApiExtension
    {
        /// <summary>
        ///     Get Voicemeeter Type.
        /// </summary>
        /// <param name="type">The variable receiving the type</param>
        /// <inheritdoc cref="RemoteApiWrapper.GetVoicemeeterType(out int)" path="/returns"/>
        public static Int32 GetVoicemeeterType(this RemoteApiWrapper api, out VoicemeeterType type)
        {
            var resp = api.GetVoicemeeterType(out Int32 typeVal);
            type = (VoicemeeterType)typeVal;
            return resp;
        }

        /// <summary>
        ///     Get Voicemeeter Version
        /// </summary>
        /// <param name="version">
        ///     Variable receiving the version
        /// </param>
        /// <inheritdoc cref="RemoteApiWrapper.GetVoicemeeterVersion(out int)" path="/returns"/>
        public static Int32 GetVoicemeeterVersion(this RemoteApiWrapper api, out VoicemeeterVersion version)
        {
            var resp = api.GetVoicemeeterVersion(out int ver);
            version = new VoicemeeterVersion(ver);
            return resp;
        }

        /// <summary>
        ///     Get Voicemeeter Version
        /// </summary>
        /// <param name="version">
        ///     Variable receiving the version
        /// </param>
        /// <inheritdoc cref="RemoteApiWrapper.GetVoicemeeterVersion(out int)" path="/returns"/>
        public static Int32 GetVoicemeeterVersion(this RemoteApiWrapper api, out string version)
        {
            var resp = api.GetVoicemeeterVersion(out VoicemeeterVersion ver);
            version = ver.ToString();
            return resp;
        }
    }
}