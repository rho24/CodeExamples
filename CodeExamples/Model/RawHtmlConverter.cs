using System.Web;

namespace CodeExamples.Model
{
    public class RawHtmlConverter : IMarkupConverter
    {
        public IHtmlString ToHtml(IMarkup markup) {
            var rawHtmlMarkup = (RawMarkUp) markup;
            return new HtmlString(rawHtmlMarkup.Markup);
        }
    }
}