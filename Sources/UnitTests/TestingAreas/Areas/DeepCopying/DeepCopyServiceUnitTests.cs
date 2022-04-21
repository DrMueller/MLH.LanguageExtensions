using FluentAssertions;
using Mmu.Mlh.LanguageExtensions.Areas.DeepCopying;
using Mmu.Mlh.LanguageExtensions.UnitTests.TestingInfrastructure.Areas.DeepCopying;
using Xunit;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.DeepCopying
{
    public class DeepCopyServiceUnitTests
    {
        [Fact]
        public void CopyingReferenceType_CreatesNewReference()
        {
            // Arrange
            var model = new DeepCopyModel(null, null, 0);

            // Act
            var actualCopy = DeepCopyService.DeepCopy(model);

            // Assert
            actualCopy.Should().NotBeSameAs(model);
        }

        [Fact]
        public void CopyingSubReferenceTypes_KeepsValues()
        {
            // Arrange
            var subModel2 = new DeepCopyModel(null, "SubModel2", 12);
            var subModel1 = new DeepCopyModel(subModel2, "SubModel1", 1);
            var model = new DeepCopyModel(subModel1, null, 0);

            // Act
            var actualCopy = DeepCopyService.DeepCopy(model);

            // Assert
            actualCopy.Name.Should().Be(model.Name);
            actualCopy.SubModel!.Name.Should().Be(model.SubModel!.Name);
            actualCopy.SubModel.Age.Should().Be(model.SubModel.Age);
            actualCopy.SubModel!.SubModel!.Name.Should().Be(model.SubModel!.SubModel!.Name);
            actualCopy.SubModel.SubModel.Age.Should().Be(model.SubModel.SubModel.Age);
        }

        [Fact]
        public void CopyingValueType_KeepsValue()
        {
            // Arrange
            const int Age = 123;

            // Act
            var actualCopy = DeepCopyService.DeepCopy(Age);

            // Assert
            actualCopy.Should().Be(Age);
        }

        [Fact]
        public void RecursivelyCopyingReferenceTypes_CreatesNewReferences()
        {
            // Arrange
            var subModel2 = new DeepCopyModel(null, "SubModel2", 12);
            var subModel1 = new DeepCopyModel(subModel2, "SubModel1", 1);
            var model = new DeepCopyModel(subModel1, null, 0);

            // Act
            var actualCopy = DeepCopyService.DeepCopy(model);

            // Assert
            actualCopy.SubModel.Should().NotBeSameAs(model.SubModel);
            actualCopy.SubModel!.SubModel.Should().NotBeSameAs(model.SubModel!.SubModel);
        }
    }
}