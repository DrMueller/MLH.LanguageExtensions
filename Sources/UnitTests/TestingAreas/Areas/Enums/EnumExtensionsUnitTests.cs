using System;
using System.Linq;
using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.Enums;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes.Implementation;
using Mmu.Mlh.LanguageExtensions.UnitTests.TestingInfrastructure.Areas.Enums;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Enums
{
    public class EnumExtensionsUnitTests
    {
        [Fact]
        public void GettingAttribute_AttributeBeingSet_GetsAttribute()
        {
            // Act
            var actualAttribute = TestEnum.Value1.GetAttribute<MyDescriptionAttribute>();

            // Assert
            actualAttribute.Should().BeOfType<MyDescriptionAttribute>();
            actualAttribute.TestString.Should().Be("TestValue1");
        }

        [Fact]
        public void GettingAttribute_AttributeNotBeingSet_ThrowsException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => TestEnum.Value1.GetAttribute<MyDescription2Attribute>());
        }

        [Fact]
        public void GettingValues_TypeBeingEnum_ReturnsEnumValues()
        {
            // Act
            var actualEnumValues = EnumExtensions.GetValues<TestEnum>().ToList();

            // Assert
            actualEnumValues.Count.Should().Be(3);
            TestEnum.Value1.Should().Be(actualEnumValues[0]);
            TestEnum.Value2.Should().Be(actualEnumValues[1]);
            TestEnum.Value3.Should().Be(actualEnumValues[2]);
        }

        [Fact]
        public void GettingValues_TypeNotBeingEnum_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnumExtensions.GetValues<long>());
        }

        [Fact]
        public void TryingTopParseInt_IntBeingInEnum_ReturnsSome()
        {
            // Act
            var parsingResult = EnumExtensions.TryParse<TestEnum>(1);

            var actualEnum = parsingResult.Reduce(() => throw new Exception("Tra"));

            // Assert
            actualEnum.Should().Be(TestEnum.Value2);
        }

        [Fact]
        public void TryingTopParseInt_IntNotBeingInEnum_ReturnsNone()
        {
            // Act
            var parsingResult = EnumExtensions.TryParse<TestEnum>(4);

            // Assert
            parsingResult.Should().BeOfType<None<TestEnum>>();
        }

        [Fact]
        public void TryingTopParseInt_TypeNotBeingEnum_ThrowsArgumentException()
        {
            // Arrange
            var act = () => EnumExtensions.TryParse<long>(5);

            // Act & Assert
            act.Should().ThrowExactly<ArgumentException>();
        }
    }
}