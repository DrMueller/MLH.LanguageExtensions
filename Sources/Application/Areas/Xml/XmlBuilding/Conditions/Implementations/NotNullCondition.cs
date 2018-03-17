namespace Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Conditions.Implementations
{
    public class NotNullCondition : XmlBuildingCondition
    {
        public override bool CheckIfSatisfiedBy(object value)
        {
            return value != null;
        }
    }
}