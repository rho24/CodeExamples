using System.Web;
using CodeExamples.Model;

namespace CodeExamples.Infrastructure
{
    public interface IMarkupConverter
    {
        IHtmlString ToHtml(IMarkup markup);
    }
}