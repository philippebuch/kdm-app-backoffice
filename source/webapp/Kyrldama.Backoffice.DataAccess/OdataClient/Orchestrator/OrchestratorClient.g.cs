using Kyrldama.Backoffice.Infrastructure;

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
            var (data, result) = await this.httpClient.GetAsync<OdataResponse<T>>(query);

            if (result.HasError())
                return (default(T), result);

            return (data.Value, result);
        }

        public async Task<(TResult, IResult)> PostAsync<TResult, TRequest>(string query, TRequest requestData)
        {
            return await this.httpClient.PostAsync<TResult, TRequest>(query, requestData);
        }

        public async Task<(TResult, IResult)> PatchAsync<TResult, TRequest>(string query, TRequest requestData)
        {
            return await this.httpClient.PatchAsync<TResult, TRequest>(query, requestData);
        }
    }
}