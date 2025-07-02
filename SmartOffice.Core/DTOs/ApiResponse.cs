namespace SmartOffice.Core.DTOs
{
    /// <summary>
    /// Generic API response wrapper for sending consistent responses.
    /// Gives uniform API responses, making frontend parsing predictable.
    /// </summary>
    /// <typeparam name="T">Type of the data returned in the response.</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Indicates whether the API call was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Descriptive message for the API response.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Data payload returned from the API call.
        /// Data as nullable here because Failure responses often wont have data
        /// </summary>
        public T? Data { get; set; }

        public ApiResponse(bool success, string message, T? data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// Builds a successful API response.
        /// </summary>

        public static ApiResponse<T> SuccessResponse(T data, string message = "")
        {
            return new ApiResponse<T>(true, message, data);
        }

        /// <summary>
        /// Builds a failed API response with an error message.
        /// </summary>

        public static ApiResponse<T> FailureMessage(string message)
        {
            return new ApiResponse<T>(false, message, default);
        }
    }
}