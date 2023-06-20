using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Kyrldama.Backoffice.Infrastructure
{
    public static class HttpClientExtension
    {

        private static async Task<(HttpResponseMessage, IResult)> PutBaseAsync(this HttpClient client,
            string requestUri, HttpContent requestContent)
        {
            return await Function.FireSafeAsync(async () =>
            {
                var result = await client.PutAsync(requestUri, requestContent);

                if (result.IsSuccessStatusCode)
                    return (result, Result.Success);

                var content = await result.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                    return (null, Result.Error(ErrorCode.HttpError, "BadRequest"));

                try
                {
                    var res = JsonConvert.DeserializeObject<ErrorResult>(content, GetJsonSerializeSettings());
                    return (null, res);
                }
                catch (Exception ex)
                {
                    return (null, Result.Error(ErrorCode.HttpException, content));
                }
            });
        }

        private static async Task<(HttpResponseMessage, IResult)> PostBaseAsync(this HttpClient client, string requestUri, HttpContent requestContent)
        {
            return await Function.FireSafeAsync(async () =>
            {
                var result = await client.PostAsync(requestUri, requestContent);

                if (result.IsSuccessStatusCode)
                    return (result, Result.Success);

                var content = await result.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                    return (null, Result.Error(ErrorCode.HttpError, "BadRequest"));

                try
                {
                    var res = JsonConvert.DeserializeObject<ErrorResult>(content, GetJsonSerializeSettings());
                    return (null, res);
                }
                catch (Exception ex)
                {
                    return (null, Result.Error(ErrorCode.HttpException, content));
                }
            });
        }

        private static async Task<(HttpResponseMessage, IResult)> PatchBaseAsync(this HttpClient client, string requestUri, HttpContent requestContent)
        {
            return await Function.FireSafeAsync(async () =>
            {
                var result = await client.PatchAsync(requestUri, requestContent);

                if (result.IsSuccessStatusCode)
                    return (result, Result.Success);

                var content = await result.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                    return (null, Result.Error(ErrorCode.HttpError, "BadRequest"));

                try
                {
                    var res = JsonConvert.DeserializeObject<ErrorResult>(content, GetJsonSerializeSettings());
                    return (null, res);
                }
                catch (Exception ex)
                {
                    return (null, Result.Error(ErrorCode.HttpException, content));
                }
            });
        }

        public static async Task<IResult> PostAsync(this HttpClient client, string requestUri, HttpContent requestContent)
        {
            var (responseMessage, result) = await PostBaseAsync(client, requestUri, requestContent);

            return result;
        }

        public static async Task<IResult> PatchAsync(this HttpClient client, string requestUri, HttpContent requestContent)
        {
            var (responseMessage, result) = await PatchBaseAsync(client, requestUri, requestContent);

            return result;
        }

        public static async Task<IResult> PutAsync(this HttpClient client, string requestUri,
            HttpContent requestContent)
        {
            var (responseMessage, result) = await PutBaseAsync(client, requestUri, requestContent);

            return result;
        }

        public static async Task<IResult> PostAsync<TRequest>(this HttpClient client, string requestUri, TRequest requestData)
        {
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(requestData, GetJsonSerializeSettings()), Encoding.UTF8, "application/json");

                var (responseMessage, result) = await PostBaseAsync(client, requestUri, stringContent);

                return result;
            }
            catch (Exception stringContentException)
            {
                return Result.Error(stringContentException);
            }
        }

        public static async Task<IResult> PatchAsync<TRequest>(this HttpClient client, string requestUri, TRequest requestData)
        {
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(requestData, GetJsonSerializeSettings()), Encoding.UTF8, "application/json");

                var (responseMessage, result) = await PatchBaseAsync(client, requestUri, stringContent);

                return result;
            }
            catch (Exception stringContentException)
            {
                return Result.Error(stringContentException);
            }
        }

        public static async Task<IResult> PutAsync<TRequest>(this HttpClient client, string requestUri,
            TRequest requestData)
        {
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(requestData, GetJsonSerializeSettings()), Encoding.UTF8, "application/json");

                var (responseMessage, result) = await PutBaseAsync(client, requestUri, stringContent);

                return result;
            }
            catch (Exception stringContentException)
            {
                return Result.Error(stringContentException);
            }
        }

        public static async Task<(TResult, IResult)> PostAsync<TResult>(this HttpClient client, string requestUri, HttpContent requestContent)
        {
            var (responseMessage, result) = await PostBaseAsync(client, requestUri, requestContent);

            if (result.HasError())
                return (default(TResult), result);

            var successContent = await responseMessage.Content.ReadAsStringAsync();

            var dataResult = JsonConvert.DeserializeObject<TResult>(successContent, GetJsonSerializeSettings());
            return (dataResult, Result.Success);
        }

        public static async Task<(TResult, IResult)> PatchAsync<TResult>(this HttpClient client, string requestUri, HttpContent requestContent)
        {
            var (responseMessage, result) = await PatchBaseAsync(client, requestUri, requestContent);

            if (result.HasError())
                return (default(TResult), result);

            var successContent = await responseMessage.Content.ReadAsStringAsync();

            var dataResult = JsonConvert.DeserializeObject<TResult>(successContent, GetJsonSerializeSettings());
            return (dataResult, Result.Success);
        }

        public static async Task<(TResult, IResult)> PutAsync<TResult>(this HttpClient client,
            string requestUri, HttpContent requestContent)
        {
            var (responseMessage, result) = await PutBaseAsync(client, requestUri, requestContent);

            if (result.HasError())
                return (default(TResult), result);

            var successContent = await responseMessage.Content.ReadAsStringAsync();

            var dataResult = JsonConvert.DeserializeObject<TResult>(successContent, GetJsonSerializeSettings());
            return (dataResult, Result.Success);
        }

        public static async Task<(TResult, IResult)> PostAsync<TResult, TRequest>(this HttpClient client, string requestUri, TRequest requestData)
        {
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(requestData, GetJsonSerializeSettings()), Encoding.UTF8, "application/json");
                return await PostAsync<TResult>(client, requestUri, stringContent);
            }
            catch (Exception stringContentException)
            {
                return (default(TResult), Result.Error(stringContentException));
            }
        }

        public static async Task<(TResult, IResult)> PatchAsync<TResult, TRequest>(this HttpClient client, string requestUri, TRequest requestData)
        {
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(requestData, GetJsonSerializeSettings()), Encoding.UTF8, "application/json");
                return await PatchAsync<TResult>(client, requestUri, stringContent);
            }
            catch (Exception stringContentException)
            {
                return (default(TResult), Result.Error(stringContentException));
            }
        }

        public static async Task<(TResult, IResult)> PutAsync<TResult, TRequest>(this HttpClient client,
            string requestUri, TRequest requestData)
        {
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(requestData, GetJsonSerializeSettings()), Encoding.UTF8, "application/json");
                return await PutAsync<TResult>(client, requestUri, stringContent);
            }
            catch (Exception stringContentException)
            {
                return (default(TResult), Result.Error(stringContentException));
            }
        }

        public static async Task<(Stream, IResult)> PostAsync(this HttpClient client, string requestUri, Stream content)
        {
            var streamContent = new StreamContent(content);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var (responseMessage, result) = await PostBaseAsync(client, requestUri, streamContent);
            return (await responseMessage.Content.ReadAsStreamAsync(), result);
        }

        public static async Task<(Stream, IResult)> PatchAsync(this HttpClient client, string requestUri, Stream content)
        {
            var streamContent = new StreamContent(content);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var (responseMessage, result) = await PatchBaseAsync(client, requestUri, streamContent);
            return (await responseMessage.Content.ReadAsStreamAsync(), result);
        }

        public static async Task<(Stream, IResult)> PutAsync(this HttpClient client,
            string requestUri, Stream content)
        {
            var streamContent = new StreamContent(content);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var (responseMessage, result) = await PutBaseAsync(client, requestUri, streamContent);
            return (await responseMessage.Content.ReadAsStreamAsync(), result);
        }

        private static async Task<(HttpResponseMessage, IResult)> GetBaseAsync(this HttpClient client, string requestUri)
        {
            return await Function.FireSafeAsync(async () =>
            {
                var result = await client.GetAsync(requestUri);

                if (result.IsSuccessStatusCode)
                    return (result, Result.Success);

                if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    return (result, Result.Error(ErrorCode.HttpError, "BadRequest"));

                return (null, Result.Error(ErrorCode.HttpException, await result.Content.ReadAsStringAsync()));
            });
        }

        public static async Task<(TResult, IResult)> GetAsync<TResult>(this HttpClient client, string requestUri)
        {
            var (responseMessage, result) = await GetBaseAsync(client, requestUri);

            if (responseMessage == null)
            {
                return (default, result);
            }

            var content = await responseMessage.Content.ReadAsStringAsync();

            try
            {
                if (result.HasError())
                {
                    var res = JsonConvert.DeserializeObject<ErrorResult>(content, GetJsonSerializeSettings());
                    return (default, res);
                }

                var dataResult = JsonConvert.DeserializeObject<TResult>(content, GetJsonSerializeSettings());
                return (dataResult, Result.Success);
            }
            catch (Exception)
            {
                return (default, result.WithError(content));
            }
        }

        public static async Task<(Stream, IResult)> GetAsync(this HttpClient client, string requestUri)
        {
            var (responseMessage, result) = await GetBaseAsync(client, requestUri);
            return (await responseMessage.Content.ReadAsStreamAsync(), result);
        }

        private static JsonSerializerSettings GetJsonSerializeSettings()
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter());
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            return settings;
        }
    }
}
