using Xunit;

namespace Gabp.Runtime.Tests
{
    public class RuntimeMetadataTests
    {
        [Fact]
        public void DeclaresExpectedScaffoldMetadata()
        {
            Assert.Equal("Gabp.Runtime", RuntimeMetadata.PackageId);
            Assert.Equal("1.0", RuntimeMetadata.TargetGabpSchemaVersion);
        }
    }
}
