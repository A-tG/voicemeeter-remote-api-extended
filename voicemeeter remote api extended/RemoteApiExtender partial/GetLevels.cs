using System;
using AtgDev.Voicemeeter.Types;

namespace AtgDev.Voicemeeter
{
    partial class RemoteApiExtender
    {
        /// <summary>
        ///     <para>Get Current levels.</para>
        ///     this function must be called from one thread only
        /// </summary>
        /// <param name="level">Variable to put level's value</param>
        /// <returns>
        ///     0: OK (no error).<br/>
        ///     -1: error<br/>
        ///     -2: no server.<br/>
        ///     -3: no level available<br/>
        ///     -4: out of range<br/>
        /// </returns>
        public Int32 GetLevel(ref VoicemeeterLevel level)
        {
            var resp = GetLevel(level.type, level.channel, out Single val);
            level.Value = val;
            return resp;
        }

        /// <summary>
        ///     <para>Get Current levels.</para>
        ///     this function must be called from one thread only
        /// </summary>
        /// <param name="type">What type of level to read</param>
        /// <param name="channel">Audio channel</param>
        /// <param name="val">The variable receiving the wanted value.</param>
        /// <returns>
        ///     0: OK (no error).<br/>
        ///     -1: error<br/>
        ///     -2: no server.<br/>
        ///     -3: no level available<br/>
        ///     -4: out of range<br/>
        /// </returns>
        public Int32 GetLevel(VoicemeeterLevelType type, VoicemeeterChannel channel, out Single val)
        {
            return GetLevel((int)type, (int)channel, out val);
        }
    }
}