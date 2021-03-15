using System;
using AtgDev.Voicemeeter.Types;

namespace AtgDev.Voicemeeter
{
    /// <summary>
    ///     <para>Extended Voicemeeter Remote API</para>
    ///     Have methods that use custom types
    /// </summary>>
    class RemoteApiExtender : RemoteApiWrapper
    {
        public RemoteApiExtender(string dllPath) : base(dllPath) { }

        /// <summary>
        ///     Waiting for voicemeeter's parameters to update, exits if waiting too long<br/>
        ///     Crucial to call this method after the Login()<br/>
        ///     Calls internaly IsParametersDirty() in a loop
        /// </summary>
        /// <param name="maxTime">Max time in ms before function exit</param>
        /// <param name="tickTime">Time in ms between requests</param>
        /// <returns>
        ///     Same as IsParametersDirty()
        /// </returns>
        public Int32 WaitForNewParams(int timeout = 10000, int tickTime = 1000 / 60)
        {
            Int32 resp = IsParametersDirty();
            for (int time = 0; time < timeout; time += tickTime)
            {
                if (resp != 0)
                {
                    break;
                }
                System.Threading.Thread.Sleep(tickTime);
                resp = IsParametersDirty();
            }
            return resp;
        }

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
        /// <returns>
        ///     0: OK (no error).<br/>
        ///     -1: cannot get client (unexpected)<br/>
        ///     -2: no server.<br/>
        /// </returns>
        public Int32 GetVoicemeeterVersion(out VoicemeeterVersion version)
        {
            var resp = GetVoicemeeterVersion(out int ver);
            version.v1 = (int)((ver & 0xFF000000) >> 24);
            version.v2 = (ver & 0x00FF0000) >> 16;
            version.v3 = (ver & 0x0000FF00) >> 8;
            version.v4 = ver & 0x000000FF;
            return resp;
        }

        /// <summary>
        ///     Get Voicemeeter Version
        /// </summary>
        /// <param name="version">
        ///     Variable receiving the version
        /// </param>
        /// <returns>
        ///     0: OK (no error).<br/>
        ///     -1: cannot get client (unexpected)<br/>
        ///     -2: no server.<br/>
        /// </returns>
        public Int32 GetVoicemeeterVersion(out string version)
        {
            var resp = GetVoicemeeterVersion(out VoicemeeterVersion ver);
            version = ver.ToString();
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
        ///     Get name and hardware ID of the device according index
        /// </summary>
        /// <param name="index">zero based index</param>
        /// <param name="devInfo">Variable receiving the device information</param>
        /// <param name="route">What type of device (input or output)</param>
        /// <returns>
        ///     0: OK (no error).<br/>
        /// </returns>
        public Int32 GetDeviceDescriptor(Int32 index, out BasicDeviceInfo devInfo, DeviceRoute route)
        {
            Int32 resp;
            if (route == DeviceRoute.Input)
            {
                resp = GetInputDeviceDescriptor(index, out devInfo);
            } else
            {
                resp = GetOutputDeviceDescriptor(index, out devInfo);
            }
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
        public Int32 MacroButtonSetStatus(Int32 buttonIndex, bool isOn, MacrobuttonMode mode)
        {
            Single val = Convert.ToSingle(isOn);
            return MacroButtonSetStatus(buttonIndex, val, mode);
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
        public Int32 MacroButtonGetStatus(Int32 buttonIndex, out bool isOn, MacrobuttonMode mode)
        {
            var resp = MacroButtonGetStatus(buttonIndex, out Single val, mode);
            isOn = Convert.ToBoolean(val);
            return resp;
        }
    }
}