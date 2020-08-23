using System;
using System.Collections.Generic;
using Nest;

namespace Phase8 {
    public class IndexHandler<T> where T : class {
        private readonly ElasticClient client;

        public IndexHandler () {
            this.client = ElasticSearch.GetClient ();
        }

        public void CreateIndex (string index) {

            var createIndexResponse = client.Indices.Create (index, c => c
                .Map<T> (m => m
                    .AutoMap ()
                )
            );
        }
        public void AddDocToIndex (string index, List<T> list) {
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