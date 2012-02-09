using System.Web;
using MarkdownDeep;

namespace CodeExamples.Model
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