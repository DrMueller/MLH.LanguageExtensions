using System;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingInfrastructure.Areas.Enums
{
    [AttributeUsage(AttributeTargets.All)]
    public class MyDescriptionAttribute : Attribute
    {
        public MyDescriptionAttribute(string testString)
        {
            TestString = testString;
        }

        public string TestString { get; }
    }
}