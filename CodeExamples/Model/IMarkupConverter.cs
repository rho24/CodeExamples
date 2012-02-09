using System.Web;

namespace CodeExamples.Model
{
    public interface IMarkupConverter
    {
        IHtmlString ToHtml(IMarkup markup);
    }
}