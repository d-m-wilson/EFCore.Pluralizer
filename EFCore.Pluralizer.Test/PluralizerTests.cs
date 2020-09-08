using Xunit;

namespace Bricelam.EntityFrameworkCore.Design
{
    public class PluralizerTests
    {
        [Theory]
        [InlineData("Tests", "Test")]
        [InlineData("Statuses", "Status")]
        [InlineData("ItemStatuses", "ItemStatus")]
        [InlineData("Statuses", "Statuses")]
        [InlineData("ItemStatuses", "ItemStatuses")]
        public void Pluralize_works(string result, string input)
                    => Assert.Equal(result, new Pluralizer().Pluralize(input));

        [Fact]
        public void Pluralize_excludesInvariantPlurals()
                    => Assert.Equal("Species", new Pluralizer().Singularize("Species"));

        [Fact]
        public void Pluralize_excludesCompoundInvariantPlurals()
            => Assert.Equal("AreaSpecies", new Pluralizer().Singularize("AreaSpecies"));

        [Theory]
        [InlineData("Test", "Tests")]
        [InlineData("Status", "Statuses")]
        [InlineData("ItemStatus", "ItemStatuses")]
        [InlineData("Status", "Status")]
        [InlineData("ItemStatus", "ItemStatus")]
        public void Singularize_works(string result, string input)
            => Assert.Equal(result, new Pluralizer().Singularize(input));

        [Fact]
        public void Singularize_excludesInvariantPlurals()
                    => Assert.Equal("Species", new Pluralizer().Singularize("Species"));

        [Fact]
        public void Singularize_excludesCompoundInvariantPlurals()
            => Assert.Equal("AreaSpecies", new Pluralizer().Singularize("AreaSpecies"));

    }
}
