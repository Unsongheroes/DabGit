using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace HandIn2_2_DDB
{
    public static class Repository<T> where T : class 
    {
        private const string EndpointUrl = "https://localhost:8081";

        private const string PrimaryKey =
            "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        private static DocumentClient client;

        
        public static async Task CreateDatabase()
        {
            client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);

            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = "PersonKatotekDB" });

            await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("PersonKatotekDB"), new DocumentCollection { Id = "PersonKatotek" });
        }

        public static async Task CreatePersonDocument(Person person)
        {
            await client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri("PersonKatotekDB", "PersonKatotek"),
                person);
        }

        public static async Task DeletePersonDocument()
        {

        }
        
    }
}
