using System.Text.RegularExpressions;

namespace CodeExamples.Infrastructure
{
    public class TitleCreator
    {
        public string CreateFromTitle(string title) {
            return Regex.Replace(title, "[^a-zA-Z0-9]", "_");
        }
    }
}