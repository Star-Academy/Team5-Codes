using System.Text.Json.Serialization;

namespace Phase8.Modules
{
    public class QuerySample
    {
        public string Text { set; get; }

        public QuerySample(string text)
        {
            Text = text;
        }
    }
}
