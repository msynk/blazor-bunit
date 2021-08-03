using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class WordsAndNumberTests2 : BunitTestContext
    {
        [TestMethod,
            DataRow(new string[] { "one", "two", "three" }, 1),
            DataRow(new string[] { "saleh", "yasser", "khasi" }, 2),
            DataRow(new string[] { "blazor", "is", "awesome" }, 3),
        ]
        public void WordsAndNumberComponentShouldRenderCorrectly(string[] words, int number)
        {
            // Arrange
            // it is implemented in the base class

            // Act
            var cut = RenderComponent<WordsAndNumber>(parameters => parameters
                .Add(p => p.Number, number)
                .Add(p => p.Words, words)
            );

            // Assert
            cut.MarkupMatches($"<span>{number}</span>: {string.Join(", ", words)}");
        }
    }
}