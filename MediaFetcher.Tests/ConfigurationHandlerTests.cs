using MediaFetcher.Configuration;
using Xunit;

namespace MediaFetcher.Tests
{
    public class ConfigurationHandlerTests
    {
        [Fact]
        public void CanReadConfigurationValues()
        {
            // Arrange - Setup an instance of ConfigurationHandler
            ConfigurationHandler target = new ConfigurationHandler("config.json");

            // Act - Rquest the data
            string result1 = target.GetConfigValue("key1");
            string result2 = target.GetConfigValue("key2");
            string resultEmpty = target.GetConfigValue("key3");

            // Assert
            Assert.Equal("value1", result1);
            Assert.Equal("value2", result2);
            Assert.Equal("", resultEmpty);
        }

        [Fact]
        public void CanStaticallyReadConfigurationValues()
        {
            // Act - Rquest the data
            string result1 = ConfigurationHandler.GetConfigValue("key1", "config.json");
            string result2 = ConfigurationHandler.GetConfigValue("key2", "config.json");
            string resultEmpty = ConfigurationHandler.GetConfigValue("key3", "config.json");

            // Assert
            Assert.Equal("value1", result1);
            Assert.Equal("value2", result2);
            Assert.Equal("", resultEmpty);
        }
    }
}
