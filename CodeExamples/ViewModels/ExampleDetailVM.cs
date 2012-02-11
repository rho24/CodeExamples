using System.Web;

namespace CodeExamples.ViewModels
{
    public class ExampleDetailVM
    {
        public string TitleUrl { get; set; }
        public string Title { get; set; }
        public IHtmlString Body { get; set; }
    }
}