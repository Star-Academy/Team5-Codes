using Nest;
using System.Collections.Generic;

namespace Phase8
{
    public class IndexHandler<T> where T : class
    {
        private readonly ElasticClient client;

        public IndexHandler(List<T> items, string indexName)
        {
            this.client = ElasticSearch.GetClient();
            this.CreateIndex(indexName);
            this.AddDocToIndex(indexName, items);
        }

        ///// Mapping is based on Person class /////
        public void CreateIndex(string index)
        {
            var createIndexResponse = client.Indices.Create(index, c => c
              .Settings(s => s
                .Analysis(a => a
                    .Analyzers(analyzers => analyzers
                    .Standard("english_Analyzer", sa => sa
                      .StopWords("_english_")
                    )
                    )
                )
              )
              .Map<Person>(map => map
                .Properties(pr => pr
                    .Number(num => num
                    .Name(n => n.Age)
                    )
                    .Text(t => t
                    .Name(n => n.EyeColor)
                    .Analyzer("english_Analyzer")
                    )
                    .Text(t => t
                    .Name(n => n.Name)
                    .Analyzer("english_Analyzer")
                    )
                    .Text(t => t
                    .Name(n => n.Gender)
                    .Analyzer("english_Analyzer")
                    )
                    .Text(t => t
                    .Name(n => n.Company)
                    .Analyzer("english_Analyzer")
                    )
                    .Text(t => t
                    .Name(n => n.Phone)
                    .Analyzer("english_Analyzer")
                    )
                    .Text(t => t
                    .Name(n => n.Address)
                    .Analyzer("english_Analyzer")
                    )
                    .Text(t => t
                    .Name(n => n.About)
                    .Analyzer("english_Analyzer")
                    )
                    .Date(d => d
                    .Name(n => n.RegistrationDate)
                    )
                    .GeoPoint(g => g
                    .Name(n => n.Location)
                    )
                )
              )
            );
            Output.Write(createIndexResponse.ToString());
        }
        public void AddDocToIndex(string index, List<T> list)
        {
            var bulkDescriptor = new BulkDescriptor();
            foreach (var person in list)
            {
                bulkDescriptor.Index<T>(x => x
                  .Index(index)
                  .Document(person)
                );
            }

            Output.Write(client.Bulk(bulkDescriptor).ToString());
            client.Indices.Refresh(index);
        }
    }
}