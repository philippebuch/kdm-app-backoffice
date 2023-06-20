using Newtonsoft.Json;

namespace Kyrldama.Backoffice.Infrastructure
{
    public class ResultBase : IResult
    {
        [JsonProperty(Required = Required.Always)]
        public ResultType Type { get; }

        public ResultBase() { }

        [JsonConstructor]
        public ResultBase(ResultType type)
        {
            Type = type;
        }
    }
}
