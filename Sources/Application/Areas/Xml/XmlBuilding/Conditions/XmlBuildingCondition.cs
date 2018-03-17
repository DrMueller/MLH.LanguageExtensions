using Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Conditions.Implementations;

namespace Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Conditions
{
    public abstract class XmlBuildingCondition
    {
        public static readonly XmlBuildingCondition None = new NoCondition();
        public static readonly XmlBuildingCondition NotNull = new NotNullOrEmptyCondition();
        public static readonly XmlBuildingCondition NotNullOrEmpty = new NotNullOrEmptyCondition();

        public abstract bool CheckIfSatisfiedBy(object value);
    }
}