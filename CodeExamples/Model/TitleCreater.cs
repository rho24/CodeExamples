using System.Text.RegularExpressions;

namespace CodeExamples.Model
{
    public class TitleCreater
    {
        public string CreateFromTitle(string title) {
            return Regex.Replace(title, "[^a-zA-Z0-9]", "_");
        }
    }
}