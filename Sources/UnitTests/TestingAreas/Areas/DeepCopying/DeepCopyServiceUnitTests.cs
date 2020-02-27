using Mmu.Mlh.LanguageExtensions.Areas.DeepCopying;
using Mmu.Mlh.LanguageExtensions.UnitTests.TestingInfrastructure.Areas.DeepCopying;
using NUnit.Framework;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.DeepCopying
{
    [TestFixture]
    public class DeepCopyServiceUnitTests
    {
        [Test]
        public void RecursivelyCopyingReferenceTypes_CreatesNewReferences()
        {
            // Arrange
            var subModel2 = new DeepCopyModel(null, "SubModel2", 12);
            var subModel1 = new DeepCopyModel(subModel2, "SubModel1", 1);
            var model = new DeepCopyModel(subModel1, null, 0);

            // Act
            var actualCopy = DeepCopyService.DeepCopy(model);

            // Assert
            Assert.IsFalse(ReferenceEquals(actualCopy.SubModel, model.SubModel));
            Assert.IsFalse(ReferenceEquals(actualCopy.SubModel.SubModel, model.SubModel.SubModel));
        }

        [Test]
        public void CopyingReferenceType_CreatesNewReference()
        {
            // Arrange
            var model = new DeepCopyModel(null, null, 0);

            // Act
            var actualCopy = DeepCopyService.DeepCopy(model);

            // Assert
            Assert.IsFalse(ReferenceEquals(model, actualCopy));
        }

        [Test]
        public void CopyingSubReferenceTypes_KeepsValues()
        {
            // Arrange
            var subModel2 = new DeepCopyModel(null, "SubModel2", 12);
            var subModel1 = new DeepCopyModel(subModel2, "SubModel1", 1);
            var model = new DeepCopyModel(subModel1, null, 0);

            // Act
            var actualCopy = DeepCopyService.DeepCopy(model);

            // Assert
            Assert.AreEqual(model.Name, actualCopy.Name);
            Assert.AreEqual(model.Age, actualCopy.Age);
            Assert.AreEqual(model.SubModel.Name, actualCopy.SubModel.Name);
            Assert.AreEqual(model.SubModel.Age, actualCopy.SubModel.Age);
            Assert.AreEqual(model.SubModel.SubModel.Name, actualCopy.SubModel.SubModel.Name);
            Assert.AreEqual(model.SubModel.SubModel.Age, actualCopy.SubModel.SubModel.Age);
        }

        [Test]
        public void CopyingValueType_KeepsValue()
        {
            // Arrange
            const int Age = 123;

            // Act
            var actualCopy = DeepCopyService.DeepCopy(Age);

            // Assert
            Assert.AreEqual(Age, actualCopy);
        }
    }
}