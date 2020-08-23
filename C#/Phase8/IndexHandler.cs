using System;
using System.Collections.Generic;
using Nest;

namespace Phase8
{
    public class IndexHandler<T> where T : class
    {
        private readonly ElasticClient client;

        public IndexHandler()
        {
            this.client = ElasticSearch.GetClient();
        }

        ///// Mapping is based on Person class /////
        public void CreateIndex(string index)
        {
            var createIndexResponse = client.Indices.Create(index, c => c
                .Settings(s => s
                    .Analysis(a => a
                        .Analyzers(analyzers => analyzers
                            .Standard("standard_english", sa => sa
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
                        .Analyzer("standard_english")
                     )
                     .Text(t => t
                        .Name(n => n.Name)
                        .Analyzer("standard_english")
                     )
                     .Text(t => t
                        .Name(n => n.Gender)
                        .Analyzer("standard_english")
                     )
                     .Text(t => t
                        .Name(n => n.Company)
                        .Analyzer("standard_english")
                     )
                     .Text(t => t
                        .Name(n => n.Phone)
                        .Analyzer("standard_english")
                     )
                     .Text(t => t
                        .Name(n => n.Address)
                        .Analyzer("standard_english")
                     )
                     .Text(t => t
                        .Name(n => n.About)
                        .Analyzer("standard_english")
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
            Console.WriteLine(createIndexResponse);
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
            Console.WriteLine(client.Bulk(bulkDescriptor));

        }
    }
}