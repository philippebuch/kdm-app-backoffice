using Kyrldama.Backoffice.Infrastructure;
using Kyrldama.Odata;
using System.Text;

namespace Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator
{
    public partial class OrchestratorClient
    {
        private readonly HttpClient httpClient;

        public OrchestratorClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<(T, IResult)> GetAsync<T>(string query)
        {
            var (response, result)  = await this.httpClient.GetAsync<OdataResponse<T>>(query);

            if (result.HasError())
                return (default(T), result);

            return (response.Value, result);
        }

        public async Task<(TResult, IResult)> PostAsync<TResult>(string query, OdataObject requestData)
        {
            var data = requestData.ToString();
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");

            return await this.httpClient.PostAsync<TResult>(query, stringContent);
        }

        public async Task<(TResult, IResult)> PatchAsync<TResult, TRequest>(string query, TRequest requestData)
        {
            return await this.httpClient.PatchAsync<TResult, TRequest>(query, requestData);
        }
    }
}