using System.Collections.Generic;

namespace CodeExamples.ViewModels
{
    public class HomeIndexVM
    {
        public IEnumerable<Example> Examples { get; set; }

        #region Nested type: Example

        public class Example
        {
            public string Id { get; set; }
            public string Title { get; set; }
        }

        #endregion
    }
}