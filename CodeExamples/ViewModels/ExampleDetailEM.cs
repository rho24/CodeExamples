using System.ComponentModel.DataAnnotations;

namespace CodeExamples.ViewModels
{
    public class ExampleDetailEM
    {
        [Required]
        public string Title { get; set; }

        [Required, DataType(DataType.MultilineText)]
        public string Markdown { get; set; }
    }
}