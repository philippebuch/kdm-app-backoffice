using Microsoft.AspNet.OData;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kyrldama.Backoffice.Infrastructure
{
    public class ODataControllerBase : ControllerBase
    {
        private static readonly IErrorResult DefaultError = new ErrorResult(new Error(ErrorCode.Default, "No result"));

        protected IActionResult Result<T>(T value, IResult result)
        {
            return Result(value, result, (x) => Ok(x));
        }

        protected IActionResult Result<T>(T value, IResult result, Func<T, IActionResult> successAction)
        {
            return result switch
            {
                SuccessResult _ => successAction(value),
                ErrorResult error => StatusCode((int)GetHttpStatusCode(error), error),
                null => StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, DefaultError),
                _ => StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, DefaultError)
            };
        }

        protected IActionResult Result<T>((IResult result, T value) tuple)
        {
            return tuple.result switch
            {
                SuccessResult => Ok(tuple.value),
                ErrorResult error => StatusCode((int)GetHttpStatusCode(error), error),
                null => StatusCode((int)GetHttpStatusCode(DefaultError), DefaultError),
                _ => StatusCode((int)GetHttpStatusCode(DefaultError), DefaultError),
            };
        }

        private static int GetHttpStatusCode(IErrorResult errorResult)
        {
            var error = errorResult.Errors.FirstOrDefault();

            if (error == null)
                return Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest;

            return error.Code switch
            {
                //ErrorCodeValues.ResourceNotFoundError => HttpStatusCode.NotFound,
                //ErrorCodeValues.AuthorizationError => HttpStatusCode.Unauthorized,
                //ErrorCodeValues.SystemExceptionError => HttpStatusCode.InternalServerError,
                //ErrorCodeValues.HttpError => HttpStatusCode.InternalServerError,
                //ErrorCodeValues.HttpExceptionError => HttpStatusCode.InternalServerError,
                //ErrorCodeValues.RepositoryError => HttpStatusCode.BadRequest,
                //ErrorCodeValues.ValidationError => HttpStatusCode.BadRequest,
                _ => Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest
            };
        }

        protected IActionResult Result(IResult result)
        {
            return Result<object>(null, result, (_) => Ok());
        }
    }
}
