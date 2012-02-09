namespace CodeExamples.Model
{
    public class RawMarkUp : IMarkup
    {
        public string Markup { get; private set; }

        public RawMarkUp(string markup) {
            Markup = markup;
        }
    }
}