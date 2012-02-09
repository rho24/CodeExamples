using System.Web;

namespace CodeExamples.ViewModels
{
    public class ExampleDetailVM
    {
        public string Title { get; set; }
        public IHtmlString Body { get; set; }
    }
}