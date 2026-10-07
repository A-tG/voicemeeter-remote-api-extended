using AtgDev.Voicemeeter.Types;
using System;

namespace AtgDev.Voicemeeter.Extensions
{
    static partial class RemoteApiExtension
    {
        public static Int32 SetCustomButton(this RemoteApiWrapper api, Int32 buttonIndex, CustomButtonType type,
            CustomButtonState state, string label, IntPtr hwnd, Int32 command)
        {
            return api.SetCustomButton(buttonIndex, (Int32)type, (Int32)state, label, hwnd, command);
        }

        public static Int32 RemoveCustomButton(this RemoteApiWrapper api, Int32 buttonIndex)
        {
            return api.SetCustomButton(buttonIndex, (Int32)CustomButtonType.NotDisplayed, (Int32)CustomButtonState.NoChange, IntPtr.Zero, IntPtr.Zero, 0);
        }
    }
}