using Nest;

namespace Phase8
{
    public class IndexHandle
    {
        private readonly ElasticClient client;
    

        public IndexHandle()
        {
            this.client = ElasticSearch.GetClient();
        }

        public void CreateIndex(string index)
        {
            var response = client.Indices.Create(index, i => i
                .Map<Person>(CreateMapping));
        }

        private 
        

        
        
    }
}