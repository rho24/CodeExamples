using System.Collections.Generic;

namespace CodeExamples.Model
{
    public class NodeWithId
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string TitleUrl { get; set; }
        public string Parent { get; set; }
        public string Before { get; set; }
        public string After { get; set; }
        public IEnumerable<string> Children { get; set; }
    }
}