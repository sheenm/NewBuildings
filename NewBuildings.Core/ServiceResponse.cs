namespace NewBuildings.Core
{
    public class ServiceResponse<T>
    {
        public ResponseStatuses Status { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }

        public static ServiceResponse<T> Ok(T data, string message = "")
        {
            return new ServiceResponse<T>
            {
                Data = data,
                Message = message,
                Status = ResponseStatuses.Ok
            };
        }

        public static ServiceResponse<T> Warning(string message, T data = default(T))
        {
            return new ServiceResponse<T>
            {
                Data = data,
                Message = message,
                Status = ResponseStatuses.Warning
            };
        }

        public static ServiceResponse<T> Exception(string message)
        {
            return new ServiceResponse<T>
            {
                Data = default(T),
                Message = message,
                Status = ResponseStatuses.Exception
            };
        }
    }
}
