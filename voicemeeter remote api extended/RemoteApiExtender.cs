using System;
using AtgDev.Voicemeeter.Types;

namespace AtgDev.Voicemeeter
{
    /// <summary>
    ///     <para>Extended Voicemeeter Remote API</para>
    ///     Have methods that are using custom types
    class RemoteApiExtender : RemoteApiWrapper
    {
        public RemoteApiExtender(string dllPath) : base(dllPath) { }

        /// <summary>
        ///     Get Voicemeeter Type.
        /// </summary>
        /// <param name="type">The variable receiving the type</param>
        /// <returns>
        ///     0: OK (no error).<br/>
        ///     -1: cannot get client (unexpected)<br/>
        ///     -2: no server.<br/>
        /// </returns>
        public Int32 GetVoicemeeterType(out VoicemeeterType type)
        {
            Int32 typeVal;
            var resp = GetVoicemeeterType(out typeVal);
            type = (VoicemeeterType)typeVal;
            return resp;
        }

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
            level.value = val;
            return resp;
        }

        public Int32 GetLevel(VoicemeeterLevelType type, VoicemeeterChannel channel, out Single val)
        {
            return GetLevel((int)type, (int)channel, out val);
        }

        /// <summary>
        ///     Get name and hardware ID of the output device according index
        /// </summary>
        /// <param name="index">zero based index</param>
        /// <param name="devInfo">Variable receiving the device information</param>
        /// <returns>
        ///     0: OK (no error).<br/>
        /// </returns>
        public Int32 GetOutputDeviceDescriptor(Int32 index, out BasicDeviceInfo devInfo)
        {
            var resp = GetOutputDeviceDescriptor(index, out Int32 type, out string deviceName, out string hardwareID);
            devInfo = new BasicDeviceInfo(deviceName, hardwareID, (DeviceType)type);
            return resp;
        }

        /// <summary>
        ///     Get name and hardware ID of the input device according index
        /// </summary>
        /// <param name="index">zero based index</param>
        /// <param name="devInfo">Variable receiving the device information</param>
        /// <returns>
        ///     0: OK (no error).<br/>
        /// </returns>
        public Int32 GetInputDeviceDescriptor(Int32 index, out BasicDeviceInfo devInfo)
        {
            var resp = GetInputDeviceDescriptor(index, out Int32 type, out string deviceName, out string hardwareID);
            devInfo = new BasicDeviceInfo(deviceName, hardwareID, (DeviceType)type);
            return resp;
        }

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
        public Int32 MacroButtonSetStatus(Int32 buttonIndex, Single val, MacrobuttonMode mode)
        {
            var modeVal = (Int32)mode;
            return MacroButtonSetStatus(buttonIndex, val, modeVal);
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
        public Int32 MacroButtonGetStatus(Int32 buttonIndex, out Single val, MacrobuttonMode mode)
        {
            var modeVal = (Int32)mode;
            return MacroButtonGetStatus(buttonIndex, out val, modeVal);
        }
    }
}