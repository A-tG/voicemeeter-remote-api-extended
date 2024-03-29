﻿using System;
using AtgDev.Voicemeeter.Types;

namespace AtgDev.Voicemeeter
{
    partial class RemoteApiExtender
    {
        /// <summary>
        ///     Get Voicemeeter Type.
        /// </summary>
        /// <param name="type">The variable receiving the type</param>
        /// <inheritdoc cref="RemoteApiWrapper.GetVoicemeeterType(out int)" path="/returns"/>
        public Int32 GetVoicemeeterType(out VoicemeeterType type)
        {
            var resp = GetVoicemeeterType(out Int32 typeVal);
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
        public Int32 GetVoicemeeterVersion(out VoicemeeterVersion version)
        {
            var resp = GetVoicemeeterVersion(out int ver);
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
        public Int32 GetVoicemeeterVersion(out string version)
        {
            var resp = GetVoicemeeterVersion(out VoicemeeterVersion ver);
            version = ver.ToString();
            return resp;
        }
    }
}