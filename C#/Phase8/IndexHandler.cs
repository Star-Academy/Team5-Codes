using System;
using Nest;

namespace Phase8 {
    public class IndexHandler {
        private readonly ElasticClient client;

        public IndexHandler () {
            this.client = ElasticSearch.GetClient ();
        }

        public void CreateIndex (string index) {
            var createIndexResponse = client.Indices.Create ("myindex", c => c
                .Map<Person> (m => m
                    .AutoMap ()
                )
            );
            Console.WriteLine(createIndexResponse);
        }

        private ITypeMapping CreateMapping (TypeMappingDescriptor<Person> mapping) {
            return mapping.Properties (p => p.AddAboutFieldMapping ());
        }

    }
}