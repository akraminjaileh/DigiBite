namespace DigiBite_Core.Helpers
{

    public class ApiResponse
    {
        public bool IsSuccess => ErrorMsg is null;
        public object? Data { get; set; }
        public string? ErrorMsg { get; set; }

        protected ApiResponse() { }

        protected ApiResponse(object data) : this() => Data = data;

        protected ApiResponse(string message) : this() => ErrorMsg = message;

    }

    public class ApiResponse<T> : ApiResponse
    {
        public ApiResponse() { }
        public ApiResponse(string message) : base(message){}
        public ApiResponse(T data) : base(data) { }
        public ApiResponse(IEnumerable<T> data) : base(data) { }

    }

    public class ApiResponseSwagger<T>
    {
        //for swagger mapping
        public bool IsSuccess { get; }
        public T? Data { get; }
        public string? ErrorMsg { get; }
    }
}

