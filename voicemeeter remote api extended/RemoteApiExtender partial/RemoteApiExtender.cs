using System;
using AtgDev.Voicemeeter.Types;

namespace AtgDev.Voicemeeter
{
    /// <summary>
    ///     <para>Extended Voicemeeter Remote API</para>
    ///     Have methods that use custom types
    /// </summary>>
    public partial class RemoteApiExtender : RemoteApiWrapper
    {
        public RemoteApiExtender(string dllPath) : base(dllPath) { }

        /// <summary>
        ///     Waiting for voicemeeter's parameters to update, exits if waiting too long<br/>
        ///     Crucial to call this method after the Login()<br/>
        ///     Calls internaly IsParametersDirty() in a loop
        /// </summary>
        /// <param name="maxTime">Max time in ms before function exit (ms)</param>
        /// <param name="tickTime">Time in ms between requests (ms)</param>
        /// <returns>
        ///     Same as IsParametersDirty()
        /// </returns>
        public Int32 WaitForNewParams(int timeout = 1000, int tickTime = 1000 / 60)
        {
            var resp = IsParametersDirty();
            for (int time = 0; time < timeout; time += tickTime)
            {
                if (resp != 0) break;
                System.Threading.Thread.Sleep(tickTime);
                resp = IsParametersDirty();
            }
            return resp;
        }

        /// <summary>
        ///     Waiting for voicemeeter's macro buttons parameters to update, exits if waiting too long<br/>
        ///     Might be crucial to call this method after the Login() in order to be able to get correct macro buttons status<br/>
        ///     Calls internaly MacroButtonIsDirty() in a loop
        /// </summary>
        /// <param name="maxTime">Max time in ms before function exit (ms)</param>
        /// <param name="tickTime">Time in ms between requests (ms)</param>
        /// <returns>
        ///     Same as IsParametersDirty()
        /// </returns>
        public Int32 WaitForMacroNewParams(int timeout = 1000, int tickTime = 1000 / 60)
        {
            int resp = MacroButtonIsDirty();
            for (int time = 0; time < timeout; time += tickTime)
            {
                if (resp != 0) break;
                System.Threading.Thread.Sleep(tickTime);
                resp = MacroButtonIsDirty();
            }
            return resp;
        }

        /// <summary>
        ///     Run Voicemeeter Application (get installation directory and run Voicemeeter Application).
        /// </summary>
        /// <param name="type">Voicemeeter type</param>
        /// <returns>
        ///     0: Ok.<br/>
        ///     -1: not installed<br/>
        /// </returns>
        public Int32 RunVoicemeeter(VoicemeeterType type)
        {
            return RunVoicemeeter((int)type);
        }
    }
}