namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingInfrastructure.Areas.Enums
{
    public enum TestEnum
    {
        [MyDescription("TestValue1")]
        Value1,

        [MyDescription("TestValue2")]
        Value2 = 1,

        [MyDescription("TestValue3")]
        Value3 = 2
    }
}