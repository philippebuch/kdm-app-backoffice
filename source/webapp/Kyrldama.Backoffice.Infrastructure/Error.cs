using Newtonsoft.Json;

namespace Kyrldama.Backoffice.Infrastructure
{
    public class Error
    {
        public ErrorCode Code { get; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Message { get; }

        public Error(string message)
        {
            Message = message;
            Code = ErrorCode.Default;
        }

        public Error(ErrorCode code)
        {
            Code = code;
        }
        public Error(ErrorCode code, string message)
        {
            Message = message;
            Code = code;
        }
    }
}
