using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AtgDev.Voicemeeter.Types;

namespace AtgDev.Voicemeeter.Extensions
{
    /// <summary>
    ///     <para>Extended Voicemeeter Remote API</para>
    ///     Have methods that use custom types
    /// </summary>>
    public static partial class RemoteApiExtension
    {
        /// <summary>
        ///     Waiting for voicemeeter's parameters to update, exits if waiting too long<br/>
        ///     Crucial to call this method after the Login()<br/>
        ///     Calls internaly IsParametersDirty() in a loop
        ///     Uses Thread.Sleep()
        /// </summary>
        /// <param name="maxTime">Max time in ms before function exit (ms)</param>
        /// <param name="tickTime">Time in ms between requests (ms)</param>
        /// <returns>
        ///     Same as IsParametersDirty()
        /// </returns>
        public static Int32 WaitForNewParams(this RemoteApiWrapper api, int maxTime = 1000, int tickTime = 1000 / 60)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Int32 resp;
            while (((resp = api.IsParametersDirty()) == 0) && (stopwatch.ElapsedMilliseconds <= maxTime))
            {
                System.Threading.Thread.Sleep(tickTime);
            };
            return resp;
        }

#if !NET40
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
        public static async Task<Int32> WaitForNewParamsAsync(this RemoteApiWrapper api, 
            double maxTime = 1000, double tickTime = 1000 / 60)
        {
            var timeSpan = TimeSpan.FromMilliseconds(tickTime);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Int32 resp;
            while (((resp = api.IsParametersDirty()) == 0) && (stopwatch.ElapsedMilliseconds <= maxTime))
            {
                await Task.Delay(timeSpan);
            };
            return resp;
        }
#endif

        /// <summary>
        ///     Waiting for voicemeeter's macro buttons parameters to update, exits if waiting too long<br/>
        ///     Might be crucial to call this method after the Login() in order to be able to get correct macro buttons status<br/>
        ///     Calls internaly MacroButtonIsDirty() in a loop
        ///     Uses Thread.Sleep()
        /// </summary>
        /// <param name="maxTime">Max time in ms before function exit (ms)</param>
        /// <param name="tickTime">Time in ms between requests (ms)</param>
        /// <returns>
        ///     Same as MacroButtonIsDirty()
        /// </returns>
        public static Int32 WaitForMacroNewParams(this RemoteApiWrapper api, int maxTime = 1000, int tickTime = 1000 / 60)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Int32 resp;
            while (((resp = api.MacroButtonIsDirty()) == 0) && (stopwatch.ElapsedMilliseconds <= maxTime))
            {
                System.Threading.Thread.Sleep(tickTime);
            };
            return resp;
        }

#if !NET40
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
        public static async Task<Int32> WaitForMacroNewParamsAsync(this RemoteApiWrapper api, 
            int maxTime = 1000, int tickTime = 1000 / 60)
        {
            var timeSpan = TimeSpan.FromMilliseconds(tickTime);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Int32 resp;
            while (((resp = api.MacroButtonIsDirty()) == 0) && (stopwatch.ElapsedMilliseconds <= maxTime))
            {
                await Task.Delay(timeSpan);
            };
            return resp;
        }
#endif

        /// <summary>
        ///     Run Voicemeeter Application (get installation directory and run Voicemeeter Application).
        /// </summary>
        /// <param name="type">Voicemeeter type</param>
        /// <returns>
        ///     0: Ok.<br/>
        ///     -1: not installed<br/>
        /// </returns>
        public static Int32 RunVoicemeeter(this RemoteApiWrapper api, VoicemeeterType type)
        {
            return api.RunVoicemeeter((int)type);
        }
    }
}