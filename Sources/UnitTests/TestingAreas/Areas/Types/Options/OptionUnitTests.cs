using Mmu.Mlh.LanguageExtensions.Areas.Types.Options;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Options.Implementation;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Types.Options
{
    [TestFixture]
    public class OptionUnitTests
    {
        [Test]
        public void CompaingApplicable_WithContentBeingEqualAndReferenceType_CompatesToTrue()
        {
            // Arrange
            var someObj = new object();
            var applicable = Option.CreateApplicable(someObj);

            // Act
            var areEqual = someObj == applicable;

            // Assert
            Assert.IsTrue(areEqual);
        }

        [Test]
        public void CompaingApplicable_WithContentBeingEqualAndValueType_CompatesToTrue()
        {
            // Arrange
            const int SomeInt = 123;
            var applicable = Option.CreateApplicable(SomeInt);

            // Act
            var areEqual = applicable == SomeInt;

            // Assert
            Assert.IsTrue(areEqual);
        }

        [Test]
        public void CompaingNotApplicable_WithTreatAsFalse_ComparesToFalse()
        {
            // Arrange
            var notApplicable = Option.CreateNotApplicable<int>(false);

            // Act
            var areEqual = notApplicable == 123;

            // Assert
            Assert.IsFalse(areEqual);
        }

        [Test]
        public void CompaingNotApplicable_WithTreatAsTrue_ComparesToTrue()
        {
            // Arrange
            var notApplicable = Option.CreateNotApplicable<int>(true);

            // Act
            var areEqual = notApplicable == 123;

            // Assert
            Assert.IsTrue(areEqual);
        }

        [Test]
        public void CreatingApplicable_CreatesApplicable()
        {
            // Act
            var actualApplicable = Option.CreateApplicable<object>(null);

            // Assert
            Assert.IsInstanceOf<ApplicableOption<object>>(actualApplicable);
        }

        [Test]
        public void CreatingNotApplicable_CreatesNotApplicable()
        {
            // Act
            var actualNotApplicable = Option.CreateNotApplicable<object>(true);

            // Assert
            Assert.IsInstanceOf<NotApplicableOption<object>>(actualNotApplicable);
        }
    }
}