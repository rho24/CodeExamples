using System.Web;
using CodeExamples.Model;
using MarkdownDeep;

namespace CodeExamples.Infrastructure
{
    public class MarkDownConverter : IMarkupConverter
    {
        private readonly Markdown _markdownService;

        public MarkDownConverter(Markdown markdownService) {
            _markdownService = markdownService;
        }

        public IHtmlString ToHtml(IMarkup markup) {
            var markdown = (MarkDownMarkUp) markup;

            return new HtmlString(_markdownService.Transform(markdown.Markdown));
        }
    }
}