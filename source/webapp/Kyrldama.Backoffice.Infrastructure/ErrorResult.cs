using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kyrldama.Backoffice.Infrastructure
{
    public sealed class ErrorResult : ResultBase, IErrorResult
    {
        [JsonProperty]
        public List<Error> Errors { get; set; }

        public ErrorResult() : base(ResultType.Error)
        {
            Errors = new List<Error>();
        }

        public ErrorResult(string message) : this()
        {
            Errors.Add(new Error(message));
        }

        public ErrorResult(Error error) : this()
        {
            Errors.Add(error);
        }

        public ErrorResult(IEnumerable<Error> errors) : this()
        {
            Errors.AddRange(errors);
        }
    }
}
