using Xunit;
using Lab5_App.Classes;

namespace Lab5_Tests
{
    public class ElectricalApplianceTests
    {
        [Fact]
        public void Fridge_Constructor_SetsCorrectProperties()
        {
            var fridge = new Fridge("Samsung", 300, 0.5, 4);

            Assert.Equal("Samsung", fridge.Name);
            Assert.Equal(300, fridge.Power);
            Assert.Equal(4, fridge.Temperature);
            Assert.False(fridge.IsPluggedIn);
        }

        [Fact]
        public void Power_SetNegativePoverValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Fridge("Test", -10, 0.1, 5));
        }

        [Theory]
        [InlineData(-11)]
        [InlineData(11)]
        public void Fridge_Temperature_OutOfBounds_ThrowsException(int temp)
        {
            Assert.Throws<ArgumentException>(() => new Fridge("LG", 200, 0.1, temp));
        }

        [Fact]
        public void PlugIn_ChangesStateToTrue()
        {
            var oven = new Oven("Bosch", 2000, 1.2);
            oven.PlugIn();
            Assert.True(oven.IsPluggedIn);
        }


        [Fact]
        public void CalculateTotalPower_OnlyIncludesPluggedInAppliances()
        {
            var apartment = new Apartment();
            var fridge = new Fridge("Fridge", 200, 0.1, 5);
            var oven = new Oven("Oven", 1500, 0.5);

            oven.PlugIn();
            apartment.AddAppliance(fridge);
            apartment.AddAppliance(oven);

            double totalPower = apartment.CalculateTotalPower();

            Assert.Equal(1500, totalPower);
        }

        [Fact]
        public void SortByPower_ReturnsAppliancesInAscendingOrder()
        {
            var apartment = new Apartment();
            apartment.AddAppliance(new Oven("Високий", 3000, 1.0));
            apartment.AddAppliance(new Computer("Невисокий", 100, 0.01, "i5", 8));
            apartment.AddAppliance(new Fridge("Середній", 500, 0.2, 4));

            var sorted = apartment.SortByPower();

            Assert.Equal(100, sorted[0].Power);
            Assert.Equal(500, sorted[1].Power);
            Assert.Equal(3000, sorted[2].Power);
        }

        [Fact]
        public void FindByRadiationRange_ReturnsCorrectItems()
        {
            var apartment = new Apartment();
            var target = new Fridge("Target", 200, 0.5, 5);
            apartment.AddAppliance(new Computer("Low", 50, 0.1, "M1", 16));
            apartment.AddAppliance(target);
            apartment.AddAppliance(new Oven("High", 2000, 2.0));

            var results = apartment.FindByRadiationRange(0.4, 0.6);

            Assert.Single(results);
            Assert.Same(target, results[0]);
        }

        [Fact]
        public void FindByRadiationRange_MinGreaterThanMax_ThrowsException()
        {
            var apartment = new Apartment();
            Assert.Throws<ArgumentException>(() => apartment.FindByRadiationRange(1.0, 0.5));
        }


        [Fact]
        public void Oven_Mode_DefaultWhenNull()
        {
            var oven = new Oven("ДухОвка", 1000, 0.5, null);
            Assert.Equal("За замовчуванням", oven.Mode);
        }

        [Fact]
        public void Computer_RamSize_NegativeValue_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Computer("Mac", 60, 0.01, "M2", -8));
        }

        [Fact]
        public void ToString_ContainsBasicInfo()
        {
            var fridge = new Fridge("Мороз", 100, 0.1, -5);
            string result = fridge.ToString();

            Assert.Contains("Мороз", result);
            Assert.Contains("100Вт", result);
            Assert.Contains("-5°C", result);
        }
    }
}
