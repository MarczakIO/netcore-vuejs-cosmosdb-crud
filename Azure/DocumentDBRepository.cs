using System;
using MarczakIO.VueSPA.Web.Models;
using Microsoft.Extensions.Options;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Azure.Documents.Linq;
using System.Linq.Expressions;
using System.Linq;

namespace MarczakIO.VueSPA.Web.Azure
{
    public class DocumentDBRepository<T> where T : class
    {
        private DatabaseSettings dbOptions;
        private DocumentClient client;

        public DocumentDBRepository(IOptions<DatabaseSettings> _dbOptions)
        {
            dbOptions = _dbOptions.Value;
            client = new DocumentClient(new Uri(dbOptions.Endpoint), dbOptions.AuthKey);
        }

        public async Task<IEnumerable<T>> GetItemsAsync(
            string CollectionId, Expression<Func<T, bool>> predicate)
        {
            IDocumentQuery<T> query = client.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(dbOptions.DatabaseId, CollectionId),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true})
                .Where(predicate)
                .AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }

        public async Task<T> CreateItemAsync(string CollectionId, T item)
        {
            Document document = await client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(dbOptions.DatabaseId, CollectionId), 
                item);

            return (T)(dynamic)document;
        }
    }
}