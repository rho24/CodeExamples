using System.ComponentModel.DataAnnotations;

namespace CodeExamples.ViewModels
{
    public class ExampleDetailEM
    {
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Markdown { get; set; }
    }
}