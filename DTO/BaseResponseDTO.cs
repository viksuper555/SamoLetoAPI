using SamoLetoAPI.Singleton;

namespace SamoLetoAPI.DTO
{
    public class BaseResponseDTO
    {
        public BaseResponseDTO() { }
        public BaseResponseDTO(ErrorCode error, string? errorString = null)
        {
            ErrorCode = (int)error;
            Success = ErrorCode == (int)Singleton.ErrorCode.OK;

            if (!ErrorCodes.Messages.TryGetValue(ErrorCode, out var message))
                message = "ERROR: UNPARSABLE ERROR";

            ErrorString = errorString ?? message;
        }
        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public string? ErrorString { get; set; }
        public object? ResponseBody { get; set; }
        public int? SuccessCode { get; set; } = 0;
    }
}
