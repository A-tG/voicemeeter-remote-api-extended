using System;
using AtgDev.Voicemeeter.Types;

namespace AtgDev.Voicemeeter
{
    partial class RemoteApiExtender
    {
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
            }
            else
            {
                resp = GetOutputDeviceDescriptor(index, out devInfo);
            }
            return resp;
        }
    }
}