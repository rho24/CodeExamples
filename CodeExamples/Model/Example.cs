using System;
using CodeExamples.Infrastructure;

namespace CodeExamples.Model
{
    public class Example
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleUrl { get; set; }
        public IMarkup Body { get; set; }
        public DateTime CreatedAt { get; set; }

        public Node Node { get; set; }
    }
}