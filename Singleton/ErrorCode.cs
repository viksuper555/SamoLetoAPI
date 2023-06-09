﻿namespace SamoLetoAPI.Singleton
{

    public enum ErrorCode
    {
        OK = 0,
        DefaultError = -1,
        NoTicketsAvailable = -1000
    }

    public static class ErrorCodes
    {
        public static Dictionary<int, string> Messages { get; set; } = new Dictionary<int, string>()
        {
            [(int)ErrorCode.OK] = "OK",
            [(int)ErrorCode.DefaultError] = "ERROR: INTERNAL EXCEPTION",
            [(int)ErrorCode.NoTicketsAvailable] = "ERROR: NO TICKETS AVAILABLE",

        };
    }

}
