using System.Collections.Generic;

namespace CodeExamples.Model
{
    public class Node
    {
        public ExampleReference Parent { get; set; }
        public ExampleReference Before { get; set; }
        public ExampleReference After { get; set; }
        public IEnumerable<ExampleReference> Children { get; set; }
    }
}