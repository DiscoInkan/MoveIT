using Xunit;

namespace MoveIT.PriceCalculator.Tests
{
    public class CalculatePriceFunctionTests
    {
        [Theory]
        [InlineData(10, 1100)]
        [InlineData(49, 1490)]
        [InlineData(50, 5400)]
        [InlineData(51, 5408)]
        [InlineData(99, 5792)]
        [InlineData(100, 10700)]
        public void CalculateDistancePrice_ReturnsCorrectPrice(int distance, int expected)
        {
            var result = CalculatePriceFunction.CalculateDistancePrice(distance);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 49, 0, 1100)]
        [InlineData(10, 10, 25, 2200)]
        [InlineData(10, 50, 0, 2200)]
        [InlineData(10, 100, 0, 3300)]
        [InlineData(10, 150, 0, 4400)]
        [InlineData(51, 170, 25, 27040)]
        public void CalculateVolumePrice_ReturnsCorrectPrice(int distance, int livingSpace, int storageSpace, int expected)
        {
            var result = CalculatePriceFunction.CalculateVolumePrice(distance, livingSpace, storageSpace);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 49, 0, true, 6100)]
        [InlineData(10, 10, 25, false, 2200)]
        [InlineData(10, 50, 0, true, 7200)]
        [InlineData(51, 170, 25, true, 32040)]
        public void CalculateTotalPrice_ReturnsCorrectPrice(int distance, int livingSpace, int storageSpace, bool hasHeavyItem, int expected)
        {
            var result = CalculatePriceFunction.CalculateTotalPrice(distance, livingSpace, storageSpace, hasHeavyItem);
            Assert.Equal(expected, result);
        }
    }
}