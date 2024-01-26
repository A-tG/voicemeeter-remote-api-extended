using System;
using AtgDev.Voicemeeter.Types;

namespace AtgDev.Voicemeeter.Extensions
{
    static partial class RemoteApiExtension
    {
        /// <summary>
        ///     Set current button value.
        /// </summary>
        /// <param name="buttonIndex">button index: 0 to 79</param>
        /// <param name="val">Value giving the status (0.0 = OFF / 1.0 = ON).</param>
        /// <param name="mode">define what kind of value you want to write/modify</param>
        /// <returns>
        ///     0: OK (no error).<br/>
        ///     -1: error<br/>
        ///     -2: no server.<br/>
        ///     -3: unknown parameter<br/>
        ///     -5: structure mismatch<br/>
        /// </returns>
        public static Int32 MacroButtonSetStatus(this RemoteApiWrapper api, Int32 buttonIndex, Single val, MacrobuttonMode mode)
        {
            var modeVal = (Int32)mode;
            return api.MacroButtonSetStatus(buttonIndex, val, modeVal);
        }

        /// <summary>
        ///     Set current button value.
        /// </summary>
        /// <param name="buttonIndex">button index: 0 to 79</param>
        /// <param name="isOn">Value giving the status</param>
        /// <param name="mode">define what kind of value you want to write/modify</param>
        /// <returns>
        ///     0: OK (no error).<br/>
        ///     -1: error<br/>
        ///     -2: no server.<br/>
        ///     -3: unknown parameter<br/>
        ///     -5: structure mismatch<br/>
        /// </returns>
        public static Int32 MacroButtonSetStatus(this RemoteApiWrapper api, Int32 buttonIndex, bool isOn, MacrobuttonMode mode)
        {
            Single val = Convert.ToSingle(isOn);
            return api.MacroButtonSetStatus(buttonIndex, val, mode);
        }

        /// <summary>
        ///     Get current status of a given button.
        /// </summary>
        /// <param name="buttonIndex">button index: 0 to 79</param>
        /// <param name="val">Variable receiving the wanted value (0.0 = OFF / 1.0 = ON)</param>
        /// <param name="mode">Define what kind of value you want to read</param>
        /// <returns>
        ///     0: OK (no error).<br/>
        ///     -1: error<br/>
        ///     -2: no server.<br/>
        ///     -3: unknown parameter<br/>
        ///     -5: structure mismatch<br/>
        /// </returns>
        public static Int32 MacroButtonGetStatus(this RemoteApiWrapper api, Int32 buttonIndex, out Single val, MacrobuttonMode mode)
        {
            var modeVal = (Int32)mode;
            return api.MacroButtonGetStatus(buttonIndex, out val, modeVal);
        }

        /// <summary>
        ///     Get current status of a given button.
        /// </summary>
        /// <param name="buttonIndex">button index: 0 to 79</param>
        /// <param name="isOn">Variable receiving the wanted value</param>
        /// <param name="mode">Define what kind of value you want to read</param>
        /// <returns>
        ///     0: OK (no error).<br/>
        ///     -1: error<br/>
        ///     -2: no server.<br/>
        ///     -3: unknown parameter<br/>
        ///     -5: structure mismatch<br/>
        /// </returns>
        public static Int32 MacroButtonGetStatus(this RemoteApiWrapper api, Int32 buttonIndex, out bool isOn, MacrobuttonMode mode)
        {
            var resp = api.MacroButtonGetStatus(buttonIndex, out Single val, mode);
            isOn = Convert.ToBoolean(val);
            return resp;
        }
    }
}