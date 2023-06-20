using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrldama.Backoffice.Infrastructure
{
    public static class Function
    {
        public static async Task<(TData, IResult)> FireSafeAsync<TData>(this Func<Task<(TData, IResult)>> func)
        {
            try
            {
                var invoke = func?.Invoke();
                if (invoke == null) return (default, Result.Error("Func cannot be null"));

                var (data, result) = await invoke;
                return (data, result);

            }
            catch (Exception ex)
            {
                return (default, Result.Error(ex));
            }
        }

        public static async Task<(TData, IResult)> FireSafeAsync<TData>(this Func<Task<TData>> func)
        {
            try
            {
                var invoke = func?.Invoke();
                if (invoke == null) return (default, Result.Error("Func cannot be null"));

                var data = await invoke;
                return (data, Result.Success);
            }
            catch (Exception ex)
            {
                return (default, Result.Error(ex));
            }
        }

        public static async Task<IResult> FireSafeAsync(this Func<Task<IResult>> func)
        {
            try
            {
                var invoke = func?.Invoke();
                if (invoke == null) return Result.Error("Func cannot be null");

                return await invoke;
            }
            catch (Exception ex)
            {
                return Result.Error(ex);
            }
        }

        public static async Task<IResult> FireSafeAsync(this Func<Task> func)
        {
            try
            {
                var invoke = func?.Invoke();
                if (invoke == null) return Result.Error("Func cannot be null");

                await func();
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Result.Error(ex);
            }
        }

        public static async Task<IResult> FireSafeAsync(this Task task)
        {
            try
            {
                await task;
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Result.Error(ex);
            }
        }

        public static async Task<IResult> FireSafeAsync(this Task<IResult> task)
        {
            try
            {
                return await task;
            }
            catch (Exception ex)
            {
                return Result.Error(ex);
            }
        }

        public static async Task<(TData, IResult)> FireSafeAsync<TData>(this Task<(TData, IResult)> task)
        {
            try
            {
                return await task;
            }
            catch (Exception ex)
            {
                return (default, Result.Error(ex));
            }
        }

        public static async Task<(TData, IResult)> FireSafeAsync<TData>(this Task<TData> task)
        {
            try
            {
                var result = await task;
                return (result, Result.Success);
            }
            catch (Exception ex)
            {
                return (default, Result.Error(ex));
            }
        }
    }
}
