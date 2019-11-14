using System;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Enums;
using Mmu.Mlh.LanguageExtensions.UnitTests.TestingInfrastructure.Areas.Enums;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Enums
{
    [TestFixture]
    public class EnumExtensionsUnitTests
    {
        [SetUp]
        public void Align()
        {
        }

        [Test]
        public void GettingAttribute_AttributeBeingSet_GetsAttribute()
        {
            // Act
            var actualAttribute = TestEnum.Value1.GetAttribute<MyDescriptionAttribute>();

            // Assert
            Assert.IsInstanceOf<MyDescriptionAttribute>(actualAttribute);
            Assert.AreEqual("TestValue1", actualAttribute.TestString);
        }

        [Test]
        public void GettingAttribute_AttributeNotBeingSet_ThrowsException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => TestEnum.Value1.GetAttribute<MyDescription2Attribute>());
        }

        [Test]
        public void GettingValues_TypeBeingEnum_ReturnsEnumValues()
        {
            // Act
            var actualEnumValues = EnumExtensions.GetValues<TestEnum>().ToList();

            // Assert
            Assert.AreEqual(3, actualEnumValues.Count);
            Assert.AreEqual(TestEnum.Value1, actualEnumValues[0]);
            Assert.AreEqual(TestEnum.Value2, actualEnumValues[1]);
            Assert.AreEqual(TestEnum.Value3, actualEnumValues[2]);
        }

        [Test]
        public void GettingValues_TypeNotBeingEnum_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnumExtensions.GetValues<long>());
        }

        [Test]
        public void TryingTopParseInt_IntBeingInEnum_ReturnsEnum()
        {
            // Act
            var actualParsingResult = EnumExtensions.TryParse<TestEnum>(1, out var actualParsedEnum);

            // Assert
            Assert.IsTrue(actualParsingResult);
            Assert.AreEqual(TestEnum.Value2, actualParsedEnum);
        }

        [Test]
        public void TryingTopParseInt_IntNotBeingInEnum_ReturnsFalse()
        {
            // Act
            var actualParsingResult = EnumExtensions.TryParse<TestEnum>(4, out _);

            // Assert
            Assert.IsFalse(actualParsingResult);
        }

        [Test]
        public void TryingTopParseInt_TypeNotBeingEnum_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => EnumExtensions.TryParse<long>(5, out _));
        }
    }
}