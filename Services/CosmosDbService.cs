using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreboard.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using Container = Microsoft.Azure.Cosmos.Container;

namespace scoreboard.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }
        
        public async Task AddScoreAsync(Score score)
        {
            await this._container.CreateItemAsync<Score>(score, new PartitionKey(score.Id));
        }

        public async Task DeleteScoreAsync(string id)
        {
            await this._container.DeleteItemAsync<Score>(id, new PartitionKey(id));
        }

        public async Task<Score> GetScoreAsync(string id)
        {
            try
            {
                ItemResponse<Score> response = await this._container.ReadItemAsync<Score>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch(CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            { 
                return null;
            }

        }

        public async Task<IEnumerable<Score>> GetScoresAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Score>(new QueryDefinition(queryString));
            List<Score> results = new List<Score>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateScoreAsync(string id, Score Score)
        {
            await this._container.UpsertItemAsync<Score>(Score, new PartitionKey(id));
        }
        
    }
}