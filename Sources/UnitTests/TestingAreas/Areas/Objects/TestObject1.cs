using JetBrains.Annotations;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingAreas.Areas.Objects
{
    [PublicAPI]
    public class TestObject1
    {
        public int TestInt { get; set; }
        public long? TestLong { get; set; }
        public string? TestString { get; set; }
    }
}