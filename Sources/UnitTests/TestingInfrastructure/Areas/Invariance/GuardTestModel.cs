using System.Collections.Generic;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingInfrastructure.Areas.Invariance
{
    public class GuardTestModel
    {
        public GuardTestModel(string testString, object testObject, IEnumerable<object> testCollection)
        {
            TestString = testString;
            TestObject = testObject;
            TestCollection = testCollection;
        }

        public IEnumerable<object> TestCollection { get; }
        public object TestObject { get; }
        public string TestString { get; }
    }
}