using System;
using AtgDev.Voicemeeter.Types;

namespace AtgDev.Voicemeeter.Extensions
{
    static partial class RemoteApiExtension
    {
        /// <param name="devInfo">Variable receiving the device information</param>
        /// <inheritdoc cref="RemoteApiWrapper.GetOutputDeviceDescriptor(int, out int, out string, out string)"/>
        public static Int32 GetOutputDeviceDescriptor(this RemoteApiWrapper api, Int32 index, out BasicDeviceInfo devInfo)
        {
            var resp = api.GetOutputDeviceDescriptor(index, out Int32 type, out string deviceName, out string hardwareID);
            devInfo = new BasicDeviceInfo(deviceName, hardwareID, (DeviceType)type);
            return resp;
        }

        /// <inheritdoc cref="RemoteApiWrapper.GetInputDeviceDescriptor(int, out int, out string, out string)"/>
        /// <inheritdoc cref="GetOutputDeviceDescriptor(RemoteApiWrapper, int, out BasicDeviceInfo)"/>
        public static Int32 GetInputDeviceDescriptor(this RemoteApiWrapper api, Int32 index, out BasicDeviceInfo devInfo)
        {
            var resp = api.GetInputDeviceDescriptor(index, out Int32 type, out string deviceName, out string hardwareID);
            devInfo = new BasicDeviceInfo(deviceName, hardwareID, (DeviceType)type);
            return resp;
        }

        /// <summary>
        ///     Get name and hardware ID of the device according index
        /// </summary>
        /// <param name="route">What type of device (input or output)</param>
        /// <inheritdoc cref="GetOutputDeviceDescriptor(RemoteApiWrapper, int, out BasicDeviceInfo)"/>
        public static Int32 GetDeviceDescriptor(this RemoteApiWrapper api, Int32 index, out BasicDeviceInfo devInfo, DeviceRoute route)
        {
            Int32 resp;
            if (route == DeviceRoute.Input)
            {
                resp = api.GetInputDeviceDescriptor(index, out devInfo);
            }
            else
            {
                resp = api.GetOutputDeviceDescriptor(index, out devInfo);
            }
            return resp;
        }
    }
}