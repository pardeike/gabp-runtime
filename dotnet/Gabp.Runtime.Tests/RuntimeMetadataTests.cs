using Xunit;

namespace Gabp.Runtime.Tests
{
    public class RuntimeMetadataTests
    {
        [Fact]
        public void DeclaresExpectedRuntimeMetadata()
        {
            Assert.Equal("Gabp.Runtime", RuntimeMetadata.PackageId);
            Assert.Equal("1.0.0", RuntimeMetadata.Version);
            Assert.Equal(RuntimeMetadata.Version, RuntimeMetadata.DevelopmentVersion);
            Assert.Equal("1.0", RuntimeMetadata.TargetGabpSchemaVersion);
        }
    }
}
