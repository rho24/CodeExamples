using System.Web;
using CodeExamples.Model;

namespace CodeExamples.Infrastructure
{
    public class RawHtmlConverter : IMarkupConverter
    {
        public IHtmlString ToHtml(IMarkup markup) {
            var rawHtmlMarkup = (RawMarkUp) markup;
            return new HtmlString(rawHtmlMarkup.Markup);
        }
    }
}