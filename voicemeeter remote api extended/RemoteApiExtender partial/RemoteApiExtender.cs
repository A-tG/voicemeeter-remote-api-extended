using System;
using System.Diagnostics;
using System.Threading.Tasks;
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
        public Int32 WaitForNewParams(int maxTime = 1000, int tickTime = 1000 / 60)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Int32 resp;
            while (((resp = IsParametersDirty()) == 0) && (stopwatch.ElapsedMilliseconds <= maxTime))
            {
                System.Threading.Thread.Sleep(tickTime);
            };
            return resp;
        }

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
        public async Task<Int32> WaitForNewParamsAsync(double maxTime = 1000, double tickTime = 1000 / 60)
        {
            var timeSpan = TimeSpan.FromMilliseconds(tickTime);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Int32 resp;
            while (((resp = IsParametersDirty()) == 0) && (stopwatch.ElapsedMilliseconds <= maxTime))
            {
                await Task.Delay(timeSpan);
            };
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
        ///     Same as MacroButtonIsDirty()
        /// </returns>
        public Int32 WaitForMacroNewParams(int maxTime = 1000, int tickTime = 1000 / 60)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Int32 resp;
            while (((resp = MacroButtonIsDirty()) == 0) && (stopwatch.ElapsedMilliseconds <= maxTime))
            {
                System.Threading.Thread.Sleep(tickTime);
            };
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
        ///     Same as MacroButtonIsDirty()
        /// </returns>
        public async Task<Int32> WaitForMacroNewParamsAsync(int maxTime = 1000, int tickTime = 1000 / 60)
        {
            var timeSpan = TimeSpan.FromMilliseconds(tickTime);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Int32 resp;
            while (((resp = MacroButtonIsDirty()) == 0) && (stopwatch.ElapsedMilliseconds <= maxTime))
            {
                await Task.Delay(timeSpan);
            };
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