namespace Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Conditions.Implementations
{
    public class NoCondition : XmlBuildingCondition
    {
        public override bool CheckIfSatisfiedBy(object? value)
        {
            return true;
        }
    }
}