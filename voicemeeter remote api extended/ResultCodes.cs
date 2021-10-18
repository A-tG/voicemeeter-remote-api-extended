namespace AtgDev.Voicemeeter
{
    public static class ResultCodes
    {
        public const int Ok = 0;
        public const int Error = -1;
        public const int NoServer = -2;

        /// <summary>
        /// For Login()
        /// </summary>
        public const int OkVmNotLaunched = 1;
        /// <summary>
        /// For RunVoicemeeter()
        /// </summary>
        public const int NotInstalled = Error;
        /// <summary>
        /// For RunVoicemeeter()
        /// </summary>
        public const int UnknownVmType = -2;

        /// <summary>
        /// For GetVoicemeeterType() and GetVoicemeeterVersion()
        /// </summary>
        public const int CantGetClient = Error;

        /// <summary>
        /// For IsParametersDirty()
        /// </summary>
        public const int NewParameters = 1;

        /// <summary>
        /// For GetParameter(), SetParameter(), MacroButtonGetStatus(), MacroButtonSetStatus()
        /// </summary>
        public const int UnknownParameter = -3;
        /// <summary>
        /// For SetParameter(), MacroButtonGetStatus(), MacroButtonSetStatus()
        /// </summary>
        public const int StructureMismatch = -5;

        /// <summary>
        /// For GetLevel()
        /// </summary>
        public const int NoLevelAvailable = -3;
        /// <summary>
        /// For GetMidiMessage()
        /// </summary>
        public const int NoMidiData1 = -5;
        /// <summary>
        /// For GetMidiMessage()
        /// </summary>
        public const int NoMidiData2 = -6;

        /// <summary>
        /// For SetParameters()
        /// </summary>
        public const int UnexpectedError1 = -3;
        /// <summary>
        /// For SetParameters()
        /// </summary>
        public const int UnexpectedError2 = -4;

        /// <summary>
        /// For AudioCallbackRegister()
        /// </summary>
        public const int CallbackAlreadyRegistered = 1;
        /// <summary>
        /// For AudioCallbackStart() and AudioCallbackStop()
        /// </summary>
        public const int NoCallback = -2;
        /// <summary>
        /// For AudioCallbackUnregister()
        /// </summary>
        public const int CallbackAlreadyUnregistered = 1;
    }
}
