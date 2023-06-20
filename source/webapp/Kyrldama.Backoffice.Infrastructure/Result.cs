using System;
using System.Collections.Generic;
using System.Linq;
#if NET5_0
using System.ComponentModel.DataAnnotations;
#endif
namespace Kyrldama.Backoffice.Infrastructure
{
    public static class Result
    {
        public static IResult Success => new SuccessResult();

        public static IResult Error() => new ErrorResult();

        public static IResult Error(string message) => new ErrorResult(message);

        public static IResult Error(ErrorCode code, string message) => Error(new Error(code, message));

        public static IResult Error(Error error) => new ErrorResult(error);
    
        public static IResult Error(Exception exception) => new ErrorResult(ExceptionToErrors(exception));
        
        public static IResult Error(IEnumerable<Error> errors) => ToErrorResult(errors);

        private static IResult ToErrorResult(IEnumerable<Error> errors)
        {
            var result = new ErrorResult();
            foreach (var error in errors)
            {
                result.WithError(error);
            }

            return result;
        }

        public static IResult WithError(this IResult result, IResult resultToConcat, ErrorCode errorCode, string message = null)
        {
            if (message != null)
                result.WithError(errorCode, message);

            if (resultToConcat is IErrorResult errorResultToConcat)
            {
                if (result is IErrorResult errorResult)
                    foreach (var error in errorResultToConcat.Errors)
                        errorResult.Errors.Add(error);
                else
                    return resultToConcat;
            }

            return result;
        }

        public static bool HasError(this IResult result) => result.Type == ResultType.Error;

        public static IResult WithError(this IResult result, string message)
        {
            if (result is IErrorResult errorResult)
            {
                errorResult.Errors.Add(new Error(message));
                return result;
            }

            return new ErrorResult(message);
        }

        public static IResult WithError(this IResult result, ErrorCode errorCode, string message)
        {
            return result.WithError(new Error(errorCode, message));
        }

        public static IResult WithError(this IResult result, Error error)
        {
            if (result is IErrorResult errorResult)
            {
                errorResult.Errors.Add(error);
                return result;
            }

            return new ErrorResult(error);
        }
        
        public static IResult WithError(this IResult result, ErrorResult errorResult)
        {
            if (!(result is IErrorResult e)) return errorResult;
            
            foreach (var error in errorResult.Errors)
            {
                e.Errors.Add(error);
            }

            return result;
        }

        public static IResult WithError(this IResult result, Exception exception)
        {
            if (result is IErrorResult errorResult)
            {
                errorResult.Errors.AddRange(ExceptionToErrors(exception));
                return result;
            }

            return new ErrorResult(ExceptionToErrors(exception));
        }

        private static IEnumerable<Error> ExceptionToErrors(Exception exception)
        {
            var list = new List<Error>();

            while (true)
            {
                if (exception == null) break;

                list.Add(new Error(ErrorCode.SystemException, exception.Message));
                exception = exception.InnerException;
            }

            return list;
        }
        
#if NET5_0
        public static IResult Error(ValidationResult result) => new ErrorResult(new ValidationError(result));

        public static IResult Error(IEnumerable<ValidationResult> result) =>
            new ErrorResult(result.Select(validationResult => new ValidationError(validationResult)));
#endif
    }
}
