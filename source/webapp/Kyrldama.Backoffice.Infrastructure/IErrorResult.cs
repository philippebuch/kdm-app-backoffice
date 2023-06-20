using System.Collections.Generic;

namespace Kyrldama.Backoffice.Infrastructure
{
    public interface IErrorResult : IResult
    {
        List<Error> Errors { get; }
    }
}