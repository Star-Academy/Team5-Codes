using System;
using System.Collections.Generic;
using Nest;

namespace Phase8 {
    public class IndexHandler {
        private readonly ElasticClient client;

        public IndexHandler () {
            this.client = ElasticSearch.GetClient ();
        }

        public void CreateIndex (string index) {
            var createIndexResponse = client.Indices.Create (index, c => c
                .Map<Person> (m => m
                    .AutoMap ()
                )
            );
        }

        public void AddDocToIndex<T> (string index, List<T> list) {
            var bulkDescriptor = new BulkDescriptor ();
            foreach (var person in list) {
                bulkDescriptor.Index<T> (x => x
                    .Index (index)
                    .Document (person)
                );
            }
            client.Bulk (bulkDescriptor);
        }
    }
}