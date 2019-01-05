using System;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingInfrastructure.Areas.Enums
{
    [AttributeUsage(AttributeTargets.All)]
    public class MyDescription2Attribute : Attribute
    {
        public string Test2String { get; }

        public MyDescription2Attribute(string test2String)
        {
            Test2String = test2String;
        }
    }
}